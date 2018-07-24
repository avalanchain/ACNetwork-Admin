module ServerUtils

open System
open System.Collections
open System.Collections.Generic
open System.Runtime.ExceptionServices
open FSharp.Control.Tasks
open System.Threading.Tasks

module Result =

    let inline isOk r = match r with | Ok _ -> true | Error _ -> false
    let inline isError r = r |> isOk |> not

    let reWrap (r: Result<Task<'T>, 'E>) : Task<Result<'T, 'E>> = task {
        let! u = match r with  // Really a hacky way of doing this
                    | Ok okTask -> task {   let! res = okTask
                                            return res :> obj  }  
                    | Error e -> e :> obj |> Task.FromResult
        return  if r |> isOk then u :?> 'T |> Ok
                else u :?> 'E |> Error
    }


// module TaskResult =
//     open System.Threading.Tasks
//     open FSharp.Control.Tasks.V2.ContextSensitive

//     type TaskResultBuilder () =
//         member __.Return value : Step<Result<'T, 'Error>> =
//             Ok value
//             |> task.Return

//         member __.ReturnFrom (taskResult : Step<Result<'T, 'Error>>) =
//             taskResult

//         member inline this.Zero () : Task<Result<unit, 'Error>> =
//             this.ReturnFrom ()

//         member inline this.Delay (generator : unit -> Step<Result<'T, 'Error>>) =
//             task.Delay generator

//         member __.Combine (r1, r2) : Task<Result<'T, 'Error>> =
//             task {
//                 let! r1' = r1
//                 match r1' with
//                 | Error error ->
//                     return Error error
//                 | Ok () ->
//                     return! r2
//             }

//         member __.Bind (value : Task<Result<'T, 'Error>>, binder : 'T -> Task<Result<'U, 'Error>>)
//             : Task<Result<'U, 'Error>> =
//             task {
//                 let! value' = value
//                 match value' with
//                 | Error error ->
//                     return Error error
//                 | Ok x ->
//                     return! binder x
//             }

//         member inline __.TryWith (computation : unit -> Step<Result<'T, 'Error>>, catchHandler : exn -> Step<Result<'T, 'Error>>) =
//             task.TryWith(computation, catchHandler)

//         member inline __.TryFinally (computation : unit -> Step<Result<'T, 'Error>>, compensation : unit -> unit) =
//             task.TryFinally (computation, compensation)

//         member inline __.Using (resource : ('T :> System.IDisposable), binder : _ -> Step<Result<'U, 'Error>>) =
//             task.Using (resource, binder)

//         member this.While (guard, body : Task<Result<unit, 'Error>>) =
//             if guard () then
//                 this.Bind (body, (fun () -> this.While (guard, body)))
//             else
//                 this.Zero ()

//         member this.For (sequence : seq<_>, body : 'T -> Task<Result<unit, 'Error>>) =
//             this.Using (sequence.GetEnumerator (), fun enum ->
//                 this.While (
//                     enum.MoveNext,
//                     this.Delay (fun () ->
//                         body enum.Current)))


//     let taskResult = TaskResultBuilder()
//     type TaskResult<'a> = Task<Result<'a, exn>>

