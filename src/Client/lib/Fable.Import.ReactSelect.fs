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

module ReactSelect =
    type [<AllowNullLiteral>] [<Pojo>] AutocompleteResult =
        abstract options: Option[] with get, set
        abstract complete: bool with get, set

    and [<AllowNullLiteral>] [<Pojo>] Option =
        abstract label: string option with get, set
        abstract value: U3<string, float, bool> option with get, set
        abstract clearableValue: bool option with get, set
        abstract disabled: bool option with get, set

    and [<AllowNullLiteral>] [<Pojo>] MenuRendererProps =
        abstract focusedOption: Option with get, set
        abstract focusOption: Func<Option, unit> with get, set
        abstract labelKey: string with get, set
        abstract options: Option[] with get, set
        abstract selectValue: Func<Option, unit> with get, set
        abstract valueArray: Option[] with get, set

    and [<AllowNullLiteral>] [<Pojo>] ArrowRendererProps =
        abstract onMouseDown: React.MouseEventHandler with get, set

    and [<AllowNullLiteral>] [<Pojo>] ReactSelectProps =
        abstract addLabelText: string option with get, set
        abstract arrowRenderer: Func<ArrowRendererProps, React.ReactElement> option with get, set
        abstract autoBlur: bool option with get, set
        abstract autofocus: bool option with get, set
        abstract autosize: bool option with get, set
        abstract backspaceRemoves: bool option with get, set
        abstract backspaceToRemoveMessage: string option with get, set
        abstract className: string option with get, set
        abstract clearAllText: string option with get, set
        abstract clearValueText: string option with get, set
        abstract clearable: bool option with get, set
        abstract delimiter: string option with get, set
        abstract disabled: bool option with get, set
        abstract escapeClearsValue: bool option with get, set
        abstract filterOption: Func<Option, string, Option> option with get, set
        abstract filterOptions: Func<Option[], string, Option[], Option[]> option with get, set
        abstract ignoreAccents: bool option with get, set
        abstract ignoreCase: bool option with get, set
        abstract inputProps: obj option with get, set
        abstract inputRenderer: Func<obj, React.ReactElement> option with get, set
        abstract instanceId: string option with get, set
        abstract isLoading: bool option with get, set
        abstract joinValues: bool option with get, set
        abstract labelKey: string option with get, set
        abstract matchPos: string option with get, set
        abstract matchProp: string option with get, set
        abstract menuBuffer: float option with get, set
        abstract menuContainerStyle: obj option with get, set
        abstract menuRenderer: Func<MenuRendererProps, React.ReactElement> option with get, set
        abstract menuStyle: obj option with get, set
        abstract multi: bool option with get, set
        abstract name: string option with get, set
        abstract noResultsText: string option with get, set
        abstract onBlur: React.FocusEventHandler option with get, set
        abstract onBlurResetsInput: bool option with get, set
        abstract onChange: Func<U3<Option, Option[], obj>, unit> option with get, set
        abstract onClose: Func<unit, unit> option with get, set
        abstract onFocus: React.FocusEventHandler option with get, set
        abstract onInputChange: Func<string, unit> option with get, set
        abstract onInputKeyDown: Func<KeyboardEvent, unit> option with get, set
        abstract onMenuScrollToBottom: Func<unit, unit> option with get, set
        abstract onOpen: Func<unit, unit> option with get, set
        abstract onOptionLabelClick: Func<string, Event, unit> option with get, set
        abstract openAfterFocus: bool option with get, set
        abstract openOnFocus: bool option with get, set
        abstract optionClassName: string option with get, set
        abstract optionComponent: React.ComponentClass<obj> option with get, set
        abstract optionRenderer: Func<Option, React.ReactElement> option with get, set
        abstract options: Option[] option with get, set
        abstract placeholder: U2<string, React.ReactElement> option with get, set
        abstract required: bool option with get, set
        abstract resetValue: obj option with get, set
        abstract scrollMenuIntoView: bool option with get, set
        abstract searchable: bool option with get, set
        abstract tabSelectsValue: bool option with get, set
        abstract value: obj option with get, set
        abstract valueKey: string option with get, set
        abstract valueRenderer: Func<Option, React.ReactElement> option with get, set
        abstract style: obj option with get, set
        abstract tabIndex: string option with get, set
        abstract valueComponent: React.ComponentClass<obj> option with get, set
        abstract wrapperStyle: obj option with get, set
        abstract onValueClick: Func<string, Event, unit> option with get, set
        abstract simpleValue: bool option with get, set

    and [<AllowNullLiteral>] [<Pojo>] ReactCreatableSelectProps =
        inherit ReactSelectProps
        abstract isOptionUnique: Func<obj, bool> option with get, set
        abstract isValidNewOption: Func<obj, bool> option with get, set
        abstract newOptionCreator: Func<obj, Option> option with get, set
        abstract promptTextCreator: Func<string, string> option with get, set
        abstract shouldKeyDownEventCreateNewOption: Func<obj, bool> option with get, set

    and [<AllowNullLiteral>] [<Pojo>] ReactAsyncSelectProps =
        inherit ReactSelectProps
        abstract autoload: bool option with get, set
        abstract cache: U2<obj, bool> option with get, set
        abstract ignoreAccents: bool option with get, set
        abstract ignoreCase: bool option with get, set
        abstract isLoading: bool option with get, set
        abstract loadOptions: Func<string, Func<obj, AutocompleteResult, obj>, obj> with get, set
        abstract loadingPlaceholder: string option with get, set
        abstract minimumInput: float option with get, set
        abstract noResultsText: string option with get, set
        abstract placeholder: string option with get, set
        abstract searchPromptText: string option with get, set
        abstract searchingText: string option with get, set


    type [<Import("Creatable","react-select")>] Creatable(props: ReactCreatableSelectProps) =
        inherit React.Component<ReactCreatableSelectProps, obj>(props)


    and [<Import("Async","react-select")>] Async(props: ReactAsyncSelectProps) =
        inherit React.Component<ReactAsyncSelectProps, obj>(props)
 

    and [<Import("AsyncCreatable","react-select")>] AsyncCreatable(props: obj) =
        inherit React.Component<obj, obj>(props)


    type [<Import("default","react-select")>] ReactSelect(props: ReactSelectProps) =
        inherit React.Component<ReactSelectProps, obj>(props)


    /// Helper functions

    let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
        let props = Fable.Core.JsInterop.createEmpty<'P>
        propsUpdate props
        com<'T, 'P, 'S> (props) 

    let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)

    let [<PassGenerics>] inline private created<[<Pojo>]'T>(updater: 'T -> unit) =
        let o = Fable.Core.JsInterop.createEmpty<'T>
        updater o
        o

    let inline ReactSelect propsUpdate = rsCom<ReactSelect, _, obj> propsUpdate

    let inline Option updater = created<Option> updater

    