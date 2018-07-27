module Client.ClustersPage

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
    

// type Model = {
//     Clusters            : ACCluster list
//     // ActiveCluster       : ACClusterId option
//     ClusterMembership   : ACClusterMembership option
//     ActiveNode          : ACNodeId option 
// }

// let init clusters = 
//     let model = {   Clusters            = clusters
//                     ClusterMembership   = None
//                     ActiveNode          = None
//     }
//     model, Cmd.none

// let update (msg: Cabinet.Msg) model : Model * Cmd<ClientMsgs.ClientMsg> = 
//     match msg with
//     | SelectCluster cid             -> 
//         model, cmdServerCabinetCall (ServerProxy.cabinetApi.getClusterMembership) cid (UpdateClusterMembership) "getClusterMembership()" 
//     | UpdateClusterMembership cm    -> { model with ClusterMembership = Some cm }, Cmd.none
// let clusterItem cluster dispatch = 
//     div [ Class "col-md-4 col-lg-3" ]
//         [ div [ Class "ibox" ]
//             [ div [ Class "ibox-content product-box" 
//                     OnClick (fun _ -> cluster.CId |> SelectCluster |> dispatch )]
//                 [ div [ Class "product-imitation" ]
//                     [ i [ Class "fa fa-database img-circle fa-5x" ]
//                         [ ] ]
//                   div [ Class "product-desc" ]
//                     [ span [ Class "product-price connected-bg" ]
//                         [ str "Active" ]
//                       small [ Class "text-muted" ]
//                         [ str "Cluster: 1" ]
//                       p [ Class "product-name" ]
//                         [
//                           str "CL_1" ]
//                       div [ Class "small m-t-xs" ]
//                           [ b [ ]
//                               [ str "ID:" ]
//                             str (string cluster.CId)]
//                       div [ Class "m-t text-righ" ]
//                         [ a [ Class "btn btn-xs btn-primary btn-outline"
//                               OnClick (fun _ -> cluster.CId |> SelectCluster |> dispatch ) ]
//                             [ str "Info "
//                               i [ Class "fa fa-long-arrow-right" ]
//                                 [ ] ] ] ] ] ] ]
let onclickFun cluster dispatch = fun _ -> cluster.CId |> SelectCluster |> dispatch 
let clBody name itemId = 
    div [ ]
        [   
            // small [ Class "text-muted" ]
            //   [ str (name + ": 1") ]
            p [ Class "product-name" ]
                [ str ("Name: " + name) ]
            div [ Class "small m-t-xs" ]
                [ b [ ]
                    [ str "ID: " ]
                  str itemId ]]

let clustersView clusters dispatch = 
    clusters
    |> List.map (fun c -> prodItem  (clBody  "CL_1" (c.CId.ToString()) ) "fa-database" (onclickFun c dispatch))
    |> div []

let clusterMembershipView clusterMembership dispatch =
    let rows = 
        clusterMembership.Nodes
        |> Seq.map (fun node -> 
            tr [] [ td [] [ node.Key |> string |> str ]
                    td [] [ node.Value |> string |> str ] ])
        |> Seq.toList

    let headAndRows =
        tr [] [
            th [] [ str "Node" ]
            th [] [ str "Status" ]
        ] :: rows       
    Fable.Helpers.React.table [] headAndRows 
        
    
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [   yield clustersView model.Clusters (ClustersMsg >> dispatch)
            match model.ClusterMembership with 
            | Some clusterMembership ->
                yield str "Cluster Membership" 
                yield clusterMembershipView clusterMembership (ClustersMsg >> dispatch)
            | None -> ()
        ]

