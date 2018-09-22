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
open Fable.Import.React
open ReactChartJs2
    
let page = Cabinet.Node |> MenuPage.Cabinet
let onclickFun = fun _ -> //cluster.CId |> SelectCluster |> dispatch 
                                                goToPage (toHash page)  
let nodeViewBtn = 
    comF button (fun o -> o.bsClass <- "btn btn-success btn-outline btn-xs" |> Some
                          o.onClick <- React.MouseEventHandler(onclickFun) |> Some  
                          )
                        [ str "Open Node" ]


let clusterChartProps (nodes: Map<ACNodeId, ACNode>) =
    //nodeName node.Key.NId
    let nodesValues = 
            nodes
            |> Seq.map (fun node -> node.Value.Chains.Count |> float) 
            |> Seq.toArray
    let nodesNames = 
            nodes
            |> Seq.map (fun node -> nodeName node.Key |> string)
            |> Seq.toArray

    let datasets  = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.data <- nodesValues |> U2.Case1 |> Some
        o.backgroundColor <- [| "#a3e1d4";  |] |> Array.map U4.Case1 |> U2.Case2 |> Some //#dedede, #FF6384,"#36A2EB"; "#FFCE56"
        o.hoverBackgroundColor <- [| "#1ab394"; |] |> U2.Case2 |> Some // #1ab394, #FF6484, "#36A3EB"; "#FFCF56" 
    )

    let chartJsData: ChartJs.Chart.ChartData = {
        labels = nodesNames |> Array.map U2.Case1  
        datasets = [| datasets |] 
    }

    let clo = jsOptions<ChartJs.Chart.ChartLegendOptions>(fun clo -> 
                            clo.position <- ChartJs.Chart.PositionType.Bottom |> Some
                            clo.display  <- None
                            )

    jsOptions<ChartComponentProps>(fun o -> 
        o.data   <- chartJsData |> ChartData.ofT
        o.legend <- clo |> Some ); 
/// 
let clusterNodes model clusterMembership dispatch = 
    
    let onclickFun page =  fun _ -> page |> NodesPagingMsg |> dispatch
    let rows = 
            clusterMembership.Nodes
            |> Seq.map (fun kv -> 
                let node = kv.Value
                tr [] [ td [] (nodeNameSpans node.NId)
                                
                        td [] [ node.Chains.Count |> string |> str ]
                        td [] [ node.Endpoint.IP |> string |> str ]
                        td [] [ node.Endpoint.Port |> string |> str ]
                        td [] [ node.Clusters |> string |> str]
                        td [] 
                           [
                               span [ Class "label label-active" ]
                                    [
                                        node.State |> string |> str ]
                                    ]
                                
                        td [] [ nodeViewBtn ] ])
            |> Seq.toList
    Ibox.btRow "Nodes" false
            [
                div [ Class "table-responsive" ]//table-responsive
                    [
                        yield comE table 
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
                              
                            ]
                        match model.ActiveCluster with 
                        | Some ac -> yield Client.Pagination.view (ac.NodesPagination) onclickFun
                        | None -> ()
                    ]
    ]



let transactionInfo (cl: ACCluster) =
    let chartTrValues = [| 4148.;1246.;7643.;14422.;9522.;6422.;7522.|] 
    let chartColor: ChartJs.Chart.ChartColor =  "#337ab7" |> U4.Case1
    let chartColorBack: ChartJs.Chart.ChartColor =  "#4faeff" |> U4.Case1
    let datasetsTr2 = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Transactions" |> Some
        o.data <- chartTrValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- chartColorBack |> U2.Case1 |> Some
        o.borderColor <- chartColor |> U2.Case1 |> Some
        // o.yAxisID <- "B" |> Some
        )   
    let chartTransData: ChartJs.Chart.ChartData = {
        labels = [| "01/01/2018"; "02/01/2018"; "03/01/2018"; "04/01/2018"; "05/01/2018"; "06/01/2018"; "07/01/2018" |] |> Array.map U2.Case1  
        datasets = [| datasetsTr2 |] 
    }
    let chartTransProps = chartProps chartTransData false 72.
    Ibox.btRow "Transaction History" false [
                         ofImport "Bar" "react-chartjs-2" chartTransProps []
                    ]

let clBody (cms : ACClusterMembership) = 
    div [ Class "row" ]
        [
            div [ Class ("col-md-6 " ) ]
                [
                    h2 [ ]
                       [ str ("Nodes: " + (string cms.Nodes.Count)) ]
                    // h1 [ ]
                    //    [ str (string cms.Nodes.Count) ]
                    div [ Class "stat-percent font-bold text-info" ]
                        [
                        ]
                    div [ ]
                        [
                            span [ Class "text-muted m-t-xs" ]
                              [ 
                             h2 [ ]
                                 [ 
                                b [ ]
                                    [ str "UUID: " ]
                                small [ Class  txtN]
                                  [str (cms.Cluster.CId.ToString()) ] 
                                div [] 
                                    [
                                        small []
                                              [
                                                  str "Zone 1"
                                              ]  
                                  ]]]
                        ]   
                 ]
            div [ Class "col-md-6" ]
                [
                    ofImport "Doughnut" "react-chartjs-2" (clusterChartProps cms.Nodes) []
                ]
        ]  

let nodesCount (cms : ACClusterMembership) =

    div [ Class "ibox float-e-margins animated fadeInUp" ]
                        [ div [ Class "ibox-title" ]
                            [ h5 [ ]
                                [ str "Cluster Info" ] 
                              span [ Class "label label-primary pull-right" ]
                                    [str "active"]
                              ] 
                          Ibox.iboxContent false [clBody cms]]


let clusterView model clusterMembership dispatch = 
    div [ Class "row" ]
        [
            div [ Class "col-md-12 col-lg-6" ]
                [
                    nodesCount clusterMembership
                ]
            div [ Class "col-md-12 col-lg-6" ]
                [
                    transactionInfo clusterMembership.Cluster
                ]
            div [ Class "col-lg-12" ]
                [
                    clusterNodes model clusterMembership dispatch
                ]
        ]
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [  
            // str "Cluster"
            match model.ActiveCluster with 
            | Some ac ->
                // yield str "Cluster Membership" 
                yield clusterView model (ac.ACluster) dispatch
            | None -> ()

           
            
        ]

