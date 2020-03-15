module Players.Routes

open Giraffe
open Players.Handlers

let playerRoutes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/players" >=> playersHandler
                routef "/players/%i" playerHandler
            ]
        POST >=> route "/players" >=> submitPlayer
    ]