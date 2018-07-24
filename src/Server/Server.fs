open System
open System.IO
open System.Threading.Tasks

open Giraffe
open Saturn
open Config

open Fable.Remoting.Server
open Fable.Remoting.Giraffe

open Shared

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection

open TypeShape.Tools

open Elmish
open Elmish.Bridge

open Seed
open LoginFlow
open Cabinet

let clientPath =
    // did we start from server folder?
    let devPath = Path.Combine("..","Client")
    if Directory.Exists devPath then devPath
    else
        // maybe we are in root of project?
        let devPath = Path.Combine("src","Client")
        if Directory.Exists devPath then devPath
        else @"./Client"
    |> Path.GetFullPath        


let publicPath = Path.Combine (clientPath, "public")

let port = 8085us

type CustomError = { errorMsg: string }

let errorHandler (ex: Exception) (routeInfo: RouteInfo<HttpContext>) = 
    // do some logging
    printfn "Error at %s on method %s" routeInfo.path routeInfo.methodName
    printfn "Exception %A" ex 
    // decide whether or not you want to propagate the error to the client
    match ex with
    | :? IOException as x ->
        // propagate custom error, this is intercepted by the client
        let customError = { errorMsg = "Something terrible happend" }
        Propagate customError
    | _ ->
        // ignore error
        Ignore


let webApp config =
    // Setting up remoting
        
    choose [
        remoting (loginProtocol config) {
            use_route_builder Route.builder
            use_error_handler errorHandler
        }        
        remoting (cabinetProtocol config) {
            use_route_builder Route.builder
            use_error_handler errorHandler
        }
        bridgeProtocol config 
        Router.router publicPath
    ]

let app config = application {
    url ("http://0.0.0.0:" + port.ToString() + "/")
    router (webApp config)
    app_config Giraffe.useWebSockets
    memory_cache
    use_static publicPath
    use_gzip
    use_config (fun _ -> config)
}

let config = { connectionString = "DataSource=database.sqlite" }

// Seeding
try
    printfn "Seeding 1..."
    // Seed.seedAll config.connectionString
    // |> Async.AwaitTask 
    // |> Async.RunSynchronously

    run (app config)
with 
| e -> printfn "SEEDING ERROR: %A" e


