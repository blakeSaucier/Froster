module Players.Bootstrap

open FSharp.Data
open Froster.Application.Players.Queries
open Froster.Application.Players.Commands
open Froster.Infrastructure.Sql.PlayerRepository

type AppSettings = JsonProvider<"./appSettings.json">
let connString = AppSettings.GetSample().ConnectionString

// Application Dependencies
let getPlayer = getPlayer (fetchPlayer connString)
let getPlayers = getPlayers (fetchPlayers connString)
let createPlayer = createPlayer (writePlayer connString)
let updatePlayer = updatePlayer (writePlayerUpdate connString) getPlayer