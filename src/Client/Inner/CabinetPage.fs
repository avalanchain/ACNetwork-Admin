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

let cmdServerCabinetCall apiFunc args completeMsg serverMethodName : Cmd<Cabinet.Msg> =
    cmdServerCall apiFunc args (completeMsg >> Cabinet.Msg.ServerMsg >> CabinetMsg) serverMethodName
    |> Cmd.map (!!)

let init authToken = 
    let model = {   Auth                = { Token = authToken }
                    Customer            = None
                    Clusters            = []
                    ClusterMembership   = None
                    ActiveNode          = None
    }
    // let cmdGetCryptoCurrencies      = cmdServerCabinetCall (ServerProxy.cabinetApi.getCryptoCurrencies) () GetCryptoCurrenciesCompleted "getCryptoCurrencies()"
    // let cmdGetTokenSale             = cmdServerCabinetCall (ServerProxy.cabinetApi.getTokenSale) () GetTokenSaleCompleted "getTokenSale()"
    // let cmdGetFullCustomerCompleted = cmdServerCabinetCall (ServerProxy.cabinetApi.getFullCustomer) (Auth.secureVoidRequest authToken) GetFullCustomerCompleted "getFullCustomer()"
    // let cmdGetTransactionsCompleted = cmdServerCabinetCall (ServerProxy.cabinetApi.getTransactions) (Auth.secureVoidRequest authToken) GetTransactionsCompleted "getTransactions()"
    // let cmd = Cmd.batch [   cmdGetCryptoCurrencies
    //                         cmdGetTokenSale
    //                         cmdGetFullCustomerCompleted
    //                         cmdGetTransactionsCompleted ]
    model, Cmd.none

let update (msg: Msg) model : Model * Cmd<Msg> = 
    match msg with
    | ClustersMsg msg_ ->
        match msg_ with
        | SelectCluster cid             -> 
            model, cmdServerCabinetCall (ServerProxy.cabinetApi.getClusterMembership) (secureRequest model.Auth.Token cid) UpdateClusterMembershipCompleted "getClusterMembership()" 
    | ServerMsg msg_     ->
        match msg_ with
        | GetClustersCompleted clusters         -> { model with Clusters = clusters } , Cmd.none 
        | UpdateClusterMembershipCompleted cm   -> { model with ClusterMembership = Some cm }, Cmd.none
        // | ReplaceMe -> model , Cmd.none
    | NodesMsg -> failwith "Not Implemented"
    | ChainsMsg -> failwith "Not Implemented"
    | AccountsMsg -> failwith "Not Implemented"
        
let view (page: Cabinet.MenuPage) (model: Model) (dispatch: Msg -> unit) = 
    match page with
        | Cabinet.MenuPage.Clusters     -> [ ClustersPage.view model dispatch ]
        | Cabinet.MenuPage.Nodes        -> [ NodesPage.view model dispatch ]
        | Cabinet.MenuPage.Chains       -> [ ChainsPage.view model dispatch ]
        | Cabinet.MenuPage.Accounts     -> [ AccountsPage.view model dispatch ]
    |> div [] 
        


