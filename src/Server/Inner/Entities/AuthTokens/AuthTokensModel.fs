namespace AuthTokens

[<CLIMutable>]
type AuthToken = {
  AuthToken: string
  CustomerId: string
  Issued: System.DateTime
  Expires: System.DateTime
}

module Validation =
  let validate v =
    let validators = [
      fun u -> if isNull u.AuthToken then Some ("AuthToken", "AuthToken shouldn't be empty") else None
    ]

    validators
    |> List.fold (fun acc e ->
      match e v with
      | Some (k,v) -> Map.add k v acc
      | None -> acc
    ) Map.empty
