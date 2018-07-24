module Client.LoginPage

open System
open System.Text.RegularExpressions

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fable.PowerPack
open Elmish
open Elmish.React

open Shared
open Shared.Auth

open Client.LoginCommon
open Client.Page
open Shared
open Shared.InputValidators
open Fable.Import.React

type Msg = 
    | ChangeEmail           of string
    | ChangePassword        of string
    | LoginAttemptResult    of Result<AuthToken, LoginError>
    | UpdateValidationErrors 
    | LogInClicked          of FormValidation


type ExternalMsg =
    | NoOp
    | LoginUser     of LoginInfo
    | UserLoggedIn  of AuthToken


type Model = {
    InputEmail              : string
    InputPassword           : string
    EmailValidationErrors   : string list
    PasswordValidationErrors: string list
    EmailStartedTyping      : bool
    PasswordStartedTyping   : bool
    TryingToLogin           : bool
    LoginErrors             : string list
}

let init email = 
    {   InputEmail               = email
        InputPassword            = ""
        EmailValidationErrors    = [ ]
        PasswordValidationErrors = [ ]
        EmailStartedTyping       = false
        PasswordStartedTyping    = false
        TryingToLogin            = false
        LoginErrors              = [ ] }, Cmd.ofMsg UpdateValidationErrors

let update (msg: Msg) model : Model * Cmd<Msg> * ExternalMsg = 
    match msg with
    | ChangeEmail username -> 
        { model with InputEmail = username; EmailStartedTyping = true; LoginErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ChangePassword password ->
        { model with InputPassword = password; PasswordStartedTyping = true; LoginErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | LoginAttemptResult res -> 
        match res with
        | Ok authToken -> { model with TryingToLogin = false }, Cmd.none, UserLoggedIn authToken
        | Error e -> match e with 
                        | EmailNotFoundOrPasswordIncorrect -> { model with LoginErrors = [ "Email or password incorrect" ]; TryingToLogin = false }, Cmd.none, NoOp
                        | LoginError.LoginServerError e -> { model with LoginErrors = handleLoginFlowServerError e; TryingToLogin = false }, Cmd.none, NoOp
    | UpdateValidationErrors -> 
        { model with    EmailValidationErrors = InputValidators.emailValidation model.InputEmail
                        PasswordValidationErrors = InputValidators.passwordValidation model.InputPassword }, Cmd.none, NoOp
    | LogInClicked validation ->
        match validation with 
        | Valid when model.EmailStartedTyping -> { model with TryingToLogin = true }, Cmd.none, LoginUser { Email = model.InputEmail; Password = model.InputPassword } // TODO: hash password
        | Valid
        | InValid -> model, Cmd.none, NoOp


let view (model: Model) (dispatch: Msg -> unit) = 
    let formValid =  if not model.LoginErrors.IsEmpty 
                             || hasErrors model.EmailStartedTyping model.EmailValidationErrors 
                             || hasErrors model.PasswordStartedTyping model.PasswordValidationErrors 
                     then FormValidation.InValid else FormValidation.Valid

    div [ Class "login" ]
        [ div [ Class "middle-box text-center loginscreen  animated fadeInDown" ]
              [   div [ ]
                    [ img [ Alt "image"
                            Class "h90"
                            Src "../lib/img/token_cab_1.png" ] ]
                  form [ Class "m-t"
                         Role "form"
                         Action "#" ]
                    [ div [ Class ("form-group " + hasErrorsClass model.EmailStartedTyping model.EmailValidationErrors) ]
                        [   input [ Id "email"
                                    Type "email" 
                                    ClassName "form-control"
                                    Placeholder "Email address" 
                                    DefaultValue model.InputEmail
                                    OnChange (fun ev -> dispatch (ChangeEmail !!ev.target?value))
                                    AutoFocus true ]
                            hasErrorsSpan model.EmailStartedTyping model.EmailValidationErrors
                        ]
                      div [ Class ("form-group " + hasErrorsClass model.PasswordStartedTyping model.PasswordValidationErrors) ]
                        [   input [ Type "password" 
                                    ClassName "form-control" 
                                    Placeholder "Password"  
                                    DefaultValue model.InputPassword
                                    OnChange (fun ev -> dispatch (ChangePassword !!ev.target?value))
                                 ]
                            hasErrorsSpan model.PasswordStartedTyping model.PasswordValidationErrors 
                        ]
                      a [ Type "submit"
                          Class ("btn btn-info block full-width m-b")
                          OnClick (fun _ -> dispatch (LogInClicked formValid) )
                          onEnter (LogInClicked formValid) dispatch 
                          Disabled (formValid <> FormValidation.Valid || not model.EmailStartedTyping)
                        ]
                        [  (if model.TryingToLogin then i [ ClassName "fa fa-circle-o-notch fa-spin" ] [] 
                            else str "Login") ] 
                      a [   Href (LoginFlow.ForgotPassword |> MenuPage.LoginFlow |> toHash) 
                            OnClick goToUrl ]
                        [ small [ ]
                            [ str "Forgot password?" ] ]
                      p [ Class "text-muted text-center" ]
                        [ small [ ]
                            [ str "Do not have an account?" ] ]
                      a [   Class "btn btn-sm btn-white btn-block"
                            Href (LoginFlow.Register |> MenuPage.LoginFlow |> toHash) 
                            OnClick goToUrl ]
                       [ str "Create an account" ]]
                  p [ Class "m-t project-title" ]
                    [ small [ ]
                        [ str "powered by "
                          a [ 
                            //   HTMLAttr.Custom ("style", "font-size: 12px;")
                              Href "http://avalanchain.com" ]
                            [ str "Avalanchain" ]
                          str " © 2018" ] ] ] ]

