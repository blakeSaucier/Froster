module Froster.Infrastructure.PlayerRepository
open Froster.Domain
open Froster.Infrastructure.Data

let fetchPlayer: FetchPlayer = fun id ->
    Map.tryFind id players

let fetchPlayers: FetchPlayers = fun () ->
    let list = Map.toList players
    list |> List.map (fun (_, player) -> player)