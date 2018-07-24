module Client.Utils

open System

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

open Fable.Helpers.React

// let reviver (name, value: obj) = 
//     match name with 
//     | "Contracts" -> 

let load<'T> key =
    Browser.localStorage.getItem(key) 
    |> unbox
    // |> Option.map (fun s -> JS.JSON.parse (s, ) |> unbox<'T>)
    |> Option.map (ofJsonWithTypeInfo >> unbox<'T>)

let save key (data: 'T) =
    // Browser.localStorage.setItem(key, JS.JSON.stringify data)
    Browser.localStorage.setItem(key, toJsonWithTypeInfo data)

let delete key =
    Browser.localStorage.removeItem(key)

[<Emit("JSON.stringify ($0, null, 2)")>]
let stringifyPretty o = jsNative

let toJsonPretty tabSize o = JS.JSON.stringify (o, Func<string, obj, obj>(fun _ -> deflate), U2.Case2(tabSize))

let text = ofString