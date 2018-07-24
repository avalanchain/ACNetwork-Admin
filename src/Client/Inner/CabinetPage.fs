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

open Web3
open Web3Types

[<Emit("window.web3")>]
let web3: Web3 = jsNative
let IsWeb3 = isNull web3

// console.log (sprintf "IsW3: '%A'" IsWeb3)

// let w3 = web3Factory.Create("http://127.0.0.1:8545" |> U2.Case2 )
let w3 = web3Factory.Create(web3.currentProvider |> U2.Case1 )

promise {
    let! accs = w3.eth.getAccounts()
    console.log "accs"
    console.log accs
    let! bal = w3.eth.getBalance(accs.[0])
    console.log "bal"
    console.log (bal / 1000000000000000000.)
    let! coinbase = w3.eth.getCoinbase()
    console.log "coinbase"
    console.log (coinbase)
    let amount = w3.utils.toWei("1" |> U3.Case1, Web3Types.Unit.Ether)
    
    // web3.eth.getTransactionCount(accounts[i])

    let! transactions = w3.eth.getTransactionCount(coinbase)
    console.log "transactions"
    console.log transactions

    let defaultAccount = web3.eth.defaultAccount
    console.log "defaultAccount"
    console.log defaultAccount
    // let provider = web3.currentProvider :> obj :?> IProvider
    // let! _ = provider.send(jsOptions<JsonRPCRequest>(fun r ->  r.method <- "personal_sign" |> Some 
    //                                                            r.``to`` <- Some "0xC25FdBeaD74a9A1d09F3209d2fcDE652d4D359fE" )) 

    let tr = jsOptions<Tx>(fun  tx -> tx.value <- amount |> Some 
                                      tx.from <- Some coinbase
                                      tx.``to`` <- Some "0xC25FdBeaD74a9A1d09F3209d2fcDE652d4D359fE" )
 
    //coinbase,"0xC25FdBeaD74a9A1d09F3209d2fcDE652d4D359fE"

    // let! tx = w3.eth.sendTransaction tr

    // console.log tx

    // let! balance = w3.eth.getBalance("0xC25FdBeaD74a9A1d09F3209d2fcDE652d4D359fE")

    // console.log "newAccount"
    // console.log (newAccount)
    // console.log "getBalanse"
    // console.log (balance)
    let! accs = w3.eth.getAccounts()
    console.log accs
}
|> PowerPack.Promise.start

let init authToken = 
    let model = {   Auth        = { Token = authToken }
                    Customer    = None
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
    | ClustersMsg  -> 
        model , Cmd.none
    | ServerMsg msg_     ->
        match msg_ with
        | ReplaceMe -> model , Cmd.none
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
        


