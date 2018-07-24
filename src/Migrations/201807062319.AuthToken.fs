namespace Migrations
open SimpleMigrations

[<Migration(201807062319L, "Create AuthTokens")>]
type CreateAuthTokens() =
  inherit Migration()

  override __.Up() =
    base.Execute(@"CREATE TABLE AuthTokens(
      AuthToken TEXT NOT NULL,
      CustomerId TEXT NOT NULL,
      Issued DATETIME NOT NULL,
      Expires DATETIME NOT NULL
    )")

  override __.Down() =
    base.Execute(@"DROP TABLE AuthTokens")
