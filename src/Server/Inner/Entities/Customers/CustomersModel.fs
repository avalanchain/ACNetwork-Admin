namespace Customers

[<CLIMutable>]
type Customer = {
  Id          : string
  Email       : string
  FirstName   : string
  LastName    : string
  EthAddress  : string
  Password    : string
  PasswordSalt: string
  Avatar      : string
  CustomerTier: string
}

module Validation =
  let validate v =
    let validators = [
      fun u -> if u.Id |> System.String.IsNullOrWhiteSpace then Some ("Id", "Id shouldn't be empty") else None
    ]

    validators
    |> List.fold (fun acc e ->
      match e v with
      | Some (k,v) -> Map.add k v acc
      | None -> acc
    ) Map.empty
