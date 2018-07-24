module Client.NodesPage

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
open Cabinet
open CabinetModel
open Helpers
open ReactBootstrap
open FormHelpers
open Client
open ReactCopyToClipboard


importAll "../../../node_modules/react-rangeslider/lib/index.css"
importAll "../../Client/lib/css/inspinia/flatUIRange.css"
// let buttonToolbar = ReactBootstrap.buttonToolbar
importAll "../../../node_modules/qrcode.react/lib/index.js"
importAll "../../../node_modules/react-moment/dist/index.js"
importAll "../../../node_modules/react-rangeslider/lib/Rangeslider.js"
importAll "../../../node_modules/react-rangeslider/lib/index.js"


let view (model: Model) (dispatch: Msg -> unit) =
    div [  ]
        [ str "Nodes Page" ]

