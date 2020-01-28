module Bootstrap

open Froster.Application
open Froster.Infrastructure

let getPlayer = GetPlayer.getPlayer PlayerRepository.fetchPlayer
let getPlayers = GetPlayers.getPlayers PlayerRepository.fetchPlayers
