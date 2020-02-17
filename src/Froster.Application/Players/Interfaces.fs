module Froster.Application.Players.Interfaces

open Froster.Domain
open Froster.Application.Players.Requests

type FetchPlayers = unit -> Player list
type FetchPlayer = int -> Player option
type WritePlayer = CreatePlayerCommand -> unit
type WritePlayerUpdate = UpdatePlayerCommand -> unit