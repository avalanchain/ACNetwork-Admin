module Client.Main

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
open ClientModels
open CabinetModel
open System.ComponentModel
open Fable.PowerPack
open Shared.Utils
open Client.Menu
open Shared.WsBridge

open Client.App
open Client.wsBridge

#if DEBUG
open Elmish.Debug
open Elmish.HMR
open Elmish.Bridge.HMR
#endif

let wsBridgeUrlUpdate result model: AppModel * Cmd<ClientMsg> = 
    let model, cmd = PageRouter.urlUpdate result model
    model, cmd |> Cmd.map AppMsg

let appMsgQueue = // A queue
    let mutable buffer = []
    (fun (msg: Cmd<AppMsg>) -> buffer <- msg :: buffer), (fun () -> 
                                                            let ret = buffer |> List.rev
                                                            buffer <- []
                                                            ret)  

let mapProgram (p: Program<_,WsBridgeModel,WsBridge.BridgeMsg,_>): Program<_,AppModel,ClientMsg,_> = 
    {   init = fun args -> 
                        let wsModel, cmdB = p.init args
                        let model, cmdA = init wsModel args
                        model, Cmd.batch [ cmdB |> Cmd.map BridgeMsg ; cmdA ]
        update = fun (msg: ClientMsg) (model: AppModel) ->
                    match msg with
                    | BridgeMsg m -> 
                        let model', cmd = p.update m model.WsBridgeModel
                        let allCmds = (snd appMsgQueue)() |> List.map (Cmd.map AppMsg) |> List.append [ cmd |> Cmd.map BridgeMsg ] |> Cmd.batch
                        { model with WsBridgeModel = model' }, allCmds
                    | AppMsg m -> 
                        let model', cmd = update m model
                        model', cmd
        subscribe = fun model -> model.WsBridgeModel |> p.subscribe |> Cmd.map BridgeMsg 
        view = view
        setState = fun model dispatch ->
                        p.setState model.WsBridgeModel (BridgeMsg >> dispatch) 
                        view model dispatch |> ignore 
        onError = p.onError
    } 

//bridge wsBridgeInit wsBridgeUpdate wsBridgeView {
bridge (wsBridge.init (fst appMsgQueue)) (wsBridge.update (fst appMsgQueue))  wsBridge.view {
    mapped BridgeMsg mapProgram
    mapped Bridge.NavigableMapping (Program.toNavigable (parseHash pageParser) wsBridgeUrlUpdate)
#if DEBUG
    simple Program.withConsoleTrace
    simple Program.withDebugger
#endif
    simple (Program.withReactUnoptimized "ac-app")
#if DEBUG
    mapped Bridge.HMRMsgMapping Program.withHMR
#endif
    at Shared.Route.wsBridgeEndpoint
}