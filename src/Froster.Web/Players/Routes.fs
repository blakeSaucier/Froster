module Players.Routes

open Giraffe
open Players.Handlers
open Froster.Application.Players.Requests

let playerRoutes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/players" >=> json playersHandler
                routef "/players/%i" playerHandler
            ]
        POST >=> route "/players" >=> bindModel<CreatePlayerCommand> None submitPlayer
    ]