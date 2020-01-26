module HttpHandlers

open Models
open Views
open Giraffe
open Froster.Application
open Froster.Infrastructure

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let playersHandler =
    let players = GetPlayers.getPlayers PlayerRepository.fetchPlayers
    players

let playerHandler id =
    let player = GetPlayer.getPlayer PlayerRepository.fetchPlayer id
    match player with
    | Some p -> json p
    | None -> setStatusCode 404