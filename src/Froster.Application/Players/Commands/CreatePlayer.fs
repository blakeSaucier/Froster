module CreatePlayer

open Froster.Application.Common.Requests
open Froster.Application.Interfaces

let private validatePlayer (createPlayerCommand: CreatePlayerCommand) =
    match createPlayerCommand.FirstName with
    | null -> Error "Invalid First Name"
    | "" -> Error "Name is Empty"
    | _ -> Ok createPlayerCommand

let createPlayer (writePlayer: WritePlayer) createPlayerCommand = 
    let validated = validatePlayer createPlayerCommand
    validated |> Result.map writePlayer

