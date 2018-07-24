namespace Migrations
open SimpleMigrations

[<Migration(201806101832L, "Create Customers")>]
type CreateCustomers() =
  inherit Migration()

  override __.Up() =
    base.Execute(@"CREATE TABLE Customers(
      Id TEXT NOT NULL,
      FirstName TEXT NOT NULL,
      LastName TEXT NOT NULL,
      EthAddress TEXT NOT NULL,
      Password TEXT NOT NULL,
      PasswordSalt TEXT NOT NULL,
      Avatar TEXT NOT NULL
    )")

  override __.Down() =
    base.Execute(@"DROP TABLE Customers")
