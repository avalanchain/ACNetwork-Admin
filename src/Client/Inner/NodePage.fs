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
open Client.Page
    

let getNode (nodes:Map<ACNode, ACNodeState>) = 
    nodes |> Map.fold (fun st k2 v2 ->
    match st with
    | Some(k1, v1) when v1 < v2 -> st
    | _ -> Some(k2, v2)) None

let node (nodes:Map<ACNode,ACNodeState>) = 
    let nd = getNode nodes
    match nd.Value with
    | (a,b) -> a

let clPage = MenuPage.Cabinet MenuPage.Cluster

let ndBody (node: ACNode) = 
    div [ ]
        [   div [ Class "m-l-md" ]
                [
            div [ Class "row" ]
                      [ 
                        div [ Class "col-md-4" ]
                            [ 
                                p [ Class "text-muted m-t-xs" ]
                                  [ 
                                     h3 [ ]
                                         [ 
                                        b [ ]
                                            [ str "ID: " ]
                                        span [ Class  txtN]
                                          (nodeName node.NId ) ]]
                              
                            ]
                        div [ Class "col-md-8" ]
                            [ 
                                p [ Class ("m-t-xs " + txtM )]
                                  [ 
                                      h3 [ ]
                                         [ b [ ]
                                             [ str "Cluster: " ]
                                           a [ Href (toHash clPage) 
                                               OnClick goToUrl ]
                                             [ node.Cluster.Value |> string |> str ]]
                                    // str (node.Cluster.Value.ToString()) 
                                    ]
                            ]
                     ]]
            
            
            
            div [ Class "p-xs m-l-sm" ]
                [ div [ Class "row" ]
                      [ 
                        div [ Class "col-md-4" ]
                            [ 
                                b [ ]
                                  [ str "IP: " ]
                                str node.Endpoint.IP 
                            ]
                        div [ Class "col-md-8" ]
                            [ 
                                b [ ]
                                  [ str "Port: " ]
                                str (node.Endpoint.Port.ToString())
                            ]
                     ]
                                    ]
                  ]

let ntrxCount (count: int) = 
    // Ibox.inner "Transactions" false
    let body = 
        div [ Class "table-responsive" ]//table-responsive
                            [
                                h1 []
                                   [ str (count.ToString()) ]
                                div [ Class "stat-percent font-bold text-info" ]
                                    [
                                    ]
                                div [ Class "stat-percent font-bold text-info" ]
                                    [ str "20%"
                                      i [ Class "fa fa-level-up" ]
                                        [ ] ]
                                small []
                                      [
                                          str "All"
                                      ]  
                            ]
    div [ Class "ibox float-e-margins animated fadeInUp" ]
                    [ div [ Class "ibox-title" ]
                        [ h5 [ ]
                            [ str "Transactions" ] 
                          span [ Class "label label-success pull-right" ]
                                [str "all time"]
                          ] 
                      Ibox.iboxContent false [body]]


let chains (chs:Set<ChainDefs.ChainDef>) = 
    let rows = 
            chs
            |> Seq.map (fun ts -> 
                tr [] [ td [] [ ts.algo |> string |> str]
                                
                        td [] [ ts.chainType |> string |> str ]
                        td [] [ ts.compression |> string |> str ]
                        td [] [ ts.encryption |> string |> str ]
                        td [] [ ts.uid |> string |> str ]
                        // td [] [ node.Key.Endpoint.IP |> string |> str ]
                        // td [] [ node.Key.Endpoint.Port |> string |> str ]
                        // td [] [ node.Key.Cluster |> string |> str]
                        // td [] 
                        //    [
                        //        span [ Class "label label-active" ]
                        //             [
                        //                 node.Value |> string |> str ]
                        //             ]
                                
                        // td [] [ nodeViewBtn ] 
                        ]
                        )
            |> Seq.toList
    Ibox.btRow "Chains" false
            [
                div [ Class "table-responsive" ]//table-responsive
                    [
                        comE table 
                            [
                                thead [][
                                    tr[][
                                        th [][str "Algo" ]
                                        th [][str "Type" ]
                                        th [][str "Compression" ]
                                        th [][str "Encryption" ]
                                        th [][str "Uid" ]
                                        // th [][str "GAS USED" ]
                                        // th [ Class "text-center"  ][str "VALUE" ]
                                    ]
                                ]
                                tbody [ ] 
                                      rows
                              
                    ]]
    ]
let nodeInfo (node: ACNode) = 
    div [ Class "ibox float-e-margins animated fadeInUp" ]
                    [ div [ Class "ibox-title" ]
                        [ h5 [ ]
                            [ str "Info" ] 
                          span [ Class "label label-primary pull-right" ]
                                [str "active"]
                          ] 
                      Ibox.iboxContent false [ndBody node]]

let nodeView clusterMembership dispatch = 
    let nd = node clusterMembership.Nodes
    div [ Class "row" ]
        [
            div [ Class "col-md-12 col-lg-4" ]
                [
                    ntrxCount nd.Chains.Count 
                ]
            div [ Class "col-md-12 col-lg-8" ]
                [
                    nodeInfo nd
                ]
            div [ Class "col-lg-12" ]
                [
                    (chains nd.Chains)
                ]
        ]
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [  
            // str "Cluster"
            match model.ClusterMembership with 
            | Some clusterMembership ->
                // yield str "Cluster Membership" 
                yield nodeView clusterMembership (ClustersMsg >> dispatch)
            | None -> ()
        ]
