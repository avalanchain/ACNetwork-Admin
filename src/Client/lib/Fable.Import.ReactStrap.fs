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


module ReactStrap =

    type [<AllowNullLiteral>] [<Pojo>] AlertProps =
        abstract className: string option with get, set
        abstract color: string option with get, set
        abstract isOpen: bool option with get, set
        abstract toggle: Function option with get, set
        abstract tag: U2<Function, string> option with get, set
        abstract transitionAppearTimeout: float option with get, set
        abstract transitionEnterTimeout: float option with get, set
        abstract transitionLeaveTimeout: float option with get, set

    and [<Import("Alert","reactstrap")>] Alert(props: AlertProps) =
        inherit React.Component<AlertProps, obj>(props)


    and [<Import("UncontrolledAlert","reactstrap")>] UncontrolledAlert(props: AlertProps) =
        inherit React.Component<AlertProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] BadgeProps =
        abstract pill: obj option with get, set
        abstract color: string option with get, set

    and [<Import("Badge","reactstrap")>] Badge(props: BadgeProps) =
        inherit React.Component<BadgeProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] BaseCardProps =
        abstract tag: U2<Function, string> option with get, set
        abstract className: string option with get, set

    and [<AllowNullLiteral>] [<Pojo>] CardProps =
        inherit BaseCardProps
        abstract inverse: bool option with get, set
        abstract color: string option with get, set
        abstract block: bool option with get, set

    and [<AllowNullLiteral>] [<Pojo>] ButtonProps =
        abstract tag: U2<Function, string> option with get, set
        abstract color: string option with get, set
        abstract active: bool option with get, set
        abstract block: bool option with get, set
        abstract disabled: bool option with get, set
        abstract outline: bool option with get, set
        abstract className: string option with get, set

    and [<Import("Button","reactstrap")>] Button(props: ButtonProps) =
        inherit React.Component<ButtonProps, obj>(props)

    and [<Import("Card","reactstrap")>] Card(props: CardProps) =
        inherit React.Component<CardProps, obj>(props)


    and [<Import("CardBlock","reactstrap")>] CardBlock(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardColumns","reactstrap")>] CardColumns(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardDeck","reactstrap")>] CardDeck(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardFooter","reactstrap")>] CardFooter(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardGroup","reactstrap")>] CardGroup(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardHeader","reactstrap")>] CardHeader(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] CardImgProps =
        inherit BaseCardProps
        abstract top: bool option with get, set
        abstract bottom: bool option with get, set

    and [<Import("CardImg","reactstrap")>] CardImg(props: CardImgProps) =
        inherit React.Component<CardImgProps, obj>(props)


    and [<Import("CardImgOverlay","reactstrap")>] CardImgOverlay(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardLink","reactstrap")>] CardLink(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardSubtitle","reactstrap")>] CardSubtitle(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardText","reactstrap")>] CardText(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and [<Import("CardTitle","reactstrap")>] CardTitle(props: BaseCardProps) =
        inherit React.Component<BaseCardProps, obj>(props)


    and ColumnTypes =
        U4<string, float, bool, obj>

    and [<AllowNullLiteral>] [<Pojo>] ColProps =
        abstract xs: ColumnTypes option with get, set
        abstract sm: ColumnTypes option with get, set
        abstract md: ColumnTypes option with get, set
        abstract lg: ColumnTypes option with get, set
        abstract xl: ColumnTypes option with get, set
        abstract widths: ResizeArray<obj> option with get, set

    and [<Import("Col","reactstrap")>] Col(props: ColProps) =
        inherit React.Component<ColProps, obj>(props)


    and [<Pojo>] CollapseProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract isOpen: bool with get, set
        abstract navbar: bool option with get, set
        abstract delay: float option with get, set
        abstract onOpened: Function option with get, set
        abstract onClosed: Function option with get, set

    and [<Import("Collapse","reactstrap")>] Collapse(props: CollapseProps) =
        inherit React.Component<CollapseProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] ContainerProps =
        abstract fluid: obj option with get, set

    and [<Import("Container","reactstrap")>] Container(props: ContainerProps) =
        inherit React.Component<ContainerProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] DropdownProps =
        abstract disabled: bool option with get, set
        abstract dropup: bool option with get, set
        abstract group: bool option with get, set
        abstract isOpen: bool with get, set
        abstract tag: string option with get, set
        abstract tether: obj option with get, set
        abstract toggle: Function option with get, set
        abstract caret: obj option with get, set

    and [<Import("Dropdown","reactstrap")>] Dropdown(props: DropdownProps) =
        inherit React.Component<DropdownProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] UncontrolledDropdownProps =
        abstract disabled: bool option with get, set
        abstract dropup: bool option with get, set
        abstract group: bool option with get, set
        abstract isOpen: bool option with get, set
        abstract tag: string option with get, set
        abstract tether: obj option with get, set
        abstract toggle: Function option with get, set
        abstract caret: obj option with get, set

    and [<Import("UncontrolledDropdown","reactstrap")>] UncontrolledDropdown(props: UncontrolledDropdownProps) =
        inherit React.Component<UncontrolledDropdownProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] DropdownToggleProps =
        abstract caret: bool option with get, set
        abstract color: string option with get, set
        abstract className: string option with get, set
        abstract disabled: bool option with get, set
        abstract onClick: Function option with get, set
        abstract ``data-toggle``: string option with get, set
        abstract ``aria-haspopup``: bool option with get, set
        abstract nav: bool option with get, set
        abstract tag: obj option with get, set
        abstract size: string option with get, set

    and [<Import("DropdownToggle","reactstrap")>] DropdownToggle(props: DropdownToggleProps) =
        inherit React.Component<DropdownToggleProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] DropdownMenuProps =
        abstract right: obj option with get, set

    and [<Import("DropdownMenu","reactstrap")>] DropdownMenu(props: DropdownMenuProps) =
        inherit React.Component<DropdownMenuProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] DropdownItemProps =
        abstract header: obj option with get, set
        abstract disabled: obj option with get, set
        abstract divider: obj option with get, set
        abstract onClick: Function option with get, set

    and [<Import("DropdownItem","reactstrap")>] DropdownItem(props: DropdownItemProps) =
        inherit React.Component<DropdownItemProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] FormProps =
        abstract ``inline``: obj option with get, set

    and [<Import("Form","reactstrap")>] Form(props: FormProps) =
        inherit React.Component<FormProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] FormGroupProps =
        abstract row: obj option with get, set
        abstract check: obj option with get, set
        abstract disabled: obj option with get, set
        abstract color: string option with get, set
        abstract tag: U2<Function, string> option with get, set

    and [<Import("FormGroup","reactstrap")>] FormGroup(props: FormGroupProps) =
        inherit React.Component<FormGroupProps, obj>(props)

    type [<AllowNullLiteral>] [<Pojo>] FormTextProps =
        abstract ``inline``: bool option with get, set
        abstract tag: string option with get, set
        abstract color: string option with get, set
        abstract className: string option with get, set

    and [<Import("FormText","reactstrap")>] FormText(props: FormTextProps) =
        inherit React.Component<FormTextProps, obj>(props)
        

    type [<AllowNullLiteral>] [<Pojo>] FormFeedbackProps =
        abstract tag: string option with get, set
        abstract className: string option with get, set

    and [<Import("FormFeedback","reactstrap")>] FormFeedback(props: FormFeedbackProps) =
        inherit React.Component<FormFeedbackProps, obj>(props)

    and [<AllowNullLiteral>] [<Pojo>] LabelProps =
        abstract ``for``: string option with get, set

    and [<Import("Label","reactstrap")>] Label(props: LabelProps) =
        inherit React.Component<LabelProps, obj>(props)


    and [<Pojo>] InputProps =
        inherit React.HTMLProps<HTMLInputElement>
        abstract ``type``: string option with get, set
        abstract name: string option with get, set
        abstract id: string option with get, set
        abstract multiple: obj option with get, set
        abstract placeholder: string option with get, set
        abstract state: string option with get, set

    and [<Import("Input","reactstrap")>] Input(props: InputProps) =
        inherit React.Component<InputProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] InputGroupProps =
        abstract tag: U2<Function, string> option with get, set
        abstract size: string option with get, set
        abstract className: string option with get, set
        abstract style: obj option with get, set

    and [<Import("InputGroup","reactstrap")>] InputGroup(props: InputGroupProps) =
        inherit React.Component<InputGroupProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] InputGroupAddOnProps =
        abstract tag: U2<Function, string> option with get, set
        abstract className: string option with get, set

    and [<Import("InputGroupAddon","reactstrap")>] InputGroupAddon(props: InputGroupAddOnProps) =
        inherit React.Component<InputGroupAddOnProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] InputGroupButtonProps =
        abstract tag: U2<Function, string> option with get, set
        abstract groupClassName: string option with get, set
        abstract groupAttributes: obj option with get, set
        abstract className: string option with get, set

    and [<Import("InputGroupButton","reactstrap")>] InputGroupButton(props: InputGroupButtonProps) =
        inherit React.Component<InputGroupButtonProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] JumbotronProps =
        abstract tag: U2<Function, string> option with get, set
        abstract fluid: bool option with get, set
        abstract className: string option with get, set

    and [<Import("Jumbotron","reactstrap")>] Jumbotron(props: JumbotronProps) =
        inherit React.Component<JumbotronProps, obj>(props)


    and [<Import("ListGroup","reactstrap")>] ListGroup() =
        inherit React.Component<unit, obj>(())


    and [<AllowNullLiteral>] [<Pojo>] ListGroupItemProps =
        abstract color: string option with get, set
        abstract disabled: obj option with get, set
        abstract active: obj option with get, set
        abstract action: obj option with get, set
        abstract tag: U2<Function, string> option with get, set
        abstract ``to``: string option with get, set
        abstract href: string option with get, set

    and [<Import("ListGroupItem","reactstrap")>] ListGroupItem(props: ListGroupItemProps) =
        inherit React.Component<ListGroupItemProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] MediaProps =
        abstract body: bool option with get, set
        abstract bottom: bool option with get, set
        abstract children: bool option with get, set
        abstract className: string option with get, set
        abstract heading: bool option with get, set
        abstract left: bool option with get, set
        abstract list: bool option with get, set
        abstract middle: bool option with get, set
        abstract ``object``: bool option with get, set
        abstract right: bool option with get, set
        abstract tag: U2<Function, string> option with get, set
        abstract top: bool option with get, set
        abstract href: string option with get, set
        abstract ``to``: string option with get, set
        abstract placeholder: obj option with get, set
        abstract image: obj option with get, set

    and [<Import("Media","reactstrap")>] Media(props: MediaProps) =
        inherit React.Component<MediaProps, obj>(props)


    and [<Pojo>] ModalProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract isOpen: bool with get, set
        abstract toggle: (unit -> unit) with get, set
        abstract size: string option with get, set
        abstract backdrop: U2<bool, obj> option with get, set
        abstract keyboard: bool option with get, set
        abstract zIndex: U2<float, string> option with get, set

    and [<Import("Modal","reactstrap")>] Modal(props: ModalProps) =
        inherit React.Component<ModalProps, obj>(props)

    and [<Pojo>] ModalHeaderProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract toggle: (unit -> unit) with get, set

    and [<Import("ModalHeader","reactstrap")>] ModalHeader(props: ModalHeaderProps) =
        inherit React.Component<ModalHeaderProps, obj>(props)


    and [<Import("ModalFooter","reactstrap")>] ModalFooter(props: React.HTMLProps<HTMLDivElement>) =
        inherit React.Component<React.HTMLProps<HTMLDivElement>, obj>(props)


    and [<Import("ModalBody","reactstrap")>] ModalBody(props: React.HTMLProps<HTMLDivElement>) =
        inherit React.Component<React.HTMLProps<HTMLDivElement>, obj>(props)


    and [<Pojo>] NavbarProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract light: bool option with get, set
        abstract inverse: bool option with get, set
        abstract full: bool option with get, set
        abstract ``fixed``: string option with get, set
        abstract color: string option with get, set
        abstract role: string option with get, set
        abstract toggleable: U2<bool, string> option with get, set
        abstract tag: U2<Function, string> option with get, set

    and [<Import("Navbar","reactstrap")>] Navbar(props: NavbarProps) =
        inherit React.Component<NavbarProps, obj>(props)


    and [<Pojo>] NavbarTogglerProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract ``type``: string option with get, set
        abstract right: bool option with get, set
        abstract left: bool option with get, set
        abstract tag: U2<Function, string> option with get, set

    and [<Import("NavbarToggler","reactstrap")>] NavbarToggler(props: NavbarTogglerProps) =
        inherit React.Component<NavbarTogglerProps, obj>(props)


    and [<Pojo>] NavbarBrandProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract tag: U2<Function, string> option with get, set
        abstract ``to``: string option with get, set

    and [<Import("NavbarBrand","reactstrap")>] NavbarBrand(props: NavbarBrandProps) =
        inherit React.Component<NavbarBrandProps, obj>(props)


    and [<Pojo>] NavProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract ``inline``: bool option with get, set
        abstract disabled: bool option with get, set
        abstract tabs: bool option with get, set
        abstract pills: bool option with get, set
        abstract stacked: bool option with get, set
        abstract navbar: bool option with get, set
        abstract tag: U2<Function, string> option with get, set

    and [<Import("Nav","reactstrap")>] Nav(props: NavProps) =
        inherit React.Component<NavProps, obj>(props)


    and [<Pojo>] NavItemProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract tag: U2<Function, string> option with get, set
        abstract ``to``: string option with get, set

    and [<Import("NavItem","reactstrap")>] NavItem(props: NavItemProps) =
        inherit React.Component<NavItemProps, obj>(props)


    and [<Pojo>] NavLinkProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract disabled: bool option with get, set
        abstract active: bool option with get, set
        abstract tag: U2<Function, string> option with get, set
        abstract ``to``: string option with get, set

    and [<Import("NavLink","reactstrap")>] NavLink(props: NavLinkProps) =
        inherit React.Component<NavLinkProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] PaginationProps =
        abstract size: string option with get, set

    and [<Import("Pagination","reactstrap")>] Pagination(props: PaginationProps) =
        inherit React.Component<PaginationProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] PaginationItemProps =
        abstract active: obj option with get, set
        abstract disabled: obj option with get, set

    and [<Import("PaginationItem","reactstrap")>] PaginationItem(props: PaginationItemProps) =
        inherit React.Component<PaginationItemProps, obj>(props)

    and [<AllowNullLiteral>] [<Pojo>] PaginationLinkProps =
        abstract previous: obj option with get, set
        abstract next: obj option with get, set
        abstract href: string option with get, set
        abstract tag: U2<Function, string> option with get, set
        abstract ``to``: string option with get, set

    and [<Import("PaginationLink","reactstrap")>] PaginationLink(props: PaginationLinkProps) =
        inherit React.Component<PaginationLinkProps, obj>(props)

    and [<RequireQualifiedAccess>][<StringEnum>] PlacementEnum =
        | Top 
        | Bottom 
        | Left 
        | Right 
        | ``Top left`` 
        | ``Top center`` 
        | ``Top right`` 
        | ``Right top`` 
        | ``Right middle`` 
        | ``Right bottom`` 
        | ``Bottom right`` 
        | ``Bottom center`` 
        | ``Bottom left`` 
        | ``Left top`` 
        | ``Left middle`` 
        | ``Left bottom``

    and [<Pojo>] PopoverProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract isOpen: bool option with get, set
        abstract toggle: Function option with get, set
        abstract target: string with get, set
        abstract tether: obj option with get, set
        abstract tetherRef: Function option with get, set
        abstract placement: PlacementEnum option with get, set

    and [<Import("Popover","reactstrap")>] Popover(props: PopoverProps) =
        inherit React.Component<PopoverProps, obj>(props)


    and [<Pojo>] PopoverTitleProps =
        inherit React.HTMLProps<HTMLDivElement>


    and [<Import("PopoverTitle","reactstrap")>] PopoverTitle(props: PopoverTitle) =
        inherit React.Component<PopoverTitle, obj>(props)


    and [<Pojo>] PopoverContentProps =
        inherit React.HTMLProps<HTMLDivElement>


    and [<Import("PopoverContent","reactstrap")>] PopoverContent(props: PopoverContentProps) =
        inherit React.Component<PopoverContentProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] ProgressProps =
        abstract multi: bool option with get, set
        abstract bar: bool option with get, set
        abstract tag: string option with get, set
        abstract value: U2<string, float> option with get, set
        abstract max: U2<string, float> option with get, set
        abstract animated: bool option with get, set
        abstract striped: bool option with get, set
        abstract color: string option with get, set
        abstract className: string option with get, set

    and [<Import("Progress","reactstrap")>] Progress(props: ProgressProps) =
        inherit React.Component<ProgressProps, obj>(props)


    and [<Import("Row","reactstrap")>] Row() =
        inherit React.Component<unit, obj>(())


    and [<AllowNullLiteral>] [<Pojo>] TableProps =
        abstract tag: U2<Function, string> option with get, set
        abstract size: string option with get, set
        abstract bordered: bool option with get, set
        abstract striped: bool option with get, set
        abstract inverse: bool option with get, set
        abstract hover: bool option with get, set
        abstract reflow: bool option with get, set
        abstract responsive: bool option with get, set

    and [<Import("Table","reactstrap")>] Table(props: TableProps) =
        inherit React.Component<TableProps, obj>(props)


    and [<Pojo>] TabContentProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract activeTab: U2<float, string> option with get, set

    and [<Import("TabContent","reactstrap")>] TabContent(props: TabContentProps) =
        inherit React.Component<TabContentProps, obj>(props)


    and [<Pojo>] TabPaneProps =
        inherit React.HTMLProps<HTMLDivElement>
        abstract tabId: U2<float, string> option with get, set

    and [<Import("TabPane","reactstrap")>] TabPane(props: TabPaneProps) =
        inherit React.Component<TabPaneProps, obj>(props)


    and [<AllowNullLiteral>] [<Pojo>] TooltipProps =
        abstract isOpen: bool option with get, set
        abstract toggle: Function option with get, set
        abstract target: string option with get, set
        abstract tether: U2<obj, bool> option with get, set
        abstract tetherRef: Function option with get, set
        abstract delay: U2<obj, float> option with get, set
        abstract autohide: bool option with get, set
        abstract placement: PlacementEnum option with get, set

    and [<Import("Tooltip","reactstrap")>] Tooltip(props: TooltipProps) =
        inherit React.Component<TooltipProps, obj>(props)


    and [<Import("UncontrolledTooltip","reactstrap")>] UncontrolledTooltip(props: TooltipProps) =
        inherit React.Component<TooltipProps, obj>(props)


    /////////// Helper functions
    let [<PassGenerics>] inline private rsCom<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> (propsUpdate: 'P -> unit) =
        let props = Fable.Core.JsInterop.createEmpty<'P>
        propsUpdate props
        com<'T, 'P, 'S> (props) 

    let [<PassGenerics>] inline private rsCom0<'T,[<Pojo>]'P,[<Pojo>]'S when 'T :> React.Component<'P,'S>> = rsCom<'T, 'P, 'S> (ignore)


    let inline Nav propsUpdate = rsCom<Nav, _, obj> propsUpdate
    let inline NavItem propsUpdate = rsCom<NavItem, _, obj> propsUpdate
    let inline NavLink propsUpdate = rsCom<NavLink, _, obj> propsUpdate

    let inline Button propsUpdate = rsCom<Button, _, obj> propsUpdate


    let inline Form propsUpdate = rsCom<Form, _, obj> propsUpdate
    let inline FormGroup propsUpdate = rsCom<FormGroup, _, obj> propsUpdate
    let inline FormText propsUpdate = rsCom<FormText, _, obj> propsUpdate
    let inline FormFeedback propsUpdate = rsCom<FormFeedback, _, obj> propsUpdate
    let inline Label propsUpdate = rsCom<Label, _, obj> propsUpdate
    let inline Input propsUpdate = rsCom<Input, _, obj> propsUpdate
    //let inline textBox propsUpdate = rsCom<TextBox, _, obj> propsUpdate

    let inline Modal propsUpdate = rsCom<Modal, _, obj> propsUpdate
    let inline ModalHeader propsUpdate = rsCom<ModalHeader, _, obj> propsUpdate
    let inline ModalFooter propsUpdate = rsCom<ModalFooter, _, obj> propsUpdate
    let inline ModalBody propsUpdate = rsCom<ModalBody, _, obj> propsUpdate

    let inline Collapse propsUpdate = rsCom<Collapse, _, obj> propsUpdate

    let inline Tooltip propsUpdate = rsCom<Tooltip, _, obj> propsUpdate
    let inline UncontrolledTooltip propsUpdate = rsCom<UncontrolledTooltip, _, obj> propsUpdate
    
