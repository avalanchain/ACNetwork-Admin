module Client.ClustersPage

open System
open System.Text.RegularExpressions

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fable.PowerPack
open Elmish
open Elmish.React

open Shared
open ViewModels
open Client.FormHelpers

open Cabinet
open CabinetModel
open ReactBootstrap
open Helpers


let view (model: Model) (dispatch: Msg -> unit) =
    div [  ]
        [ str "Clusters Page" ]

