namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.React
open Fable.Helpers.React
open Fable.Import.ReactHelpers

module BootstrapTable =

    type [<AllowNullLiteral>] [<Pojo>] BootstrapTableProps =
        //inherit Props<BootstrapTable>
        abstract data: ResizeArray<obj> with get, set
        abstract remote: bool option with get, set
        abstract keyField: string option with get, set
        abstract height: string option with get, set
        abstract maxHeight: string option with get, set
        abstract striped: bool option with get, set
        abstract hover: bool option with get, set
        abstract condensed: bool option with get, set
        abstract bordered: bool option with get, set
        abstract pagination: bool option with get, set
        abstract trClassName: U2<string, Func<obj, float, string>> option with get, set
        abstract insertRow: bool option with get, set
        abstract deleteRow: bool option with get, set
        abstract columnFilter: bool option with get, set
        abstract search: bool option with get, set
        abstract searchPlaceholder: string option with get, set
        abstract multiColumnSearch: bool option with get, set
        abstract exportCSV: bool option with get, set
        abstract csvFileName: string option with get, set
        abstract selectRow: SelectRow option with get, set
        abstract cellEdit: CellEdit option with get, set
        abstract options: Options option with get, set
        abstract fetchInfo: FetchInfo option with get, set
        abstract printable: bool option with get, set
        abstract tableStyle: obj option with get, set
        abstract containerStyle: obj option with get, set
        abstract headerStyle: obj option with get, set
        abstract bodyStyle: obj option with get, set
        abstract ignoreSinglePage: bool option with get, set
        abstract containerClass: string option with get, set
        abstract tableContainerClass: string option with get, set
        abstract headerContainerClass: string option with get, set
        abstract bodyContainerClass: string option with get, set
        abstract expandableRow: Func<obj, bool> option with get, set
        abstract expandComponent: Func<obj, obj> option with get, set

    and [<RequireQualifiedAccess>] [<StringEnum>] SelectRowMode = | None | Radio | Checkbox

    and [<AllowNullLiteral>] SelectRow =
        abstract mode: SelectRowMode with get, set
        abstract clickToSelect: bool option with get, set
        abstract clickToSelectAndEditCell: bool option with get, set
        abstract bgColor: string option with get, set
        abstract className: string option with get, set
        abstract selected: ResizeArray<string> option with get, set
        abstract hideSelectColumn: bool option with get, set
        abstract showOnlySelected: bool option with get, set
        abstract onSelect: Func<obj, Boolean, obj, bool> option with get, set
        abstract onSelectAll: Func<bool, obj, bool> option with get, set
        abstract unselectable: ResizeArray<float> option with get, set

    and [<RequireQualifiedAccess>] [<StringEnum>] CellEditClickMode = | None | Click | Dbclick 

    and [<AllowNullLiteral>] CellEdit =
        abstract mode: CellEditClickMode with get, set
        abstract blurToSave: bool option with get, set
        abstract beforeSaveCell: Func<obj, string, obj, bool> option with get, set
        abstract afterSaveCell: Func<obj, string, obj, unit> option with get, set

    and [<RequireQualifiedAccess>] [<StringEnum>] SortOrder = Asc | Desc

    and [<AllowNullLiteral>] Options =
        abstract sortName: string option with get, set
        abstract sortOrder: SortOrder option with get, set
        abstract defaultSortName: string option with get, set
        abstract defaultSortOrder: SortOrder option with get, set
        abstract sortIndicator: bool option with get, set
        abstract noDataText: U2<string, ReactElement> option with get, set
        abstract searchDelayTime: float option with get, set
        abstract exportCSVText: string option with get, set
        abstract ignoreEditable: bool option with get, set
        abstract clearSearch: bool option with get, set
        abstract afterTableComplete: Function option with get, set
        abstract afterDeleteRow: Func<ResizeArray<string>, unit> option with get, set
        abstract afterInsertRow: Func<obj, unit> option with get, set
        abstract prePage: string option with get, set
        abstract nextPage: string option with get, set
        abstract firstPage: string option with get, set
        abstract lastPage: string option with get, set
        abstract page: float option with get, set
        abstract sizePerPageList: ResizeArray<float> option with get, set
        abstract sizePerPage: float option with get, set
        abstract pageStartIndex: string option with get, set
        abstract paginationSize: float option with get, set
        abstract onPageChange: Func<float, float, unit> option with get, set
        abstract onSizePerPageList: Func<float, unit> option with get, set
        abstract onSortChange: Func<string, SortOrder, unit> option with get, set
        abstract afterSearch: Func<string, obj, unit> option with get, set
        abstract afterColumnFilter: Func<ResizeArray<obj>, obj, unit> option with get, set
        abstract onRowClick: Func<obj, unit> option with get, set
        abstract onRowDoubleClick: Func<obj, unit> option with get, set
        abstract expandRowBgColor: string option with get, set
        abstract onMouseEnter: Function option with get, set
        abstract onMouseLeave: Function option with get, set
        abstract onRowMouseOver: Function option with get, set
        abstract onRowMouseOut: Function option with get, set
        abstract handleConfirmDeleteRow: Func<Function, ResizeArray<obj>, unit> option with get, set
        abstract paginationShowsTotal: U2<bool, ReactElement> option with get, set
        abstract onSearchChange: Function option with get, set
        abstract onAddRow: Function option with get, set
        abstract onExportToCSV: Function option with get, set
        abstract insertText: string option with get, set
        abstract deleteText: string option with get, set
        abstract saveText: string option with get, set
        abstract closeText: string option with get, set

        abstract handleAddRow: row: obj -> unit
        abstract handleAddRowAtBegin: row: obj -> unit
        abstract handleDropRow: rowKeys: ResizeArray<obj> -> unit
        abstract handleFilterData: filter: obj -> unit
        abstract handleSearch: search: string -> unit
        abstract handleSort: order: SortOrder * field: string -> unit
        abstract getPageByRowKey: rowKey: string -> obj
        abstract handleExportCSV: unit -> unit
        abstract cleanSelected: unit -> unit
        abstract hideSizePerPage: bool option with get, set


    and [<AllowNullLiteral>] FetchInfo =
        abstract dataTotalSize: float option with get, set

    and [<Import("BootstrapTable","react-bootstrap-table")>] BootstrapTable(props) =
        inherit React.Component<BootstrapTableProps, obj>(props)

    and [<RequireQualifiedAccess>] [<StringEnum>] DataAlignType = | Left | Center | Right | Start

    and [<AllowNullLiteral>] [<Pojo>] TableHeaderColumnProps =
        // inherit Props<TableHeaderColumn>
        abstract dataField: string option with get, set
        abstract isKey: bool option with get, set
        abstract width: string option with get, set
        abstract dataAlign: DataAlignType option with get, set
        abstract headerAlign: DataAlignType option with get, set
        abstract dataSort: bool option with get, set
        abstract defaultSearch: string option with get, set
        abstract caretRender: Function option with get, set
        abstract customEditor: obj option with get, set
        abstract dataFormat: Func<obj, obj, obj, U2<string, ReactElement>> option with get, set
        abstract filterFormatted: bool option with get, set
        abstract hidden: bool option with get, set
        abstract searchable: bool option with get, set
        abstract sortFunc: Func<obj, obj, SortOrder, obj, obj, float> option with get, set
        abstract sortFuncExtraData: obj option with get, set
        abstract className: U2<string, Func<obj, obj, float, float, string>> option with get, set
        abstract columnClassName: U2<string, Func<obj, obj, float, float, string>> option with get, set
        abstract editable: U2<bool, Editable> option with get, set
        abstract autoValue: bool option with get, set
        abstract filter: Filter option with get, set
        abstract onSort: Function option with get, set
        abstract csvHeader: string option with get, set
        abstract csvFormat: Function option with get, set
        abstract columnTitle: bool option with get, set
        abstract sort: SortOrder option with get, set
        abstract formatExtraData: obj option with get, set
        abstract row: float option with get, set
        abstract rowSpan: float option with get, set
        abstract colSpan: float option with get, set

    and [<AllowNullLiteral>] Editable =
        abstract ``type``: string option with get, set
        abstract validator: Func<obj, bool> option with get, set
        abstract options: obj option with get, set
        abstract cols: float option with get, set
        abstract rows: float option with get, set

    and SetFilterCallback =
        Func<obj, bool>

    and [<AllowNullLiteral>] ApplyFilterParameter =
        abstract callback: SetFilterCallback with get, set

    and [<RequireQualifiedAccess>] [<StringEnum>] FilterType =
        | TextFilter | RegexFilter | SelectFilter | NumberFilter | DateFilter | CustomFilter 

    and [<AllowNullLiteral>] Filter =
        abstract ``type``: FilterType option with get, set
        abstract defaultValue: obj option with get, set
        abstract delay: float option with get, set
        abstract placeholder: U2<string, Regex> option with get, set
        abstract numberComparators: ResizeArray<string> option with get, set
        abstract options: obj option with get, set
        abstract condition: string option with get, set
        abstract getElement: Func<Func<ApplyFilterParameter, unit>, obj, ReactElement> option with get, set
        abstract customFilterParameters: obj option with get, set

    and [<Import("TableHeaderColumn","react-bootstrap-table")>] TableHeaderColumn(props) =
        inherit React.Component<TableHeaderColumnProps, obj>(props)

    /// Helper functions

    let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
        let props = Fable.Core.JsInterop.createEmpty<'P>
        propsUpdate props
        com<'T, 'P, 'S> (props) 

    let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)


    let inline BootstrapTable propsUpdate = rsCom<BootstrapTable, _, obj> propsUpdate
    let inline TableHeaderColumn propsUpdate = rsCom<TableHeaderColumn, _, obj> propsUpdate 
    let inline TableOptions propsUpdate = 
        let props = Fable.Core.JsInterop.createEmpty<Options>
        propsUpdate props 
        props
