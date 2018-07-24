module Client.ContactsPage

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.PowerPack
open Fable.Helpers
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish
open Elmish.React

open ReactBootstrap
open Helpers
open FormHelpers

let helper = div [ Class "border-bottom ibox-content m-b-sm" ] [
              p [ Class "p-xs" ] 
                [
                  div [ Class "pull-left m-r-md" ]
                      [ i [ Class "fa fa-envelope text-info mid-icon" ] [ ] ]    
                  h2 [ ] [
                     str "Please, contact us" ]
                  a [ Href "mailto:info@avalanchain.com" ] [ str "info@avalanchain.com" ]
                                     ]]
  
let view = Ibox.emptyRow [ helper ]
