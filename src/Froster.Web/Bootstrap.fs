module Bootstrap

open Froster.Application
open Froster.Infrastructure
open FSharp.Data

type AppSettings = JsonProvider<"./appSettings.json">
let connString = AppSettings.GetSample().ConnectionString

// Persistence Dependencies
let fetchPlayerImplementation = Sql.PlayerRepository.fetchPlayer connString
let fetchPlayersImplementation = Sql.PlayerRepository.fetchPlayers connString
let writePlayerImplementation = Sql.PlayerRepository.writePlayer connString

// Application Dependencies
let getPlayer = GetPlayer.getPlayer fetchPlayerImplementation
let getPlayers = GetPlayers.getPlayers fetchPlayersImplementation
let createPlayer = CreatePlayer.createPlayer writePlayerImplementation