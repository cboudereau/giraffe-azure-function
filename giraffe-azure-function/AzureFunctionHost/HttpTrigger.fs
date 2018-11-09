namespace AzureFunctionHost

open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open FSharp.Control.Tasks.V2.ContextInsensitive

open Giraffe

module HttpTrigger =
  let run (req: HttpRequest, log: ILogger) =
    task {
        log.LogInformation("F# HTTP trigger function processed a request.")

        let zero:HttpFunc = fun _ -> None |> System.Threading.Tasks.Task.FromResult

        let! r = Helloworld.webApp zero req.HttpContext
        
        r |> ignore
    }