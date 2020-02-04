module Routing

open Giraffe
open HttpHandlers
open Froster.Application.Common

let webApp: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
                route "/players" >=> json playersHandler
                routef "/player/%i" playerHandler
            ]
        POST >=> route "/player" >=> bindModel<CreatePlayerCommand> None submitPlayer
        setStatusCode 404 >=> text "Not Found" ]
