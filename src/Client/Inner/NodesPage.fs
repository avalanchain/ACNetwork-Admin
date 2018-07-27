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
open Client.InnerHelpers


importAll "../../../node_modules/react-rangeslider/lib/index.css"
importAll "../../Client/lib/css/inspinia/flatUIRange.css"
// let buttonToolbar = ReactBootstrap.buttonToolbar
importAll "../../../node_modules/qrcode.react/lib/index.js"
importAll "../../../node_modules/react-moment/dist/index.js"
importAll "../../../node_modules/react-rangeslider/lib/Rangeslider.js"
importAll "../../../node_modules/react-rangeslider/lib/index.js"


//let onclickFun node dispatch = fun _ -> node.Id |> SelectCluster |> dispatch 
let nodeData = 
    div [ ]
        [

        ]
        
let ndBody name itemId = 
    div [ ]
        [   small [ Class "text-muted" ]
              [ b [ ]
                    [ str "ID: " ]
                str itemId ]
            p [ Class "text-muted m-t-xs" ]
              [ b [ ]
                    [ str "Cluster: " ]
                str "CL_1" ]
            div [ Class "small m-t-xs" ]
                [ div [ Class "row" ]
                    [ 
                        div [ Class "col-md-6" ]
                            [ 
                                b [ ]
                                  [ str "IP: " ]
                                str "http://127.0.0.1" 
                            ]
                        div [ Class "col-md-6" ]
                            [ 
                                b [ ]
                                  [ str "Port: " ]
                                str "2000"
                            ]
                     ]
                                    ]
                  ]

let nodesView nodes dispatch = 
    nodes
    |> List.map (fun c -> prodItem (ndBody  "NODE" "ed64f1595f5a45eea946a2c480fd91cd" ) "fa-table" ignore)
    |> div []

let count = [1..4]
let view (model: Model) (dispatch: Msg -> unit) =
    div [  ]
        [ nodesView count dispatch ]

