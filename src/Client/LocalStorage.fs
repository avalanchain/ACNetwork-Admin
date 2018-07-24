module LocalStorage

open System
open Fable
open Fable.PowerPack
open Elmish

open Client.LoginCommon

type BrowserStorageMsg =
    | BrowserStorageUpdated
    | BrowserStorageFailure of Exception

let loadUser () : AuthModel option =
    BrowserLocalStorage.load "user"

let saveUserCmd (authModel: AuthModel) =
    Cmd.ofFunc (BrowserLocalStorage.save "user") authModel (fun _ -> BrowserStorageUpdated) (BrowserStorageFailure)

let deleteUserCmd =
    Cmd.ofFunc BrowserLocalStorage.delete "user" (fun _ -> BrowserStorageUpdated) (BrowserStorageFailure)
