namespace CustomerPreferences

open Database
open Microsoft.Data.Sqlite
open System.Threading.Tasks

module Database =
  let getAll connectionString : Task<Result<CustomerPreference seq, exn>> =
    use connection = new SqliteConnection(connectionString)
    query connection "SELECT Id, Language FROM CustomerPreferences" None

  let getById connectionString id : Task<Result<CustomerPreference option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT Id, Language FROM CustomerPreferences WHERE Id=@Id" (Some <| dict ["id" => id])

  let update connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "UPDATE CustomerPreferences SET Id = @Id, Language = @Language WHERE Id=@Id" v

  let insert connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "INSERT INTO CustomerPreferences(Id, Language) VALUES (@Id, @Language)" v

  let delete connectionString id : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM CustomerPreferences WHERE Id=@Id" (dict ["id" => id])

  let deleteAll connectionString : Task<Result<int, exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM CustomerPreferences" None