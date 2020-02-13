module Froster.Application.Common.Requests

type CreatePlayerCommand =
    {
        FirstName: string
        LastName: string
        Position: string
        JerseyNumber: int
        PhoneNumber: string
        Status: string
    }

type UpdatePlayerCommand =
    {
        PlayerId: int
        FirstName: string
        LastName: string
        Position: string
        JerseyNumber: int
        PhoneNumber: string
        Status: string
    }