module Bootstrap

open Froster.Application
open Froster.Infrastructure

let getPlayer = GetPlayer.getPlayer Sql.PlayerRepository.fetchPlayer
let getPlayers = GetPlayers.getPlayers PlayerRepository.fetchPlayers
let createPlayer = CreatePlayer.createPlayer