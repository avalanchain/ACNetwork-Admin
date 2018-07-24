// ts2fable 0.6.1
module rec ReactCopyToClipboard
open System
open Fable.Core
open Fable.Import
open Fable.Import.JS

open Client.Helpers
open Fable.Helpers

let [<Import("*","react-copy-to-clipboard")>] copyToClipboard: CopyToClipboard = jsNative


module CopyToClipboard =
    type [<AllowNullLiteral>] Options =
        abstract debug: bool with get, set
        abstract message: string with get, set

    type [<AllowNullLiteral>] Props =
        abstract text: string with get, set
        abstract onCopy: (string * bool -> unit) with get, set
        abstract options: Options option with get, set

type [<AbstractClass>] CopyToClipboard =
    inherit React.Component<CopyToClipboard.Props>

type [<AllowNullLiteral>] CopyToClipboardStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> CopyToClipboard
