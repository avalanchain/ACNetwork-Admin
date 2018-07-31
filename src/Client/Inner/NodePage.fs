module Client.NodePage

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
open Client.InnerHelpers
open ReactBootstrap
open Helpers
open Shared.ViewModels.ChainNetwork
open ClientModels
    
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [  
            str "Node"
        ]
