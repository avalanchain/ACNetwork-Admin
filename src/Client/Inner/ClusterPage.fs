module Client.ClusterPage

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
open Client.Page
    

let nodeViewBtn = 
    comF button (fun o -> o.bsClass <- "btn btn-success btn-outline btn-xs" |> Some
                        //   o.onClick <- React.MouseEventHandler(fun _ -> GetCoinbase |> dispatch) |> Some  
                          )
                        [ str "Open Node" ]
//TODO MOVE TO NODE PAGE                        
// let page = MenuPage.Cabinet MenuPage.Cluster
// td [] 
//                            [ 
//                             a [ Href (toHash page) 
//                                 OnClick goToUrl ]
//                               [ node.Key.Cluster |> string |> str ]
                             
//                            ]
// let onClickFn = fun _ -> goToPage (toHash (page))
let clusterNodes clusterMembership dispatch = 
    let master cl sign name = [ span [ ] [ str name ]
                                span [ Class (fb + cl) ] [ str sign ]]
    let nodeName nId = 
        match nId with
        | NR nr ->  nr.Nid |> string |>  master "" "" 
        | MNR mnr -> mnr.MNid |> string |>  master txtN " M"
    let rows = 
            clusterMembership.Nodes
            |> Seq.map (fun node -> 
                tr [] [ td [] (nodeName node.Key.NId)
                                
                        td [] [ node.Key.Chains.Count |> string |> str ]
                        td [] [ node.Key.Endpoint.IP |> string |> str ]
                        td [] [ node.Key.Endpoint.Port |> string |> str ]
                        td [] [ node.Key.Cluster |> string |> str]
                        td [] 
                           [
                               span [ Class "label label-active" ]
                                    [
                                        node.Value |> string |> str ]
                                    ]
                                
                        td [] [ nodeViewBtn ] ])
            |> Seq.toList
    Ibox.btRow "Nodes" false
            [
                div [ Class "table-responsive" ]//table-responsive
                    [
                        comE table 
                            [
                                thead [][
                                    tr[][
                                        th [][str "Node" ]
                                        th [][str "Chains" ]
                                        th [][str "IP" ]
                                        th [][str "Port" ]
                                        th [][str "Cluster" ]
                                        th [][str "Status" ]
                                        th [][str "Action" ]
                                        // th [][str "GAS USED" ]
                                        // th [ Class "text-center"  ][str "VALUE" ]
                                    ]
                                ]
                                tbody [ ] 
                                      rows
                              
                    ]]
    ]

let nodesCount = 
    Ibox.btRow "Nodes" false
                [
                    div [ Class "table-responsive" ]//table-responsive
                        [
                            h1 []
                               [ str "1" ]
                            div [ Class "stat-percent font-bold text-info" ]
                                [
                                ]
                            small []
                                  [
                                      str "All"
                                  ]  
                        ]
        ]

let clusterView clusterMembership dispatch = 
    div [ Class "Row" ]
        [
            div [ Class "col-md-12 col-lg-6" ]
                [
                    nodesCount 
                ]
            div [ Class "col-md-12 col-lg-6" ]
                [
                    nodesCount 
                ]
            div [ Class "col-lg-12" ]
                [
                    clusterNodes clusterMembership dispatch
                ]
        ]
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [  
            // str "Cluster"
            match model.ClusterMembership with 
            | Some clusterMembership ->
                // yield str "Cluster Membership" 
                yield clusterView clusterMembership (ClustersMsg >> dispatch)
            | None -> ()
        ]

