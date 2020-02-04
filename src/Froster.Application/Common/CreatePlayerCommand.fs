module Froster.Application.Common

type CreatePlayerCommand =
    {
        FirstName: string
        LastName: string
        Position: string
        JerseyNumber: int
        PhoneNumber: string
        Status: string
    }