module Players.Routes

open Giraffe
open Players.Handlers
open Bootstrap

let playerRoutes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/players" >=> playersHandler getPlayers
                routef "/players/%i" (playerHandler getPlayer)
            ]
        POST >=> route "/players" >=> submitPlayer createPlayer
    ]