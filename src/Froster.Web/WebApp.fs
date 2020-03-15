module Froster.Web.WebApp

open Giraffe
open Web.Common
open Index.Routes
open Players.Routes
open Players.Bootstrap
open Players.Handlers

let playerHandlers = {
    GetPlayersHandler = getPlayersHandler getPlayers
    GetPlayerHandler = (getPlayerHandler getPlayer)
    CreatePlayerHandler = createPlayerHandler createPlayer
}

let indexHandlers = { Index = indexHandler }

let routes handlers : Router =
    let playerHandlers, indexHandlers = handlers
    choose [
        indexRoutes indexHandlers
        playerRoutes playerHandlers
        setStatusCode 404 >=> text "Not Found"
    ]

let webApp : Router = routes (playerHandlers, indexHandlers)
