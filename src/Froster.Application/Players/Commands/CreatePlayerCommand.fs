module Froster.Application.CreatePlayer

type CreatePlayerCommand =
    {
        FirstName: string
        LastName: string
        Position: string
        Number: int
        PhoneNumber: string
        Status: string
    }