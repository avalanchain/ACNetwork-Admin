module Seed

open Shared.ViewModels
open System
open Dapper

open FSharp.Control.Tasks.V2.ContextInsensitive

let createCustomer email password ethAddress : Customers.Customer =
    let id = System.Guid.NewGuid().ToString("N") 
    {   Id              = id
        Email           = email
        FirstName       = ""
        LastName        = ""
        EthAddress      = ethAddress
        Password        = password
        PasswordSalt    = id + email
        Avatar          = "MyPicture"
        CustomerTier    = "" }


let seedT connectionString deleteAll insert lst = task {
    let! _ = deleteAll connectionString
    for l in lst do
        printfn "Seeding Type: %A" (l.GetType())
        let! res = insert connectionString l
        printfn "Seeding Result: %A" res
}

let customerPreferencesSeed connectionString =
    let lst: CustomerPreferences.CustomerPreference list = 
        [   {   Id          = Guid.NewGuid().ToString("N")
                Language    = CustomerPreferences.Validation.supportedLangs.[0] } ]
    lst |> seedT connectionString CustomerPreferences.Database.deleteAll CustomerPreferences.Database.insert       

let customerSeed connectionString =
    let lst: Customers.Customer list = 
        [ createCustomer "trader@cryptoinvestor.com" "!!!ChangeMe111" "0x001002003004005006007008009" ]
    lst |> seedT connectionString Customers.Database.deleteAll Customers.Database.insert        

let authTokenSeed connectionString = task {
    let! _ = AuthTokens.Database.deleteAll connectionString
    ()
}


let seedAll connectionString = task {
    printfn "Seeding ..."
    let startDate = DateTime.Today
    let endDate   = DateTime.Today.AddMonths 3

    do! customerPreferencesSeed connectionString
    do! customerSeed connectionString

    do! authTokenSeed connectionString
}
