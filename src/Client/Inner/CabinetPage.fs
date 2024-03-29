module Client.CabinetPage

open System

open Fable
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Import.BigNumber
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack
// open Fable.PowerPack.Fetch.Fetch_types

open Elmish
open Elmish.React
open Elmish.React.Common
open Elmish.Browser
open Elmish.Browser.Navigation
open Elmish.Toastr

open Shared
open Helpers
open ClientMsgs
open ClientModels
open Client.CabinetModel
open Client.LoginCommon
open Client.Cabinet
open Shared.Auth
open Shared.WsBridge

let cmdServerCabinetCall apiFunc args completeMsg serverMethodName =
    cmdServerCall apiFunc args (completeMsg >> Cabinet.Msg.ServerMsg >> CabinetMsg) serverMethodName

let init authToken = 
    let model = {   Auth                = { Token = authToken }
                    Customer            = None
                    Clusters            = []
                    ActiveCluster       = None                    
    }
    // let cmdGetCryptoCurrencies      = cmdServerCabinetCall (ServerProxy.cabinetApi.getCryptoCurrencies) () GetCryptoCurrenciesCompleted "getCryptoCurrencies()"
    // let cmdGetTokenSale             = cmdServerCabinetCall (ServerProxy.cabinetApi.getTokenSale) () GetTokenSaleCompleted "getTokenSale()"
    let cmdGetCustomer = cmdServerCabinetCall (ServerProxy.cabinetApi.getCustomer) (Auth.secureVoidRequest authToken) GetCustomerCompleted "getCustomer()"
    let cmdGetClusters = cmdServerCabinetCall (ServerProxy.cabinetApi.getClusters) (Auth.secureVoidRequest authToken) GetClustersCompleted "getClusters()"
    let cmd = Cmd.batch [   //cmdGetCryptoCurrencies
                            //cmdGetTokenSale
                            cmdGetCustomer
                            cmdGetClusters 
                            ]
    model, cmd

let update (msg: Msg) model : Model * Cmd<ClientMsg> = 
    match msg with
    | ClustersMsg msg_ ->
        match msg_ with
        | SelectCluster cid             -> 
            model, cmdServerCabinetCall (ServerProxy.cabinetApi.getClusterMembership) (secureRequest model.Auth.Token cid) UpdateClusterMembershipCompleted "getClusterMembership()" 
    | ServerMsg msg_     ->
        match msg_ with
        | GetCustomerCompleted customer         -> { model with Customer = Some customer } , Cmd.none
        | GetClustersCompleted clusters         -> { model with Clusters = clusters } , Cmd.none 
        | UpdateClusterMembershipCompleted cm   -> { model with //ClusterMembership = Some cm
                                                                ActiveCluster = {   ACluster        = cm 
                                                                                    ActiveNode      =   match cm.Nodes |> Seq.tryHead with
                                                                                                        | None -> None
                                                                                                        | Some kv -> {  ANode               = kv.Value
                                                                                                                        ChainsPagination    = { Page    = 1 
                                                                                                                                                Total   = 8
                                                                                                                                                MaxSize = 5 } } |> Some
                                                                                    NodesPagination = { Page    = 1 
                                                                                                        Total   = 8
                                                                                                        MaxSize = 5 } } |> Some }, Cmd.none
        // | ReplaceMe -> model , Cmd.none
    | NodesMsg -> failwith "Not Implemented"
    | ChainsMsg -> failwith "Not Implemented"
    | ChainsPagingMsg pageIndex -> 
        // { model with ActiveNode = { model.ActiveNode with ChainsPagination = { model.ActiveNode.ChainsPagination with Page = msg_ } } }, Cmd.none
        let m = match model.ActiveCluster with 
                | Some ac ->
                    match ac.ActiveNode with
                    | Some an ->  
                        { model with ActiveCluster = Some { ac with NodesPagination = { ac.NodesPagination with Page = pageIndex } } }
                    | None -> model
                | None -> model
        m, Cmd.none
    | NodesPagingMsg pageIndex -> 
        let m = match model.ActiveCluster with 
                | Some ac -> { model with ActiveCluster = Some { ac with NodesPagination = { ac.NodesPagination with Page = pageIndex } } }
                | None -> model
        m, Cmd.none
    | AccountsMsg -> failwith "Not Implemented"
        
let view (page: Cabinet.MenuPage) (model: Model) (dispatch: Msg -> unit) = 
    match page with
        | Cabinet.MenuPage.Clusters      -> [ ClustersPage.view model dispatch ]
        | Cabinet.MenuPage.Nodes         -> [ NodesPage.view model dispatch ]
        | Cabinet.MenuPage.Cluster       -> [ ClusterPage.view model dispatch ]
        | Cabinet.MenuPage.Node          -> [ NodePage.view model dispatch ]
        | Cabinet.MenuPage.Chains        -> [ ChainsPage.view model dispatch ]
        | Cabinet.MenuPage.Accounts      -> [ AccountsPage.view model dispatch ]
        | Cabinet.MenuPage.Dashboard     -> [ DashboardPage.view model dispatch ]
    |> div [] 
        


