module Client.PageRouter

open FSharp.Reflection

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.PowerPack
open Fable.Helpers
open Fable.Helpers.React
open Elmish
open Elmish.React
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser

open Client.Page
open ClientMsgs
open ClientModels
open CabinetModel
open Shared.Utils
open Client.Page

let urlUpdate (result: MenuPage option) (model: AppModel): AppModel * Cmd<AppMsg> =
    match result with
    | None ->
        Browser.console.error("Error parsing url:")
        model, Navigation.modifyUrl (toHash model.Page)

    | Some (MenuPage.LoginFlow p as page) ->
        match model.PageModel with
        | LoginFlowModel m ->
            let model', cmd' = LoginFlowPage.switchTo p m
            { model with Page = page; PageModel = LoginFlowModel model' }, Cmd.map LoginFlowMsg cmd'
        | NoPageModel
        | CabinetModel _ -> model, Navigation.modifyUrl (toHash model.Page)

    | Some (MenuPage.Cabinet p as page) ->
        match model.PageModel with
        | CabinetModel _ -> { model with Page = page }, Cmd.none
        | NoPageModel
        | LoginFlowModel _ -> model, Cmd.ofMsg (Logout |> UIMsg)

    | Some (MenuPage.Home as page) ->
        { model with Page = page }, Cmd.none
