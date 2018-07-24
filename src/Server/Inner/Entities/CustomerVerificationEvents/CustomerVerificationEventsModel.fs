namespace CustomerVerificationEvents

[<CLIMutable>]
type CustomerVerificationEvent = {
  Id: System.Guid
  CustomerId: System.Guid
  EventType: string
  CreatedOn: System.DateTime
  CreatedBy: System.DateTime
  Proof: string
}

module Validation =
  let validate v =
    let validators = [
      fun u -> if u.Id = System.Guid.Empty then Some ("Id", "'Id' shouldn't be empty") else None
      fun u -> if u.CustomerId = System.Guid.Empty then Some ("CustomerId", "'Customer Id' shouldn't be empty") else None
      fun u -> if isNull u.EventType then Some ("EventType", "'EventType' shouldn't be empty") else None
    ]

    validators
    |> List.fold (fun acc e ->
      match e v with
      | Some (k,v) -> Map.add k v acc
      | None -> acc
    ) Map.empty
