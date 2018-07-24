namespace Migrations
open SimpleMigrations

[<Migration(201806101833L, "Create CustomerPreferences")>]
type CreateCustomerPreferences() =
  inherit Migration()

  override __.Up() =
    base.Execute(@"CREATE TABLE CustomerPreferences(
      Id TEXT NOT NULL,
      Language TEXT NOT NULL
    )")

  override __.Down() =
    base.Execute(@"DROP TABLE CustomerPreferences")
