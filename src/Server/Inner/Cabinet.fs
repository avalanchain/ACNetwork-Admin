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

let getClusters config (request: SecureVoidRequest) : Task<ServerResult<ACCluster list>> = task { 
    printfn "getClusters() called"
    return [{CId = UUID (Guid.NewGuid()) }]
            |> Ok 
}

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

let cabinetProtocol config =
    {   getClusters = getClusters   config    >> Async.AwaitTask

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