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
open Client.Page
open Client.Cabinet
open Client.Page
    
let onclickFun cluster page dispatch = fun _ -> cluster.CId |> SelectCluster |> dispatch 
                                                goToPage (toHash page)  
let page = Cabinet.Cluster |> MenuPage.Cabinet
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
    |> List.map (fun c -> prodItem  (clBody  "CL_1" (c.CId.ToString()) ) "fa-database" (onclickFun c page dispatch))
    |> div []
        
    
let view (model: Model) (dispatch: Cabinet.Msg -> unit) =
    div [  ]
        [   yield clustersView model.Clusters (ClustersMsg >> dispatch)
            // match model.ClusterMembership with 
            // | Some clusterMembership ->
            //     yield str "Cluster Membership" 
            //     yield clusterMembershipView clusterMembership (ClustersMsg >> dispatch)
            // | None -> ()
        ]

