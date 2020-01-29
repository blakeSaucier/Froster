module HttpHandlers

open Models
open Views
open Giraffe
open Bootstrap
open FSharp.Control.Tasks.V2
open Froster.Application.CreatePlayer

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let playersHandler = getPlayers

let playerHandler id =
    let player = getPlayer id
    match player with
    | Some p -> json p
    | None -> setStatusCode 404

let submitPlayer: HttpHandler = fun next context ->
    task {
        let! command = context.BindJsonAsync<CreatePlayerCommand>()
        let result = createPlayer command
        let response =
            match result with
            | Ok _ -> Successful.OK ()
            | Error e -> RequestErrors.BAD_REQUEST e
        return! response next context
    }