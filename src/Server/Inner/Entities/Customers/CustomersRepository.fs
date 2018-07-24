namespace Customers

open Database
open Microsoft.Data.Sqlite
open System.Threading.Tasks
open Dapper
open System

module Database =
  // type GuidTypeHandler() =
  //   inherit SqlMapper.TypeHandler<Guid>()

  //   override __.Parse (value: obj) =
  //       let inVal = string value
  //       new Guid(inVal)

  //   override __.SetValue (parameter: System.Data.IDbDataParameter, value: Guid) =
  //       raise (new NotImplementedException())
  //       // let outVal = value.ToString("N")
  //       // parameter.Value <- outVal

  let getAll connectionString : Task<Result<Customer seq, exn>> =
    use connection = new SqliteConnection(connectionString)
    query connection "SELECT Id, Email, FirstName, LastName, EthAddress, Password, PasswordSalt, Avatar, CustomerTier FROM Customers" None

  let getById connectionString id : Task<Result<Customer option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT Id, Email, FirstName, LastName, EthAddress, Password, PasswordSalt, Avatar, CustomerTier FROM Customers WHERE Id=@Id" (Some <| dict ["id" => id])

  let getByEmail connectionString email : Task<Result<Customer option, exn>> =
    use connection = new SqliteConnection(connectionString)
    querySingle connection "SELECT Id, Email, FirstName, LastName, EthAddress, Password, PasswordSalt, Avatar, CustomerTier FROM Customers WHERE Email=@email LIMIT 1" (Some <| dict ["email" => email])


  let update connectionString v : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "UPDATE Customers SET Id = @Id, Email = @Email, FirstName = @FirstName, LastName = @LastName, EthAddress = @EthAddress, Password = @Password, PasswordSalt = @PasswordSalt, Avatar = @Avatar, CustomerTier = @CustomerTier WHERE Id=@Id" v

  let insert connectionString v : Task<Result<int,exn>> =
    // SqlMapper.AddTypeHandler<Guid>(new GuidTypeHandler())
    use connection = new SqliteConnection(connectionString)
    execute connection "INSERT INTO Customers(Id, Email, FirstName, LastName, EthAddress, Password, PasswordSalt, Avatar, CustomerTier) VALUES (@Id, @Email, @FirstName, @LastName, @EthAddress, @Password, @PasswordSalt, @Avatar, @CustomerTier)" v

  let delete connectionString id : Task<Result<int,exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM Customers WHERE Id=@Id" (dict ["id" => id])

  let deleteAll connectionString : Task<Result<int, exn>> =
    use connection = new SqliteConnection(connectionString)
    execute connection "DELETE FROM Customers" None