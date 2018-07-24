module Client.PasswordResetPage

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
    | ChangePassword            of string
    | ChangeConfPassword        of string
    | ResetAttemptResult        of Result<AuthToken, PasswordResetError>
    | UpdateValidationErrors 
    | RegisterClicked

type ExternalMsg =
    | NoOp
    | ResetPassword        of ResetPasswordInfo
    | UserPasswordReset    of AuthToken

type Model = {
    Email                       : string
    PwdResetToken               : string
    InputPassword               : string
    InputPasswordConf           : string
    PasswordValidationErrors    : string list
    PasswordConfValidationErrors: string list
    PasswordStartedTyping       : bool
    PasswordConfStartedTyping   : bool
    TryingToReset               : bool
    ResettingErrors             : string list
}

let init email pwdResetToken = 
    {   Email                        = email
        PwdResetToken                = pwdResetToken
        InputPassword                = ""
        InputPasswordConf            = ""
        PasswordValidationErrors     = [ ]
        PasswordConfValidationErrors = [ ]
        PasswordStartedTyping        = false
        PasswordConfStartedTyping    = false
        TryingToReset                = false
        ResettingErrors              = [ ] }, Cmd.ofMsg UpdateValidationErrors

let update (msg: Msg) model : Model * Cmd<Msg> * ExternalMsg = 
    match msg with
    | ChangePassword password ->
        { model with InputPassword = password; PasswordStartedTyping = true; ResettingErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ChangeConfPassword password ->
        { model with InputPasswordConf = password; PasswordConfStartedTyping = true; ResettingErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ResetAttemptResult res -> 
        match res with
        | Ok authToken -> { model with TryingToReset = false }, Cmd.none, UserPasswordReset authToken
        | Error e -> match e with 
                        | ValidationErrors (emailErrors, pwdErrors) -> { model with ResettingErrors = emailErrors @ pwdErrors; TryingToReset = false }, Cmd.none, NoOp
                        | PasswordResetServerError e -> { model with ResettingErrors = handleLoginFlowServerError e; TryingToReset = false }, Cmd.none, NoOp
    | UpdateValidationErrors -> 
        { model with    PasswordValidationErrors = InputValidators.passwordConfValidation model.InputPasswordConf model.InputPassword
                        PasswordConfValidationErrors = InputValidators.passwordConfValidation model.InputPasswordConf model.InputPassword }, Cmd.none, NoOp
    | RegisterClicked ->
        { model with TryingToReset = true }, Cmd.none, ResetPassword { PwdResetToken = model.PwdResetToken; Password = model.InputPassword } // TODO: hash password


let view model (dispatch: Msg -> unit) =
    let buttonActive =  if not model.ResettingErrors.IsEmpty 
                            && hasErrors model.PasswordStartedTyping model.PasswordValidationErrors |> not
                            && hasErrors model.PasswordConfStartedTyping model.PasswordConfValidationErrors |> not
                            && (model.PasswordStartedTyping || model.PasswordConfStartedTyping)
                        then "btn-disabled" else "btn-info"        
    div [ Class "login"
            // HTMLAttr.Custom ("style", "background: white; padding: 10% 0px; height: 100vh") 
            ]
            [ div [ Class "middle-box text-center loginscreen  animated fadeInDown" ]
                [     div [ ]
                        [ img [ Alt "image"
                                Class "h55"
                                Src "../lib/img/token_cab_1.png" ] ]
                    //   br [ ]
                      h3 [ ]
                        [ str "Please reset your password" ]
                      p [ ]
                        [ str "Please reset your password." ]
                      form [ Class "m-t"
                             Role "form"
                             Action "#" ]
                        [ 
                          str model.Email  // TODO: ADD PROPER LABEL
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
                              OnClick (fun _ -> dispatch RegisterClicked)
                              onEnter RegisterClicked dispatch 
                              ]
                            [  (if model.TryingToReset then i [ ClassName "fa fa-circle-o-notch fa-spin" ] [] 
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
