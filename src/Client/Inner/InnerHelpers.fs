module Client.InnerHelpers

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
// open CabinetModel
open ReactBootstrap
open Helpers
open Shared.ViewModels.ChainNetwork
// open ClientModels
    
let prodItem body icon onClickFun = 
    div [ Class "col-md-4 col-lg-3" ]
        [ div [ Class "ibox" ]
            [ div [ Class "ibox-content product-box" 
                    OnClick (onClickFun)]
                [ div [ Class "product-imitation" ]
                    [ i [ Class ("fa img-circle fa-5x " + icon) ]
                        [ ] ]
                  div [ Class "product-desc" ]
                    [ span [ Class "product-price connected-bg" ]
                        [ str "Active" ]
                      body
                    //   div [ Class "m-t text-righ" ]
                    //     [ a [ Class "btn btn-xs btn-primary btn-outline"
                    //         //   OnClick (fun _ -> item.CId |> SelectCluster |> dispatch ) 
                    //           ]
                    //         [ str "Info "
                    //           i [ Class "fa fa-long-arrow-right" ]
                    //             [ ] ] ] 
                                ] ] ] ]
let master cl sign name = [     span [ ] [ str name ]
                                span [ Class (fb + cl) ] [ str sign ]]
let nodeNameSpans nId = 
        match nId with
        | NR nr ->  nr.Nid |> string |>  master "" "" 
        | MNR mnr -> mnr.MNid |> string |>  master txtN " M"
let nodeName nId = 
        match nId with
        | NR nr ->  nr.Nid |> string 
        | MNR mnr -> mnr.MNid |> string 