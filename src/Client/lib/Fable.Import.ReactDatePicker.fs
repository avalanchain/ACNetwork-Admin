namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import
open Fable.Import.ReactDom
open Fable.Import.Browser
open Fable.Import.JS
open Fable.Helpers
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.ReactHelpers

open Fable.Import.Moment

module ReactDatePicker =

    type [<AllowNullLiteral>] ReactDatePickerProps =
        abstract autoComplete: string option with get, set
        abstract autoFocus: bool option with get, set
        abstract calendarClassName: string option with get, set
        abstract className: string option with get, set
        abstract customInput: React.ReactNode option with get, set
        abstract dateFormat: U2<string, ResizeArray<string>> option with get, set
        abstract dateFormatCalendar: string option with get, set
        abstract disabled: bool option with get, set
        abstract disabledKeyboardNavigation: bool option with get, set
        abstract dropdownMode: string option with get, set
        abstract endDate: Moment option with get, set
        abstract excludeDates: ResizeArray<obj> option with get, set
        abstract fixedHeight: bool option with get, set
        abstract forceShowMonthNavigation: bool option with get, set
        abstract highlightDates: ResizeArray<obj> option with get, set
        abstract id: string option with get, set
        abstract includeDates: ResizeArray<obj> option with get, set
        abstract ``inline``: bool option with get, set
        abstract isClearable: bool option with get, set
        abstract locale: string option with get, set
        abstract maxDate: Moment option with get, set
        abstract minDate: Moment option with get, set
        abstract monthsShown: float option with get, set
        abstract name: string option with get, set
        abstract openToDate: Moment option with get, set
        abstract peekNextMonth: bool option with get, set
        abstract placeholderText: string option with get, set
        abstract popoverAttachment: string option with get, set
        abstract popoverTargetAttachment: string option with get, set
        abstract popoverTargetOffset: string option with get, set
        abstract readOnly: bool option with get, set
        abstract renderCalendarTo: obj option with get, set
        abstract required: bool option with get, set
        abstract scrollableYearDropdown: bool option with get, set
        abstract selected: U2<Moment, obj> option with get, set
        abstract ``null``: obj with get, set
        abstract selectsEnd: bool option with get, set
        abstract selectsStart: bool option with get, set
        abstract showMonthDropdown: bool option with get, set
        abstract showWeekNumbers: bool option with get, set
        abstract showYearDropdown: bool option with get, set
        abstract startDate: Moment option with get, set
        abstract tabIndex: float option with get, set
        abstract tetherConstraints: ResizeArray<obj> option with get, set
        abstract title: string option with get, set
        abstract todayButton: string option with get, set
        abstract utcOffset: float option with get, set
        abstract value: string option with get, set
        abstract withPortal: bool option with get, set
        abstract filterDate: unit -> obj
        abstract onBlur: ``event``: React.FocusEvent -> unit
        abstract onChange: date: U2<Moment, obj> * ``event``: U2<React.SyntheticEvent, obj> -> unit
        abstract onChangeRaw: ``event``: React.FocusEvent -> unit
        abstract onClickOutside: ``event``: React.MouseEvent -> unit
        abstract onFocus: ``event``: React.FocusEvent -> unit
        abstract onMonthChange: date: Moment -> unit


    type [<Import("default","react-datepicker")>] ReactDatePicker(props: ReactDatePickerProps) =
        inherit React.Component<ReactDatePickerProps, obj>(props)


    /// Helper functions

    let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
        let props = Fable.Core.JsInterop.createEmpty<'P>
        propsUpdate props
        com<'T, 'P, 'S> (props) 

    let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)

    let inline ReactDatePicker propsUpdate = rsCom<ReactDatePicker, _, obj> propsUpdate []


    