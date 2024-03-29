module Client.Cabinet

open Shared
open Shared.ViewModels.ChainNetwork
open ReactBootstrap
open Client.Helpers

type MenuPage =
    | Dashboard
    | Clusters
    | Nodes
    | Chains
    | Accounts
    | Cluster
    | Node
    with static member Default = Clusters  


type Msg =
    | ClustersMsg       of ClustersMsg
    | NodesMsg  
    | ChainsMsg    
    | ChainsPagingMsg    of int
    | NodesPagingMsg    of int
    | AccountsMsg
    | ServerMsg         of ServerMsg
and ServerMsg =
    | GetCustomerCompleted              of ViewModels.Customer
    | GetClustersCompleted              of ViewModels.ChainNetwork.ACCluster list
    | UpdateClusterMembershipCompleted  of ACClusterMembership
    // | GetClustersCompleted  of ViewModels.ChainNetwork.ACCluster list
    // | GetClustersCompleted  of ViewModels.ChainNetwork.ACCluster list
    // | GetClustersCompleted  of ViewModels.ChainNetwork.ACCluster list

    // | GetTokenSaleCompleted         of ViewModels.TokenSale
    // | GetFullCustomerCompleted      of ViewModels.FullCustomer
    // | GetTransactionsCompleted      of ViewModels.ETransaction list
and ClustersMsg = 
    | SelectCluster             of ACClusterId

// and ChainsPaginMsg = 
//     | ChainsPaginMsg             of Paginate
