namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import
open Fable.Import.ReactDom
open Fable.Import.Browser
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Import.ReactHelpers

module ReactJsonSchemaForm =
    type [<AllowNullLiteral>] [<Pojo>] FormProps =
        abstract schema: obj with get, set
        abstract uiSchema: obj option with get, set
        abstract formData: obj option with get, set
        abstract widgets: obj option with get, set
        abstract fields: obj option with get, set
        abstract noValidate: bool option with get, set
        abstract noHtml5Validate: bool option with get, set
        abstract showErrorList: bool option with get, set
        abstract validate: Func<obj, obj, obj> option with get, set
        abstract onChange: Func<IChangeEvent, obj> option with get, set
        abstract onError: Func<obj, obj> option with get, set
        abstract onSubmit: Func<obj, obj> option with get, set
        abstract liveValidate: bool option with get, set
        abstract safeRenderCompletion: bool option with get, set

    and [<AllowNullLiteral>] [<Pojo>] IChangeEvent =
        abstract edit: bool with get, set
        abstract formData: obj with get, set
        abstract errors: ResizeArray<obj> with get, set
        abstract errorSchema: obj with get, set
        abstract idSchema: obj with get, set
        abstract status: string with get, set

    and [<Import("default","react-jsonschema-form")>] Form(props: FormProps) =
        inherit React.Component<FormProps, obj>(props)


    /// Helper functions

    let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
        let props = Fable.Core.JsInterop.createEmpty<'P>
        propsUpdate props
        com<'T, 'P, 'S> (props) 

    let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)


    let inline Form propsUpdate = rsCom<Form, _, obj> propsUpdate