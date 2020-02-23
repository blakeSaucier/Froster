module Froster.Domain

open System

type JerseyNumber = int

type Team =
    {
        TeamId: int
        TeamName: string
        Location: string
        TimeZone: TimeZoneInfo
    }

type Player =
    {
        PlayerId: int
        FirstName: string
        LastName: string
        Position: string option
        Number: JerseyNumber
        PhoneNumber: string
        Status: string 
    }

type Game =
    {
        Id: int
        Location: string
        StartTimeUtc: DateTime
        Description: string
    }