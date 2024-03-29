namespace AuthTokens

open Microsoft.AspNetCore.Http
open Giraffe.GiraffeViewEngine
open Saturn

module Views =
  let index (ctx : HttpContext) (objs : AuthToken list) =
    let cnt = [
      div [_class "container "] [
        h2 [ _class "title"] [rawText "Listing AuthTokens"]

        table [_class "table is-hoverable is-fullwidth"] [
          thead [] [
            tr [] [
              th [] [rawText "AuthToken"]
              th [] [rawText "CustomerId"]
              th [] [rawText "Issued"]
              th [] [rawText "Expires"]
              th [] []
            ]
          ]
          tbody [] [
            for o in objs do
              yield tr [] [
                td [] [rawText (string o.AuthToken)]
                td [] [rawText (string o.CustomerId)]
                td [] [rawText (string o.Issued)]
                td [] [rawText (string o.Expires)]
                td [] [
                  a [_class "button is-text"; _href (Links.withId ctx o.AuthToken )] [rawText "Show"]
                  a [_class "button is-text"; _href (Links.edit ctx o.AuthToken )] [rawText "Edit"]
                  a [_class "button is-text is-delete"; attr "data-href" (Links.withId ctx o.AuthToken ) ] [rawText "Delete"]
                ]
              ]
          ]
        ]

        a [_class "button is-text"; _href (Links.add ctx )] [rawText "New AuthToken"]
      ]
    ]
    App.layout ([section [_class "section"] cnt])


  let show (ctx : HttpContext) (o : AuthToken) =
    let cnt = [
      div [_class "container "] [
        h2 [ _class "title"] [rawText "Show AuthToken"]

        ul [] [
          li [] [ strong [] [rawText "AuthToken: "]; rawText (string o.AuthToken) ]
          li [] [ strong [] [rawText "CustomerId: "]; rawText (string o.CustomerId) ]
          li [] [ strong [] [rawText "Issued: "]; rawText (string o.Issued) ]
          li [] [ strong [] [rawText "Expires: "]; rawText (string o.Expires) ]
        ]
        a [_class "button is-text"; _href (Links.edit ctx o.AuthToken)] [rawText "Edit"]
        a [_class "button is-text"; _href (Links.index ctx )] [rawText "Back"]
      ]
    ]
    App.layout ([section [_class "section"] cnt])

  let private form (ctx: HttpContext) (o: AuthToken option) (validationResult : Map<string, string>) isUpdate =
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
        form [ _action (if isUpdate then Links.withId ctx o.Value.AuthToken else Links.index ctx ); _method "post"] [
          if not validationResult.IsEmpty then
            yield validationMessage
          yield field (fun i -> (string i.AuthToken)) "AuthToken" "AuthToken" 
          yield field (fun i -> (string i.CustomerId)) "CustomerId" "CustomerId" 
          yield field (fun i -> (string i.Issued)) "Issued" "Issued" 
          yield field (fun i -> (string i.Expires)) "Expires" "Expires" 
          yield buttons
        ]
      ]
    ]
    App.layout ([section [_class "section"] cnt])

  let add (ctx: HttpContext) (o: AuthToken option) (validationResult : Map<string, string>)=
    form ctx o validationResult false

  let edit (ctx: HttpContext) (o: AuthToken) (validationResult : Map<string, string>) =
    form ctx (Some o) validationResult true
