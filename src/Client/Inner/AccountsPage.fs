module Client.AccountsPage

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.PowerPack
open Fable.Helpers
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish
open Elmish.React

open ReactBootstrap
open Helpers
open FormHelpers
open Cabinet
open ReactCopyToClipboard
open CabinetModel

let view (model: Model) (dispatch: Msg -> unit) =
    div [  ]
        [ str "Accounts Page" ]

