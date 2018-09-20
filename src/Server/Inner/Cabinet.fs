module Cabinet

open System
open System.Threading.Tasks
open FSharp.Control.Tasks.V2.ContextInsensitive
open FSharp.Data

open Shared
open Shared.ViewModels
open Shared.Auth
open Shared.Utils
open Shared.Result
open Shared.WsBridge

open TypeShape.Tools

open Elmish
open Elmish.Bridge

open AuthJwt
open Config
open LoginFlow

open Shared.ChainDefs
open Shared.ViewModels.ChainNetwork

let unwrapResult res = 
    match res with 
    | Ok r -> r
    | Error e -> match (box e) with 
                    | :? Exception as exn -> raise exn
                    | exn -> failwithf "Error: '%A'" exn

let unwrapResultOpt res = 
    match res with 
    | Ok (Some r) -> r
    | Ok None -> failwithf "Incorrect Database setup"
    | Error exn -> raise exn


let getAllFromDb<'T,'U> config (getAll: string -> Task<Result<seq<'T>, exn>>) (f: 'T -> 'U) : Task<Result<'U list, ServerError>> = task {
    printfn "get%s() called" typeof<'T>.Name
    let! res = getAll config.connectionString 
    return match res with
            | Ok o -> o |> Seq.map f |> List.ofSeq |> Ok
            | Error exn ->  printfn "Data access exception: '%A'" exn
                            exn |> InternalError |> Error
}


let getCustomerResult config = task {
    let processStatus (customer: Customers.Customer) = 
        {   Id          = Guid.Parse(customer.Id)
            Email       = customer.Email
            FirstName   = customer.FirstName
            LastName    = customer.LastName
            EthAddress  = customer.EthAddress
            Avatar      = customer.Avatar
        }, customer
    let! st = getAllFromDb config Customers.Database.getAll processStatus
    return st |> Result.map Seq.head 
}

let  getCustomer config (request: SecureVoidRequest) = task { 
    printfn "getCustomer() called"

    return! 
        if request.Token |> isTokenValid |> not then TokenInvalid |> AuthError |> Error |> Task.FromResult
        elif request.Token |> checkAuthTokenValid config |> not then UserDoesNotHaveAccess |> AuthError |> Error |> Task.FromResult
        else task {
            let! customerRes = getCustomerResult config
            let customer, customerDTO = customerRes |> unwrapResult

            return customer |> Ok
        }
}   

module FakeData = 
    open NodeManagement

    let cluster1 = { CId = UUID (Guid.NewGuid()) }
    let clusters = [ cluster1 ]

    let chains = [
        {   Def     = newChain()
            Status  = ChainStatus.Active
            Pos     = 10UL }
        {   Def     = newChain()
            Status  = ChainStatus.Passive
            Pos     = 15UL }
        {   Def     = newChain()
            Status  = ChainStatus.Banned
            Pos     = 8UL }
        {   Def     = newChain()
            Status  = ChainStatus.Blocked "Suspicious activity"
            Pos     = 1000UL }
        {   Def     = newChain()
            Status  = ChainStatus.Stopped
            Pos     = 3450UL }
        {   Def     = newChain()
            Status  = ChainStatus.Active
            Pos     = 18UL }
    ]

    let node1 = {   NId      = NR { Nid = "Node 1" } 
                    Chains   = chains |> List.map (fun ch -> ch.Def) |> Set.ofList
                    Endpoint = { IP = "http://127.0.0.1"; Port = 20000us }
                    Clusters = [ cluster1.CId ]
                    State    = ACNodeState.Active
                }

    let nodes = [ node1 ]

    let cluster1Membership =  { Cluster = { CId = cluster1.CId }
                                Nodes   = [ node1 ] |> List.map (fun n -> n.NId, n) |> Map.ofList }

    let clusterMemberships = [ cluster1Membership ]

    let getClusters config (request: SecureVoidRequest) : Task<ServerResult<ACCluster list>> = task { 
        printfn "getClusters() called"
        return Ok clusters
    }

    let getClusterById config (request: SecureRequest<ACClusterId>) : Task<ServerResult<ACCluster>> = task { 
        printfn "getClusterById() called"
        return clusters 
                |> List.tryFind (fun c -> c.CId = request.Content) 
                |> function 
                    | Some cluster  -> Ok cluster
                    | None          -> Error NotFound
    }

    let getClusterMembership config (request: SecureRequest<ACClusterId>) : Task<ServerResult<ACClusterMembership>> = task { 
        printfn "getClusterMembership() called"
        return clusterMemberships 
                |> List.tryFind (fun c -> c.Cluster.CId = request.Content)
                |> function 
                    | Some cluster  -> Ok cluster
                    | None          -> Error NotFound
 
    }

    let getNodeById config (request: SecureRequest<ACNodeId>) : Task<ServerResult<ACNode>> = task { 
        printfn "getNodeById() called"
        return nodes 
                |> List.tryFind (fun n -> n.NId = request.Content)
                |> function 
                    | Some node -> Ok node
                    | None      -> Error NotFound

    }

    let getNodeMembership config (request: SecureRequest<ACNodeId>) : Task<ServerResult<ACClusterId list>> = task { 
        printfn "getNodeMembership() called"
        return nodes 
                |> List.tryFind (fun n -> n.NId = request.Content) 
                |> Option.map (fun n -> n.Clusters)
                |> function 
                    | Some cms  -> Ok cms
                    | None      -> Error NotFound

    }

    let getNodeChainIds config (request: SecureRequest<ACNodeId>) : Task<ServerResult<Set<ChainId>>> = task { 
        printfn "getNodeChainIds() called"
        return nodes 
            |> List.tryFind(fun n -> n.NId = request.Content ) 
            |> Option.map (fun n -> n.Chains |> Set.map (fun ch -> ch.ChainId))
            |> Option.defaultValue Set.empty
            |> Ok
    }

    let getNodeChainDefs config (request: SecureRequest<ACNodeId>) : Task<ServerResult<ChainDef list>> = task { 
        printfn "getNodeChainDefs() called"
        return nodes 
            |> List.tryFind(fun n -> n.NId = request.Content ) 
            |> Option.map (fun n -> n.Chains |> Seq.toList)
            |> Option.defaultValue []
            |> Ok
    }

    let getNodeChain config (request: SecureRequest<ACNodeId * ChainId>) : Task<ServerResult<ChainState>> = task { 
        printfn "getNodeChain() called"
        let nodeId, chainId = request.Content
        return 
            if nodes |> List.tryFind (fun n -> n.NId = nodeId && (n.Chains |> Seq.tryFind (fun c -> c.ChainId = chainId) |> Option.isSome)) |> Option.isSome then
                chains 
                |> List.tryFind (fun c -> c.Def.ChainId = chainId)
                |> function 
                    | Some chainState   -> Ok chainState
                    | None              -> Error NotFound
            else Error NotFound
    }

    let getNodeChains config (request: SecureRequest<ACNodeId>) : Task<ServerResult<ChainState list>> = task { 
        printfn "getNodeChains() called"
        return nodes 
            |> List.tryFind(fun n -> n.NId = request.Content ) 
            |> Option.map (fun n -> n.Chains |> Set.map (fun ch -> chains |> List.find (fun c -> c.Def = ch)) |> Seq.toList)
            |> Option.defaultValue []
            |> Ok
    }

    let getChainDefById config (request: SecureRequest<ChainId>) : Task<ServerResult<ChainDef>> = task { 
        printfn "getNodeChains() called"
        return chains 
            |> List.tryFind (fun c -> c.Def.ChainId = request.Content)
            |> function 
                | Some chainState   -> Ok chainState.Def
                | None              -> Error NotFound

    }

let cabinetProtocol config =
    {   getCustomer             = getCustomer                    config    >> Async.AwaitTask
        getClusters             = FakeData.getClusters           config    >> Async.AwaitTask

        getClusterById          = FakeData.getClusterById        config    >> Async.AwaitTask
        getClusterMembership    = FakeData.getClusterMembership  config    >> Async.AwaitTask

        getNodeById             = FakeData.getNodeById           config    >> Async.AwaitTask
        getNodeMembership       = FakeData.getNodeMembership     config    >> Async.AwaitTask
        getNodeChainIds         = FakeData.getNodeChainIds       config    >> Async.AwaitTask
        getNodeChainDefs        = FakeData.getNodeChainDefs      config    >> Async.AwaitTask
        getNodeChain            = FakeData.getNodeChain          config    >> Async.AwaitTask
        getNodeChains           = FakeData.getNodeChains         config    >> Async.AwaitTask

        getChainDefById         = FakeData.getChainDefById       config    >> Async.AwaitTask
    }


type BridgeConnectionState =
    | Connected of AuthToken
    | Disconnected

let bridgeConnections =
    ServerHub<BridgeConnectionState, WsBridge.ServerMsg, WsBridge.BridgeMsg>.New()    

let toClientMsg = BC >> C >> Cmd.ofMsg   

let bridgeInit () =
    printfn "Server init"
    Disconnected, ServerConnected |> toClientMsg

let bridgeUpdate config msg state =
    printfn "bridgeUpdate: %A" msg
    match msg with
    | Closed                -> Disconnected, Cmd.none
    | ConnectUser authToken ->
        if checkAuthTokenValid config authToken then 
            Connected authToken, UserConnected authToken |> toClientMsg
        else state, ErrorResponse(TokenInvalid |> AuthError, msg) |> toClientMsg
    | DisconnectUser        -> Disconnected, Cmd.none    
let bridgeProtocol config =
    bridge bridgeInit (bridgeUpdate config) {
        serverHub bridgeConnections
        at Shared.Route.wsBridgeEndpoint
    }       