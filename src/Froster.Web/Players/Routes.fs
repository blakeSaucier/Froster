module Players.Routes

open Giraffe
open Players.Handlers
open Web.Common

let playerRoutes handlers : Router =
    choose [
        GET >=>
            choose [
                route "/players" >=> handlers.GetPlayersHandler
                routef "/players/%i" handlers.GetPlayerHandler
            ]
        POST >=> route "/players" >=> handlers.CreatePlayerHandler
    ]