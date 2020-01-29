module CreatePlayer

open Froster.Application.CreatePlayer

let private validatePlayer createPlayerCommand =
    match createPlayerCommand.FirstName with
    | null -> Error "Invalid First Name"
    | "" -> Error "Name is Empty"
    | _ -> Ok createPlayerCommand

let createPlayer createPlayerCommand = validatePlayer createPlayerCommand
