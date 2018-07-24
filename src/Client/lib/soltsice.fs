// ts2fable 0.6.1
module rec soltsice
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","soltsice")>] soltsice: Soltsice.IExports = jsNative

module Soltsice =

    type [<AllowNullLiteral>] IExports =
        abstract parseArgs: args: ResizeArray<string> -> obj
        abstract generateTypes: options: GenerateTypesOptions -> unit
        /// Create or get local key file and return private key and address. This is a blocking sync function for file read/write, therefore should be used during initial startup. 
        abstract getLocalPrivateKeyAndAddress: filepath: string * password: string -> obj

    type [<AllowNullLiteral>] GenerateTypesOptions =
        abstract source: string with get, set
        abstract destination: string with get, set
        abstract W3importPath: string with get, set
