module Client.DashboardPage

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
    

// importAll "../../../node_modules/react-jvectormap/build/index.js"
let page = Cabinet.Node |> MenuPage.Cabinet
let onclickFun = fun _ -> //cluster.CId |> SelectCluster |> dispatch 
                                                goToPage (toHash page)  
let nodeViewBtn = 
    comF button (fun o -> o.bsClass <- "btn btn-success btn-outline btn-xs" |> Some
                          o.onClick <- React.MouseEventHandler(onclickFun) |> Some  
                          )
                        [ str "Open Node" ]

type [<Pojo>] MapStyleProp = { width: string ;height: string }
type [<Pojo>] FillMap = { fill: string; }
type [<Pojo>] ColorStylesMap = { initial: FillMap ; selected: FillMap }

type [<Pojo>] CountryMap = {   RU: int option
                               GB: int option
                               US: int option
                               CN: int option
                               AU: int option }
type Country =             
    | RU
    | GB 
    | US 
    | CN 
    | AU                             
// type CountryName = {           RU: string
//                                GB: string
//                                US: string
//                                CN: string
//                                AU: string }
type [<Pojo>] ScaleProp = { active: string }
type [<Pojo>] RegionsProp = { scale     : string array
                              attribute : string
                              values    : CountryMap }
   
type [<Pojo>] SeriesProp = { regions: RegionsProp[] }
///////////CHART
/// 


type [<Pojo>] GaugeChartProps = { width: int }
let GaugeChart : GaugeChartProps -> ReactElement = importDefault "../GaugeChart.jsx"
// let GaugeChart : unit -> ReactElement = import "GaugeChart" "../GaugeChart.jsx"


let clusterMap (mapData:CountryMap) = 
    ///     Map
    let contstyle: MapStyleProp =  { width = "100%"; height = "300px"}
    let regionStyle: ColorStylesMap =   {  initial = { fill = "#DBDAD6" }; selected = { fill = "#1ab394" } }            

    let seriesProp: SeriesProp =   {
        regions = [|{ scale = [| "#22d6b1"; "#15997d" |] //1ab393
                      attribute = "fill"
                      values =  mapData } |]
    }
    
    ///     Chart
    let datasets = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.data <- [| 2.; 5.; 1.; 4.; 1. |] |> U2.Case1 |> Some
        o.backgroundColor <- [| "#1ab394"; "#ed5565"; "#FFCE56"; "#23c6c8"; "#1c84c6" |] |> Array.map U4.Case1 |> U2.Case2 |> Some
        o.hoverBackgroundColor <- [| "#15997d"; "#15997d"; "#15997d"; "#15997d"; "#15997d" |] |> U2.Case2 |> Some)

    let chartJsData: ChartJs.Chart.ChartData = {
        // let countrNames name = 
        //     match name with 
        //     | RU -> "Russia"
        //     | GB -> "United Kingdom"
        //     | US -> "USA"
        //     | CN -> "China"
        //     | AU -> "Australia"

        labels = [| "Russia"; "United Kingdom"; "USA"; "China"; "Australia" |] |> Array.map U2.Case1  
        datasets = [| datasets |] 
    }

    let chartProps = 
        let clo =  jsOptions<ChartJs.Chart.ChartLegendOptions>(fun clo -> 
                            clo.position <- ChartJs.Chart.PositionType.Bottom |> Some
                            // clo.display  <-  true |> Some
                            )

        jsOptions<ChartComponentProps>(fun o -> 
                o.data   <- chartJsData |> ChartData.ofT
                o.legend <- clo |> Some ); 

    Ibox.btRow "Clusters worldwide" false 

                    [   Ibox.emptyRow
                            [
                                Ibox.btColEmpty "5" [
                                    ofImport "Doughnut" "react-chartjs-2" chartProps []
                                    ]
                                Ibox.btColEmpty "7" [
                                    ofImport "VectorMap" "react-jvectormap" (createObj [   "map" ==> "world_mill"
                                                                                        //    "fills" ==> fills
                                                                                           "regionStyle" ==> regionStyle
                                                                                           "backgroundColor" ==> "#ffffff"
                                                                                           "containerStyle" ==> contstyle
                                                                                           "series" ==> seriesProp 
                                                                                           "regionsSelectable" ==> true 
                                                                                             ]) []
                                    ]
                                    ]
                    ]

let clBody (count:int) subname = 
    div [ ]
        [
            h2 []
                   [ str (count.ToString()) ]
            div [ Class "stat-percent font-bold text-info" ]
                [
                ]
            small []
                  [
                      str subname 
                  ]  
        ]    
let nodesInfo count =

    div [ Class "ibox float-e-margins animated fadeInUp" ]
                        [ div [ Class "ibox-title" ]
                            [ h5 [ ]
                                [ str "Nodes" ] 
                              span [ Class "label label-primary pull-right" ]
                                    [str "up"]
                              ] 
                          Ibox.iboxContent false [clBody 30 "Testnet" ]]
let transactionsInfo count =

    div [ Class "ibox float-e-margins animated fadeInUp" ]
                        [ div [ Class "ibox-title" ]
                            [ h5 [ ]
                                [ str "Transactions" ] 
                              span [ Class "label label-primary pull-right" ]
                                    [str "signed"]
                              ] 
                          Ibox.iboxContent false [clBody 12434325 "Testnet" ]]
let clustersInfo count =

    div [ Class "ibox float-e-margins animated fadeInUp" ]
                        [ div [ Class "ibox-title" ]
                            [ h5 [ ]
                                [ str "Clusters" ] 
                              span [ Class "label label-primary pull-right" ]
                                    [str "up"]
                              ] 
                          Ibox.iboxContent false [clBody count "Cluster by region"]]

let dashboardView count = 
    div [ Class "row" ] 
                            [
                                div [ Class "col-md-4" ] 
                                    [
                                        clustersInfo count
                                    ]
                                div [ Class "col-md-4" ] 
                                    [
                                        nodesInfo count
                                    ]
                                div [ Class "col-md-4" ] 
                                    [
                                        transactionsInfo count
                                    ]
                            ]
    // Ibox.btRow "Testnet" false 
    //                 [
    //                     div [ Class "row" ] 
    //                         [
    //                             div [ Class "col-md-4" ] 
    //                                 [
    //                                     clustersInfo count
    //                                 ]
    //                             div [ Class "col-md-4" ] 
    //                                 [
    //                                     // ofImport "Doughnut" "react-chartjs-2" chartProps []
    //                                 ]
    //                         ]
                        
    //                     div [ Class "row" ] 
    //                         [
    //                             div [ Class "col-md-6" ] 
    //                                 [
    //                                     ofFunction GaugeChart { width = 500 } [ p[] [ str "asasdasdasdasd"]]
    //                                 ]
    //                             div [ Class "col-md-6" ] 
    //                                 [
    //                                     GaugeChart { width = 500 }
    //                                 ]
    //                         ]
                        
    //                     // ChartsPG.radialChartSample()
                        
                        
    //                 ]
                    // let rMoment (date:DateTime)  = ofImport "default" "react-moment" (createObj [  "date" ==> date
//                                                                                "fromNow" ==> true  ]) []

//"Russia"; "United Kingdom"; "USA"; "China"; "Australia"

let countryNames = function
                    | RU  -> "Russia"
                    | GB  -> "United Kingdom"
                    | US  -> "USA"
                    | CN  -> "China"
                    | AU  -> "Australia"
// let t (data: (Country * int) []) : ResizeArray<string> = 
//         // let dt:CountryMap  = {}
//         let countrynames = ResizeArray<string>()
//         // let mutable tt  = ""
        
//         let cn (country: Country * int) = country |> U2.Case1 |> countryNames
//         for country in data ->
//             countrynames.Add(cn country)
//         //     // match (co |> Case1) with
//         //     //     | US -> dt.US = 1
//         // dt 
//         countrynames                  
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    let data1 = [| US, 2; GB, 5; RU, 1; CN, 4; AU, 1; |]
    // let tt = t data1
    let dataCountry:CountryMap = {  US = Some 2 ;
                                    GB = Some 5;
                                    RU = Some 1;
                                    CN = Some 4
                                    AU = Some 1 } 
    div [  ]
        [  
            
    

           clusterMap dataCountry
           dashboardView data1.Length
            // str "Cluster"
            // match model.ClusterMembership with 
            // | Some clusterMembership ->
            //     // yield str "Cluster Membership" 
            //     yield clusterView clusterMembership (ClustersMsg >> dispatch)
            // | None -> ()

             
            
        ]


// let clusterNodes clusterMembership dispatch = 
    
    
//     let rows = 
//             clusterMembership.Nodes
//             |> Seq.map (fun node -> 
//                 tr [] [ td [] (nodeNameSpans node.Key.NId)
                                
//                         td [] [ node.Key.Chains.Count |> string |> str ]
//                         td [] [ node.Key.Endpoint.IP |> string |> str ]
//                         td [] [ node.Key.Endpoint.Port |> string |> str ]
//                         td [] [ node.Key.Cluster |> string |> str]
//                         td [] 
//                            [
//                                span [ Class "label label-active" ]
//                                     [
//                                         node.Value |> string |> str ]
//                                     ]
                                
//                         td [] [ nodeViewBtn ] ])
//             |> Seq.toList
//     Ibox.btRow "Nodes" false
//             [
//                 div [ Class "table-responsive" ]//table-responsive
//                     [
//                         comE table 
//                             [
//                                 thead [][
//                                     tr[][
//                                         th [][str "Node" ]
//                                         th [][str "Chains" ]
//                                         th [][str "IP" ]
//                                         th [][str "Port" ]
//                                         th [][str "Cluster" ]
//                                         th [][str "Status" ]
//                                         th [][str "Action" ]
//                                         // th [][str "GAS USED" ]
//                                         // th [ Class "text-center"  ][str "VALUE" ]
//                                     ]
//                                 ]
//                                 tbody [ ] 
//                                       rows
                              
//                     ]]
//     ]


// let clBody (cl: ACCluster) = 
//     div [ ]
//         [
//             h2 []
//                    [ str ( "UUID: " + cl.CId.ToString()) ]
//             div [ Class "stat-percent font-bold text-info" ]
//                 [
//                 ]
//             small []
//                   [
//                       str "Main"
//                   ]  
//         ]    
// let clusterInfo (cl: ACCluster) =

//     div [ Class "ibox float-e-margins animated fadeInUp" ]
//                         [ div [ Class "ibox-title" ]
//                             [ h5 [ ]
//                                 [ str "Cluster Info" ] 
//                               span [ Class "label label-primary pull-right" ]
//                                     [str "active"]
//                               ] 
//                           Ibox.iboxContent false [clBody cl]]
// let nodesCount = 
//     Ibox.inner "Nodes" false
//                 [
                    
//                     h1 []
//                        [ str "1" ]
//                     div [ Class "stat-percent font-bold text-info" ]
//                         [
//                         ]
//                     small []
//                           [
//                               str "All"
//                           ]  
                        
//         ]
