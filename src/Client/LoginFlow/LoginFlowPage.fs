module Client.LoginFlowPage

open System
open System.Text.RegularExpressions

open Shared
open Auth
open Client
open Client.Page

open Fable
open Fable.Core
open Fable.Import.RemoteDev
open Fable.Import.Browser
open Fable.Import.React
open Fable.Import
open Elmish
open Elmish.React
open JsInterop

open Fable.Helpers.React
open Fable.Helpers.React.Props

open LoginCommon

type Msg = 
    | LoginPageMsg          of LoginPage.Msg
    | RegisterPageMsg       of RegisterPage.Msg
    | ForgotPasswordPageMsg of ForgotPasswordPage.Msg
    | PasswordResetPageMsg  of PasswordResetPage.Msg

type ExternalMsg =
    | NoOp
    | LoginUser          of LoginInfo
    | RegisterUser       of LoginInfo
    | ForgotPasswordUser of ForgotPasswordInfo
    | ResetPassword      of ResetPasswordInfo
    | LoggedIn           of AuthToken


type Model = 
    | LoginPageModel            of LoginPage.Model
    | RegisterPageModel         of RegisterPage.Model
    | ForgotPasswordPageModel   of ForgotPasswordPage.Model
    | PasswordResetPageModel    of PasswordResetPage.Model

let mapMC f1 f2 (a, b) = f1 a, Cmd.map f2 b 

let switchTo (page: LoginFlow) (model: Model) = 
    match model, page with 
    | RegisterPageModel m       , Login -> LoginPage.init m.InputEmail |> mapMC LoginPageModel LoginPageMsg
    | ForgotPasswordPageModel m , Login -> LoginPage.init m.InputEmail |> mapMC LoginPageModel LoginPageMsg
    | PasswordResetPageModel m  , Login -> LoginPage.init m.Email      |> mapMC LoginPageModel LoginPageMsg
    | LoginPageModel m          , Register -> RegisterPage.init m.InputEmail |> mapMC RegisterPageModel RegisterPageMsg
    | ForgotPasswordPageModel m , Register -> RegisterPage.init m.InputEmail |> mapMC RegisterPageModel RegisterPageMsg
    | PasswordResetPageModel m  , Register -> RegisterPage.init m.Email |> mapMC RegisterPageModel RegisterPageMsg
    | LoginPageModel m          , ForgotPassword -> ForgotPasswordPage.init m.InputEmail |> mapMC ForgotPasswordPageModel ForgotPasswordPageMsg
    | RegisterPageModel m       , ForgotPassword -> ForgotPasswordPage.init m.InputEmail |> mapMC ForgotPasswordPageModel ForgotPasswordPageMsg
    | PasswordResetPageModel m  , ForgotPassword -> ForgotPasswordPage.init m.Email |> mapMC ForgotPasswordPageModel ForgotPasswordPageMsg
    | LoginPageModel m          , PasswordReset -> LoginPage.init m.InputEmail |> mapMC LoginPageModel LoginPageMsg
    | RegisterPageModel m       , PasswordReset -> LoginPage.init m.InputEmail |> mapMC LoginPageModel LoginPageMsg
    | ForgotPasswordPageModel m , PasswordReset -> LoginPage.init m.InputEmail |> mapMC LoginPageModel LoginPageMsg
    | LoginPageModel _          , Login 
    | RegisterPageModel _       , Register
    | ForgotPasswordPageModel _ , ForgotPassword
    | PasswordResetPageModel _  , PasswordReset -> model, Cmd.none


let init () = 
    LoginPage.init "" |> mapMC LoginPageModel LoginPageMsg


let rec update (msg: Msg) model : Model * Cmd<Msg> * ExternalMsg = 
    match model, msg with
    | LoginPageModel model_, LoginPageMsg msg_ -> 
        let model', cmd', emsg' = LoginPage.update msg_ model_
        let emsg' = match emsg' with 
                    | LoginPage.NoOp                    -> NoOp
                    | LoginPage.LoginUser info          -> LoginUser info
                    | LoginPage.UserLoggedIn authToken  -> LoggedIn authToken
        LoginPageModel model', Cmd.map LoginPageMsg cmd', emsg'                  
    | RegisterPageModel model_, RegisterPageMsg msg_ -> 
        let model', cmd', emsg' = RegisterPage.update msg_ model_
        let emsg' = match emsg' with 
                    | RegisterPage.NoOp                     -> NoOp
                    | RegisterPage.RegisterUser info        -> RegisterUser info
                    | RegisterPage.UserRegistered authToken -> LoggedIn authToken
        RegisterPageModel model', Cmd.map RegisterPageMsg cmd', emsg'                  
    | ForgotPasswordPageModel model_, ForgotPasswordPageMsg msg_ -> 
        let model', cmd', emsg' = ForgotPasswordPage.update msg_ model_
        let emsg' = match emsg' with 
                    | ForgotPasswordPage.NoOp                   -> NoOp
                    | ForgotPasswordPage.ForgotPassword info    -> ForgotPasswordUser info
        ForgotPasswordPageModel model', Cmd.map ForgotPasswordPageMsg cmd', emsg'   
    | PasswordResetPageModel model_, PasswordResetPageMsg msg_ -> 
        let model', cmd', emsg' = PasswordResetPage.update msg_ model_
        let emsg' = match emsg' with 
                    | PasswordResetPage.NoOp                        -> NoOp
                    | PasswordResetPage.ResetPassword resetPwdInfo  -> ResetPassword resetPwdInfo
                    | PasswordResetPage.UserPasswordReset authToken -> LoggedIn authToken
        PasswordResetPageModel model', Cmd.map PasswordResetPageMsg cmd', emsg'   
    | _ ->
        console.error(sprintf "Impossible Msg '%A' Model '%A' combination" msg model)
        let model', cmd' =
            match msg with
            | LoginPageMsg _          -> switchTo LoginFlow.Login model
            | RegisterPageMsg _       -> switchTo LoginFlow.Register model
            | ForgotPasswordPageMsg _ -> switchTo LoginFlow.ForgotPassword model
            | PasswordResetPageMsg _  -> switchTo LoginFlow.PasswordReset model
        let model'', cmd'', emsg'' = update msg model'
        model'', Cmd.batch [cmd'; cmd''], emsg''
let [<Literal>] ENTER_KEY = 13.

let view model (dispatch: Msg -> unit) = 
    match model with
    | LoginPageModel m          -> LoginPage.view m (LoginPageMsg >> dispatch)
    | RegisterPageModel m       -> RegisterPage.view m (RegisterPageMsg >> dispatch) 
    | ForgotPasswordPageModel m -> ForgotPasswordPage.view m (ForgotPasswordPageMsg >> dispatch)
    | PasswordResetPageModel m  -> PasswordResetPage.view m (PasswordResetPageMsg >> dispatch)