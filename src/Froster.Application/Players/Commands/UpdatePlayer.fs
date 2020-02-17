module Froster.Application.UpdatePlayer

open Froster.Application.Interfaces
open Froster.Application.Common.Requests
open System

let private failIf condition message data =
    if condition then Error message else Ok data

let private playerMustExist (getPlayer: FetchPlayer) updateCommand =
    let player = getPlayer updateCommand.PlayerId
    match player with
    | Some _ -> Ok updateCommand
    | None -> Error "Player does not exist"

let private nameNotLongerThan50 updateCommand =
    failIf (updateCommand.FirstName.Length > 50) "Invalid First Name" updateCommand

let private nameNotEmpty updateCommand =
    failIf (String.IsNullOrWhiteSpace updateCommand.FirstName) "Invalid First Name" updateCommand

let private validJerseyNumber updateCommand =
    let greaterThan0 = failIf (updateCommand.JerseyNumber <= 0) "Invalid JerseyNumber"
    let lessThan100 = failIf (updateCommand.JerseyNumber >= 100) "Invalid JerseyNumber"
    updateCommand
    |> greaterThan0
    |> Result.bind lessThan100

let private phoneNumberLength updateCommand =
    failIf (updateCommand.PhoneNumber.Length < 10) "Invalid phone number" updateCommand

let private validate updateCommand = 
    updateCommand
    |> nameNotEmpty
    |> Result.bind nameNotLongerThan50
    |> Result.bind validJerseyNumber
    |> Result.bind phoneNumberLength

let updatePlayer (writeUpdate: WritePlayerUpdate) (getPlayer: FetchPlayer) updateCommand =
    updateCommand
    |> playerMustExist getPlayer
    |> Result.bind validate
    |> Result.map writeUpdate