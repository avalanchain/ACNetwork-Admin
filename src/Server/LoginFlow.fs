module LoginFlow 

open System.IO
open System.Threading.Tasks
open FSharp.Data

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Saturn
open Config

open Fable.Remoting.Server
open Fable.Remoting.Giraffe

open Shared
open Shared.ViewModels
open Shared.Auth
open Shared.Utils
open Shared.Result
open Shared.WsBridge

open ServerUtils

open System
open Microsoft.AspNetCore.Http
open Dapper

open TypeShape.Tools

open Seed

let issueAuthToken email =
    let userRigths = { AuthJwt.UserRights.UserName = email }
    userRigths |> AuthJwt.encode |> AuthToken

let saveAuthToken connectionString (authToken: AuthToken) customerId =
    let auth: AuthTokens.AuthToken = {  AuthToken = authToken.Token
                                        CustomerId = customerId
                                        Issued = DateTime.Now
                                        Expires = DateTime.Now.AddMonths 1 }
    AuthTokens.Database.insert connectionString auth |> Ok 

let internal isTokenValid authToken =
    let (AuthToken authToken) = authToken
    authToken |> AuthJwt.checkValid |> Option.isSome

let internal checkAuthTokenValid config authToken =
    //logins.ContainsKey authToken
    true

let private login config (loginInfo: LoginInfo) : Task<LoginResult> = task {
    let! customerRes = Customers.Database.getByEmail config.connectionString loginInfo.Email
    let r = result {
        let! customerOpt = customerRes |> Result.mapError (LoginInternalError >> LoginServerError)
        let! customer = customerOpt |> Result.ofOption EmailNotFoundOrPasswordIncorrect
        let authToken = issueAuthToken customer.Email
        
        let! _ = saveAuthToken config.connectionString authToken customer.Id 
                    |> Result.mapError (LoginInternalError >> LoginServerError) // TODO: Add reaction to non-zero return code

        return authToken 
    }

    return r |> Ok 
}

let private register config (loginInfo: LoginInfo) : Task<RegisteringResult> = task {  // TODO: Change this!!!
    let authToken = issueAuthToken loginInfo.Email
    let customer = createCustomer loginInfo.Email loginInfo.Password ""
    let! res = Customers.Database.insert config.connectionString customer
    let! authInsertRes = 
        match res with
        | Ok code when code = 0 -> saveAuthToken config.connectionString authToken customer.Id 
        | Ok code -> 
            let msg = sprintf "Error creating new customer. Code: '%d'" code
            printfn "%s" msg
            InternalError (new Exception(msg)) |> Error
        | Error exn -> exn |> InternalError |> Error
        |> Result.reWrap
    return 
        match authInsertRes with 
        | Ok r -> 
            match r with 
            | Ok code when code = 0 -> authToken |> Ok |> Ok 
            | Ok code -> 
                let msg = sprintf "Error when saving authToken, Code: '%d'" code
                printfn "%s" msg
                InternalError (new Exception(msg)) |> Error 
            | Error exn -> exn |> InternalError |> Error 
        | Error exn -> exn |> Error 
}

let private forgotPassword config (forgotPasswordInfo: ForgotPasswordInfo) = task { // TODO: Change this!!!
    return "Reset email sent" |> Ok |> Ok
}

let private resetPassword config (resetPasswordInfo: ResetPasswordInfo) = task { // TODO: Change this!!!
    let userRigths = { AuthJwt.UserRights.UserName = "trader@cryptoinvestor.com" }
    let token = userRigths |> AuthJwt.encode |> AuthToken
    // logins.[token] <- userRigths
    return token |> Ok |> Ok
}

let loginProtocol config =
    {   login               = login                 config    >> Async.AwaitTask
        register            = register              config    >> Async.AwaitTask
        forgotPassword      = forgotPassword        config    >> Async.AwaitTask
        resetPassword       = resetPassword         config    >> Async.AwaitTask
    }            
