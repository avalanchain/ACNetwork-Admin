namespace Customers

open System
open Microsoft.AspNetCore.Http
open Giraffe.GiraffeViewEngine
open Saturn

module Views =
  let index (ctx : HttpContext) (objs : Customer list) =
    let cnt = [
      div [_class "container "] [
        h2 [ _class "title"] [rawText "Listing Customers"]

        table [_class "table is-hoverable is-fullwidth"] [
          thead [] [
            tr [] [
              th [] [rawText "Id"]
              th [] [rawText "FirstName"]
              th [] [rawText "LastName"]
              th [] [rawText "EthAddress"]
              th [] [rawText "Password"]
              th [] [rawText "PasswordSalt"]
              th [] [rawText "Avatar"]
              th [] []
            ]
          ]
          tbody [] [
            for o in objs do
              yield tr [] [
                td [] [rawText (string o.Id)]
                td [] [rawText (string o.FirstName)]
                td [] [rawText (string o.LastName)]
                td [] [rawText (string o.EthAddress)]
                td [] [rawText (string o.Password)]
                td [] [rawText (string o.PasswordSalt)]
                td [] [rawText (string o.Avatar)]
                td [] [
                  a [_class "button is-text"; _href (Links.withId ctx o.Id )] [rawText "Show"]
                  a [_class "button is-text"; _href (Links.edit ctx o.Id )] [rawText "Edit"]
                  a [_class "button is-text is-delete"; attr "data-href" (Links.withId ctx o.Id ) ] [rawText "Delete"]
                ]
              ]
          ]
        ]

        a [_class "button is-text"; _href (Links.add ctx )] [rawText "New Customer"]
      ]
    ]
    App.layout ([section [_class "section"] cnt])


  let show (ctx : HttpContext) (o : Customer) =
    let cnt = [
      div [_class "container "] [
        h2 [ _class "title"] [rawText "Show Customer"]

        ul [] [
          li [] [ strong [] [rawText "Id: "]; rawText (string o.Id) ]
          li [] [ strong [] [rawText "FirstName: "]; rawText (string o.FirstName) ]
          li [] [ strong [] [rawText "LastName: "]; rawText (string o.LastName) ]
          li [] [ strong [] [rawText "EthAddress: "]; rawText (string o.EthAddress) ]
          li [] [ strong [] [rawText "Password: "]; rawText (string o.Password) ]
          li [] [ strong [] [rawText "PasswordSalt: "]; rawText (string o.PasswordSalt) ]
          li [] [ strong [] [rawText "Avatar: "]; rawText (string o.Avatar) ]
        ]
        a [_class "button is-text"; _href (Links.edit ctx o.Id)] [rawText "Edit"]
        a [_class "button is-text"; _href (Links.index ctx )] [rawText "Back"]
      ]
    ]
    App.layout ([section [_class "section"] cnt])

  let private form (ctx: HttpContext) (o: Customer option) (validationResult : Map<string, string>) isUpdate =
    let validationMessage =
      div [_class "notification is-danger"] [
        a [_class "delete"; attr "aria-label" "delete"] []
        rawText "Oops, something went wrong! Please check the errors below."
      ]

    let field selector lbl key =
      div [_class "field"] [
        yield label [_class "label"] [rawText (string lbl)]
        yield div [_class "control has-icons-right"] [
          yield input [_class (if validationResult.ContainsKey key then "input is-danger" else "input"); _value (defaultArg (o |> Option.map selector) ""); _name key ; _type "text" ]
          if validationResult.ContainsKey key then
            yield span [_class "icon is-small is-right"] [
              i [_class "fas fa-exclamation-triangle"] []
            ]
        ]
        if validationResult.ContainsKey key then
          yield p [_class "help is-danger"] [rawText validationResult.[key]]
      ]

    let buttons =
      div [_class "field is-grouped"] [
        div [_class "control"] [
          input [_type "submit"; _class "button is-link"; _value "Submit"]
        ]
        div [_class "control"] [
          a [_class "button is-text"; _href (Links.index ctx)] [rawText "Cancel"]
        ]
      ]

    let cnt = [
      div [_class "container "] [
        form [ _action (if isUpdate then Links.withId ctx o.Value.Id else Links.index ctx ); _method "post"] [
          if not validationResult.IsEmpty then
            yield validationMessage
          yield field (fun i -> (string i.Id)) "Id" "Id" 
          yield field (fun i -> (string i.FirstName)) "FirstName" "FirstName" 
          yield field (fun i -> (string i.LastName)) "LastName" "LastName" 
          yield field (fun i -> (string i.EthAddress)) "EthAddress" "EthAddress" 
          yield field (fun i -> (string i.Password)) "Password" "Password" 
          yield field (fun i -> (string i.PasswordSalt)) "PasswordSalt" "PasswordSalt" 
          yield field (fun i -> (string i.Avatar)) "Avatar" "Avatar" 
          yield buttons
        ]
      ]
    ]
    App.layout ([section [_class "section"] cnt])

  let add (ctx: HttpContext) (o: Customer option) (validationResult : Map<string, string>)=
    form ctx o validationResult false

  let edit (ctx: HttpContext) (o: Customer) (validationResult : Map<string, string>) =
    form ctx (Some o) validationResult true
