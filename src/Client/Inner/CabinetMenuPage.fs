module Client.Cabinet

open Shared
open Shared.ViewModels.ChainNetwork


type MenuPage =
    | Clusters
    | Nodes
    | Chains
    | Accounts
    with static member Default = Clusters  


type Msg =
    | ClustersMsg       of ClustersMsg
    | NodesMsg  
    | ChainsMsg    
    | AccountsMsg
    | ServerMsg         of ServerMsg
and ServerMsg =
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
