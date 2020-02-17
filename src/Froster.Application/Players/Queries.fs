module Froster.Application.Players.Queries

open Froster.Domain
open Froster.Application.Players.Interfaces

let getPlayer (fetchPlayer: FetchPlayer) playerId = fetchPlayer playerId

let getPlayers (fetchPlayers: FetchPlayers) =
    let players = fetchPlayers ()
    players |> List.sortBy (fun p -> p.LastName)