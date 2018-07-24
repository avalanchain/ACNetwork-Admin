module ClientModels

open System

open Elmish
open Elmish.React

open Fable
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.RemoteDev
open Fable.Import.Browser
open Fable.Import
open JsInterop

open Shared
open Auth
open Client


open Fable.Core.JsInterop

open Client.Page
open ClientMsgs
open LoginPage
open CabinetModel
open Client.LoginCommon
open Shared.WsBridge
open Elmish

type PageModel =
    | NoPageModel
    | LoginFlowModel of LoginFlowPage.Model
    | CabinetModel   of CabinetModel.Model

type WsBridgeModel = 
    | Connected
    | Disconnected of Pending: Bridge.Msg<ServerMsg, BridgeMsg> list

type AppModel = {
    Page            : MenuPage
    PageModel       : PageModel

    Loading         : bool

    WsBridgeModel   : WsBridgeModel
}

let cmdServerCall (apiFunc: 'T -> Async<ServerResult<'R>>) (args: 'T) (completeMsg: 'R -> AppMsg) serverMethodName =
    Cmd.ofAsync
        apiFunc
        args
        (fun res -> match res with
                    | Ok cc             -> cc |> completeMsg |> AppMsg
                    | Error serverError -> serverError |> ServerError |> ServerErrorMsg |> UnexpectedMsg |> AppMsg
                    )
        (fun exn -> console.error(sprintf "Exception during %s call: '%A'" serverMethodName exn)
                    exn |> CommunicationError |> ServerErrorMsg |> UnexpectedMsg |> AppMsg)

let cmdServerCabinetCall apiFunc args completeMsg serverMethodName =
    cmdServerCall apiFunc args (completeMsg >> Cabinet.Msg.ServerMsg >> CabinetMsg) serverMethodName
