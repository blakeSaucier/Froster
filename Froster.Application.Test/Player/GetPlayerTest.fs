module Froster.Application.Test.Player.GetPlayerTest

open NUnit.Framework
open Froster.Domain
open Froster.Application.GetPlayer
open FsUnit

let mockPlayer = 
    {
        Id = 1
        FirstName = "James"
        LastName = "Saucier"
        Position = Some "Center"
        PhoneNumber = "604503423"
        Number = 89
        Status = "FullTime"
    }

[<Test>]
let ``Should Find Player`` () =
    let fetchPlayer = fun _ -> Some mockPlayer
    let result = getPlayer fetchPlayer 1
    result |> should equal (Some mockPlayer)

[<Test>]
let ``Should Not Find Player`` () =
    let fetchPlayer = fun _ -> None
    let result = getPlayer fetchPlayer 1
    result |> should equal None