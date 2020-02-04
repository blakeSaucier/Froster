module Froster.Application.Interfaces

open Froster.Domain
open Froster.Application.Common

type FetchPlayers = unit -> Player list
type FetchPlayer = int -> Player option
type WritePlayer = CreatePlayerCommand -> unit