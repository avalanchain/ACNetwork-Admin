module ClientMsgs

open System
open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Shared
open Auth
open Client

open Fable
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.RemoteDev
open Fable.Import.Browser
open Fable.Import
open JsInterop

open Elmish.Bridge
open Elmish.Bridge.Browser

open Client
open Client.Page
open LocalStorage

type RemotingError =
    | CommunicationError of exn
    | ServerError of ServerError

type AppMsg =
    | AuthMsg           of AuthMsg
    | UIMsg             of UIMsg
    | BrowserStorageMsg of BrowserStorageMsg 
    | UnexpectedMsg     of UnexpectedMsg
    | ErrorMsg          of string * AppMsg * string
    | LoginFlowMsg      of LoginFlowPage.Msg
    | CabinetMsg        of Cabinet.Msg

and AuthMsg =
    | LoggedIn      of Auth.AuthToken
    | LoggedOut
and UIMsg =
    | Tick                  of uint64
    | MenuSelected          of Cabinet.MenuPage
    | Login
    | Logout 
and UnexpectedMsg =
    | ServerErrorMsg        of RemotingError

type ClientMsg = 
    | BridgeMsg of WsBridge.BridgeMsg
    | AppMsg    of AppMsg

type BridgedMsg = Msg<WsBridge.ServerMsg, ClientMsg>

let msgMapC f = function    | C m -> m |> f |> C 
                            | S m -> S m
