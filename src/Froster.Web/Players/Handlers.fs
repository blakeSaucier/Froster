module Players.Handlers

open Giraffe
open Bootstrap

let playersHandler = getPlayers

let playerHandler id =
    let player = getPlayer id
    match player with
    | Some p -> json p
    | None -> RequestErrors.notFound (json None)

let submitPlayer createPlayerCommand =
    let result = createPlayer createPlayerCommand
    match result with 
    | Ok _ -> Successful.OK ()
    | Error e -> RequestErrors.BAD_REQUEST e