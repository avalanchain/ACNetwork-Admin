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


let clusters model dispatch = 
    model.Clusters
    |> List.map (fun c -> p [] [ a [Href ("#" + c.CId.ToString())
                                    OnClick (fun _ -> c.CId |> SelectCluster |> dispatch ) ] [ c.CId |> string |> str ] ])
    |> div []

let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [   str "Clusters"
            clusters model (ClustersMsg >> dispatch)
            str "Cluster Membership" 
        ]

