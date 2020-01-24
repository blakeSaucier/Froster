module Froster.Application.GetPlayers

open Froster.Domain

let getPlayers = [
    { 
        Id = 1
        FirstName = "James"
        LastName = "Saucier"
        Position = Center
        Number = 89
        PhoneNumber = "7789952549"
        Status = Fulltime
    };
    {
        Id = 2
        FirstName = "Don"
        LastName = "Ma"
        Position = LeftWing
        Number = 81
        PhoneNumber = "6048819293"
        Status = Fulltime
    };
    ]