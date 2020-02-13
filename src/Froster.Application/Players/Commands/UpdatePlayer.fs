module UpdatePlayer

open Froster.Domain
open Froster.Application.Interfaces
open Froster.Application.Common.Requests

let private validate (updateCommand:UpdatePlayerCommand) = Ok updateCommand // Add some validation here
    
let updatePlayer (writeUpdate: WritePlayerUpdate) updateCommand =
    let validated = validate updateCommand
    validated |> Result.map writeUpdate