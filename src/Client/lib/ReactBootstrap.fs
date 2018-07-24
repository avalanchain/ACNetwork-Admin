// ts2fable 0.6.1
module rec ReactBootstrap
open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser
open Fable.Import.React
open Fable.Import.ReactDomServer

open Client.Helpers
open Fable.Helpers

type Omit<'T, 'K> =
    interface end

type [<StringEnum>] [<RequireQualifiedAccess>] Sizes =
    | Xs
    | Xsmall
    | Sm
    | Small
    | Medium
    | Lg
    | Large

type SelectCallback = React.EventHandler<obj option>

type TransitionCallbacks =
    abstract onEnter: node: HTMLElement -> obj option
    abstract onEntered: node: HTMLElement -> obj option
    abstract onEntering: node: HTMLElement -> obj option
    abstract onExit: node: HTMLElement -> obj option
    abstract onExited: node: HTMLElement -> obj option
    abstract onExiting: node: HTMLElement -> obj option
let [<Import("*","react-bootstrap/lib/Accordion")>] accordion: Accordion.Accordion = jsNative

module Accordion =

    type AccordionProps =
        inherit HTMLProps<Accordion>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract collapsible: bool option with get, set
        abstract defaultExpanded: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract expanded: bool option with get, set
        abstract footer: React.ReactNode option with get, set
        abstract header: React.ReactNode option with get, set

    type [<AbstractClass>] Accordion =
        inherit React.Component<Accordion.AccordionProps>

    type AccordionStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Accordion
let [<Import("*","react-bootstrap/lib/Alert")>] alert: Alert.Alert = jsNative

module Alert =

    type AlertProps =
        inherit React.HTMLProps<Alert>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract closeLabel: string option with get, set
        abstract dismissAfter: float option with get, set
        abstract onDismiss: Function option with get, set

    type [<AbstractClass>] Alert =
        inherit React.Component<Alert.AlertProps>

    type AlertStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Alert
let [<Import("*","react-bootstrap/lib/Badge")>] badge: Badge.Badge = jsNative

module Badge =

    type BadgeProps =
        inherit React.HTMLProps<Badge>
        abstract bsClass: string option with get, set
        abstract pullRight: bool option with get, set

    type [<AbstractClass>] Badge =
        inherit React.Component<Badge.BadgeProps>

    type BadgeStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Badge
let [<Import("*","react-bootstrap/lib/BreadcrumbItem")>] breadcrumbItem: BreadcrumbItem.BreadcrumbItem = jsNative

module BreadcrumbItem =

    type BreadcrumbItemProps =
        inherit React.Props<BreadcrumbItem>
        abstract active: bool option with get, set
        abstract href: string option with get, set
        abstract title: React.ReactNode option with get, set
        abstract target: string option with get, set

    type [<AbstractClass>] BreadcrumbItem =
        inherit React.Component<BreadcrumbItem.BreadcrumbItemProps>

    type BreadcrumbItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> BreadcrumbItem

let [<Import("*","react-bootstrap/lib/Breadcrumb")>] breadcrumb: Breadcrumb.Breadcrumb = jsNative

module Breadcrumb =

    type BreadcrumbProps =
        inherit React.HTMLProps<Breadcrumb>
        abstract bsClass: string option with get, set

    type [<AbstractClass>] Breadcrumb =
        inherit React.Component<Breadcrumb.BreadcrumbProps>
        abstract Item: obj with get, set

    type BreadcrumbStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Breadcrumb
let [<Import("*","react-bootstrap/lib/Button")>] button: Button.Button = jsNative

module Button =

    type ButtonProps =
        inherit React.HTMLProps<Button>
        abstract bsClass: string option with get, set
        abstract active: bool option with get, set
        abstract block: bool option with get, set
        abstract bsStyle: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract disabled: bool option with get, set

    type [<AbstractClass>] Button =
        inherit React.Component<Button.ButtonProps>

    type ButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Button
let [<Import("*","react-bootstrap/lib/ButtonGroup")>] buttonGroup: ButtonGroup.ButtonGroup = jsNative

module ButtonGroup =

    type ButtonGroupProps =
        inherit React.HTMLProps<ButtonGroup>
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract justified: bool option with get, set
        abstract vertical: bool option with get, set

    type [<AbstractClass>] ButtonGroup =
        inherit React.Component<ButtonGroup.ButtonGroupProps>

    type ButtonGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ButtonGroup

let [<Import("*","react-bootstrap/lib/ButtonToolbar")>] buttonToolbar: ButtonToolbar.ButtonToolbar = jsNative

module ButtonToolbar =

    type ButtonToolbarProps =
        inherit React.HTMLProps<ButtonToolbar>
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract justified: bool option with get, set
        abstract vertical: bool option with get, set

    type [<AbstractClass>] ButtonToolbar =
        inherit React.Component<ButtonToolbar.ButtonToolbarProps>

    type ButtonToolbarStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ButtonToolbar
let [<Import("*","react-bootstrap/lib/CarouselItem")>] carouselItem: CarouselItem.CarouselItem = jsNative

module CarouselItem =

    type CarouselItemProps =
        inherit React.HTMLProps<CarouselItem>
        abstract active: bool option with get, set
        abstract animtateIn: bool option with get, set
        abstract animateOut: bool option with get, set
        abstract direction: string option with get, set
        abstract index: float option with get, set
        abstract onAnimateOutEnd: Function option with get, set

    type [<AbstractClass>] CarouselItem =
        inherit React.Component<CarouselItem.CarouselItemProps>

    type CarouselItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> CarouselItem
let [<Import("*","react-bootstrap/lib/CarouselCaption")>] carouselCaption: CarouselCaption.CarouselCaption = jsNative


module CarouselCaption =

    type CarouselCaptionProps =
        inherit React.HTMLProps<CarouselCaption>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] CarouselCaption =
        inherit React.Component<CarouselCaption.CarouselCaptionProps>

    type CarouselCaptionStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> CarouselCaption
let [<Import("*","react-bootstrap/lib/Carousel")>] carousel: Carousel.Carousel = jsNative

module Carousel =

    type CarouselProps =
        interface end

    type [<AbstractClass>] Carousel =
        inherit React.Component<Carousel.CarouselProps>
        abstract Caption: obj with get, set
        abstract Item: obj with get, set

    type CarouselStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Carousel
let [<Import("*","react-bootstrap/lib/Checkbox")>] checkbox: Checkbox.Checkbox = jsNative

module Checkbox =

    type CheckboxProps =
        inherit React.HTMLProps<Checkbox>
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract ``inline``: bool option with get, set
        abstract inputRef: (HTMLInputElement -> unit) option with get, set
        abstract validationState: U3<string, string, string> option with get, set

    type [<AbstractClass>] Checkbox =
        inherit React.Component<Checkbox.CheckboxProps>

    type CheckboxStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Checkbox
let [<Import("*","react-bootstrap/lib/Clearfix")>] clearfix: Clearfix.Clearfix = jsNative

module Clearfix =

    type ClearfixProps =
        inherit React.HTMLProps<Clearfix>
        abstract componentClass: React.ReactType option with get, set
        abstract visibleXsBlock: bool option with get, set
        abstract visibleSmBlock: bool option with get, set
        abstract visibleMdBlock: bool option with get, set
        abstract visibleLgBlock: bool option with get, set

    type [<AbstractClass>] Clearfix =
        inherit React.Component<Clearfix.ClearfixProps>

    type ClearfixStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Clearfix
let [<Import("*","react-bootstrap/lib/Col")>] col: Col.Col = jsNative


module Col =

    type ColProps =
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

    type [<AbstractClass>] Col =
        inherit React.Component<Col.ColProps>

    type ColStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Col
let [<Import("*","react-bootstrap/lib/Collapse")>] collapse: Collapse.Collapse = jsNative


module Collapse =

    type CollapseProps =
        inherit TransitionCallbacks
        inherit HTMLAttributes
        abstract dimension: U3<string, string, obj> option with get, set
        abstract getDimensionValue: (float -> React.ReactElement -> float) option with get, set
        abstract ``in``: bool option with get, set
        abstract timeout: float option with get, set
        abstract transitionAppear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    type [<AbstractClass>] Collapse =
        inherit React.Component<Collapse.CollapseProps>

    type CollapseStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Collapse
let [<Import("*","react-bootstrap/lib/ControlLabel")>] controlLabel: ControlLabel.ControlLabel = jsNative


module ControlLabel =

    type ControlLabelProps =
        inherit React.HTMLProps<ControlLabel>
        abstract bsClass: string option with get, set
        abstract htmlFor: string option with get, set
        abstract srOnly: bool option with get, set

    type [<AbstractClass>] ControlLabel =
        inherit React.Component<ControlLabel.ControlLabelProps>

    type ControlLabelStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ControlLabel
let [<Import("*","react-bootstrap/lib/DropdownToggle")>] dropdownToggle: DropdownToggle.DropdownToggle = jsNative


module DropdownToggle =

    type DropdownToggleProps =
        inherit React.HTMLProps<DropdownToggle>
        abstract bsRole: string option with get, set
        abstract noCaret: bool option with get, set
        abstract ``open``: bool option with get, set
        abstract title: string option with get, set
        abstract useAnchor: bool option with get, set
        abstract bsClass: string option with get, set
        abstract bsStyle: string option with get, set
        abstract bsSize: string option with get, set

    type [<AbstractClass>] DropdownToggle =
        inherit React.Component<DropdownToggle.DropdownToggleProps>

    type DropdownToggleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> DropdownToggle
let [<Import("*","react-bootstrap/lib/DropdownMenu")>] dropdownMenu: DropdownMenu.DropdownMenu = jsNative


module DropdownMenu =

    type DropdownMenuProps =
        inherit React.HTMLProps<DropdownMenu>
        abstract labelledBy: U2<string, float> option with get, set
        abstract onClose: Function option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract ``open``: bool option with get, set
        abstract pullRight: bool option with get, set

    type [<AbstractClass>] DropdownMenu =
        inherit React.Component<DropdownMenu.DropdownMenuProps>

    type DropdownMenuStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> DropdownMenu
let [<Import("*","react-bootstrap/lib/Dropdown")>] dropdown: Dropdown.Dropdown = jsNative


module Dropdown =

    type DropdownBaseProps =
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract disabled: bool option with get, set
        abstract dropup: bool option with get, set
        abstract id: string with get, set
        abstract onClose: Function option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract onToggle: (bool -> unit) option with get, set
        abstract ``open``: bool option with get, set
        abstract pullRight: bool option with get, set
        abstract role: string option with get, set

    type DropdownProps =
        interface end

    type [<AbstractClass>] Dropdown =
        inherit React.Component<Dropdown.DropdownProps>
        abstract Menu: obj with get, set
        abstract Toggle: obj with get, set

    type DropdownStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Dropdown
let [<Import("*","react-bootstrap/lib/DropdownButton")>] dropdownButton: DropdownButton.DropdownButton = jsNative


module DropdownButton =

    type DropdownButtonBaseProps =
        inherit Dropdown.DropdownBaseProps
        abstract block: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract navItem: bool option with get, set
        abstract noCaret: bool option with get, set
        abstract pullRight: bool option with get, set
        abstract title: React.ReactNode with get, set

    type DropdownButtonProps =
        interface end

    type [<AbstractClass>] DropdownButton =
        inherit React.Component<DropdownButton.DropdownButtonProps>

    type DropdownButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> DropdownButton
let [<Import("*","react-bootstrap/lib/Fade")>] fade: Fade.Fade = jsNative


module Fade =

    type FadeProps =
        inherit TransitionCallbacks
        inherit React.HTMLProps<Fade>
        abstract ``in``: bool option with get, set
        abstract timeout: float option with get, set
        abstract mountOnEnter: bool option with get, set
        abstract appear: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    type [<AbstractClass>] Fade =
        inherit React.Component<Fade.FadeProps>

    type FadeStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Fade
let [<Import("*","react-bootstrap/lib/Form")>] form: Form.Form = jsNative


module Form =

    type FormProps =
        inherit React.HTMLProps<Form>
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract horizontal: bool option with get, set
        abstract ``inline``: bool option with get, set

    type [<AbstractClass>] Form =
        inherit React.Component<Form.FormProps>

    type FormStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Form
let [<Import("*","react-bootstrap/lib/FormControlFeedback")>] formControlFeedback: FormControlFeedback.FormControlFeedback = jsNative


module FormControlFeedback =

    type FormControlFeedbackProps =
        React.HTMLProps<FormControlFeedback>

    type [<AbstractClass>] FormControlFeedback =
        inherit React.Component<FormControlFeedback.FormControlFeedbackProps>

    type FormControlFeedbackStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> FormControlFeedback
let [<Import("*","react-bootstrap/lib/FormControlStatic")>] formControlStatic: FormControlStatic.FormControlStatic = jsNative


module FormControlStatic =

    type FormControlStaticProps =
        inherit React.HTMLProps<FormControlStatic>
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] FormControlStatic =
        inherit React.Component<FormControlStatic.FormControlStaticProps>

    type FormControlStaticStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> FormControlStatic
let [<Import("*","react-bootstrap/lib/FormControl")>] formControl: FormControl.FormControl = jsNative

module FormControl =

    type FormControlProps =
        inherit React.HTMLProps<FormControl>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract componentClass: string option with get, set
        abstract id: string option with get, set
        abstract inputRef: (HTMLInputElement -> unit) option with get, set
        abstract ``type``: string option with get, set

    type [<AbstractClass>] FormControl =
        inherit React.Component<FormControl.FormControlProps>
        abstract Feedback: obj with get, set
        abstract Static: obj with get, set

    type FormControlStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> FormControl
let [<Import("*","react-bootstrap/lib/FormGroup")>] formGroup: FormGroup.FormGroup = jsNative


module FormGroup =

    type FormGroupProps =
        inherit React.HTMLProps<FormGroup>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract controlId: string option with get, set
        abstract validationState: U3<string, string, string> option with get, set

    type [<AbstractClass>] FormGroup =
        inherit React.Component<FormGroup.FormGroupProps>

    type FormGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> FormGroup
let [<Import("*","react-bootstrap/lib/Glyphicon")>] glyphicon: Glyphicon.Glyphicon = jsNative


module Glyphicon =

    type GlyphiconProps =
        inherit React.HTMLProps<Glyphicon>
        abstract glyph: string with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>] Glyphicon =
        inherit React.Component<Glyphicon.GlyphiconProps>

    type GlyphiconStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Glyphicon
let [<Import("*","react-bootstrap/lib/Grid")>] grid: Grid.Grid = jsNative


module Grid =

    type GridProps =
        inherit React.HTMLProps<Grid>
        abstract componentClass: React.ReactType option with get, set
        abstract fluid: bool option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>] Grid =
        inherit React.Component<Grid.GridProps>

    type GridStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Grid
let [<Import("*","react-bootstrap/lib/HelpBlock")>] helpBlock: HelpBlock.HelpBlock = jsNative


module HelpBlock =

    type HelpBlockProps =
        inherit React.HTMLProps<HelpBlock>
        abstract bsClass: string option with get, set

    type [<AbstractClass>] HelpBlock =
        inherit React.Component<HelpBlock.HelpBlockProps>

    type HelpBlockStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> HelpBlock
let [<Import("*","react-bootstrap/lib/Image")>] image: Image.Image = jsNative


module Image =

    type ImageProps =
        inherit React.HTMLProps<Image>
        abstract circle: bool option with get, set
        abstract responsive: bool option with get, set
        abstract rounded: bool option with get, set
        abstract thumbnail: bool option with get, set

    type [<AbstractClass>] Image =
        inherit React.Component<Image.ImageProps>

    type ImageStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Image
let [<Import("*","react-bootstrap/lib/InputGroupAddon")>] inputGroupAddon: InputGroupAddon.InputGroupAddon = jsNative


module InputGroupAddon =

    type InputGroupAddonProps =
        React.HTMLProps<InputGroupAddon>

    type [<AbstractClass>] InputGroupAddon =
        inherit React.Component<InputGroupAddon.InputGroupAddonProps>

    type InputGroupAddonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> InputGroupAddon
let [<Import("*","react-bootstrap/lib/InputGroupButton")>] inputGroupButton: InputGroupButton.InputGroupButton = jsNative


module InputGroupButton =

    type InputGroupButtonProps =
        React.HTMLProps<InputGroupButton>

    type [<AbstractClass>] InputGroupButton =
        inherit React.Component<InputGroupButton.InputGroupButtonProps>

    type InputGroupButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> InputGroupButton
let [<Import("*","react-bootstrap/lib/InputGroup")>] inputGroup: InputGroup.InputGroup = jsNative

module InputGroup =

    type InputGroupProps =
        inherit React.HTMLProps<InputGroup>
        abstract bsClass: string option with get, set
        abstract bsSize: Sizes option with get, set

    type [<AbstractClass>] InputGroup =
        inherit React.Component<InputGroup.InputGroupProps>
        abstract Addon: obj with get, set
        abstract Button: obj with get, set

    type InputGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> InputGroup
let [<Import("*","react-bootstrap/lib/Jumbotron")>] jumbotron: Jumbotron.Jumbotron = jsNative

module Jumbotron =

    type JumbotronProps =
        inherit React.HTMLProps<Jumbotron>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] Jumbotron =
        inherit React.Component<Jumbotron.JumbotronProps>

    type JumbotronStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Jumbotron
let [<Import("*","react-bootstrap/lib/Label")>] label: Label.Label = jsNative

module Label =

    type LabelProps =
        inherit React.HTMLProps<Label>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    type [<AbstractClass>] Label =
        inherit React.Component<Label.LabelProps>

    type LabelStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Label
let [<Import("*","react-bootstrap/lib/ListGroup")>] listGroup: ListGroup.ListGroup = jsNative

module ListGroup =

    type ListGroupProps =
        inherit React.HTMLProps<ListGroup>
        abstract bsClass: string option with get, set
        abstract componentClass: React.ReactType option with get, set
        abstract fill: bool option with get, set

    type [<AbstractClass>] ListGroup =
        inherit React.Component<ListGroup.ListGroupProps>

    type ListGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ListGroup
let [<Import("*","react-bootstrap/lib/ListGroupItem")>] listGroupItem: ListGroupItem.ListGroupItem = jsNative

module ListGroupItem =

    type ListGroupItemProps =
        inherit React.HTMLProps<ListGroupItem>
        abstract active: obj option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract eventKey: obj option with get, set
        abstract header: React.ReactNode option with get, set
        abstract listItem: bool option with get, set

    type [<AbstractClass>] ListGroupItem =
        inherit React.Component<ListGroupItem.ListGroupItemProps>

    type ListGroupItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ListGroupItem
let [<Import("*","react-bootstrap/lib/MediaBody")>] mediaBody: MediaBody.MediaBody = jsNative


module MediaBody =

    type MediaBodyProps =
        // inherit React.ClassAttributes<MediaBody>
        inherit HTMLAttributes
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] MediaBody =
        inherit React.Component<MediaBody.MediaBodyProps>

    type MediaBodyStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaBody
let [<Import("*","react-bootstrap/lib/MediaHeading")>] mediaHeading: MediaHeading.MediaHeading = jsNative


module MediaHeading =

    type MediaHeadingProps =
        inherit React.HTMLProps<MediaHeading>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] MediaHeading =
        inherit React.Component<MediaHeading.MediaHeadingProps>

    type MediaHeadingStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaHeading
let [<Import("*","react-bootstrap/lib/MediaLeft")>] mediaLeft: MediaLeft.MediaLeft = jsNative


module MediaLeft =

    type MediaLeftProps =
        inherit React.HTMLProps<MediaLeft>
        abstract align: string option with get, set

    type [<AbstractClass>] MediaLeft =
        inherit React.Component<MediaLeft.MediaLeftProps>

    type MediaLeftStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaLeft
let [<Import("*","react-bootstrap/lib/MediaList")>] mediaList: MediaList.MediaList = jsNative


module MediaList =

    type MediaListProps =
        React.HTMLProps<MediaList>

    type [<AbstractClass>] MediaList =
        inherit React.Component<MediaList.MediaListProps>

    type MediaListStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaList
let [<Import("*","react-bootstrap/lib/MediaListItem")>] mediaListItem: MediaListItem.MediaListItem = jsNative


module MediaListItem =

    type MediaListItemProps =
        inherit React.HTMLProps<MediaListItem>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] MediaListItem =
        inherit React.Component<MediaListItem.MediaListItemProps>

    type MediaListItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaListItem
let [<Import("*","react-bootstrap/lib/MediaRight")>] mediaRight: MediaRight.MediaRight = jsNative


module MediaRight =

    type MediaRightProps =
        inherit React.HTMLProps<MediaRight>
        abstract align: string option with get, set

    type [<AbstractClass>] MediaRight =
        inherit React.Component<MediaRight.MediaRightProps>

    type MediaRightStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MediaRight
let [<Import("*","react-bootstrap/lib/Media")>] media: Media.Media = jsNative

module Media =

    type MediaProps =
        inherit React.HTMLProps<Media>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] Media =
        inherit React.Component<Media.MediaProps>
        abstract Body: obj with get, set
        abstract Heading: obj with get, set
        abstract Left: obj with get, set
        abstract Right: obj with get, set
        abstract List: obj with get, set
        abstract ListItem: obj with get, set

    type MediaStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Media
let [<Import("*","react-bootstrap/lib/MenuItem")>] menuItem: MenuItem.MenuItem = jsNative

module MenuItem =

    type MenuItemProps =
        inherit React.HTMLProps<MenuItem>
        abstract active: bool option with get, set
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract divider: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract header: bool option with get, set
        abstract onClick: React.MouseEventHandler option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract target: string option with get, set
        abstract title: string option with get, set

    type [<AbstractClass>] MenuItem =
        inherit React.Component<MenuItem.MenuItemProps>

    type MenuItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> MenuItem
let [<Import("*","react-bootstrap/lib/ModalBody")>] modalBody: ModalBody.ModalBody = jsNative


module ModalBody =

    type ModalBodyProps =
        inherit React.HTMLProps<ModalBody>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] ModalBody =
        inherit React.Component<ModalBody.ModalBodyProps>

    type ModalBodyStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModalBody
let [<Import("*","react-bootstrap/lib/ModalHeader")>] modalHeader: ModalHeader.ModalHeader = jsNative

module ModalHeader =

    type ModalHeaderProps =
        inherit React.HTMLProps<ModalHeader>
        abstract closeButton: bool option with get, set
        abstract closeLabel: string option with get, set
        abstract onHide: Function option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>] ModalHeader =
        inherit React.Component<ModalHeader.ModalHeaderProps>

    type ModalHeaderStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModalHeader
let [<Import("*","react-bootstrap/lib/ModalTitle")>] modalTitle: ModalTitle.ModalTitle = jsNative


module ModalTitle =

    type ModalTitleProps =
        inherit React.HTMLProps<ModalTitle>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] ModalTitle =
        inherit React.Component<ModalTitle.ModalTitleProps>

    type ModalTitleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModalTitle
let [<Import("*","react-bootstrap/lib/ModalDialog")>] modalDialog: ModalDialog.ModalDialog = jsNative

module ModalDialog =

    type ModalDialogProps =
        inherit React.HTMLProps<ModalDialog>
        abstract onHide: Function option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExited: Function option with get, set
        abstract onExiting: Function option with get, set

    type [<AbstractClass>] ModalDialog =
        inherit React.Component<ModalDialog.ModalDialogProps>

    type ModalDialogStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModalDialog
let [<Import("*","react-bootstrap/lib/ModalFooter")>] modalFooter: ModalFooter.ModalFooter = jsNative


module ModalFooter =

    type ModalFooterProps =
        inherit React.HTMLProps<ModalFooter>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>] ModalFooter =
        inherit React.Component<ModalFooter.ModalFooterProps>

    type ModalFooterStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModalFooter
let [<Import("*","react-bootstrap/lib/Modal")>] modal: Modal.Modal = jsNative

module Modal =

    type ModalProps =
        inherit TransitionCallbacks
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
        abstract onBackdropClick: (HTMLElement -> obj option) option with get, set
        abstract onEscapeKeyUp: (HTMLElement -> obj option) option with get, set
        abstract onShow: (HTMLElement -> obj option) option with get, set
        abstract show: bool option with get, set
        abstract transition: React.ReactElement option with get, set

    type [<AbstractClass>] Modal =
        inherit React.Component<Modal.ModalProps>
        abstract Body: obj with get, set
        abstract Header: obj with get, set
        abstract Title: obj with get, set
        abstract Footer: obj with get, set
        abstract Dialog: obj with get, set

    type ModalStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Modal
let [<Import("*","react-bootstrap/lib/Nav")>] nav: Nav.Nav = jsNative

module Nav =

    type NavProps =
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

    type [<AbstractClass>] Nav =
        inherit React.Component<Nav.NavProps>

    type NavStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Nav
let [<Import("*","react-bootstrap/lib/NavbarBrand")>] navbarBrand: NavbarBrand.NavbarBrand = jsNative


module NavbarBrand =

    type NavbarBrandProps =
        React.HTMLProps<NavbarBrand>

    type [<AbstractClass>] NavbarBrand =
        inherit React.Component<NavbarBrand.NavbarBrandProps>

    type NavbarBrandStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarBrand
let [<Import("*","react-bootstrap/lib/NavbarCollapse")>] navbarCollapse: NavbarCollapse.NavbarCollapse = jsNative


module NavbarCollapse =

    type NavbarCollapseProps =
        React.HTMLProps<NavbarCollapse>

    type [<AbstractClass>] NavbarCollapse =
        inherit React.Component<NavbarCollapse.NavbarCollapseProps>

    type NavbarCollapseStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarCollapse
let [<Import("*","react-bootstrap/lib/NavbarHeader")>] navbarHeader: NavbarHeader.NavbarHeader = jsNative


module NavbarHeader =

    type NavbarHeaderProps =
        React.HTMLProps<NavbarHeader>

    type [<AbstractClass>] NavbarHeader =
        inherit React.Component<NavbarHeader.NavbarHeaderProps>

    type NavbarHeaderStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarHeader
let [<Import("*","react-bootstrap/lib/NavbarToggle")>] navbarToggle: NavbarToggle.NavbarToggle = jsNative


module NavbarToggle =

    type NavbarToggleProps =
        inherit React.HTMLProps<NavbarToggle>
        abstract onClick: React.MouseEventHandler option with get, set

    type [<AbstractClass>] NavbarToggle =
        inherit React.Component<NavbarToggle.NavbarToggleProps>

    type NavbarToggleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarToggle
let [<Import("*","react-bootstrap/lib/Navbar")>] navbar: Navbar.NavbarExports = jsNative

module Navbar =
    type NavbarExports =
        abstract Navbar: Navbar
        abstract NavbarLink: NavbarLink
        abstract NavbarText: NavbarText
        abstract NavbarForm: NavbarForm

    type NavbarProps =
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
        abstract expanded: bool option with get, set
        abstract onToggle: Function option with get, set
        abstract staticTop: bool option with get, set
        abstract toggleButton: obj option with get, set
        abstract toggleNavKey: U2<string, float> option with get, set

    type [<AbstractClass>] Navbar =
        inherit React.Component<Navbar.NavbarProps>
        abstract Brand: obj with get, set
        abstract Collapse: obj with get, set
        abstract Header: obj with get, set
        abstract Toggle: obj with get, set
        abstract Link: obj with get, set
        abstract Text: obj with get, set
        abstract Form: obj with get, set

    type NavbarStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Navbar

    /// the classes below aren't present in lib/
    type NavbarLinkProps =
        inherit React.HTMLProps<NavbarLink>
        abstract href: string with get, set
        abstract onClick: React.MouseEventHandler option with get, set

    type [<AbstractClass>] NavbarLink =
        inherit React.Component<NavbarLinkProps>

    type NavbarLinkStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarLink

    type NavbarTextProps =
        inherit React.HTMLProps<NavbarText>
        abstract pullRight: bool option with get, set

    type [<AbstractClass>] NavbarText =
        inherit React.Component<NavbarTextProps>

    type NavbarTextStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarText

    type NavbarFormProps =
        inherit React.HTMLProps<NavbarForm>
        abstract componentClass: React.ReactType option with get, set
        abstract pullRight: bool option with get, set
        abstract pullLeft: bool option with get, set

    type [<AbstractClass>] NavbarForm =
        inherit React.Component<NavbarFormProps>

    type NavbarFormStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavbarForm
let [<Import("*","react-bootstrap/lib/NavDropdown")>] navDropdown: NavDropdown.NavDropdown = jsNative


module NavDropdown =

    type NavDropdownBaseProps =
        inherit Dropdown.DropdownBaseProps
        abstract active: bool option with get, set
        abstract noCaret: bool option with get, set
        abstract eventKey: obj option with get, set

    type NavDropdownProps =
        interface end

    type [<AbstractClass>] NavDropdown =
        inherit React.Component<NavDropdown.NavDropdownProps>

    type NavDropdownStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavDropdown
let [<Import("*","react-bootstrap/lib/NavItem")>] navItem: NavItem.NavItem = jsNative

module NavItem =

    type NavItemProps =
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

    type [<AbstractClass>] NavItem =
        inherit React.Component<NavItem.NavItemProps>

    type NavItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> NavItem
let [<Import("*","react-bootstrap/lib/Overlay")>] overlay: Overlay.Overlay = jsNative

module Overlay =

    type OverlayProps =
        inherit TransitionCallbacks
        abstract animation: obj option with get, set
        abstract container: obj option with get, set
        abstract containerPadding: float option with get, set
        abstract onHide: Function option with get, set
        abstract placement: string option with get, set
        abstract rootClose: bool option with get, set
        abstract show: bool option with get, set
        abstract target: U2<Function, React.ReactInstance> option with get, set
        abstract shouldUpdatePosition: bool option with get, set

    type [<AbstractClass>] Overlay =
        inherit React.Component<Overlay.OverlayProps>

    type OverlayStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Overlay
let [<Import("*","react-bootstrap/lib/OverlayTrigger")>] overlayTrigger: OverlayTrigger.OverlayTrigger = jsNative


module OverlayTrigger =

    type OverlayTriggerProps =
        inherit React.Props<OverlayTrigger>
        abstract overlay: obj option with get, set
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

    type [<AbstractClass>] OverlayTrigger =
        inherit React.Component<OverlayTrigger.OverlayTriggerProps>

    type OverlayTriggerStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> OverlayTrigger
let [<Import("*","react-bootstrap/lib/PageHeader")>] pageHeader: PageHeader.PageHeader = jsNative


module PageHeader =

    type PageHeaderProps =
        React.HTMLProps<PageHeader>

    type [<AbstractClass>] PageHeader =
        inherit React.Component<PageHeader.PageHeaderProps>

    type PageHeaderStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PageHeader
let [<Import("*","react-bootstrap/lib/PagerItem")>] pagerItem: PagerItem.PagerItem = jsNative


module PagerItem =

    type PagerItemProps =
        inherit React.HTMLProps<PagerItem>
        abstract disabled: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract next: bool option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract previous: bool option with get, set
        abstract target: string option with get, set

    type [<AbstractClass>] PagerItem =
        inherit React.Component<PagerItem.PagerItemProps>

    type PagerItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PagerItem
let [<Import("*","react-bootstrap/lib/PageItem")>] pageItem: PageItem.PageItem = jsNative


module PageItem =

    type PageItemProps =
        inherit React.HTMLProps<PageItem>

    type [<AbstractClass>]PageItem =
        inherit React.Component<PageItem.PageItemProps>

    type PageItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PageItem
let [<Import("*","react-bootstrap/lib/Pager")>] pager: Pager.Pager = jsNative

module Pager =

    type PagerProps =
        inherit React.HTMLProps<Pager>
        abstract onSelect: SelectCallback option with get, set

    type [<AbstractClass>]Pager =
        inherit React.Component<Pager.PagerProps>
        abstract Item: obj with get, set

    type PagerStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Pager
let [<Import("First","react-bootstrap/lib/Pagination")>] paginationFirst: PaginationFirst.PaginationFirst = jsNative


module PaginationFirst =

    type PaginationFirstProps =
        inherit React.HTMLProps<PaginationFirst>
        abstract disabled: bool option with get, set

    type [<AbstractClass>]PaginationFirst =
        inherit React.Component<PaginationFirst.PaginationFirstProps>

    type PaginationFirstStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationFirst
let [<Import("Prev","react-bootstrap/lib/Pagination")>] paginationPrev: PaginationPrev.PaginationPrev = jsNative


module PaginationPrev =

    type PaginationPrevProps =
        inherit React.HTMLProps<PaginationPrev>
        abstract disabled: bool option with get, set

    type [<AbstractClass>]PaginationPrev =
        inherit React.Component<PaginationPrev.PaginationPrevProps>

    type PaginationPrevStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationPrev
let [<Import("Next","react-bootstrap/lib/Pagination")>] paginationNext: PaginationNext.PaginationNext = jsNative


module PaginationNext =

    type PaginationNextProps =
        inherit React.HTMLProps<PaginationNext>
        abstract disabled: bool option with get, set

    type [<AbstractClass>]PaginationNext =
        inherit React.Component<PaginationNext.PaginationNextProps>

    type PaginationNextStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationNext
let [<Import("Last","react-bootstrap/lib/Pagination")>] paginationLast: PaginationLast.PaginationLast = jsNative


module PaginationLast =

    type PaginationLastProps =
        inherit React.HTMLProps<PaginationLast>
        abstract disabled: bool option with get, set

    type [<AbstractClass>]PaginationLast =
        inherit React.Component<PaginationLast.PaginationLastProps>

    type PaginationLastStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationLast
let [<Import("Ellipsis","react-bootstrap/lib/Pagination")>] paginationEllipsis: PaginationEllipsis.PaginationEllipsis = jsNative


module PaginationEllipsis =

    type PaginationEllipsisProps =
        inherit React.HTMLProps<PaginationEllipsis>
        abstract disabled: bool option with get, set

    type [<AbstractClass>]PaginationEllipsis =
        inherit React.Component<PaginationEllipsis.PaginationEllipsisProps>

    type PaginationEllipsisStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationEllipsis
let [<Import("*","react-bootstrap/lib/PaginationItem")>] paginationItem: PaginationItem.PaginationItem = jsNative


module PaginationItem =

    type PaginationItemProps =
        inherit React.HTMLProps<PaginationItem>
        abstract disabled: bool option with get, set
        abstract active: bool option with get, set

    type [<AbstractClass>]PaginationItem =
        inherit React.Component<PaginationItem.PaginationItemProps>

    type PaginationItemStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PaginationItem
let [<Import("*","react-bootstrap/lib/Pagination")>] pagination: Pagination.Pagination = jsNative


module Pagination =

    type PaginationProps =
        inherit React.HTMLProps<Pagination>
        abstract bsSize: Sizes option with get, set

    type [<AbstractClass>]Pagination =
        inherit React.Component<Pagination.PaginationProps>
        abstract First: obj with get, set
        abstract Prev: obj with get, set
        abstract Next: obj with get, set
        abstract Last: obj with get, set
        abstract Ellipsis: obj with get, set
        abstract Item: obj with get, set

    type PaginationStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Pagination
let [<Import("*","react-bootstrap/lib/PanelHeading")>] panelHeading: PanelHeading.PanelHeading = jsNative


module PanelHeading =

    type PanelHeadingProps =
        inherit React.HTMLProps<PanelHeading>
        abstract componentClass: string option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>]PanelHeading =
        inherit React.Component<PanelHeading.PanelHeadingProps>

    type PanelHeadingStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelHeading
let [<Import("*","react-bootstrap/lib/PanelTitle")>] panelTitle: PanelTitle.PanelTitle = jsNative


module PanelTitle =

    type PanelTitleProps =
        inherit React.HTMLProps<PanelTitle>
        abstract componentClass: string option with get, set
        abstract bsClass: string option with get, set
        abstract toggle: bool option with get, set

    type [<AbstractClass>]PanelTitle =
        inherit React.Component<PanelTitle.PanelTitleProps>

    type PanelTitleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelTitle
let [<Import("*","react-bootstrap/lib/PanelToggle")>] panelToggle: PanelToggle.PanelToggle = jsNative


module PanelToggle =

    type PanelToggleProps =
        inherit React.HTMLProps<PanelToggle>
        abstract componentClass: string option with get, set

    type [<AbstractClass>]PanelToggle =
        inherit React.Component<PanelToggle.PanelToggleProps>

    type PanelToggleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelToggle
let [<Import("*","react-bootstrap/lib/PanelCollapse")>] panelCollapse: PanelCollapse.PanelCollapse = jsNative


module PanelCollapse =

    type PanelCollapseProps =
        inherit React.HTMLProps<PanelCollapse>
        abstract bsClass: string option with get, set
        abstract onEnter: Function option with get, set
        abstract onEntering: Function option with get, set
        abstract onEntered: Function option with get, set
        abstract onExit: Function option with get, set
        abstract onExiting: Function option with get, set
        abstract onExited: Function option with get, set

    type [<AbstractClass>]PanelCollapse =
        inherit React.Component<PanelCollapse.PanelCollapseProps>

    type PanelCollapseStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelCollapse
let [<Import("*","react-bootstrap/lib/PanelBody")>] panelBody: PanelBody.PanelBody = jsNative

module PanelBody =

    type PanelBodyProps =
        inherit React.HTMLProps<PanelBody>
        abstract collapsible: bool option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>]PanelBody =
        inherit React.Component<PanelBody.PanelBodyProps>

    type PanelBodyStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelBody
let [<Import("*","react-bootstrap/lib/PanelFooter")>] panelFooter: PanelFooter.PanelFooter = jsNative


module PanelFooter =

    type PanelFooterProps =
        inherit React.HTMLProps<PanelFooter>
        abstract bsClass: string option with get, set

    type [<AbstractClass>]PanelFooter =
        inherit React.Component<PanelFooter.PanelFooterProps>

    type PanelFooterStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelFooter
let [<Import("*","react-bootstrap/lib/Panel")>] panel: Panel.Panel = jsNative


module Panel =

    type PanelProps =
        inherit TransitionCallbacks
        inherit React.HTMLProps<Panel>
        abstract bsStyle: string option with get, set
        abstract defaultExpanded: bool option with get, set
        abstract eventKey: obj option with get, set
        abstract expanded: bool option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract onToggle: SelectCallback option with get, set

    type [<AbstractClass>]Panel =
        inherit React.Component<Panel.PanelProps>
        abstract Heading: obj with get, set
        abstract Title: obj with get, set
        abstract Toggle: obj with get, set
        abstract Collapse: obj with get, set
        abstract Body: obj with get, set
        abstract Footer: obj with get, set

    type PanelStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Panel
let [<Import("*","react-bootstrap/lib/PanelGroup")>] panelGroup: PanelGroup.PanelGroup = jsNative


module PanelGroup =

    type PanelGroupProps =
        inherit React.HTMLProps<PanelGroup>
        abstract accordion: bool option with get, set
        abstract activeKey: obj option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract role: string option with get, set
        abstract generateChildId: Function option with get, set

    type [<AbstractClass>]PanelGroup =
        inherit React.Component<PanelGroup.PanelGroupProps>

    type PanelGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> PanelGroup
let [<Import("*","react-bootstrap/lib/Popover")>] popover: Popover.Popover = jsNative


module Popover =

    type PopoverProps =
        inherit Omit<React.HTMLProps<Popover>, string>
        abstract arrowOffsetLeft: U2<float, string> option with get, set
        abstract arrowOffsetTop: U2<float, string> option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract placement: string option with get, set
        abstract positionLeft: U2<float, string> option with get, set
        abstract positionTop: U2<float, string> option with get, set
        abstract title: React.ReactNode option with get, set

    type [<AbstractClass>]Popover =
        inherit React.Component<Popover.PopoverProps>

    type PopoverStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Popover
let [<Import("*","react-bootstrap/lib/ProgressBar")>] progressBar: ProgressBar.ProgressBar = jsNative


module ProgressBar =

    type ProgressBarProps =
        inherit Omit<React.HTMLProps<ProgressBar>, string>
        abstract active: bool option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract interpolatedClass: obj option with get, set
        abstract max: float option with get, set
        abstract min: float option with get, set
        abstract now: float option with get, set
        abstract srOnly: bool option with get, set
        abstract striped: bool option with get, set
        abstract label: React.ReactNode option with get, set

    type [<AbstractClass>]ProgressBar =
        inherit React.Component<ProgressBar.ProgressBarProps>

    type ProgressBarStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ProgressBar
let [<Import("*","react-bootstrap/lib/Radio")>] radio: Radio.Radio = jsNative


module Radio =

    type RadioProps =
        inherit React.HTMLProps<Radio>
        abstract bsClass: string option with get, set
        abstract disabled: bool option with get, set
        abstract ``inline``: bool option with get, set
        abstract inputRef: (HTMLInputElement -> unit) option with get, set
        abstract validationState: U3<string, string, string> option with get, set

    type [<AbstractClass>]Radio =
        inherit React.Component<Radio.RadioProps>

    type RadioStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Radio
let [<Import("*","react-bootstrap/lib/ResponsiveEmbed")>] responsiveEmbed: ResponsiveEmbed.ResponsiveEmbed = jsNative


module ResponsiveEmbed =

    type ResponsiveEmbedProps =
        inherit React.HTMLProps<ResponsiveEmbed>
        abstract a16by9: bool option with get, set
        abstract a4by3: bool option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>]ResponsiveEmbed =
        inherit React.Component<ResponsiveEmbed.ResponsiveEmbedProps>

    type ResponsiveEmbedStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ResponsiveEmbed
let [<Import("*","react-bootstrap/lib/Row")>] row: Row.Row = jsNative


module Row =

    type RowProps =
        inherit React.HTMLProps<Row>
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>]Row =
        inherit React.Component<Row.RowProps>

    type RowStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Row
let [<Import("*","react-bootstrap/lib/SafeAnchor")>] safeAnchor: SafeAnchor.SafeAnchor = jsNative


module SafeAnchor =

    type SafeAnchorProps =
        inherit React.HTMLProps<SafeAnchor>
        abstract href: string option with get, set
        abstract onClick: React.MouseEventHandler option with get, set
        abstract disabled: bool option with get, set
        abstract role: string option with get, set
        abstract componentClass: React.ReactType option with get, set

    type [<AbstractClass>]SafeAnchor =
        inherit React.Component<SafeAnchor.SafeAnchorProps>

    type SafeAnchorStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SafeAnchor
let [<Import("*","react-bootstrap/lib/SplitButton")>] splitButton: SplitButton.SplitButton = jsNative


module SplitButton =

    type SplitButtonProps =
        inherit Omit<React.HTMLProps<SplitButton>, string>
        abstract bsStyle: string option with get, set
        abstract bsSize: Sizes option with get, set
        abstract dropdownTitle: obj option with get, set
        abstract dropup: bool option with get, set
        abstract pullRight: bool option with get, set
        abstract title: React.ReactNode with get, set
        abstract id: string with get, set

    type [<AbstractClass>]SplitButton =
        inherit React.Component<SplitButton.SplitButtonProps>

    type SplitButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SplitButton
let [<Import("*","react-bootstrap/lib/SplitToggle")>] splitToggle: SplitToggle.SplitToggle = jsNative


module SplitToggle =

    type SplitToggleProps =
        interface end

    type [<AbstractClass>]SplitToggle =
        inherit React.Component<SplitToggle.SplitToggleProps>

    type SplitToggleStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SplitToggle
let [<Import("*","react-bootstrap/lib/TabContainer")>] tabContainer: TabContainer.TabContainer = jsNative


module TabContainer =

    type TabContainerProps =
        inherit React.HTMLProps<TabContainer>
        abstract activeKey: obj option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract generateChildId: (obj option -> obj option -> string) option with get, set

    type [<AbstractClass>]TabContainer =
        inherit React.Component<TabContainer.TabContainerProps>

    type TabContainerStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> TabContainer
let [<Import("*","react-bootstrap/lib/TabPane")>] tabPane: TabPane.TabPane = jsNative


module TabPane =

    type TabPaneProps =
        inherit TransitionCallbacks
        inherit React.HTMLProps<TabPane>
        abstract animation: U2<bool, React.ComponentClass<obj option>> option with get, set
        abstract ``aria-labelledby``: string option with get, set
        abstract bsClass: string option with get, set
        abstract eventKey: obj option with get, set
        abstract mountOnEnter: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    type [<AbstractClass>]TabPane =
        inherit React.Component<TabPane.TabPaneProps>

    type TabPaneStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> TabPane
let [<Import("*","react-bootstrap/lib/TabContent")>] tabContent: TabContent.TabContent = jsNative


module TabContent =

    type TabContentProps =
        inherit React.HTMLProps<TabContent>
        abstract componentClass: React.ReactType option with get, set
        abstract animation: U2<bool, React.ReactType> option with get, set
        abstract mountOnEnter: bool option with get, set
        abstract unmountOnExit: bool option with get, set

    type [<AbstractClass>]TabContent =
        inherit React.Component<TabContent.TabContentProps>

    type TabContentStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> TabContent
let [<Import("*","react-bootstrap/lib/Tab")>] tab: Tab.Tab = jsNative


module Tab =

    type TabProps =
        inherit TransitionCallbacks
        inherit Omit<React.HTMLProps<Tab>, string>
        abstract animation: bool option with get, set
        abstract ``aria-labelledby``: string option with get, set
        abstract bsClass: string option with get, set
        abstract eventKey: obj option with get, set
        abstract unmountOnExit: bool option with get, set
        abstract tabClassName: string option with get, set
        abstract title: string option with get, set

    type [<AbstractClass>]Tab =
        inherit React.Component<Tab.TabProps>
        abstract Container: obj with get, set
        abstract Content: obj with get, set
        abstract Pane: obj with get, set

    type TabStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Tab
let [<Import("*","react-bootstrap/lib/Table")>] table: Table.Table = jsNative


module Table =

    type TableProps =
        inherit React.HTMLProps<Table>
        abstract bordered: bool option with get, set
        abstract condensed: bool option with get, set
        abstract hover: bool option with get, set
        abstract responsive: bool option with get, set
        abstract striped: bool option with get, set
        abstract fill: bool option with get, set
        abstract bsClass: string option with get, set

    type [<AbstractClass>]Table =
        inherit React.Component<Table.TableProps>

    type TableStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Table
let [<Import("*","react-bootstrap/lib/Tabs")>] tabs: Tabs.Tabs = jsNative


module Tabs =

    type TabsProps =
        inherit React.HTMLProps<Tabs>
        abstract activeKey: obj option with get, set
        abstract animation: bool option with get, set
        abstract bsStyle: string option with get, set
        abstract defaultActiveKey: obj option with get, set
        abstract onSelect: SelectCallback option with get, set
        abstract paneWidth: obj option with get, set
        abstract position: string option with get, set
        abstract tabWidth: obj option with get, set
        abstract mountOnEnter: bool option with get, set
        abstract unmountOnExit: bool option with get, set
        abstract justified: bool option with get, set

    type [<AbstractClass>]Tabs =
        inherit React.Component<Tabs.TabsProps>

    type TabsStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Tabs
let [<Import("*","react-bootstrap/lib/Thumbnail")>] thumbnail: Thumbnail.Thumbnail = jsNative


module Thumbnail =

    type ThumbnailProps =
        inherit React.HTMLProps<Thumbnail>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    type [<AbstractClass>]Thumbnail =
        inherit React.Component<Thumbnail.ThumbnailProps>

    type ThumbnailStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Thumbnail
let [<Import("*","react-bootstrap/lib/ToggleButton")>] toggleButton: ToggleButton.ToggleButton = jsNative


module ToggleButton =

    type ToggleButtonProps =
        inherit React.HTMLProps<ToggleButton>
        abstract ``checked``: bool option with get, set
        abstract name: string option with get, set
        abstract value: U2<float, string> with get, set

    type [<AbstractClass>]ToggleButton =
        inherit React.Component<ToggleButtonProps>

    type ToggleButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ToggleButton

let [<Import("*","react-bootstrap/lib/ToggleButtonGroup")>] private toggleButtonGroup_: obj = jsNative
let toggleButtonGroup<'P when 'P :> ToggleButtonGroup.BaseProps> = toggleButtonGroup_ :?> ToggleButtonGroup.ToggleButtonGroup<'P> 


module ToggleButtonGroup =

    type BaseProps =
        /// You'll usually want to use string|number|string[]|number[] here,
        /// but you can technically use any|any[].
        abstract defaultValue: obj option with get, set
        /// You'll usually want to use string|number|string[]|number[] here,
        /// but you can technically use any|any[].
        abstract value: obj option with get, set

    type RadioProps =
        inherit BaseProps
        /// Required if `type` is set to "radio" 
        abstract name: string with get, set
        abstract ``type``: string with get, set
        abstract onChange: value: obj option -> unit

    type CheckboxProps =
        inherit BaseProps
        abstract name: string option with get, set
        abstract ``type``: string with get, set
        abstract onChange: values: ResizeArray<obj option> -> unit

    type ToggleButtonGroupProps =
        inherit BaseProps

    type [<AbstractClass>]ToggleButtonGroup<'T when 'T :> BaseProps> =
        inherit React.Component<'T>

    type ToggleButtonGroupStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ToggleButtonGroup<BaseProps>
let [<Import("*","react-bootstrap/lib/Tooltip")>] tooltip: Tooltip.Tooltip = jsNative


module Tooltip =

    type TooltipProps =
        inherit React.HTMLProps<Tooltip>
        abstract arrowOffsetLeft: U2<float, string> option with get, set
        abstract arrowOffsetTop: U2<float, string> option with get, set
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set
        abstract placement: string option with get, set
        abstract positionLeft: float option with get, set
        abstract positionTop: float option with get, set

    type [<AbstractClass>]Tooltip =
        inherit React.Component<Tooltip.TooltipProps>

    type TooltipStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Tooltip
let [<Import("*","react-bootstrap/lib/Well")>] well: Well.WellExports = jsNative


module Well =

    type WellProps =
        inherit React.HTMLProps<Well>
        abstract bsSize: Sizes option with get, set
        abstract bsStyle: string option with get, set

    type [<AbstractClass>]Well =
        inherit React.Component<Well.WellProps>

    type WellStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Well

    type WellExports =
        abstract prefix: props: PrefixProps * ?variant: string -> string
        abstract bsClass: defaultClass: obj option * Component: obj option -> obj option
        abstract bsStyles: styles: obj option * defaultStyle: obj option * Component: obj option -> obj option
        abstract bsSizes: sizes: obj option * defaultSize: obj option * Component: obj option -> obj option
        abstract getClassSet: props: obj option -> obj option
        abstract getBsProps: props: obj option -> BSProps
        abstract isBsProp: propName: string -> bool
        abstract splitBsProps: props: obj option -> BSProps * obj option
        abstract splitBsPropsAndOmit: props: obj option * omittedPropNames: obj option -> BSProps * obj option
        abstract addStyle: Component: obj option * [<ParamArray>] styleVariant: ResizeArray<obj option> -> obj option

    type PrefixProps =
        abstract bsClass: obj option with get, set

    type BSProps =
        abstract bsClass: obj option with get, set
        abstract bsSize: obj option with get, set
        abstract bsStyle: obj option with get, set
        abstract bsRole: obj option with get, set

