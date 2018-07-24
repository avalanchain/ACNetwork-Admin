module Client.Helpers

open Fable.Helpers.React
open Fable.Helpers.React.Props
// open ClientMsgs
open Fable
open Shared.ViewModels
open Fable.DateFunctions
open System
open Fable.Import.React
open Fable.Core.JsInterop
open Shared
open System.Numerics

module Option = 
    let map2 f a b = match a, b with    | Some a, Some b -> f a b |> Some 
                                        | _ -> None

let symbolLogo = function
                    | ETH  -> "../lib/img/coins/eth_logo.png"
                    | ETC  -> "../lib/img/coins/etc_logo.png"
                    | BTC  -> "../lib/img/coins/btc_logo.png"
                    | LTC  -> "../lib/img/coins/ltc_logo.png"
                    | BCH  -> "../lib/img/coins/bch_logo.png"
                    | BTG  -> "../lib/img/coins/btg_logo.png"
                    | DASH -> "../lib/img/coins/dash_logo.png"                


module React =
    type Component<'P> = Fable.Import.React.Component<'P, obj>

let inline com<'P> (com: React.Component<'P>) (props: 'P ) (children: ReactElement seq): ReactElement =
    createElement(com, props, children)
let inline comF<'P> (com: React.Component<'P>) (propsFunc: 'P -> unit) (children: ReactElement seq): ReactElement =
    createElement(com, jsOptions<'P> propsFunc, children)
let inline comE<'P> (com: React.Component<'P>) (children: ReactElement seq): ReactElement =
    createElement(com, createEmpty<'P>, children)


let iboxSpinner = 
    div [ Class "sk-spinner sk-spinner-double-bounce" ]
        [ div [ Class "sk-double-bounce1" ]
            [ ]
          div [ Class "sk-double-bounce2" ]
            [ ] ]

let divider = 1000000000000000000m
let normalizeBigInt (v : decimal) = (v / divider)