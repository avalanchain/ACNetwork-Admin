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


let getClusters config (request: SecureVoidRequest) : Task<ServerResult<ACCluster list>> = task { 
    printfn "getClusters() called"
    return [{CId = UUID (Guid.NewGuid()) }]
            |> Ok 
}

let getClusterMembership config (request: SecureRequest<ACClusterId>) : Task<ServerResult<ACClusterMembership>> = task { 
    printfn "getClusterMembership() called"
    return 
        {
            Cluster = { CId = request.Content }
            Nodes   = [{    NId      = NR { Nid = "Node 1" } 
                            Chains   = [] |> Set.ofList
                            Endpoint = { IP = "http://127.0.0.1"; Port = 20000us }
                            Cluster  = Some request.Content
                        }, ACNodeState.Active ] |> Map.ofList
        }
        |> Ok 
}


let cabinetProtocol config =
    {   getCustomer             = getCustomer           config    >> Async.AwaitTask
        getClusters             = getClusters           config    >> Async.AwaitTask
        getClusterMembership    = getClusterMembership  config    >> Async.AwaitTask
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