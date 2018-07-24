module Client.wsBridge

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.React
open Elmish.Toastr
open Elmish.Bridge
open Elmish.Bridge.Browser

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Shared

open Fable
open Fable.Core
open Fable.Import.RemoteDev
open Fable.Import.Browser
open Fable.Import
open JsInterop

open Fable.Core.JsInterop

open Client
open Client.Page
open ClientMsgs
open Cabinet
open ClientModels
open CabinetModel
open System.ComponentModel
open Fable.PowerPack
open Shared.Utils
open Client.Menu
open Shared.WsBridge

open Auth
open Client.App

#if DEBUG
open Elmish.Debug
open Elmish.HMR
open Elmish.Bridge.HMR
#endif

let wsBridgeUrlUpdate result model: AppModel * Cmd<ClientMsg> = 
    let model, cmd = PageRouter.urlUpdate result model
    model, cmd |> Cmd.map AppMsg

module wsBridge =
    let init (appCommands: Cmd<AppMsg> -> unit) initialState : WsBridgeModel * Cmd<Msg<WsBridge.ServerMsg, WsBridge.BridgeMsg>> =
        Disconnected [], Cmd.none
    let update (appCommands: Cmd<AppMsg> -> unit) (msg: WsBridge.BridgeMsg) (model: WsBridgeModel) : WsBridgeModel * Cmd<Msg<WsBridge.ServerMsg, WsBridge.BridgeMsg>> = 
        console.log ("p.update: " + msg.ToString()) 
        match msg with 
        | BS bsMsg -> 
            match bsMsg with
            | ConnectUserOnServer authToken ->
                let msg' = ConnectUser authToken |> S
                match model with
                | Disconnected pending   -> (msg' :: pending) |> Disconnected, Cmd.none
                | Connected              -> model, msg' |> Cmd.ofMsg  
            | DisconnectUserOnServer        -> 
                let msg' = DisconnectUser |> S
                match model with
                | Disconnected pending   -> (msg' :: pending) |> Disconnected, Cmd.none
                | Connected              -> model, msg' |> Cmd.ofMsg  
        | BC bcMsg -> 
            match bcMsg with
            | ErrorResponse(e, request)     -> 
                match e with
                | AuthError _               -> 
                    AuthMsg.LoggedOut |> AuthMsg |> Cmd.ofMsg |> appCommands
                    model, Cmd.none 
                | InternalError _           -> 
                    let msg' = S request
                    let cmd = Cmd.ofAsync (fun () -> async { do! Async.Sleep 1000; }) () (fun _ -> msg') (fun _ -> msg') // Wait for a sec before retry
                    model, cmd
                | NotImplementedError       -> failwith "Not Implemented"            
            | ConnectionLost                -> Disconnected [], Cmd.none 
            | ServerConnected               -> 
                match model with
                | Disconnected pending   -> Disconnected [], pending |> List.rev |> List.map Cmd.ofMsg |> Cmd.batch
                | Connected              -> model, Cmd.none
            | UserConnected _               -> Connected, Cmd.none
            
    let view (model: WsBridgeModel) (dispatch: Msg<WsBridge.ServerMsg, WsBridge.BridgeMsg> -> unit) =
        div [] []
