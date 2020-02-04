module Froster.Application.Interfaces

open Froster.Domain

type FetchPlayers = unit -> Player list
type FetchPlayer = int -> Player option