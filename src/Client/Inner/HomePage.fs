module Client.HomePage

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


let [<PassGenerics>] view (): React.ReactElement =
    div [][ 
            img [   ClassName "img-fluid"
                    Src "img/ind_er_glb_ho_2002_lo.png" ] 
            hr []
            a [ Href "http://www.avalanchain.com" ] [ str "Avalanchain" ] 

    ]