module CreatePlayer

open Froster.Application.Common
open Froster.Application.Interfaces

let private validatePlayer createPlayerCommand =
    match createPlayerCommand.FirstName with
    | null -> Error "Invalid First Name"
    | "" -> Error "Name is Empty"
    | _ -> Ok createPlayerCommand

let createPlayer (writePlayer:WritePlayer) createPlayerCommand = 
    let validated = validatePlayer createPlayerCommand
    validated |> Result.map writePlayer

