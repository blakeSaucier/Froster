module Froster.Application.Test.Player.UpdatePlayerTest

open NUnit.Framework
open FsUnit
open Froster.Domain
open Froster.Application.Common.Requests
open Froster.Application

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

let mockRequest = 
    {
        PlayerId = 1
        FirstName = "James"
        LastName = "James"
        Position = "Center"
        PhoneNumber = "6045039423"
        JerseyNumber = 89
        Status = "FullTime"
    }

let invalidRequest = 
    {
        PlayerId = 1
        FirstName = " "
        LastName = " "
        Position = "Center"
        PhoneNumber = "603423"
        JerseyNumber = 89
        Status = "FullTime"
    }

let private ok : Result<unit,string> = Ok ()
let private withError message : Result<unit,string> = Error message

[<Test>]
let ``Player doesn't exist`` () =
    let fetchPlayer = fun _ -> None
    let writeUpdate = fun _ -> ()
    let expected = withError "Player does not exist"
    let actual = UpdatePlayer.updatePlayer writeUpdate fetchPlayer mockRequest
    actual |> should equal expected

[<Test>]
let ``Should pass validations`` () =
    let fetchPlayer = fun _ -> Some mockPlayer
    let writeUpdate = fun _ -> ()
    let expected = ok
    let result = UpdatePlayer.updatePlayer writeUpdate fetchPlayer mockRequest
    result |> should equal expected

[<Test>]
let ``Should fail validations`` () =
    let fetchPlayer = fun _ -> Some mockPlayer
    let writeUpdate = fun _ -> ()
    let expected = withError "Invalid First Name"
    let result = UpdatePlayer.updatePlayer writeUpdate fetchPlayer invalidRequest
    result |> should equal expected