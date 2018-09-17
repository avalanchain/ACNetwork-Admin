module Router

open System.IO
open Saturn
open Giraffe.Core
open Giraffe.ResponseWriters
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2.ContextInsensitive
open Giraffe.Common


let browser = pipeline {
    plug acceptHtml
    plug putSecureBrowserHeaders
    plug fetchSession
    set_header "x-pipeline-type" "Browser"
}

let defaultView = scope {
    //get "/" (htmlView Index.layout)
    get "/" (htmlFile "../index.html")
    get "/index.html" (redirectTo false "/")
    get "/default.html" (redirectTo false "/")
}

type HttpContext with
    member this.WriteJavascriptFileAsync (filePath : string) =
        task {
            let filePath =
                match Path.IsPathRooted filePath with
                | true  -> filePath
                | false ->
                    let env = this.GetHostingEnvironment()
                    Path.Combine(env.ContentRootPath, filePath)
            this.SetContentType "text/javascript"
            let! html = readFileAsStringAsync filePath
            return! this.WriteStringAsync html
        }

let jsFile (filePath : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        printfn "BOOOOMMM"
        ctx.WriteJavascriptFileAsync filePath

let bundle publicPath = scope {
    get "/public/bundle.js" (jsFile (Path.Combine (publicPath, "bundle.js")))
}

let browserRouter publicPath = scope {
    not_found_handler (htmlView NotFound.layout) //Use the default 404 webpage
    pipe_through browser // Use the default browser pipeline

    forward "" (bundle publicPath) //public/bundle.js 
    forward "" defaultView // Use the default view

}

//Other scopes may use different pipelines and error handlers

// let api = pipeline {
//     plug acceptJson
//     set_header "x-pipeline-type" "Api"
// }

// let apiRouter = scope {
//     error_handler (text "Api 404")
//     pipe_through api
//
//     forward "/someApi" someScopeOrController
// }

let router publicPath = scope {
    // forward "/api" apiRouter
    forward "" (browserRouter publicPath)
}