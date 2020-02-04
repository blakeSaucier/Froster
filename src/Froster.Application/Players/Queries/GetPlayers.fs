module Froster.Application.GetPlayers

open Froster.Domain
open Froster.Application.Interfaces

let getPlayers (fetchPlayers: FetchPlayers) =
    let players = fetchPlayers ()
    players |> List.sortBy (fun p -> p.LastName)
