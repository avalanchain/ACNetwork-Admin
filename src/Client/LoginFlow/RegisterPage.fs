module Client.RegisterPage

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
open ViewModels

open Client.LoginCommon
open Client.Page

type Msg = 
    | ChangeEmail               of string
    | ChangePassword            of string
    | ChangeConfPassword        of string
    | RegisteringAttemptResult  of Result<AuthToken, RegisteringError>
    | UpdateValidationErrors 
    | RegisterClicked           of FormValidation

type ExternalMsg =
    | NoOp
    | RegisterUser      of LoginInfo
    | UserRegistered    of AuthToken

type Model = {
    InputEmail                  : string
    InputPassword               : string
    InputPasswordConf           : string
    EmailValidationErrors       : string list
    PasswordValidationErrors    : string list
    PasswordConfValidationErrors: string list
    EmailStartedTyping          : bool
    PasswordStartedTyping       : bool
    PasswordConfStartedTyping   : bool
    TryingToRegister            : bool
    RegisteringErrors           : string list
}

let init email = 
    {   InputEmail                   = email
        InputPassword                = ""
        InputPasswordConf            = ""
        EmailValidationErrors        = [ ]
        PasswordValidationErrors     = [ ]
        PasswordConfValidationErrors = [ ]
        EmailStartedTyping           = false
        PasswordStartedTyping        = false
        PasswordConfStartedTyping    = false
        TryingToRegister             = false
        RegisteringErrors            = [ ] }, Cmd.ofMsg UpdateValidationErrors

let update (msg: Msg) model : Model * Cmd<Msg> * ExternalMsg = 
    match msg with
    | ChangeEmail username -> 
        { model with InputEmail = username; EmailStartedTyping = true; RegisteringErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ChangePassword password ->
        { model with InputPassword = password; PasswordStartedTyping = true; RegisteringErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ChangeConfPassword password ->
        { model with InputPasswordConf = password; PasswordConfStartedTyping = true; RegisteringErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | RegisteringAttemptResult res -> 
        match res with
        | Ok authToken -> { model with TryingToRegister = false }, Cmd.none, UserRegistered authToken
        | Error e -> match e with 
                        | EmailAlreadyRegistered -> { model with RegisteringErrors = [ "Email already registered" ]; TryingToRegister = false }, Cmd.none, NoOp
                        | RegisteringError.ValidationErrors (emailErrors, pwdErrors) -> { model with RegisteringErrors = emailErrors @ pwdErrors; TryingToRegister = false }, Cmd.none, NoOp
                        | RegisteringServerError e -> { model with RegisteringErrors = handleLoginFlowServerError e; TryingToRegister = false }, Cmd.none, NoOp
    | UpdateValidationErrors -> 
        { model with    EmailValidationErrors = InputValidators.emailValidation model.InputEmail
                        PasswordValidationErrors = InputValidators.passwordConfValidation model.InputPasswordConf model.InputPassword
                        PasswordConfValidationErrors = InputValidators.passwordConfValidation model.InputPasswordConf model.InputPassword }, Cmd.none, NoOp
    | RegisterClicked validation ->
        match validation with 
        | Valid -> { model with TryingToRegister = true }, Cmd.none, RegisterUser { Email = model.InputEmail; Password = model.InputPassword } // TODO: hash password
        | InValid -> model, Cmd.none, NoOp

let view model (dispatch: Msg -> unit) =
    let formValid =  if not model.RegisteringErrors.IsEmpty 
                              || hasErrors model.EmailStartedTyping model.EmailValidationErrors
                              || hasErrors model.PasswordStartedTyping model.PasswordValidationErrors 
                              || hasErrors model.PasswordConfStartedTyping model.PasswordConfValidationErrors 
                            //   && (model.EmailStartedTyping || model.PasswordStartedTyping || model.PasswordConfStartedTyping)
                     then FormValidation.InValid else FormValidation.Valid    
    div [ Class "login"
            // HTMLAttr.Custom ("style", "background: white; padding: 10% 0px; height: 100vh") 
            ]
            [ div [ Class "middle-box text-center loginscreen  animated fadeInDown" ]
                [     div [ ]
                        [ img [ Alt "image"
                                Class "h90"
                                Src "../lib/img/token_cab_1.png" ] ]
                      form [ Class "m-t"
                             Role "form"
                             Action "#" ]
                        [ 
                          div [ Class ("form-group " + hasErrorsClass model.EmailStartedTyping model.EmailValidationErrors) ]
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
                                        OnChange (fun ev -> dispatch (ChangePassword !!ev.target?value)) ]
                                hasErrorsSpan model.PasswordStartedTyping model.PasswordValidationErrors 
                            ]
                          div [ Class ("form-group " + hasErrorsClass model.PasswordConfStartedTyping model.PasswordConfValidationErrors) ]
                            [   input [ Type "password" 
                                        ClassName "form-control" 
                                        Placeholder "Confirm Password"  
                                        DefaultValue model.InputPasswordConf
                                        OnChange (fun ev -> dispatch (ChangeConfPassword !!ev.target?value)) ]
                                hasErrorsSpan model.PasswordConfStartedTyping model.PasswordConfValidationErrors 
                            ]
                          a [ 
                              Type "submit"
                              Class "btn btn-info block full-width m-b"
                              OnClick (fun _ -> dispatch (RegisterClicked formValid))
                              onEnter (RegisterClicked formValid) dispatch 
                              Disabled (formValid <> FormValidation.Valid || not model.EmailStartedTyping)
                              ]
                            [  (if model.TryingToRegister then i [ ClassName "fa fa-circle-o-notch fa-spin" ] [] 
                                else str "Register") ] 
                          p [ Class "text-muted text-center" ]
                            [ small [ ]
                                [ str "Already have an account?" ] ]
                          a [ Class "btn btn-sm btn-white btn-block"
                              Href (LoginFlow.Login |> MenuPage.LoginFlow |> toHash) 
                              OnClick goToUrl ]
                            [ str "Login" ]]
                      p [ Class "m-t project-title" ]
                        [ small [ ]
                            [ str "powered by "
                              a [ 
                                //   HTMLAttr.Custom ("style", "font-size: 12px;")
                                  Href "http://avalanchain.com" ]
                                [ str "Avalanchain" ]
                              str " © 2018" ] ] ] ]
