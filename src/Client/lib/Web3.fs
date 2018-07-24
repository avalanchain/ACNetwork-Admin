// ts2fable 0.6.1
module rec Web3
open System
open Fable.Core
open Fable.Import.JS

module T = Web3Types

let [<Import("*","web3")>] web3Factory: Web3Static = jsNative
// let web3 = web3Factory.Create()

type [<AllowNullLiteral>] IExports =
    abstract Web3: Web3Static

type [<AllowNullLiteral>] Web3 =
    abstract providers: T.Providers with get, set
    abstract givenProvider: T.Provider with get, set
    abstract modules: obj with get, set
    abstract version: string with get, set
    abstract BatchRequest: obj with get, set
    abstract extend: methods: obj option -> obj option
    abstract bzz: T.Bzz with get, set
    abstract currentProvider: T.Provider with get, set
    abstract eth: T.Eth with get, set
    abstract ssh: T.Shh with get, set
    abstract setProvider: provider: T.Provider -> unit
    abstract utils: T.Utils with get, set

type [<AllowNullLiteral>] Web3Static =
    [<Emit "new $0($1...)">] abstract Create: ?provider: U2<T.Provider, string> -> Web3
