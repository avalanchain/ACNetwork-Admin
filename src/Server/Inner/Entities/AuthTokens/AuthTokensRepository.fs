namespace AuthTokens

open Database
open Microsoft.Data.Sqlite
open System.Threading.Tasks

module Database =
  let getAll connectionString : Task<Result<AuthToken seq, exn>> =
    use connection = new SqliteConnection(connectionString)
    query connection "SELECT AuthToken, CustomerId, Issued, Expires FROM AuthTokens" None

  let getById connectionString authToken : Task<Result<AuthToken option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT AuthToken, CustomerId, Issued, Expires FROM AuthTokens WHERE AuthToken=@AuthToken" (Some <| dict ["AuthToken" => authToken])

  let getByCustomerId connectionString customerId : Task<Result<AuthToken option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT AuthToken, CustomerId, Issued, Expires FROM AuthTokens WHERE CustomerId=@CustomerId ORDER BY CreatedOn DESC LIMIT 1" (Some <| dict ["CustomerId" => customerId])


  let update connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "UPDATE AuthTokens SET AuthToken = @AuthToken, CustomerId = @CustomerId, Issued = @Issued, Expires = @Expires WHERE AuthToken=@AuthToken" v

  let insert connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "INSERT INTO AuthTokens(AuthToken, CustomerId, Issued, Expires) VALUES (@AuthToken, @CustomerId, @Issued, @Expires)" v

  let delete connectionString id : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM AuthTokens WHERE AuthToken=@AuthToken" (dict ["id" => id])

  let deleteAll connectionString : Task<Result<int, exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM AuthTokens" None