module Client.Menu

open System

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser

open Fable.Core
open Fable.Import
open Fable.Import.Browser
open Fable.PowerPack
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Shared.Auth
open Shared.Utils

open ClientMsgs
open Client.Page

open LoginPage
open LoginCommon

module O = FSharp.Core.Option


let init() = Utils.load<AuthModel> "user", Cmd.none


[<PassGenerics>]
let viewLink page description icon bage =
    a [ Href (toHash page) 
        OnClick goToUrl] [
            yield i [ ClassName icon ] [ ]
            yield  span [ Class "nav-label" ]
                                [ str description ]  
            if bage > 0u then yield span [ ClassName "pull-right label label-primary" ] [ ofString (bage.ToString()) ] 
    ]

[<PassGenerics>]
let navViewLink page description icon isActive =
    li [ ClassName (if isActive then " active" else "") ] 
       [ viewLink page description icon 0u ]

let buttonLink page description icon onClick =
    a [ ClassName "nav-link"
        OnClick (fun _ -> onClick())
        OnTouchStart (fun _ -> onClick()) ] [
        i [ ClassName icon ] [ ]
        ofString (" " + description)
    ]
let navButtonLink page description icon onClick =
    li [ ClassName "nav-item" ] [ buttonLink page description icon onClick ]

[<PassGenerics>]
let cabinetNavViewLink page description icon bage isActive =
    li [ ClassName ("nav-item" + (if isActive then " active" else "")) ] [ viewLink page description icon bage  ]

let handleClick (e: React.MouseEvent) =
    Browser.console.log (sprintf "Menu  Mouse evt: '%A'" e)
    e.preventDefault()
    e.target?parentElement?classList?toggle("open") |> ignore


// let testlink = 

let view (menuPage: Cabinet.MenuPage) (dispatch: UIMsg -> unit) =
    let icon  (page: Cabinet.MenuPage) = 
                match page with 
                | Cabinet.MenuPage.Clusters         -> "fa fa-database"    
                | Cabinet.MenuPage.Nodes            -> "fa fa-th"  
                | Cabinet.MenuPage.Chains           -> "fa fa-link"  
                | Cabinet.MenuPage.Accounts         -> "fa fa-users"
                // | Cabinet.MenuPage.Contacts         -> "fa fa-phone"            
                // | Dashboard         -> "fa fa-th-large"         

    let cabinet = 
        [   for page in getUnionCases<Cabinet.MenuPage> ->
                let pageName = page.Name |> splitOnCapital 
                let page = page |> getUnionCase<Cabinet.MenuPage>
                navViewLink (MenuPage.Cabinet page) pageName (icon page) (page = menuPage)
        ]

    // let divider = li [ ClassName "divider" ] [ ]

    let staticPart = 
        li [ Class "nav-header" ]
            [   div [ Class "dropdown profile-element" ]
                                        [ a [ DataToggle "dropdown"
                                              Class "dropdown-toggle"
                                              Href "#" ]
                                            [ span [ Class "clear" ]
                                                   [ img [ Class "logolong"
                                                           Src "../lib/img/token_cab_2.png" ] ] ]
                                           ]
                div [ Class "logo-element" ]
                    [ ofString "TC" ] 
            ]
                    

    nav [ Class "navbar-default navbar-static-side"
          Role "navigation" ]
            [ div [ Class "sidebar-collapse" ]
                [ ul [ Class "nav metismenu"
                       Id "side-menu" ]
                    
                        (staticPart :: cabinet)
                            ] ] 

let mainView page (model: CabinetModel.Model) (dispatch: AppMsg -> unit) cabinetPageView = 
    let customer = model.Customer
    div [ Id "wrapper" ]
        [   view page (AppMsg.UIMsg >> dispatch)
            div [ Id "page-wrapper"
                  Class "gray-bg" ] [
                  TopNavbar.navBar customer (AppMsg.UIMsg >> dispatch)
                  div [ Class "wrapper wrapper-content animated fadeInRight"]
                      [ cabinetPageView page model (CabinetMsg >> dispatch) ]

                  Footer.footer
            ]
        ]
