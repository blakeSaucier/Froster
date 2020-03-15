module Froster.Web.Test.PlayerTests

open TestBootstrap
open Giraffe
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
let ``"/players/1" should should successfully return http`` () =
     let mockContext = mockHttpContext "GET" "/players/1"
     let fetchPlayerMock = fun _ -> Some mockPlayer
     let getPlayer = getPlayerHandler fetchPlayerMock
     task {
        let! result = getPlayer 1 next mockContext
        match result with
        | Some p -> getBody p |> should contain "James"
        | None -> failWithMsg "Should have returned http result"
     }

[<Fact>]
let ``should produce 404 when no player is found`` () =
    let mockContext = mockHttpContext "GET" "/players/1"
    let fetchPlayerMock = fun _ -> None
    let handler = getPlayerHandler fetchPlayerMock
    task {
       let! result = handler 1 next mockContext
       match result with
       | Some context -> context.Response.StatusCode |> should equal 404
       | None -> failWithMsg "Should have returned http result"
    }

open Players.Routes
let mockHandlers = {
    GetPlayersHandler = json ()
    GetPlayerHandler = fun _ -> json ()
    CreatePlayerHandler = json ()
}

[<Fact>]
let ``Should resolve player route to handler`` () =
    let mockContext = mockHttpContext "GET" "/players/1"
    let mockHandler = fun _ -> json (Some "Called Handler")
    let handlers = { mockHandlers with GetPlayerHandler = mockHandler }
    let playerRouting = playerRoutes handlers
    task {
        let! result = playerRouting next mockContext
        match result with
        | Some context -> 
            getBody context |> should contain "Called Handler"
        | None -> failWithMsg "Should have returned http result"
    }

