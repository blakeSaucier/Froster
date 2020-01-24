module Froster.Domain

open System

type Position =
    | Defense
    | LeftWing
    | RightWing
    | Center

type JerseyNumber = int

type PlayerStatus =
    | Fulltime
    | Spare
    | Unavailable

type Player =
    {
        Id: int
        FirstName: string
        LastName: string
        Position: Position
        Number: JerseyNumber
        PhoneNumber: string
        Status: PlayerStatus 
    }

type Game =
    {
        Id: int
        Location: string
        StartTimeUtc: DateTime
        Description: string
    }