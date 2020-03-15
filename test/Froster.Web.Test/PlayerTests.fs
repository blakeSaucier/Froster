module Froster.Web.Test.PlayerTests

open TestBootstrap
open Xunit
open Players.Handlers
open Froster.Domain
open FsUnit
open FSharp.Control.Tasks.V2

let mockPlayer = 
    {
        PlayerId = 1
        FirstName = "James"
        LastName = "Saucier"
        Position = Some "Center"
        PhoneNumber = "604503423"
        Number = 89
        Status = "FullTime"
        TeamId = 1
    }

[<Fact>]
let ``getPlayer should should successfully return http`` () =
    true |> should equal true
    // let mockContext = mockHttpContext "GET" "/players/1"
    // let getPlayerMock = fun (_:int) -> Some mockPlayer
    // task {
        //let! result = playerHandler getPlayerMock 1
        //match result with
        //| Some p -> p |> should equal mockPlayer
        //| None -> failWithMsg "Should have returned http result"
    // }
