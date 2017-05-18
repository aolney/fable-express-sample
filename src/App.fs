module FableExpressSample

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let app = express.Invoke()

// Handle request using plain `string` route specification
app.get
  ( U2.Case1 "/hello/:name", 
    fun (req:express.Request) (res:express.Response) _ ->
      res.send(sprintf "Hello %O" req.``params``?name) |> box)
|> ignore

// Get PORT environment variable or use default
let port =
  match unbox Node.Globals.``process``.env?PORT  with
  | Some x -> x | None -> 8080

// Start the server on the port
app.listen(port, unbox (fun () ->
  printfn "Server started: http://localhost:%i/" port))
|> ignore