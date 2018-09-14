module Fable.Import.ReactHelpers

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Helpers.React
let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
    let props = Fable.Core.JsInterop.createEmpty<'P>
    propsUpdate props
    ofType<'T, 'P, 'S> (props) 

let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)
