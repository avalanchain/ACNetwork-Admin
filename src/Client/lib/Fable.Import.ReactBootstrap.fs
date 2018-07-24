namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.ReactHelpers

module ReactBootstrap =
    type [<AllowNullLiteral>] [<StringEnum>] Sizes =
        | Xs | Xsmall | Sm | Small | Medium | Lg | Large

    and [<AllowNullLiteral>] SelectCallback =
        inherit React.EventHandler<obj>
        [<Emit("$0($1...)")>] abstract Invoke: eventKey: obj * e: React.SyntheticEvent<obj> -> unit
        [<Emit("$0($1...)")>] abstract Invoke: e: React.MouseEvent<obj> -> unit

    and [<AllowNullLiteral>] TransitionCallbacks =
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set

    and [<AllowNullLiteral>] AccordionProps =
        inherit React.HTMLProps<Accordion>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract collapsible: bool option with get, set
        abstract defaultExpanded: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract expanded: bool option with get, set
        abstract footer: obj option with get, set
        abstract header: obj option with get, set

    and [<AllowNullLiteral>] Accordion =
        React.ClassicComponent<AccordionProps, obj>

    and [<AllowNullLiteral>] BreadcrumbProps =
        inherit React.Props<Breadcrumb>
        abstract bsClass: string option with get, set

    and [<AllowNullLiteral>] BreadcrumbClass =
        inherit React.ClassicComponentClass<BreadcrumbProps>
        abstract Item: obj with get, set

    and [<AllowNullLiteral>] Breadcrumb =
        React.ClassicComponent<BreadcrumbProps, obj>

    and [<AllowNullLiteral>] BreadcrumbItemProps =
        inherit React.Props<BreadcrumbItem>
        abstract active: bool option with get, set
        abstract id: U2<string, float> option with get, set
        abstract href: string option with get, set
        abstract title: React.ReactNode option with get, set
        abstract target: string option with get, set

    and [<AllowNullLiteral>] BreadcrumbItem =
        React.ClassicComponent<BreadcrumbItemProps, obj>

    and [<AllowNullLiteral>] ButtonProps =
        inherit React.HTMLProps<Button>
        abstract bsClass: string option with get, set
        abstract active: bool option with get, set
        abstract block: bool option with get, set
        abstract bsStyle: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract disabled: bool option with get, set

    and [<AllowNullLiteral>] Button =
        React.ClassicComponent<ButtonProps, obj>

    and [<AllowNullLiteral>] ButtonToolbarProps =
        inherit React.HTMLProps<ButtonToolbar>
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract justified: bool option with get, set
        abstract vertical: bool option with get, set

    and [<AllowNullLiteral>] ButtonToolbar =
        React.ClassicComponent<ButtonToolbarProps, obj>

    and [<AllowNullLiteral>] ButtonGroupProps =
        inherit React.HTMLProps<ButtonGroup>
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract justified: bool option with get, set
        abstract vertical: bool option with get, set

    and [<AllowNullLiteral>] ButtonGroup =
        React.ClassicComponent<ButtonGroupProps, obj>

    and [<AllowNullLiteral>] SafeAnchorProps =
        inherit React.HTMLProps<SafeAnchor>
        abstract href: string option with get, set
        abstract onClick: React.MouseEventHandler<obj> option with get, set
        abstract disabled: bool option with get, set
        abstract role: string option with get, set
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] SafeAnchor =
        React.ClassicComponent<SafeAnchorProps, obj>

    and [<AllowNullLiteral>] CheckboxProps =
        inherit React.HTMLProps<Checkbox>
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract ``inline``: bool option with get, set
        abstract inputRef: Func<HTMLInputElement, unit> option with get, set
        abstract validationState: (* TODO StringEnum success | warning | error *) string option with get, set

    and [<AllowNullLiteral>] [<Import("Checkbox","ReactBootstrap")>] Checkbox() =
        interface React.Component<CheckboxProps, obj>


    and [<AllowNullLiteral>] ClearfixProps =
        inherit React.HTMLProps<Clearfix>
        abstract componentClass: React.ReactType option with get, set
        abstract visibleXsBlock: bool option with get, set
        abstract visibleSmBlock: bool option with get, set
        abstract visibleMdBlock: bool option with get, set
        abstract visibleLgBlock: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Clearfix","ReactBootstrap")>] Clearfix() =
        interface React.Component<ClearfixProps, obj>


    and [<AllowNullLiteral>] CollapseProps =
        inherit TransitionCallbacks
        inherit React.Props<Collapse>
        abstract dimension: (* TODO StringEnum height | width |  *) string option with get, set
        abstract getDimensionValue: Func<float, React.ReactElement<obj>, float> option with get, set
        abstract ``in``: bool option with get, set
        abstract timeout: float option with get, set
        abstract transitionAppear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Collapse","ReactBootstrap")>] Collapse() =
        interface React.Component<CollapseProps, obj>


    and [<AllowNullLiteral>] DropdownBaseProps =
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract disabled: bool option with get, set
        abstract dropup: bool option with get, set
        abstract id: string with get, set
        abstract onClose: Function option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract onToggle: Func<bool, unit> option with get, set
        abstract ``open``: bool option with get, set
        abstract pullRight: bool option with get, set
        abstract role: string option with get, set

    and [<AllowNullLiteral>] DropdownProps =
        obj

    and [<AllowNullLiteral>] [<Import("Dropdown","ReactBootstrap")>] Dropdown() =
        interface React.Component<DropdownProps, obj>
        member __.Menu with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.Toggle with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] DropdownButtonBaseProps =
        inherit DropdownBaseProps
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract navItem: bool option with get, set
        abstract noCaret: bool option with get, set
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] DropdownButtonProps =
        obj

    and [<AllowNullLiteral>] [<Import("DropdownButton","ReactBootstrap")>] DropdownButton() =
        interface React.Component<DropdownButtonProps, obj>


    and [<AllowNullLiteral>] DropdownMenuProps =
        inherit React.HTMLProps<DropdownMenu>
        abstract labelledBy: U2<string, float> option with get, set
        abstract onClose: Function option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract ``open``: bool option with get, set
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] [<Import("DropdownMenu","ReactBootstrap")>] DropdownMenu() =
        interface React.Component<DropdownMenuProps, obj>


    and [<AllowNullLiteral>] DropdownToggleProps =
        inherit React.HTMLProps<DropdownToggle>
        abstract bsRole: string option with get, set
        abstract noCaret: bool option with get, set
        abstract ``open``: bool option with get, set
        abstract title: string option with get, set
        abstract useAnchor: bool option with get, set
        abstract bsClass: string option with get, set
        abstract bsStyle: string option with get, set

    and [<AllowNullLiteral>] [<Import("DropdownToggle","ReactBootstrap")>] DropdownToggle() =
        interface React.Component<DropdownToggleProps, obj>


    and [<AllowNullLiteral>] FadeProps =
        inherit TransitionCallbacks
        inherit React.Props<Fade>
        abstract ``in``: bool option with get, set
        abstract timeout: float option with get, set
        abstract transitionAppear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Fade","ReactBootstrap")>] Fade() =
        interface React.Component<FadeProps, obj>


    and [<AllowNullLiteral>] MenuItemProps =
        inherit React.HTMLProps<MenuItem>
        abstract active: bool option with get, set
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract divider: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract header: bool option with get, set
        abstract onClick: React.MouseEventHandler<obj> option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract target: string option with get, set
        abstract title: string option with get, set

    and [<AllowNullLiteral>] [<Import("MenuItem","ReactBootstrap")>] MenuItem() =
        interface React.Component<MenuItemProps, obj>


    and [<AllowNullLiteral>] PanelProps =
        inherit TransitionCallbacks
        inherit React.HTMLProps<Panel>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract collapsible: bool option with get, set
        abstract defaultExpanded: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract expanded: bool option with get, set
        abstract footer: React.ReactNode option with get, set
        abstract header: React.ReactNode option with get, set
        abstract onSelect: SelectCallback option with get, set

    and [<AllowNullLiteral>] Panel =
        React.ClassicComponent<PanelProps, obj>

    and [<AllowNullLiteral>] PanelGroupProps =
        inherit React.HTMLProps<PanelGroup>
        abstract accordion: bool option with get, set
        abstract activeKey: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract onSelect: SelectCallback option with get, set

    and [<AllowNullLiteral>] PanelGroup =
        React.ClassicComponent<PanelGroupProps, obj>

    and [<AllowNullLiteral>] SplitButtonProps =
        inherit React.HTMLProps<SplitButton>
        abstract bsStyle: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract dropdownTitle: obj option with get, set
        abstract dropup: bool option with get, set
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] [<Import("SplitButton","ReactBootstrap")>] SplitButton() =
        interface React.Component<SplitButtonProps, obj>


    and [<AllowNullLiteral>] ModalDialogProps =
        inherit React.HTMLProps<ModalDialog>
        abstract onHide: Function option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set

    and [<AllowNullLiteral>] ModalDialog =
        React.ClassicComponent<ModalDialogProps, obj>

    and [<AllowNullLiteral>] ModalHeaderProps =
        inherit React.HTMLProps<ModalHeader>
        abstract closeButton: bool option with get, set
        abstract modalClassName: string option with get, set
        abstract onHide: Function option with get, set

    and [<AllowNullLiteral>] [<Import("ModalHeader","ReactBootstrap")>] ModalHeader() =
        interface React.Component<ModalHeaderProps, obj>


    and [<AllowNullLiteral>] ModalTitleProps =
        inherit React.HTMLProps<ModalTitle>
        abstract modalClassName: string option with get, set

    and [<AllowNullLiteral>] [<Import("ModalTitle","ReactBootstrap")>] ModalTitle() =
        interface React.Component<ModalTitleProps, obj>


    and [<AllowNullLiteral>] ModalBodyProps =
        inherit React.HTMLProps<ModalBody>
        abstract modalClassName: string option with get, set

    and [<AllowNullLiteral>] [<Import("ModalBody","ReactBootstrap")>] ModalBody() =
        interface React.Component<ModalBodyProps, obj>


    and [<AllowNullLiteral>] ModalFooterProps =
        inherit React.HTMLProps<ModalFooter>
        abstract modalClassName: string option with get, set

    and [<AllowNullLiteral>] [<Import("ModalFooter","ReactBootstrap")>] ModalFooter() =
        interface React.Component<ModalFooterProps, obj>


    and [<AllowNullLiteral>] ModalProps =
        inherit React.HTMLProps<Modal>
        abstract onHide: Function with get, set
        abstract animation: bool option with get, set
        abstract autoFocus: bool option with get, set
        abstract backdrop: U2<bool, string> option with get, set
        abstract backdropClassName: string option with get, set
        abstract backdropStyle: obj option with get, set
        abstract backdropTransitionTimeout: float option with get, set
        abstract bsSize: Sizes option with get, set
        abstract container: obj option with get, set
        abstract containerClassName: string option with get, set
        abstract dialogClassName: string option with get, set
        abstract dialogComponent: obj option with get, set
        abstract dialogTransitionTimeout: float option with get, set
        abstract enforceFocus: bool option with get, set
        abstract keyboard: bool option with get, set
        abstract onBackdropClick: Func<HTMLElement, obj> option with get, set
        abstract onEnter: Func<HTMLElement, obj> option with get, set
        abstract onEntered: Func<HTMLElement, obj> option with get, set
        abstract onEntering: Func<HTMLElement, obj> option with get, set
        abstract onEscapeKeyUp: Func<HTMLElement, obj> option with get, set
        abstract onExit: Func<HTMLElement, obj> option with get, set
        abstract onExited: Func<HTMLElement, obj> option with get, set
        abstract onExiting: Func<HTMLElement, obj> option with get, set
        abstract onShow: Func<HTMLElement, obj> option with get, set
        abstract show: bool option with get, set
        abstract transition: React.ReactElement<obj> option with get, set

    and [<AllowNullLiteral>] ModalClass =
        inherit React.ClassicComponentClass<ModalProps>
        abstract Body: obj with get, set
        abstract Header: obj with get, set
        abstract Title: obj with get, set
        abstract Footer: obj with get, set
        abstract Dialog: obj with get, set

    and [<AllowNullLiteral>] Modal =
        React.ClassicComponent<ModalProps, obj>

    and [<AllowNullLiteral>] OverlayTriggerProps =
        abstract overlay: obj with get, set
        abstract animation: obj option with get, set
        abstract container: obj option with get, set
        abstract containerPadding: float option with get, set
        abstract defaultOverlayShown: bool option with get, set
        abstract delay: float option with get, set
        abstract delayHide: float option with get, set
        abstract delayShow: float option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract placement: string option with get, set
        abstract rootClose: bool option with get, set
        abstract trigger: U2<string, ResizeArray<string>> option with get, set

    and [<AllowNullLiteral>] OverlayTrigger =
        React.ClassicComponent<OverlayTriggerProps, obj>

    and [<AllowNullLiteral>] TooltipProps =
        inherit React.HTMLProps<Tooltip>
        abstract arrowOffsetLeft: U2<float, string> option with get, set
        abstract arrowOffsetTop: U2<float, string> option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract placement: string option with get, set
        abstract positionLeft: float option with get, set
        abstract positionTop: float option with get, set

    and [<AllowNullLiteral>] Tooltip =
        React.ClassicComponent<TooltipProps, obj>

    and [<AllowNullLiteral>] PopoverProps =
        inherit React.HTMLProps<Popover>
        abstract arrowOffsetLeft: U2<float, string> option with get, set
        abstract arrowOffsetTop: U2<float, string> option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract placement: string option with get, set
        abstract positionLeft: U2<float, string> option with get, set
        abstract positionTop: U2<float, string> option with get, set

    and [<AllowNullLiteral>] Popover =
        React.ClassicComponent<PopoverProps, obj>

    and [<AllowNullLiteral>] OverlayProps =
        abstract animation: obj option with get, set
        abstract container: obj option with get, set
        abstract containerPadding: float option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract onHide: Function option with get, set
        abstract placement: string option with get, set
        abstract rootClose: bool option with get, set
        abstract show: bool option with get, set
        abstract target: Function option with get, set
        abstract shouldUpdatePosition: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Overlay","ReactBootstrap")>] Overlay() =
        interface React.Component<OverlayProps, obj>


    and [<AllowNullLiteral>] ProgressBarProps =
        inherit React.HTMLProps<ProgressBar>
        abstract active: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract interpolatedClass: obj option with get, set
        abstract max: float option with get, set
        abstract min: float option with get, set
        abstract now: float option with get, set
        abstract srOnly: bool option with get, set
        abstract striped: bool option with get, set

    and [<AllowNullLiteral>] [<Import("ProgressBar","ReactBootstrap")>] ProgressBar() =
        interface React.Component<ProgressBarProps, obj>


    and [<AllowNullLiteral>] NavProps =
        inherit React.HTMLProps<Nav>
        abstract activeHref: string option with get, set
        abstract activeKey: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract collapsible: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract expanded: bool option with get, set
        abstract justified: bool option with get, set
        abstract navbar: bool option with get, set
        abstract pullRight: bool option with get, set
        abstract right: bool option with get, set
        abstract stacked: bool option with get, set
        abstract ulClassName: string option with get, set
        abstract ulId: string option with get, set

    and [<AllowNullLiteral>] [<Import("Nav","ReactBootstrap")>] Nav() =
        interface React.Component<NavProps, obj>


    and [<AllowNullLiteral>] NavItemProps =
        inherit React.HTMLProps<NavItem>
        abstract active: bool option with get, set
        abstract brand: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract defaultNavExpanded: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract fixedBottom: bool option with get, set
        abstract fixedTop: bool option with get, set
        abstract fluid: bool option with get, set
        abstract inverse: bool option with get, set
        abstract linkId: string option with get, set
        abstract navExpanded: bool option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract onToggle: Function option with get, set
        abstract staticTop: bool option with get, set
        abstract toggleButton: obj option with get, set
        abstract toggleNavKey: U2<string, float> option with get, set

    and [<AllowNullLiteral>] NavItem =
        React.ClassicComponent<NavItemProps, obj>

    and [<AllowNullLiteral>] NavbarBrandProps =
        inherit React.HTMLProps<NavbarBrand>


    and [<AllowNullLiteral>] [<Import("NavbarBrand","ReactBootstrap")>] NavbarBrand() =
        interface React.Component<NavbarBrandProps, obj>


    and [<AllowNullLiteral>] NavbarCollapseProps =
        interface end

    and [<AllowNullLiteral>] NavbarCollapse =
        React.ClassicComponent<NavbarCollapseProps, obj>

    and [<AllowNullLiteral>] NavbarHeaderProps =
        inherit React.HTMLProps<NavbarHeader>


    and [<AllowNullLiteral>] NavbarHeader =
        React.ClassicComponent<NavbarHeaderProps, obj>

    and [<AllowNullLiteral>] NavbarToggleProps =
        abstract onClick: React.MouseEventHandler<HTMLButtonElement> option with get, set

    and [<AllowNullLiteral>] NavbarToggle =
        React.ClassicComponent<NavbarToggleProps, obj>

    and [<AllowNullLiteral>] NavbarLinkProps =
        abstract href: string with get, set
        abstract onClick: React.MouseEventHandler<HTMLAnchorElement> option with get, set

    and [<AllowNullLiteral>] NavbarLink =
        React.ClassicComponent<NavbarLinkProps, obj>

    and [<AllowNullLiteral>] NavbarTextProps =
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] NavbarText =
        React.ClassicComponent<NavbarTextProps, obj>

    and [<AllowNullLiteral>] NavbarFormProps =
        inherit React.HTMLProps<NavbarForm>
        abstract componentClass: React.ReactType option with get, set
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] NavbarForm =
        React.ClassicComponent<NavbarFormProps, obj>

    and [<AllowNullLiteral>] NavbarProps =
        inherit React.HTMLProps<Navbar>
        abstract brand: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract collapseOnSelect: bool option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract defaultNavExpanded: bool option with get, set
        abstract fixedBottom: bool option with get, set
        abstract fixedTop: bool option with get, set
        abstract fluid: bool option with get, set
        abstract inverse: bool option with get, set
        abstract navExpanded: bool option with get, set
        abstract onToggle: Function option with get, set
        abstract staticTop: bool option with get, set
        abstract toggleButton: obj option with get, set
        abstract toggleNavKey: U2<string, float> option with get, set

    and [<AllowNullLiteral>] NavbarClass =
        inherit React.ClassicComponentClass<NavbarProps>
        abstract Brand: obj with get, set
        abstract Collapse: obj with get, set
        abstract Header: obj with get, set
        abstract Toggle: obj with get, set
        abstract Link: obj with get, set
        abstract Text: obj with get, set
        abstract Form: obj with get, set

    and [<AllowNullLiteral>] Navbar =
        React.ClassicComponent<NavbarProps, obj>

    and [<AllowNullLiteral>] NavDropdownBaseProps =
        inherit DropdownBaseProps
        abstract active: bool option with get, set
        abstract noCaret: bool option with get, set
        abstract eventKey: obj option with get, set

    and [<AllowNullLiteral>] NavDropdownProps =
        obj

    and [<AllowNullLiteral>] [<Import("NavDropdown","ReactBootstrap")>] NavDropdown() =
        interface React.Component<NavDropdownProps, obj>


    and [<AllowNullLiteral>] TabsProps =
        inherit React.HTMLProps<Tabs>
        abstract activeKey: obj option with get, set
        abstract animation: bool option with get, set
        abstract bsStyle: string option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract paneWidth: obj option with get, set
        abstract position: string option with get, set
        abstract tabWidth: obj option with get, set
        abstract unmountOnExit: bool option with get, set
        abstract justified: bool option with get, set

    and [<AllowNullLiteral>] Tabs =
        React.ClassicComponent<TabsProps, obj>

    and [<AllowNullLiteral>] TabProps =
        inherit React.HTMLProps<Tab>
        abstract animation: bool option with get, set
        abstract ``aria-labelledby``: string option with get, set
        abstract bsClass: string option with get, set
        abstract eventKey: obj option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract unmountOnExit: bool option with get, set
        abstract tabClassName: string option with get, set

    and [<AllowNullLiteral>] TabClass =
        inherit React.ClassicComponentClass<TabProps>
        abstract Container: TabContainer with get, set
        abstract Pane: TabPane with get, set
        abstract Content: TabClass with get, set

    and [<AllowNullLiteral>] Tab =
        TabClass

    and [<AllowNullLiteral>] TabContainerProps =
        inherit React.HTMLAttributes<obj>
        abstract activeKey: obj option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract generateChildId: Func<obj, obj, string> option with get, set

    and [<AllowNullLiteral>] TabContainer =
        React.ClassicComponentClass<TabContainerProps>

    and [<AllowNullLiteral>] TabPaneProps =
        inherit React.HTMLAttributes<obj>
        abstract animation: U2<bool, React.ComponentClass<obj>> option with get, set
        abstract ``aria-labelledby``: string option with get, set
        abstract bsClass: string option with get, set
        abstract eventKey: obj option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract unmountOnExit: bool option with get, set

    and [<AllowNullLiteral>] TabPane =
        React.ClassicComponentClass<TabPaneProps>

    and [<AllowNullLiteral>] PagerProps =
        inherit React.HTMLProps<Pager>
        abstract onSelect: SelectCallback option with get, set

    and [<AllowNullLiteral>] PagerClass =
        inherit React.ClassicComponentClass<PagerProps>
        abstract Item: obj with get, set

    and [<AllowNullLiteral>] Pager =
        React.ClassicComponent<PagerProps, obj>

    and [<AllowNullLiteral>] PageItemProps =
        inherit React.HTMLProps<PageItem>
        abstract disabled: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract next: bool option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract previous: bool option with get, set
        abstract target: string option with get, set

    and [<AllowNullLiteral>] PageItem =
        React.ClassicComponent<PageItemProps, obj>

    and [<AllowNullLiteral>] PaginationProps =
        inherit React.HTMLProps<Pagination>
        abstract activePage: float option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract boundaryLinks: bool option with get, set
        abstract buttonComponentClass: React.ReactType option with get, set
        abstract ellipsis: React.ReactNode option with get, set
        abstract first: React.ReactNode option with get, set
        abstract items: float option with get, set
        abstract last: React.ReactNode option with get, set
        abstract maxButtons: float option with get, set
        abstract next: React.ReactNode option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract prev: React.ReactNode option with get, set

    and [<AllowNullLiteral>] Pagination =
        React.ClassicComponent<PaginationProps, obj>

    and [<AllowNullLiteral>] AlertProps =
        inherit React.HTMLProps<Alert>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract closeLabel: string option with get, set
        abstract dismissAfter: float option with get, set
        abstract onDismiss: Function option with get, set

    and [<AllowNullLiteral>] Alert =
        React.ClassicComponent<AlertProps, obj>

    and [<AllowNullLiteral>] CarouselProps =
        inherit React.HTMLProps<Carousel>
        abstract activeIndex: float option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract controls: bool option with get, set
        abstract defaultActiveIndex: float option with get, set
        abstract direction: string option with get, set
        abstract indicators: bool option with get, set
        abstract interval: float option with get, set
        abstract nextIcon: React.ReactNode option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract onSlideEnd: Function option with get, set
        abstract pauseOnHover: bool option with get, set
        abstract prevIcon: React.ReactNode option with get, set
        abstract slide: bool option with get, set

    and [<AllowNullLiteral>] CarouselClass =
        inherit React.ClassicComponentClass<CarouselProps>
        abstract Caption: obj with get, set
        abstract Item: obj with get, set

    and [<AllowNullLiteral>] Carousel =
        React.ClassicComponent<CarouselProps, obj>

    and [<AllowNullLiteral>] CarouselItemProps =
        inherit React.HTMLProps<CarouselItem>
        abstract active: bool option with get, set
        abstract animtateIn: bool option with get, set
        abstract animateOut: bool option with get, set
        abstract direction: string option with get, set
        abstract index: float option with get, set
        abstract onAnimateOutEnd: Function option with get, set

    and [<AllowNullLiteral>] CarouselItem =
        React.ClassicComponent<CarouselItemProps, obj>

    and [<AllowNullLiteral>] CarouselCaptionProps =
        inherit React.HTMLProps<CarouselCaption>
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] CarouselCaption =
        React.ClassicComponent<CarouselCaptionProps, obj>

    and [<AllowNullLiteral>] GridProps =
        inherit React.HTMLProps<Grid>
        abstract componentClass: React.ReactType option with get, set
        abstract fluid: bool option with get, set
        abstract bsClass: string option with get, set

    and [<AllowNullLiteral>] Grid =
        React.ClassicComponent<GridProps, obj>

    and [<AllowNullLiteral>] RowProps =
        inherit React.HTMLProps<Row>
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] Row =
        React.ClassicComponent<RowProps, obj>

    and [<AllowNullLiteral>] ColProps =
        inherit React.HTMLProps<Col>
        abstract componentClass: React.ReactType option with get, set
        abstract lg: float option with get, set
        abstract lgHidden: bool option with get, set
        abstract lgOffset: float option with get, set
        abstract lgPull: float option with get, set
        abstract lgPush: float option with get, set
        abstract md: float option with get, set
        abstract mdHidden: bool option with get, set
        abstract mdOffset: float option with get, set
        abstract mdPull: float option with get, set
        abstract mdPush: float option with get, set
        abstract sm: float option with get, set
        abstract smHidden: bool option with get, set
        abstract smOffset: float option with get, set
        abstract smPull: float option with get, set
        abstract smPush: float option with get, set
        abstract xs: float option with get, set
        abstract xsHidden: bool option with get, set
        abstract xsOffset: float option with get, set
        abstract xsPull: float option with get, set
        abstract xsPush: float option with get, set

    and [<AllowNullLiteral>] Col =
        React.ClassicComponent<ColProps, obj>

    and [<AllowNullLiteral>] ThumbnailProps =
        inherit React.HTMLProps<Thumbnail>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    and [<AllowNullLiteral>] Thumbnail =
        React.ClassicComponent<ThumbnailProps, obj>

    and [<AllowNullLiteral>] ListGroupProps =
        inherit React.HTMLProps<ListGroup>
        abstract componentClass: React.ReactType option with get, set
        abstract fill: bool option with get, set

    and [<AllowNullLiteral>] [<Import("ListGroup","ReactBootstrap")>] ListGroup() =
        interface React.Component<ListGroupProps, obj>


    and [<AllowNullLiteral>] ListGroupItemProps =
        inherit React.HTMLProps<ListGroupItem>
        abstract active: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract eventKey: obj option with get, set
        abstract header: obj option with get, set
        abstract key: obj option with get, set
        abstract listItem: bool option with get, set

    and [<AllowNullLiteral>] [<Import("ListGroupItem","ReactBootstrap")>] ListGroupItem() =
        interface React.Component<ListGroupItemProps, obj>


    and [<AllowNullLiteral>] LabelProps =
        inherit React.HTMLProps<Label>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    and [<AllowNullLiteral>] [<Import("Label","ReactBootstrap")>] Label() =
        interface React.Component<LabelProps, obj>


    and [<AllowNullLiteral>] BadgeProps =
        inherit React.HTMLProps<Badge>
        abstract pullRight: bool option with get, set

    and [<AllowNullLiteral>] Badge =
        React.ClassicComponent<BadgeProps, obj>

    and [<AllowNullLiteral>] JumbotronProps =
        inherit React.HTMLProps<Jumbotron>
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] Jumbotron =
        React.ClassicComponent<JumbotronProps, obj>

    and [<AllowNullLiteral>] ImageProps =
        inherit React.HTMLProps<Image>
        abstract circle: bool option with get, set
        abstract responsive: bool option with get, set
        abstract rounded: bool option with get, set
        abstract thumbnail: bool option with get, set

    and [<AllowNullLiteral>] Image =
        React.ClassicComponent<ImageProps, obj>

    and [<AllowNullLiteral>] ResponsiveEmbedProps =
        inherit React.HTMLProps<ResponsiveEmbed>
        abstract a16by9: bool option with get, set
        abstract a4by3: bool option with get, set
        abstract bsClass: string option with get, set

    and [<AllowNullLiteral>] [<Import("ResponsiveEmbed","ReactBootstrap")>] ResponsiveEmbed() =
        interface React.Component<ResponsiveEmbedProps, obj>


    and [<AllowNullLiteral>] PageHeaderProps =
        inherit React.HTMLProps<PageHeader>


    and [<AllowNullLiteral>] [<Import("PageHeader","ReactBootstrap")>] PageHeader() =
        interface React.Component<PageHeaderProps, obj>


    and [<AllowNullLiteral>] WellProps =
        inherit React.HTMLProps<Well>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    and [<AllowNullLiteral>] [<Import("Well","ReactBootstrap")>] Well() =
        interface React.Component<WellProps, obj>


    and [<AllowNullLiteral>] GlyphiconProps =
        inherit React.HTMLProps<Glyphicon>
        abstract glyph: string with get, set

    and [<AllowNullLiteral>] Glyphicon =
        React.ClassicComponent<GlyphiconProps, obj>

    and [<AllowNullLiteral>] TableProps =
        inherit React.HTMLProps<Table>
        abstract bordered: bool option with get, set
        abstract condensed: bool option with get, set
        abstract hover: bool option with get, set
        abstract responsive: bool option with get, set
        abstract striped: bool option with get, set
        abstract fill: bool option with get, set

    and [<AllowNullLiteral>] Table =
        React.ClassicComponent<TableProps, obj>

    and [<AllowNullLiteral>] InputGroupProps =
        inherit React.HTMLProps<InputGroup>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set

    and [<AllowNullLiteral>] InputGroupClass =
        inherit React.ClassicComponentClass<InputGroupProps>
        abstract Addon: obj with get, set
        abstract Button: obj with get, set

    and [<AllowNullLiteral>] InputGroup =
        React.Component<InputGroupProps, obj>

    and [<AllowNullLiteral>] InputGroupAddonProps =
        inherit React.HTMLProps<InputGroupAddon>


    and [<AllowNullLiteral>] InputGroupAddon =
        React.ClassicComponent<InputGroupAddonProps, obj>

    and [<AllowNullLiteral>] InputGroupButtonProps =
        inherit React.HTMLProps<InputGroupButton>


    and [<AllowNullLiteral>] InputGroupButton =
        React.ClassicComponent<InputGroupButtonProps, obj>

    and [<AllowNullLiteral>] FormProps =
        inherit React.HTMLProps<Form>
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract horizontal: bool option with get, set
        abstract ``inline``: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Form","ReactBootstrap")>] Form() =
        interface React.Component<FormProps, obj>


    and [<AllowNullLiteral>] FormGroupProps =
        inherit React.HTMLProps<FormGroup>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract controlId: string option with get, set
        abstract validationState: (* TODO StringEnum success | warning | error *) string option with get, set

    and [<AllowNullLiteral>] [<Import("FormGroup","ReactBootstrap")>] FormGroup() =
        interface React.Component<FormGroupProps, obj>


    and [<AllowNullLiteral>] ControlLabelProps =
        inherit React.HTMLProps<ControlLabel>
        abstract bsClass: string option with get, set
        abstract htmlFor: string option with get, set
        abstract srOnly: bool option with get, set

    and [<AllowNullLiteral>] [<Import("ControlLabel","ReactBootstrap")>] ControlLabel() =
        interface React.Component<ControlLabelProps, obj>


    and [<AllowNullLiteral>] FormControlProps =
        inherit React.HTMLProps<FormControl>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract id: string option with get, set
        abstract inputRef: Func<HTMLInputElement, unit> option with get, set
        abstract ``type``: string option with get, set

    and [<AllowNullLiteral>] FormControlClass =
        inherit React.ClassicComponentClass<FormControlProps>
        abstract Feedback: obj with get, set
        abstract Static: obj with get, set

    and [<AllowNullLiteral>] FormControl =
        React.Component<FormControlProps, obj>

    and [<AllowNullLiteral>] FormControlFeedbackProps =
        inherit React.HTMLProps<FormControlFeedback>


    and [<AllowNullLiteral>] [<Import("FormControlFeedback","ReactBootstrap")>] FormControlFeedback() =
        interface React.Component<FormControlFeedbackProps, obj>


    and [<AllowNullLiteral>] FormControlStaticProps =
        inherit React.HTMLProps<FormControlStatic>
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] [<Import("FormControlStatic","ReactBootstrap")>] FormControlStatic() =
        interface React.Component<FormControlStaticProps, obj>


    and [<AllowNullLiteral>] HelpBlockProps =
        inherit React.HTMLProps<HelpBlock>
        abstract bsClass: string option with get, set

    and [<AllowNullLiteral>] [<Import("HelpBlock","ReactBootstrap")>] HelpBlock() =
        interface React.Component<HelpBlockProps, obj>


    and [<AllowNullLiteral>] RadioProps =
        inherit React.HTMLProps<Radio>
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract ``inline``: bool option with get, set
        abstract inputRef: Func<HTMLInputElement, unit> option with get, set
        abstract validationState: (* TODO StringEnum success | warning | error *) string option with get, set

    and [<AllowNullLiteral>] [<Import("Radio","ReactBootstrap")>] Radio() =
        interface React.Component<RadioProps, obj>


    and [<AllowNullLiteral>] PortalProps =
        inherit React.Props<Portal>
        abstract dimension: U2<string, Function> option with get, set
        abstract getDimensionValue: Function option with get, set
        abstract ``in``: bool option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract role: string option with get, set
        abstract timeout: float option with get, set
        abstract transitionAppear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    and [<AllowNullLiteral>] Portal =
        React.ClassicComponent<PortalProps, obj>

    and [<AllowNullLiteral>] PositionProps =
        inherit TransitionCallbacks
        inherit React.Props<Position>
        abstract dimension: U2<string, Function> option with get, set
        abstract getDimensionValue: Function option with get, set
        abstract ``in``: bool option with get, set
        abstract role: string option with get, set
        abstract timeout: float option with get, set
        abstract transitionAppear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    and [<AllowNullLiteral>] [<Import("Position","ReactBootstrap")>] Position() =
        interface React.Component<PositionProps, obj>


    and [<AllowNullLiteral>] MediaLeftProps =
        abstract align: string option with get, set

    and [<AllowNullLiteral>] MediaLeft =
        React.ClassicComponent<MediaLeftProps, obj>

    and [<AllowNullLiteral>] MediaRightProps =
        abstract align: string option with get, set

    and [<AllowNullLiteral>] MediaRight =
        React.ClassicComponent<MediaRightProps, obj>

    and [<AllowNullLiteral>] MediaHeadingProps =
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] MediaHeading =
        React.ClassicComponent<MediaHeadingProps, obj>

    and [<AllowNullLiteral>] MediaBodyProps =
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] MediaBody =
        React.ClassicComponent<MediaBodyProps, obj>

    and [<AllowNullLiteral>] MediaListProps =
        interface end

    and [<AllowNullLiteral>] MediaList =
        React.ClassicComponent<MediaListProps, obj>

    and [<AllowNullLiteral>] MediaListItemProps =
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] MediaListItem =
        React.ClassicComponent<MediaListItemProps, obj>

    and [<AllowNullLiteral>] MediaProps =
        inherit React.HTMLProps<Media>
        abstract componentClass: React.ReactType option with get, set

    and [<AllowNullLiteral>] MediaClass =
        inherit React.ClassicComponentClass<MediaProps>
        abstract Left: obj with get, set
        abstract Right: obj with get, set
        abstract Heading: obj with get, set
        abstract Body: obj with get, set
        abstract List: obj with get, set
        abstract ListItem: obj with get, set

    and [<AllowNullLiteral>] Media =
        React.ClassicComponent<MediaProps, obj>

    and [<AllowNullLiteral>] bootstrapUtilsType =
        interface end

    and [<AllowNullLiteral>] ValidComponentChildrenType =
        abstract map: Func<obj, obj, obj, obj> with get, set
        abstract forEach: Func<obj, obj, obj, obj> with get, set
        abstract count: Func<obj, float> with get, set
        abstract filter: Func<obj, obj, obj, obj> with get, set
        abstract find: Func<obj, obj, obj, obj> with get, set
        abstract every: Func<obj, obj, obj, obj> with get, set
        abstract some: Func<obj, obj, obj, obj> with get, set
        abstract toArray: Func<obj, obj> with get, set

    and [<AllowNullLiteral>] [<Import("utils","ReactBootstrap")>] utils() =
        member __.bootstrapUtils with get(): bootstrapUtilsType = jsNative and set(v: bootstrapUtilsType): unit = jsNative
        member __.createChainedFunction with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.ValidComponentChildren with get(): ValidComponentChildrenType = jsNative and set(v: ValidComponentChildrenType): unit = jsNative

    type [<Import("*","ReactBootstrap")>] Globals =
        static member Accordion with get(): React.ClassicComponentClass<AccordionProps> = jsNative and set(v: React.ClassicComponentClass<AccordionProps>): unit = jsNative
        static member Breadcrumb with get(): BreadcrumbClass = jsNative and set(v: BreadcrumbClass): unit = jsNative
        static member BreadcrumbItem with get(): React.ClassicComponentClass<BreadcrumbItemProps> = jsNative and set(v: React.ClassicComponentClass<BreadcrumbItemProps>): unit = jsNative
        static member Button with get(): React.ClassicComponentClass<ButtonProps> = jsNative and set(v: React.ClassicComponentClass<ButtonProps>): unit = jsNative
        static member ButtonToolbar with get(): React.ClassicComponentClass<ButtonToolbarProps> = jsNative and set(v: React.ClassicComponentClass<ButtonToolbarProps>): unit = jsNative
        static member ButtonGroup with get(): React.ClassicComponentClass<ButtonGroupProps> = jsNative and set(v: React.ClassicComponentClass<ButtonGroupProps>): unit = jsNative
        static member SafeAnchor with get(): React.ClassicComponentClass<SafeAnchorProps> = jsNative and set(v: React.ClassicComponentClass<SafeAnchorProps>): unit = jsNative
        static member Panel with get(): React.ClassicComponentClass<PanelProps> = jsNative and set(v: React.ClassicComponentClass<PanelProps>): unit = jsNative
        static member PanelGroup with get(): React.ClassicComponentClass<PanelGroupProps> = jsNative and set(v: React.ClassicComponentClass<PanelGroupProps>): unit = jsNative
        static member ModalDialog with get(): React.ClassicComponentClass<ModalDialogProps> = jsNative and set(v: React.ClassicComponentClass<ModalDialogProps>): unit = jsNative
        static member Modal with get(): ModalClass = jsNative and set(v: ModalClass): unit = jsNative
        static member OverlayTrigger with get(): React.ClassicComponentClass<OverlayTriggerProps> = jsNative and set(v: React.ClassicComponentClass<OverlayTriggerProps>): unit = jsNative
        static member Tooltip with get(): React.ClassicComponentClass<TooltipProps> = jsNative and set(v: React.ClassicComponentClass<TooltipProps>): unit = jsNative
        static member Popover with get(): React.ClassicComponentClass<PopoverProps> = jsNative and set(v: React.ClassicComponentClass<PopoverProps>): unit = jsNative
        static member NavItem with get(): React.ClassicComponentClass<NavItemProps> = jsNative and set(v: React.ClassicComponentClass<NavItemProps>): unit = jsNative
        static member NavbarCollapse with get(): React.ClassicComponentClass<NavbarCollapseProps> = jsNative and set(v: React.ClassicComponentClass<NavbarCollapseProps>): unit = jsNative
        static member NavbarHeader with get(): React.ClassicComponentClass<NavbarHeaderProps> = jsNative and set(v: React.ClassicComponentClass<NavbarHeaderProps>): unit = jsNative
        static member NavbarToggle with get(): React.ClassicComponentClass<NavbarToggleProps> = jsNative and set(v: React.ClassicComponentClass<NavbarToggleProps>): unit = jsNative
        static member NavbarLink with get(): React.ClassicComponentClass<NavbarLinkProps> = jsNative and set(v: React.ClassicComponentClass<NavbarLinkProps>): unit = jsNative
        static member NavbarText with get(): React.ClassicComponentClass<NavbarTextProps> = jsNative and set(v: React.ClassicComponentClass<NavbarTextProps>): unit = jsNative
        static member NavbarForm with get(): React.ClassicComponentClass<NavbarFormProps> = jsNative and set(v: React.ClassicComponentClass<NavbarFormProps>): unit = jsNative
        static member Navbar with get(): NavbarClass = jsNative and set(v: NavbarClass): unit = jsNative
        static member Tabs with get(): React.ClassicComponentClass<TabsProps> = jsNative and set(v: React.ClassicComponentClass<TabsProps>): unit = jsNative
        static member Tab with get(): TabClass = jsNative and set(v: TabClass): unit = jsNative
        static member Pager with get(): PagerClass = jsNative and set(v: PagerClass): unit = jsNative
        static member PageItem with get(): React.ClassicComponentClass<PageItemProps> = jsNative and set(v: React.ClassicComponentClass<PageItemProps>): unit = jsNative
        static member Pagination with get(): React.ClassicComponentClass<PaginationProps> = jsNative and set(v: React.ClassicComponentClass<PaginationProps>): unit = jsNative
        static member Alert with get(): React.ClassicComponentClass<AlertProps> = jsNative and set(v: React.ClassicComponentClass<AlertProps>): unit = jsNative
        static member Carousel with get(): CarouselClass = jsNative and set(v: CarouselClass): unit = jsNative
        static member CarouselItem with get(): React.ClassicComponentClass<CarouselItemProps> = jsNative and set(v: React.ClassicComponentClass<CarouselItemProps>): unit = jsNative
        static member CarouselCaption with get(): React.ClassicComponentClass<CarouselCaptionProps> = jsNative and set(v: React.ClassicComponentClass<CarouselCaptionProps>): unit = jsNative
        static member Grid with get(): React.ClassicComponentClass<GridProps> = jsNative and set(v: React.ClassicComponentClass<GridProps>): unit = jsNative
        static member Row with get(): React.ClassicComponentClass<RowProps> = jsNative and set(v: React.ClassicComponentClass<RowProps>): unit = jsNative
        static member Col with get(): React.ClassicComponentClass<ColProps> = jsNative and set(v: React.ClassicComponentClass<ColProps>): unit = jsNative
        static member Thumbnail with get(): React.ClassicComponentClass<ThumbnailProps> = jsNative and set(v: React.ClassicComponentClass<ThumbnailProps>): unit = jsNative
        static member Badge with get(): React.ClassicComponentClass<BadgeProps> = jsNative and set(v: React.ClassicComponentClass<BadgeProps>): unit = jsNative
        static member Jumbotron with get(): React.ClassicComponentClass<JumbotronProps> = jsNative and set(v: React.ClassicComponentClass<JumbotronProps>): unit = jsNative
        static member Image with get(): React.ClassicComponentClass<ImageProps> = jsNative and set(v: React.ClassicComponentClass<ImageProps>): unit = jsNative
        static member Glyphicon with get(): React.ClassicComponentClass<GlyphiconProps> = jsNative and set(v: React.ClassicComponentClass<GlyphiconProps>): unit = jsNative
        static member Table with get(): React.ClassicComponentClass<TableProps> = jsNative and set(v: React.ClassicComponentClass<TableProps>): unit = jsNative
        static member InputGroup with get(): InputGroupClass = jsNative and set(v: InputGroupClass): unit = jsNative
        static member InputGroupAddon with get(): React.ClassicComponentClass<InputGroupAddonProps> = jsNative and set(v: React.ClassicComponentClass<InputGroupAddonProps>): unit = jsNative
        static member InputGroupButton with get(): React.ClassicComponentClass<InputGroupButtonProps> = jsNative and set(v: React.ClassicComponentClass<InputGroupButtonProps>): unit = jsNative
        static member FormControl with get(): FormControlClass = jsNative and set(v: FormControlClass): unit = jsNative
        static member Portal with get(): React.ClassicComponentClass<PortalProps> = jsNative and set(v: React.ClassicComponentClass<PortalProps>): unit = jsNative
        static member MediaLeft with get(): React.ClassicComponentClass<MediaLeftProps> = jsNative and set(v: React.ClassicComponentClass<MediaLeftProps>): unit = jsNative
        static member MediaRight with get(): React.ClassicComponentClass<MediaRightProps> = jsNative and set(v: React.ClassicComponentClass<MediaRightProps>): unit = jsNative
        static member MediaHeading with get(): React.ClassicComponentClass<MediaHeadingProps> = jsNative and set(v: React.ClassicComponentClass<MediaHeadingProps>): unit = jsNative
        static member MediaBody with get(): React.ClassicComponentClass<MediaBodyProps> = jsNative and set(v: React.ClassicComponentClass<MediaBodyProps>): unit = jsNative
        static member MediaList with get(): React.ClassicComponentClass<MediaListProps> = jsNative and set(v: React.ClassicComponentClass<MediaListProps>): unit = jsNative
        static member MediaListItem with get(): React.ClassicComponentClass<MediaListItemProps> = jsNative and set(v: React.ClassicComponentClass<MediaListItemProps>): unit = jsNative
        static member Media with get(): MediaClass = jsNative and set(v: MediaClass): unit = jsNative
        static member createChainedFunctionType([<ParamArray>] funcs: Function[]): Function = jsNative


