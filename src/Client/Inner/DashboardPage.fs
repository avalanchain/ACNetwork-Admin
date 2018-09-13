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

type CountryInfo = {
    Abbreviation: Country
    Name        : string
    CountOfNodes: uint32
    BackgroundColor: string
    // ForegroundColor: string
}                         

type [<Pojo>] ScaleProp   = { active    : string }
type [<Pojo>] RegionsProp = { scale     : string array
                              attribute : string
                              values    : CountryMap }
   
type [<Pojo>] SeriesProp = { regions: RegionsProp[] }
///////////CHART
/// 


let clusterMap clusters = 
    let mapData: CountryMap = clusters |> Array.map (fun ci -> ci.Abbreviation |> string ==> Some ci.CountOfNodes ) |> createObj |> unbox
    
    let chartValues = clusters |> Array.map (fun ci -> ci.CountOfNodes |> float )
    let chartLabels = clusters |> Array.map (fun ci -> ci.Name )
    let chartBGColors = clusters |> Array.map (fun ci -> ci.BackgroundColor )
    
    // let chartHoverColors = Array.init clusters.Length (fun _ ->  "#15997d")
    let chartHoverColors = clusters |> Array.map(fun _ ->  "#15997d" )
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
        o.data <- chartValues |> U2.Case1 |> Some
        o.backgroundColor <- chartBGColors |> Array.map U4.Case1 |> U2.Case2 |> Some
        // o.hoverBackgroundColor <- chartHoverColors |> U2.Case2 |> Some
        )

    let chartJsData: ChartJs.Chart.ChartData = {
        labels = chartLabels |> Array.map U2.Case1  
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
            h2 [ Class "fbold" ]
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
                          Ibox.iboxContent false [clBody 724304032 "Testnet" ]]
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


let testNetView clusters = 
    let chartNodeValues = clusters |> Array.map (fun ci -> ci.CountOfNodes+3u |> float )
    let chartTrValues = clusters |> Array.map (fun ci -> (ci.CountOfNodes * (uint32 ci.Name.Length) ) |> float )

    let datasetsNodes = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Nodes" |> Some
        o.data <- chartNodeValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- [| "#1ab394"; "#ed5565"; "#FFCE56"; "#23c6c8"; "#1c84c6" |] |> Array.map U4.Case1 |> U2.Case2 |> Some
        o.yAxisID <- "A"     |> Some
        )

    let datasetsTr = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Transactions" |> Some
        o.data <- chartTrValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- [| "#1ab300"; "#ed5500"; "#FFCE00"; "#23c600"; "#1c8400" |] |> Array.map U4.Case1 |> U2.Case2 |> Some
        o.yAxisID <- "B" |> Some
        )


    let chartColor: ChartJs.Chart.ChartColor =  "#1c84c6" |> U4.Case1
    let chartColorBack: ChartJs.Chart.ChartColor =  "#3aa3e6" |> U4.Case1
    
    let datasetsTr2 = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.label <- "Transactions" |> Some
        o.data <- chartTrValues |> Array.map(fun fl -> fl |> chartPoint ) |> U2.Case2 |> Some
        o.backgroundColor <- chartColorBack |> U2.Case1 |> Some
        o.borderColor <- chartColor |> U2.Case1 |> Some
        // o.yAxisID <- "B" |> Some
        )    
    let chartNodesData: ChartJs.Chart.ChartData = {
        labels = [| "Russia"; "United Kingdom"; "USA"; "China"; "Australia" |] |> Array.map U2.Case1  
        datasets = [| datasetsNodes; datasetsTr |] 
    }
    let chartTransData: ChartJs.Chart.ChartData = {
        labels = [| "01/01/2018"; "02/01/2018"; "03/01/2018"; "04/01/2018"; "05/01/2018" |] |> Array.map U2.Case1  
        datasets = [| datasetsTr2 |] 
    }
    let chartNodesProps = 
        let clo =  jsOptions<ChartJs.Chart.ChartLegendOptions>(fun clo -> 
                            clo.position <- ChartJs.Chart.PositionType.Bottom |> Some
                            )
        let cTicks = jsOptions<ChartJs.Chart.TickOptions>(fun ct -> 
                                    ct.beginAtZero <- true |> Some
                                    // ct.display <- false |> Some
                                    )   
        let cTicks2 = jsOptions<ChartJs.Chart.TickOptions>(fun ct -> 
                                    ct.display <- true |> Some
                                    ct.min <- 0u :> obj |> Some
                                    )                                   
        let sTileO name = jsOptions<ChartJs.Chart.ScaleTitleOptions>(fun sto -> 
                                    sto.labelString <- name |> Some
                                    sto.display <- true |> Some
                                    )           
        let chartYAxeFirst = jsOptions<ChartJs.Chart.ChartYAxe>(fun cya -> 
                                    cya.ticks <- cTicks2 |> Some
                                    cya.id <- "A" |> Some
                                    cya.position <- "left" |> Some
                                    cya.scaleLabel <- sTileO "Nodes" |> Some
                                    )
        let chartYAxeSecond = jsOptions<ChartJs.Chart.ChartYAxe>(fun cya -> 
                                    cya.ticks <- cTicks |> Some
                                    cya.id <- "B" |> Some
                                    cya.position <- "right" |> Some
                                   
                                    cya.scaleLabel <- sTileO "Transactions" |> Some
                                    )                            
        let raYAxe =  ResizeArray<ChartJs.Chart.ChartYAxe>()     
        raYAxe.Add(chartYAxeFirst) 
        raYAxe.Add(chartYAxeSecond) 

        // let chartXAxeFirst = jsOptions<ChartJs.Chart.ChartXAxe>(fun cya -> 
        //                             cya.display <- false |> Some
        //                             )
        // let raXAxe =  ResizeArray<ChartJs.Chart.ChartXAxe>()     
        // raXAxe.Add(chartXAxeFirst)
        // raXAxe.Add(chartXAxeFirst)
        let cScales =  jsOptions<ChartJs.Chart.ChartScales>(fun sc -> 
                                    sc.yAxes <- raYAxe |> Some
                                    // sc.xAxes <- raXAxe |> Some
                                    // sc.gridLines < - 
                                    )
        let cOptions =  jsOptions<ChartJs.Chart.ChartOptions>(fun co -> 
                                    co.scales <- cScales |> Some
                                    )
        jsOptions<ChartComponentProps>(fun o -> 
                o.data   <- chartNodesData |> ChartData.ofT
                o.options <- cOptions |> Some
                o.legend <- clo |> Some 
                ); 
                
    let chartTransProps = chartProps chartTransData false 0.

    div [ Class "row" ] 
        [
            div [ Class "col-md-12 col-lg-6" ] 
                [
                    Ibox.btRow "Nodes / Transaction" false [
                         ofImport "Bar" "react-chartjs-2" chartNodesProps []
                    ]
                   
                ]
            div [ Class "col-md-12 col-lg-6" ] 
                [
                    Ibox.btRow "Transaction Volume" false [
                         ofImport "Line" "react-chartjs-2" chartTransProps []
                    ]
                   
                ]
        ]
let countryInfos =
    [|
        {   Abbreviation = RU
            Name         = "Russia"
            CountOfNodes = 1u
            BackgroundColor = "#1ab394" }
        {   Abbreviation = GB
            Name         = "United Kingdom"
            CountOfNodes = 7u 
            BackgroundColor = "#ed5565" }
        {   Abbreviation = US
            Name         = "USA"
            CountOfNodes = 3u 
            BackgroundColor = "#FFCE56" }
        {   Abbreviation = CN
            Name         = "China"
            CountOfNodes = 4u 
            BackgroundColor = "#23c6c8" }
        {   Abbreviation = AU
            Name         = "Australia"
            CountOfNodes = 5u 
            BackgroundColor = "#1c84c6" }
    |]

let labels: U2<string,string []> [] = countryInfos |> Array.map (fun ci -> ci.Name |> U2.Case1)
let dataCountry: CountryMap = countryInfos |> Array.map (fun ci -> ci.Name ==> Some ci.CountOfNodes ) |> createObj |> unbox

              
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    let clusters = countryInfos
    div [  ]
        [  
           dashboardView clusters.Length
           testNetView clusters   
           clusterMap clusters        
            
        ]

// type Country2 = Abbr of string

// let countries: Country2[] = [| Abbr "UK"; Abbr "US" |]


// let getAbbr (Abbr abbr) = abbr 

// let countyAbbrs = countries |> Array.map (fun c -> getAbbr c)

// let i = 1
// let o = i :> obj

// let box a = a :> obj
// let unbox<'T> (o: obj) = o :?> 'T 