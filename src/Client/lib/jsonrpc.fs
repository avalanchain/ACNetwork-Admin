// ts2fable 0.6.1
module rec jsonrpc
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","./jsonrpc.ts")>] jsonrpc: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract JsonRPCRequest: JsonRPCRequestStatic
    abstract JsonRPCResponse: JsonRPCResponseStatic
    abstract JsonRPCError: JsonRPCErrorStatic

type [<AllowNullLiteral>] JsonRPCRequest =
    abstract counter: obj with get, set
    abstract jsonrpc: string
    abstract ``method``: string with get, set
    abstract ``params``: ResizeArray<obj option> with get, set
    abstract id: U2<float, string> option with get, set

type [<AllowNullLiteral>] JsonRPCRequestStatic =
    abstract nextCounter: unit -> unit
    [<Emit "new $0($1...)">] abstract Create: ``method``: string * ``params``: ResizeArray<obj option> * ?notification: bool -> JsonRPCRequest

type [<AllowNullLiteral>] JsonRPCResponse =
    abstract id: U2<float, string> with get, set
    abstract result: obj option with get, set
    abstract error: JsonRPCError option with get, set
    abstract jsonrpc: string

type [<AllowNullLiteral>] JsonRPCResponseStatic =
    [<Emit "new $0($1...)">] abstract Create: id: U2<float, string> * ?result: obj option * ?error: JsonRPCError -> JsonRPCResponse

type [<AllowNullLiteral>] JsonRPCError =
    abstract code: float with get, set
    abstract message: string with get, set
    abstract data: obj option with get, set

type [<AllowNullLiteral>] JsonRPCErrorStatic =
    [<Emit "new $0($1...)">] abstract Create: code: float * message: string * ?data: obj option -> JsonRPCError
