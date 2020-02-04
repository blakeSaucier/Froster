module Bootstrap

open Froster.Application
open Froster.Infrastructure

let connString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\James\Documents\Froster.mdf;Integrated Security=True;Connect Timeout=30"

// Persistence Dependencies
let fetchPlayerImplementation = Sql.PlayerRepository.fetchPlayer connString
let fetchPlayersImplementation = Sql.PlayerRepository.fetchPlayers connString

// Application Dependencies
let getPlayer = GetPlayer.getPlayer fetchPlayerImplementation
let getPlayers = GetPlayers.getPlayers fetchPlayersImplementation
let createPlayer = CreatePlayer.createPlayer