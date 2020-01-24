module Froster.Application.GetPlayer

open Froster.Domain

let getPlayer (fetchPlayer: FetchPlayer) playerId =
    let player = fetchPlayer playerId
    player