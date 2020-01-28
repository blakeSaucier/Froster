module Routing

open Giraffe
open HttpHandlers
open Froster.Application.CreatePlayer
open FSharp.Control.Tasks.V2

let submitPlayer: HttpHandler = fun next context ->
    task {
        let! command = context.BindJsonAsync<CreatePlayerCommand>() |> Async.AwaitTask
        return! createPlayer command next context
    }


let webApp: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
                route "/players" >=> json playersHandler
                routef "/player/%i" playerHandler
            ]
        POST >=> route "/player" >=> submitPlayer
        setStatusCode 404 >=> text "Not Found" ]
