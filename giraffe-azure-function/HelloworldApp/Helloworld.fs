module Helloworld

open System.Globalization
open Giraffe

[<CLIMutable>]
type Person = 
    { Name:string }

let ic = Some CultureInfo.InvariantCulture

let sayHello name = sprintf "hello %s" name

let hello = bindQuery ic (fun p -> sayHello p.Name |> text)

let webApp : HttpHandler =
    choose [
        GET >=> route "/api/v1/ping" >=> text "pong"
        GET >=> route "/api/v1/hello" >=> hello
        GET >=> text "home page" ]