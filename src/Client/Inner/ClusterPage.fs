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

///////////CHART
/// 
module ChartsPG =
    open Fable.Recharts   
    open Fable.Recharts.Props
    module R = Fable.Helpers.React
    module P = R.Props

    let margin t r b l =
        Chart.Margin { top = t; bottom = b; right = r; left = l }

    type [<Pojo>] Data =
        { name: string; uv: int; pv: int; amt: int }
    let data =
        [| { name = "Page A"; uv = 4000; pv = 2400; amt = 2400 }
           { name = "Page B"; uv = 3000; pv = 1398; amt = 2210 }
           { name = "Page C"; uv = 2000; pv = 9800; amt = 2290 }
           { name = "Page D"; uv = 2780; pv = 3908; amt = 2000 }
           { name = "Page E"; uv = 1890; pv = 4800; amt = 2181 }
           { name = "Page F"; uv = 2390; pv = 3800; amt = 2500 }
           { name = "Page G"; uv = 3490; pv = 4300; amt = 2100 }
        |]

    let lineChartSample() =
        lineChart
            [ margin 5. 20. 5. 0.
              Chart.Width 600.
              Chart.Height 300.
              Chart.Data data ]
            [ line
                [ Cartesian.Type Monotone
                  Cartesian.DataKey "uv"
                  P.Stroke "#8884d8"
                  P.StrokeWidth 2. ]
                []
              cartesianGrid
                [ P.Stroke "#ccc"
                  P.StrokeDasharray "5 5" ]
                []
              xaxis [Cartesian.DataKey "name"] []
              yaxis [] []
              tooltip [] []
            ]

    type PieData = {
        name: string
        value: int
    }
    let pieData = [ {name = "Group A"; value = 400} 
                    {name = "Group B"; value = 300}
                    {name = "Group C"; value = 300}
                    {name = "Group D"; value = 200} ];
    let COLORS = ["#0088FE", "#00C49F", "#FFBB28", "#FF8042"];

    let RADIAN = System.Math.PI / 180.;      

    let radialChartSample() =
        pieChart
            [ margin 5. 20. 5. 0.
              Chart.Width 600.
              Chart.Height 300. ]
            [ pie
                [   Chart.Data data
                    Chart.Cx 420.
                    Chart.Cy 200.
                    Chart.StartAngle 180.
                    Chart.EndAngle 0.
                    Chart.InnerRadius 60.
                    Chart.OuterRadius 80.
                    // Custom ("fill", "#8884d8")
                    Polar.PaddingAngle 5. ]
                [
                    cell [ !!(Cell.Fill "#8884d8") ] []
                ]
            ]
    

type [<Pojo>] GaugeChartProps = { width: int }
let GaugeChart : GaugeChartProps -> ReactElement = importDefault "../GaugeChart.jsx"
// let GaugeChart : unit -> ReactElement = import "GaugeChart" "../GaugeChart.jsx"

// let datasets = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
//     o.data <- [| 300.; 50.; 100. |] |> U2.Case1 |> Some
//     o.backgroundColor <- [| "#FF6384";  |] |> Array.map U4.Case1 |> U2.Case2 |> Some //"#36A2EB"; "#FFCE56"
//     o.hoverBackgroundColor <- [| "#FF6484"; |] |> U2.Case2 |> Some // "#36A3EB"; "#FFCF56" 
// )

// let chartJsData: ChartJs.Chart.ChartData = {
//     labels = [| "Red"; "Green"; "Yellow" |] |> Array.map U2.Case1  
//     datasets = [| datasets |] 
// }

// let chartProps = jsOptions<ChartComponentProps>(fun o -> 
//     o.data <- chartJsData |> ChartData.ofT ); 



let clusterChartProps (nodes: Map<ACNode,ACNodeState>) =
    //nodeName node.Key.NId
    let nodesValues = 
            nodes
            |> Seq.map (fun node -> node.Key.Chains.Count |> float) 
            |> Seq.toArray
    let nodesNames = 
            nodes
            |> Seq.map (fun node -> nodeName node.Key.NId |> string)
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
    
    
    let ndPagin = model.ActiveCluster.NodesPagination
    let onclickFun page =  fun _ -> page |> NodesPaginMsg |> dispatch
    let rows = 
            clusterMembership.Nodes
            |> Seq.map (fun node -> 
                tr [] [ td [] (nodeNameSpans node.Key.NId)
                                
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
                              
                            ]
                        Client.Pagination.view ndPagin onclickFun
                    ]
    ]



let transactionInfo (cl: ACCluster) =
    let chartTrValues = [| 414.;124.;764.;144.;95.|] 
    let chartColor: ChartJs.Chart.ChartColor =  "#ed5565" |> U4.Case1
    let chartColorBack: ChartJs.Chart.ChartColor =  "#f37280" |> U4.Case1
    let datasetsTr2 = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Transactions" |> Some
        o.data <- chartTrValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- chartColorBack |> U2.Case1 |> Some
        o.borderColor <- chartColor |> U2.Case1 |> Some
        // o.yAxisID <- "B" |> Some
        )   
    let chartTransData: ChartJs.Chart.ChartData = {
        labels = [| "01/01/2018"; "02/01/2018"; "03/01/2018"; "04/01/2018"; "05/01/2018" |] |> Array.map U2.Case1  
        datasets = [| datasetsTr2 |] 
    }
    let chartTransProps = chartProps chartTransData false 72.
    Ibox.btRow "Transactions" false [
                         ofImport "Line" "react-chartjs-2" chartTransProps []
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
                                                    ] 
                                                
                                                  ]]
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
            match model.ActiveCluster.ACluster with 
            | Some clusterMembership ->
                // yield str "Cluster Membership" 
                yield clusterView model clusterMembership dispatch
            | None -> ()

           
            
        ]

