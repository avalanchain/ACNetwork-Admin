module Client.CabinetModel 

open Shared
open LoginCommon
open Elmish.Toastr
open Fable.PowerPack
open System.Transactions
open Web3Types
open System.Transactions
open Shared.ViewModels
open Shared.ViewModels.ChainNetwork
open Client.Helpers

type Model = {
    Auth                : AuthModel
    Customer            : Customer option             
    // Loading     : bool  

    Clusters            : ACCluster list     
    ActiveCluster       : ActiveCluster option
}
and ActiveCluster = {
    ACluster            : ACClusterMembership
    ActiveNode          : ActiveNode option

    NodesPagination     : Paginate
}
and ActiveNode = {
    ANode               : ACNode

    ChainsPagination    : Paginate
}


type TostrStatus = Success | Warning | Err | Info

let toastrCommon (status:TostrStatus) text =   
                    Toastr.message text
                    |> Toastr.withProgressBar
                    |> Toastr.position BottomRight
                    |> Toastr.timeout 2000
                    |> match status with
                        | TostrStatus.Success -> Toastr.success
                        | TostrStatus.Err -> Toastr.error
                        | TostrStatus.Warning -> Toastr.warning
                        | TostrStatus.Info -> Toastr.info
let toastrSuccess text = toastrCommon TostrStatus.Success text
let toastrError text = toastrCommon TostrStatus.Err text
let toastrWarning text = toastrCommon TostrStatus.Warning text
let toastrInfo text = toastrCommon TostrStatus.Info text