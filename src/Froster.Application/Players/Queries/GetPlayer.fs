module Froster.Application.GetPlayer

open Froster.Application.Interfaces

let getPlayer (fetchPlayer: FetchPlayer) playerId =
    let player = fetchPlayer playerId
    player