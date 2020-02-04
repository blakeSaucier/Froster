module Froster.Domain

open System

type JerseyNumber = int

type Player =
    {
        Id: int
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