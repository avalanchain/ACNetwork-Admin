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

let getFirstNode (nodes:Map<ACNodeId, ACNode>) = 
   nodes |> Seq.tryHead |> Option.map (fun kv -> kv.Value) 

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
                   
                    span [ Class "text-muted m-t-xs" ]
                      [ 
                         h2 [ ]
                             [ 
                            b [ ]
                                [ str "ID: " ]
                            span [ Class  txtN]
                              (nodeNameSpans node.NId ) ]]
                      
                ]
            div [ Class "hr-line-dashed" ]  []
            div [  ]
                [  
                    span [ Class ("m-t-xs " + txtM )]
                      [ 
                          h3 [ ]
                             [ b [ ]
                                 [  str "Cluster: " ]
                               a [  Href (toHash clPage) 
                                    OnClick goToUrl ]
                                 [ node.Cluster.Value |> string |> str ]
                              ]
                        ]
                 ]
            div [ Class "hr-line-dashed" ]  []
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
                            ] ] ]
            
            div [ Class "hr-line-dashed" ]  []     
            div [  ]
                [  
                    div [ Class "row" ]
                      [ 
                        div [ Class "col-md-4" ]
                            [ 
                                b [ ]
                                  [ str "Transactions: " ]
                                str "249543" 
                            ]
                        div [ Class "col-md-8" ]
                            [ 
                                b [ ]
                                  [ str "Blocks: " ]
                                str "115"
                            ] ]
                 ]     

                  ]

let transactionInfo (cl: ACCluster) =
    let chartTrValues = [| 414.;124.;764.;144.;95.;844.;195.|] 
    let chartColor: ChartJs.Chart.ChartColor =  "#337ab7" |> U4.Case1
    let chartColorBack: ChartJs.Chart.ChartColor =  "#4faeff" |> U4.Case1
    let dataset = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Transactions" |> Some
        o.data <- chartTrValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- chartColorBack |> U2.Case1 |> Some
        o.borderColor <- chartColor |> U2.Case1 |> Some
        // o.yAxisID <- "B" |> Some
        )   
    let chartTransData: ChartJs.Chart.ChartData = {
        labels = [| "01/01/2018"; "02/01/2018"; "03/01/2018"; "04/01/2018"; "05/01/2018"; "06/01/2018"; "07/01/2018" |] |> Array.map U2.Case1  
        datasets = [| dataset |] 
    }
    let chartTransProps = chartProps chartTransData false 72.
    Ibox.btRow "Transaction History" false [
                         ofImport "Line" "react-chartjs-2" chartTransProps []
                    ]


let onclickFun = fun _ -> ()//cluster.CId |> SelectCluster |> dispatch 
                                                // goToPage (toHash page)  
let showBtn = 
    comF button (fun o -> o.bsClass <- "btn btn-success btn-outline btn-xs" |> Some
                          o.onClick <- React.MouseEventHandler(onclickFun) |> Some  
                          )
                        [ str "show" ]

let chains (chs:Set<ChainDefs.ChainDef>) (model:ActiveNode) dispatch = 
    let chPagin = model.ChainsPagination
    let onclickFun page =  fun _ -> page |> ChainsPagingMsg |> dispatch
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

let nodeView clusterMembership (model: ActiveNode option) dispatch = 
    let nd = getFirstNode clusterMembership.Nodes
    div [ Class "row" ]
        [
            match model with 
            | Some node ->
                yield div [ Class "col-md-12 col-lg-6" ]
                        [   nodeInfo node.ANode ] 
            | None -> ()
            yield div [ Class "col-md-12 col-lg-6" ]
                [
                    transactionInfo clusterMembership.Cluster
                ]
            match model with 
            | Some node ->
                yield div [ Class "col-md-12 " ]
                        [   chains node.ANode.Chains node dispatch ]
            | None -> ()
        ]

let view model (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        (match model.ActiveCluster with 
            | Some ac -> [   nodeView ac.ACluster ac.ActiveNode dispatch ]
            | None -> [] )
