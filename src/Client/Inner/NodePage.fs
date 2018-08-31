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
open BootstrapTable    

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

let chainType (chain:ChainDefs.ChainType) = 
        match chain with
        | ChainDefs.ChainType.New  -> span [ Class "label label-active" ] 
                                           [ "new" |> string |>  str ] 
        | ChainDefs.ChainType.Derived (cr, pos, dr) -> span [ Class "label label-success" ] 
                                                            [ dr |> string |>  str ]

let ndBody (node: ACNode) = 
    div [ ]
        [   div [  ]
                [
                    div [ Class "row" ]
                              [ 
                                div [ Class "col-md-4" ]
                                    [ 
                                        span [ Class "text-muted m-t-xs" ]
                                          [ 
                                             h2 [ ]
                                                 [ 
                                                b [ ]
                                                    [ str "ID: " ]
                                                span [ Class  txtN]
                                                  (nodeNameSpans node.NId ) ]]
                                      
                                    ]
                                div [ Class "col-md-8" ]
                                    [ 
                                        span [ Class ("m-t-xs " + txtM )]
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
            
            
            
            div [  ]
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
        div [ ]
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
// // [ str "First"]


let onclickFun = fun _ -> ()//cluster.CId |> SelectCluster |> dispatch 
                                                // goToPage (toHash page)  
let showBtn = 
    comF button (fun o -> o.bsClass <- "btn btn-success btn-outline btn-xs" |> Some
                          o.onClick <- React.MouseEventHandler(onclickFun) |> Some  
                          )
                        [ str "show" ]

let chains (chs:Set<ChainDefs.ChainDef>) (model:Model) dispatch = 
    let chPagin = model.ActiveNode.ChainsPagination
    let onclickFun page =  fun _ -> page |> ChainsPaginMsg |> dispatch
    let rows = 
            chs
            |> Seq.map (fun ts -> 
                tr [] [                         
                        td [] [ 
                                  chainType ts.chainType
                             ]
                        td [] [ ts.uid |> string |> str ]
                        td [] [ ts.algo |> string |> str]
                                
                        td [] [ ts.compression |> string |> str ]
                        td [] [ ts.encryption |> string |> str ]
                        td [] [ showBtn ]
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
                                        th [][str "Type" ]
                                        th [][str "Uid" ]
                                        th [][str "Algo" ]
                                        th [][str "Compression" ]
                                        th [][str "Encryption" ]
                                        th [][str "Action" ]
                                        // th [ Class "text-center"  ][str "VALUE" ]
                                    ]
                                ]
                                tbody [ ] 
                                      rows
                              
                         ]

                        Client.Pagination.view chPagin onclickFun
                    ]
    ]
let nodeInfo (node: ACNode) = 
    div [ Class "ibox float-e-margins animated fadeInUp" ]
                    [ div [ Class "ibox-title" ]
                        [ h5 [ ]
                            [ str "Node Info" ] 
                          span [ Class "label label-primary pull-right" ]
                                [str "active"]
                          ] 
                      Ibox.iboxContent false [ndBody node]]

let nodeView clusterMembership model dispatch = 
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
            div [ Class "col-md-12 " ]
                [
                    (chains nd.Chains model  dispatch)
                ]
        ]
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [  
            // str "Cluster"
            match model.ClusterMembership with 
            | Some clusterMembership ->
                // yield str "Cluster Membership" 
                yield nodeView clusterMembership model dispatch
            | None -> ()
        ]
