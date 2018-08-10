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
        [   div [ Class "m-l-md" ]
                [
                    div [ Class "row" ]
                              [ 
                                div [ Class "col-md-4" ]
                                    [ 
                                        span [ Class "text-muted m-t-xs" ]
                                          [ 
                                             h3 [ ]
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
let pagBtn name cl pos = 
    comF button (fun b -> //b.bsSize <- Sizes.Sm |> Some 
                          b.bsClass <- "btn btn-default btn-sm " + cl|> Some )[ str name ]
let paginationButtons act sz = 
    let size = sz
    let active = act
    let pageStart = active - 2
    let pageEnd = active + 2

    comE buttonGroup [
        yield pagBtn "First" "" 1
        yield pagBtn "Prev" "" (if active > 1 then (active - 1) else active)
        if pageStart > 0 then yield pagBtn ((active - 2) |> string) "" (active - 2)
        if pageStart + 1 > 0 then yield pagBtn ((active - 1) |> string) "" (active - 1)
        yield pagBtn ((active |> string)) "active" 1
        if pageEnd - 2 < size then yield pagBtn ((active + 1) |> string) "" (active + 1)
        if pageEnd - 1 < size then yield pagBtn ((active + 2) |> string) "" (active + 2)
        yield pagBtn "Next" "" (if size > active then (active + 1) else active)
        yield pagBtn "Last" "" size
    ]



let chains (chs:Set<ChainDefs.ChainDef>) = 
    // let items = 
    let rows = 
            chs
            |> Seq.map (fun ts -> 
                tr [] [ td [] [ ts.algo |> string |> str]
                                
                        td [] [ 
                                  chainType ts.chainType
                             ]
                        td [] [ ts.compression |> string |> str ]
                        td [] [ ts.encryption |> string |> str ]
                        td [] [ ts.uid |> string |> str ]
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
                              
                         ]

                        // BootstrapTable (fun t -> t.data <- ResizeArray(chs|> Seq.map (fun kv -> kv :> obj))
                        //                          t.pagination <- Some true
                        //                          t.striped <- Some true)
                        //         [
                        //             TableHeaderColumn (fun p -> p.dataField <- Some "ChainDefs.Uid"
                        //                                         // p.dataSort <- Some true
                        //                                         p.isKey <- Some true
                        //                                         // p.width <- Some "90"
                        //                                         ) [ str "Id"] 
                        //         ]

                        paginationButtons 1 8

                        // comF pagination (fun p ->   p.bsSize <- Sizes.Sm |> Some
                        //                             p.``type`` <- "Symbol(react.context)" |> Some
                        //                             p.onSelect <- React.ReactEventHandler(fun _ -> Browser.console.log "Selected") |> Some  
                        //                             p.onClick <- React.MouseEventHandler(fun _ -> Browser.console.log "Selected Item") |> Some 
                        //                           )   
                        //                             [ 
                        //                             ]
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
            div [ Class "col-md-12 " ]
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
