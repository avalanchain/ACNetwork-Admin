module Client.Cabinet

open Shared

type MenuPage =
    | Clusters
    | Nodes
    | Chains
    | Accounts
    with static member Default = Clusters  


type Msg =
    | ClustersMsg       //of ClustersMsg
    | NodesMsg  
    | ChainsMsg    
    | AccountsMsg
    | ServerMsg         of ServerMsg
and ServerMsg =
    | ReplaceMe
    // | GetCryptoCurrenciesCompleted  of ViewModels.ChainNetwork.CryptoCurrency list
    // | GetTokenSaleCompleted         of ViewModels.TokenSale
    // | GetFullCustomerCompleted      of ViewModels.FullCustomer
    // | GetTransactionsCompleted      of ViewModels.ETransaction list
// and ClustersMsg = 
//     | ActiveSymbolChanged of symbol: CryptoCurrencySymbol
