namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.ReactHelpers


type [<AllowNullLiteral>] UncontrolledProps =
    abstract className: string option with get, set
    abstract color: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract transitionAppearTimeout: float option with get, set
    abstract transitionEnterTimeout: float option with get, set
    abstract transitionLeaveTimeout: float option with get, set

and [<AllowNullLiteral>] Props =
    inherit UncontrolledProps
    abstract isOpen: bool option with get, set
    abstract toggle: Func<unit, unit> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Alert with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


type [<AllowNullLiteral>] Props =
    abstract color: string option with get, set
    abstract pill: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Badge with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


type [<AllowNullLiteral>] Props =
    abstract tag: string option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Breadcrumb with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract active: bool option with get, set
    abstract className: string option with get, set
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: others: string -> obj with get, set

type [<Erase>]Globals =
    [<Global>] static member BreadcrumbItem with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    inherit React.HTMLProps<HTMLButtonElement>
    abstract outline: bool option with get, set
    abstract active: bool option with get, set
    abstract block: bool option with get, set
    abstract color: string option with get, set
    abstract disabled: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract onClick: React.MouseEventHandler<obj> option with get, set
    abstract size: obj option with get, set
    abstract id: string option with get, set
    abstract style: React.CSSProperties option with get, set

type [<Erase>]Globals =
    [<Global>] static member Button with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] UncontrolledProps =
    inherit DropdownUncontrolledProps


and [<AllowNullLiteral>] Props =
    inherit DropdownProps


type [<Erase>]Globals =
    [<Global>] static member ButtonDropdown with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract ``aria-label``: string option with get, set
    abstract className: string option with get, set
    abstract role: string option with get, set
    abstract size: string option with get, set
    abstract vertical: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member ButtonGroup with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract ``aria-label``: string option with get, set
    abstract className: string option with get, set
    abstract role: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ButtonToolbar with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract inverse: bool option with get, set
    abstract color: string option with get, set
    abstract block: bool option with get, set
    abstract outline: bool option with get, set
    abstract className: string option with get, set
    abstract style: React.CSSProperties option with get, set

type [<Erase>]Globals =
    [<Global>] static member Card with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardBlock with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardColumns with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardDeck with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardFooter with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardGroup with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardHeader with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract top: bool option with get, set
    abstract bottom: bool option with get, set
    abstract className: string option with get, set
    abstract src: string option with get, set
    abstract width: string option with get, set
    abstract height: string option with get, set
    abstract alt: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardImg with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardImgOverlay with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set
    abstract href: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardLink with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardSubtitle with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardText with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member CardTitle with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] ColumnProps =
    U4<string, bool, float, obj>

and [<AllowNullLiteral>] Props =
    abstract xs: ColumnProps option with get, set
    abstract sm: ColumnProps option with get, set
    abstract md: ColumnProps option with get, set
    abstract lg: ColumnProps option with get, set
    abstract xl: ColumnProps option with get, set
    abstract widths: ResizeArray<string> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Col with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    inherit React.HTMLProps<HTMLElement>
    abstract isOpen: bool option with get, set
    abstract classNames: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract navbar: bool option with get, set
    abstract delay: obj option with get, set
    abstract onOpened: Func<unit, unit> option with get, set
    abstract onClosed: Func<unit, unit> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Collapse with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract fluid: bool option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Container with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] UncontrolledProps =
    abstract isOpen: bool option with get, set
    abstract toggle: Func<unit, unit> option with get, set

and [<AllowNullLiteral>] Props =
    inherit UncontrolledProps
    abstract disabled: bool option with get, set
    abstract dropup: bool option with get, set
    abstract group: bool option with get, set
    abstract size: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract tether: U2<bool, Tether.ITetherOptions> option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Dropdown with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract disabled: bool option with get, set
    abstract divider: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract header: bool option with get, set
    abstract onClick: Func<React.MouseEvent<obj>, unit> option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member DropdownItem with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract right: bool option with get, set
    abstract className: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member DropdownMenu with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract caret: bool option with get, set
    abstract className: string option with get, set
    abstract disabled: bool option with get, set
    abstract onClick: React.MouseEventHandler<obj> option with get, set
    abstract ``data-toggle``: string option with get, set
    abstract ``aria-haspopup``: bool option with get, set
    abstract split: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract nav: bool option with get, set
    abstract color: string option with get, set
    abstract size: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member DropdownToggle with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract baseClass: string option with get, set
    abstract baseClassIn: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set
    abstract transitionAppearTimeout: float option with get, set
    abstract transitionEnterTimeout: float option with get, set
    abstract transitionLeaveTimeout: float option with get, set
    abstract transitionAppear: bool option with get, set
    abstract transitionEnter: bool option with get, set
    abstract transitionLeave: bool option with get, set
    abstract onLeave: Func<unit, unit> option with get, set
    abstract onEnter: Func<unit, unit> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Fade with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    inherit React.HTMLProps<HTMLFormElement>
    abstract ``inline``: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Form with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: string option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member FormFeedback with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract row: bool option with get, set
    abstract check: bool option with get, set
    abstract disabled: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract color: string option with get, set
    abstract className: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member FormGroup with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract ``inline``: bool option with get, set
    abstract tag: string option with get, set
    abstract color: string option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member FormText with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] InputType =
    obj

and [<AllowNullLiteral>] Intermediate =
    inherit React.ChangeTargetHTMLProps<HTMLInputElement>
    abstract size: obj option with get, set

and [<AllowNullLiteral>] InputProps =
    inherit Intermediate
    abstract ``type``: InputType option with get, set
    abstract size: string option with get, set
    abstract state: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract addon: bool option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Input with get(): React.StatelessComponent<InputProps> = jsNative and set(v: React.StatelessComponent<InputProps>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract size: string option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member InputGroup with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member InputGroupAddon with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract groupClassName: string option with get, set
    abstract groupAttributes: obj option with get, set
    abstract className: string option with get, set
    abstract color: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member InputGroupButton with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract fluid: bool option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Jumbotron with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract hidden: bool option with get, set
    abstract check: bool option with get, set
    abstract ``inline``: bool option with get, set
    abstract disabled: bool option with get, set
    abstract size: string option with get, set
    abstract ``for``: string option with get, set
    abstract tag: string option with get, set
    abstract className: string option with get, set
    abstract xs: ColumnProps option with get, set
    abstract sm: ColumnProps option with get, set
    abstract md: ColumnProps option with get, set
    abstract lg: ColumnProps option with get, set
    abstract xl: ColumnProps option with get, set

type [<Erase>]Globals =
    [<Global>] static member Label with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract flush: bool option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ListGroup with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract active: bool option with get, set
    abstract disabled: bool option with get, set
    abstract color: string option with get, set
    abstract action: bool option with get, set
    abstract className: string option with get, set
    abstract href: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ListGroupItem with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ListGroupItemHeading with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ListGroupItemText with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract body: bool option with get, set
    abstract bottom: bool option with get, set
    abstract className: string option with get, set
    abstract heading: bool option with get, set
    abstract left: bool option with get, set
    abstract list: bool option with get, set
    abstract middle: bool option with get, set
    abstract ``object``: bool option with get, set
    abstract right: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract top: bool option with get, set
    abstract href: string option with get, set
    abstract alt: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Media with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract isOpen: bool option with get, set
    abstract size: string option with get, set
    abstract toggle: Func<unit, unit> option with get, set
    abstract keyboard: bool option with get, set
    abstract backdrop: U2<bool, obj> option with get, set
    abstract onEnter: Func<unit, unit> option with get, set
    abstract onExit: Func<unit, unit> option with get, set
    abstract className: string option with get, set
    abstract wrapClassName: string option with get, set
    abstract modalClassName: string option with get, set
    abstract backdropClassName: string option with get, set
    abstract contentClassName: string option with get, set
    abstract zIndex: U2<float, string> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Modal with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ModalBody with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member ModalFooter with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set
    abstract wrapTag: React.ReactType option with get, set
    abstract toggle: Func<unit, unit> option with get, set

type [<Erase>]Globals =
    [<Global>] static member ModalHeader with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract ``inline``: bool option with get, set
    abstract disabled: bool option with get, set
    abstract tabs: bool option with get, set
    abstract pills: bool option with get, set
    abstract stacked: bool option with get, set
    abstract navbar: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Nav with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract light: bool option with get, set
    abstract inverse: bool option with get, set
    abstract full: bool option with get, set
    abstract ``fixed``: string option with get, set
    abstract sticky: string option with get, set
    abstract color: string option with get, set
    abstract role: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set
    abstract toggleable: U2<bool, string> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Navbar with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] NavbarBrand =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member NavbarBrand with get(): React.StatelessComponent<React.HTMLProps<obj>> = jsNative and set(v: React.StatelessComponent<React.HTMLProps<obj>>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    inherit React.HTMLProps<HTMLAnchorElement>
    abstract tag: React.ReactType option with get, set
    abstract ``type``: string option with get, set
    abstract className: string option with get, set
    abstract right: bool option with get, set
    abstract left: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member NavbarToggler with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] UncontrolledProps =
    inherit DropdownUncontrolledProps


and [<AllowNullLiteral>] Props =
    inherit DropdownProps


type [<Erase>]Globals =
    [<Global>] static member NavDropdown with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member NavItem with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract disabled: bool option with get, set
    abstract active: bool option with get, set
    abstract className: string option with get, set
    abstract onClick: React.MouseEventHandler<obj> option with get, set
    abstract href: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member NavLink with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract className: string option with get, set
    abstract size: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Pagination with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract className: string option with get, set
    abstract active: bool option with get, set
    abstract disabled: bool option with get, set
    abstract tag: React.ReactType option with get, set

type [<Erase>]Globals =
    [<Global>] static member PaginationItem with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    inherit React.HTMLProps<HTMLAnchorElement>
    abstract ``aria-label``: string option with get, set
    abstract className: string option with get, set
    abstract next: bool option with get, set
    abstract previous: bool option with get, set
    abstract tag: React.ReactType option with get, set

type [<Erase>]Globals =
    [<Global>] static member PaginationLink with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Placement =
    (* TODO StringEnum top | bottom | left | right | top left | top center | top right | right top | right middle | right bottom | bottom right | bottom center | bottom left | left top | left middle | left bottom *) string

and [<AllowNullLiteral>] Props =
    abstract placement: Placement option with get, set
    abstract target: string with get, set
    abstract isOpen: bool option with get, set
    abstract tether: Tether.ITetherOptions option with get, set
    abstract className: string option with get, set
    abstract toggle: Func<unit, unit> option with get, set

type [<Erase>]Globals =
    [<Global>] static member Popover with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member PopoverContent with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member PopoverTitle with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract bar: bool option with get, set
    abstract multi: bool option with get, set
    abstract tag: string option with get, set
    abstract value: U2<string, float> option with get, set
    abstract max: U2<string, float> option with get, set
    abstract animated: bool option with get, set
    abstract striped: bool option with get, set
    abstract color: string option with get, set
    abstract className: string option with get, set
    abstract barClassName: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Progress with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract className: string option with get, set
    abstract tag: React.ReactType option with get, set
    abstract noGutters: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member Row with get(): React.StatelessComponent<React.HTMLProps<obj>> = jsNative and set(v: React.StatelessComponent<React.HTMLProps<obj>>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract activeTab: U2<float, string> option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member TabContent with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract className: string option with get, set
    abstract size: string option with get, set
    abstract bordered: bool option with get, set
    abstract striped: bool option with get, set
    abstract inverse: bool option with get, set
    abstract hover: bool option with get, set
    abstract reflow: bool option with get, set
    abstract responsive: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract responsiveTag: React.ReactType option with get, set

type [<Erase>]Globals =
    [<Global>] static member Table with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set
    abstract tabId: U2<float, string> option with get, set

type [<Erase>]Globals =
    [<Global>] static member TabPane with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract color: string option with get, set
    abstract pill: bool option with get, set
    abstract tag: React.ReactType option with get, set
    abstract className: string option with get, set

type [<Erase>]Globals =
    [<Global>] static member Tag with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Props =
    abstract className: string option with get, set
    abstract arrow: string option with get, set
    abstract disabled: bool option with get, set
    abstract isOpen: bool with get, set
    abstract toggle: Func<unit, unit> with get, set
    abstract tether: Tether.ITetherOptions with get, set
    abstract tetherRef: Func<Tether, unit> option with get, set
    abstract style: React.CSSProperties option with get, set

type [<Erase>]Globals =
    [<Global>] static member TetherContent with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] Placement =
    (* TODO StringEnum top | bottom | left | right | top left | top center | top right | right top | right middle | right bottom | bottom right | bottom center | bottom left | left top | left middle | left bottom *) string

and [<AllowNullLiteral>] UncontrolledProps =
    abstract placement: Placement option with get, set
    abstract target: string with get, set
    abstract disabled: bool option with get, set
    abstract tether: Tether.ITetherOptions option with get, set
    abstract tetherRef: Func<Tether, unit> option with get, set
    abstract className: string option with get, set
    abstract autohide: bool option with get, set
    abstract delay: U2<float, obj> option with get, set

and [<AllowNullLiteral>] Props =
    inherit UncontrolledProps
    abstract toggle: Func<unit, unit> option with get, set
    abstract isOpen: bool option with get, set

type [<Erase>]Globals =
    [<Global>] static member Tooltip with get(): React.StatelessComponent<Props> = jsNative and set(v: React.StatelessComponent<Props>): unit = jsNative


namespace Fable.Import.ReactStrap
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<Erase>]Globals =
    [<Global>] static member UncontrolledAlert with get(): React.StatelessComponent<AlertUncontrolledProps> = jsNative and set(v: React.StatelessComponent<AlertUncontrolledProps>): unit = jsNative
    [<Global>] static member UncontrolledButtonDropdown with get(): React.StatelessComponent<ButtonDropdownUncontrolledProps> = jsNative and set(v: React.StatelessComponent<ButtonDropdownUncontrolledProps>): unit = jsNative
    [<Global>] static member UncontrolledDropdown with get(): React.StatelessComponent<DropdownUncontrolledProps> = jsNative and set(v: React.StatelessComponent<DropdownUncontrolledProps>): unit = jsNative
    [<Global>] static member UncontrolledNavDropdown with get(): React.StatelessComponent<NavDropdownUncontrolledProps> = jsNative and set(v: React.StatelessComponent<NavDropdownUncontrolledProps>): unit = jsNative
    [<Global>] static member UncontrolledTooltip with get(): React.StatelessComponent<TooltipUncontrolledProps> = jsNative and set(v: React.StatelessComponent<TooltipUncontrolledProps>): unit = jsNative


