module HttpHandlers

open Models
open Views
open Giraffe
open Bootstrap

let indexHandler name =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let playersHandler = getPlayers

let playerHandler id =
    let player = getPlayer id
    match player with
    | Some p -> json p
    | None -> RequestErrors.notFound (json "an error")

let submitPlayer createPlayerCommand =
    let result = createPlayer createPlayerCommand
    match result with 
    | Ok _ -> Successful.OK ()
    | Error e -> RequestErrors.BAD_REQUEST e