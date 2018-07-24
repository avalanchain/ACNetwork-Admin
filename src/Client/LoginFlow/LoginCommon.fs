module Client.LoginCommon
open Shared.Auth
open Fable.Core
open Fable.Core.Exceptions
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

type AuthModel = {
    Token: AuthToken
}

type FormValidation =
    | Valid
    | InValid     

type LoginState =
    | LoggedOut
    | LoggedIn  of AuthModel

[<Emit("null")>]
let emptyElement : ReactElement = jsNative
let hasErrors startedTyping (errors: List<_>) = startedTyping && not errors.IsEmpty 
let hasErrorsClass startedTyping (errors: List<_>) =
    if hasErrors startedTyping errors then "has-error" else ""
let hasErrorsSpan startedTyping (errors: List<_>) =
    if hasErrors startedTyping errors 
    then span [ Class "text-danger" ] 
            [ div [ Class "m-t-xs" ]  [ for error in errors -> div [ ] [ str error ] ] ]
    else emptyElement        

let [<Literal>] ENTER_KEY = 13.

let onEnter msg dispatch =
    function 
    | (ev:KeyboardEvent) when ev.keyCode = ENTER_KEY ->
        ev.preventDefault() 
        dispatch msg
    | _ -> ()
    |> OnKeyDown

let handleLoginFlowServerError = function
    | AccountBanned -> [ "Requested account is banned" ]
    | DdosProtection blockedForRemaining -> [ sprintf "Please wait for %d seconds" (int blockedForRemaining.TotalSeconds) ] 
    | LoginInternalError _ -> [ "Server internal error" ] 
