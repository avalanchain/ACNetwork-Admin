namespace CustomerVerificationEvents

open Database
open Microsoft.Data.Sqlite
open System.Threading.Tasks

module Database =
  let getAll connectionString : Task<Result<CustomerVerificationEvent seq, exn>> =
    use connection = new SqliteConnection(connectionString)
    query connection "SELECT Id, CustomerId, EventType, CreatedOn, CreatedBy, Proof FROM CustomerVerificationEvents" None

  let getById connectionString id : Task<Result<CustomerVerificationEvent option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT Id, CustomerId, EventType, CreatedOn, CreatedBy, Proof FROM CustomerVerificationEvents WHERE Id=@Id" (Some <| dict ["id" => id])

  let update connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "UPDATE CustomerVerificationEvents SET Id = @Id, CustomerId = @CustomerId, EventType = @EventType, CreatedOn = @CreatedOn, CreatedBy = @CreatedBy, Proof = @Proof WHERE Id=@Id" v

  let insert connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "INSERT INTO CustomerVerificationEvents(Id, CustomerId, EventType, CreatedOn, CreatedBy, Proof) VALUES (@Id, @CustomerId, @EventType, @CreatedOn, @CreatedBy, @Proof)" v

  let delete connectionString id : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM CustomerVerificationEvents WHERE Id=@Id" (dict ["id" => id])

