module Bootstrap

open Froster.Application
open Froster.Infrastructure
open FSharp.Data

type AppSettings = JsonProvider<"./appSettings.json">
let connString = AppSettings.GetSample().ConnectionString

// Persistence Dependencies
let fetchPlayerDb = Sql.PlayerRepository.fetchPlayer connString
let fetchPlayersDb = Sql.PlayerRepository.fetchPlayers connString
let writePlayerDb = Sql.PlayerRepository.writePlayer connString
let updatePlayerDb = Sql.PlayerRepository.updatePlayer connString

// Application Dependencies
let getPlayer = GetPlayer.getPlayer fetchPlayerDb
let getPlayers = GetPlayers.getPlayers fetchPlayersDb
let createPlayer = CreatePlayer.createPlayer writePlayerDb 
let updatePlayer = UpdatePlayer.updatePlayer updatePlayerDb getPlayer