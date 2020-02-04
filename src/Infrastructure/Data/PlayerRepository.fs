module Froster.Infrastructure.PlayerRepository

open Froster.Infrastructure.Data
open Froster.Application.Interfaces

let fetchPlayer: FetchPlayer = fun id ->
    Map.tryFind id players

let fetchPlayers: FetchPlayers = fun () ->
    let list = Map.toList players
    list |> List.map (fun (_, player) -> player)