module Client.ForgotPasswordPage

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
open Elmish.Browser.Navigation
open Fable


type Msg = 
    | ChangeEmail                 of string
    | ForgotPasswordAttemptResult of Result<string, ForgotPasswordError>
    | UpdateValidationErrors 
    | PasswordResetClicked        of FormValidation

type ExternalMsg =
    | NoOp
    | ForgotPassword of ForgotPasswordInfo


type Model = {
    InputEmail              : string
    EmailValidationErrors   : string list
    EmailStartedTyping      : bool
    TryingToSendReset       : bool
    ForgotPasswordErrors    : string list
    ShowSuccessPage         : bool
}

let init email = 
    {   InputEmail               = email
        EmailValidationErrors    = [ ]
        EmailStartedTyping       = false
        TryingToSendReset        = false
        ForgotPasswordErrors     = [ ] 
        ShowSuccessPage          = false }, Cmd.ofMsg UpdateValidationErrors

let update (msg: Msg) model : Model * Cmd<Msg> * ExternalMsg = 
    match msg with
    | ChangeEmail username -> 
        { model with InputEmail = username; EmailStartedTyping = true; ForgotPasswordErrors = [] }, Cmd.ofMsg UpdateValidationErrors, NoOp
    | ForgotPasswordAttemptResult res -> 
        match res with
        | Ok _      -> { model with ShowSuccessPage = true; TryingToSendReset = false }, Cmd.none, NoOp
        | Error e   -> match e with 
                        | ForgotPasswordError.ForgotPasswordServerError e -> { model with ForgotPasswordErrors = handleLoginFlowServerError e; TryingToSendReset = false }, Cmd.none, NoOp
    | UpdateValidationErrors -> 
        { model with EmailValidationErrors = InputValidators.emailValidation model.InputEmail }, Cmd.none, NoOp
    | PasswordResetClicked validation ->
        match validation with  
        | Valid when model.EmailStartedTyping -> { model with TryingToSendReset = true }, Cmd.none, ForgotPassword { UserName = model.InputEmail } // TODO: hash password
        | Valid
        | InValid -> model, Cmd.none, NoOp


let view model (dispatch: Msg -> unit) =
    let formValid =  if not model.ForgotPasswordErrors.IsEmpty 
                            || hasErrors model.EmailStartedTyping model.EmailValidationErrors
                            // || (model.EmailStartedTyping)
                        then FormValidation.InValid else FormValidation.Valid 
    let errors = model.ForgotPasswordErrors @ model.EmailValidationErrors 

    if model.ShowSuccessPage then div [] [ str "Email sent Successfully"] // TODO: Add propoer content
    else
        div [ Class "login"
                // HTMLAttr.Custom ("style", "background: white; padding: 10% 0px; height: 100vh") 
                ]
                [ div [ Class "middle-box text-center animated fadeInDown" ]
                    [ div [ ]
                            [ 
                              div [ Class "col-md-12" ]
                                    [ div [ Class "ibox-content" ]
                                        [ div [ ]
                                              [ img [ Alt "image"
                                                      Class "h90"
                                                      Src "../lib/img/token_cab_1.png" ] ]
                                          div [ Class "row" ]
                                            [ div [ Class "col-lg-12" ]
                                                [ form [ Class "m-t"
                                                         Role "form"
                                                         Action "#" ]
                                                    [ div [ Class ("form-group " + hasErrorsClass model.EmailStartedTyping errors) ]
                                                        [ input [ Id "email"
                                                                  Type "email"
                                                                  Class "form-control"
                                                                  Placeholder "Email address"
                                                                  DefaultValue model.InputEmail
                                                                  OnChange (fun ev -> dispatch (ChangeEmail !!ev.target?value))
                                                                  AutoFocus true ]
                                                          hasErrorsSpan model.EmailStartedTyping errors
                                                        ]
                                                      button [  Type "submit"
                                                                Class "btn btn-info block full-width m-b"
                                                                OnClick (fun _ -> dispatch (PasswordResetClicked formValid ))
                                                                onEnter (PasswordResetClicked formValid) dispatch 
                                                                Disabled (formValid <> FormValidation.Valid || not model.EmailStartedTyping)]
                                                        [  (if model.TryingToSendReset then i [ ClassName "fa fa-circle-o-notch fa-spin" ] [] 
                                                            else str "Reset password") ]
                                                      p [ Class "text-muted text-center" ]
                                                        [ small [ ]
                                                            [ str "Go back to Login" ] ]
                                                      a [ Class "btn btn-sm btn-white btn-block"
                                                          Href (LoginFlow.Login |> MenuPage.LoginFlow |> toHash) 
                                                          OnClick goToUrl ]
                                                        [ str "Login" ] ] ] ] ] ]  
                              p [ Class "m-t project-title" ]
                                [ small [ ]
                                    [ str "powered by "
                                      a [ 
                                        //   HTMLAttr.Custom ("style", "font-size: 12px;")
                                          Href "http://avalanchain.com" ]
                                        [ str "Avalanchain" ]
                                      str " © 2018" ] ] ] ] ]
