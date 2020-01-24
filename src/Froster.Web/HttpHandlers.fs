module HttpHandlers

open Models
open Views
open Giraffe
open Froster.Application.GetPlayers

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let playersHandler =
    let players = getPlayers
    players

