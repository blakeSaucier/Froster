module Players.Handlers

open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2
open Froster.Application.Players.Requests

type PlayerHandlers = {
    GetPlayersHandler: HttpHandler
    GetPlayerHandler: int -> HttpHandler
    CreatePlayerHandler: HttpHandler
}

let getPlayersHandler getPlayers: HttpHandler = json getPlayers

let getPlayerHandler getPlayer playerId : HttpHandler =
    let player = getPlayer playerId
    match player with
    | Some p -> json p
    | None -> RequestErrors.notFound (json None)

let createPlayerHandler createPlayer : HttpHandler =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let! createPlayerCommand = ctx.BindModelAsync<CreatePlayerCommand>()
            let result = createPlayer createPlayerCommand
            return!
                (match result with
                | Ok _ -> Successful.OK () next ctx
                | Error e -> RequestErrors.BAD_REQUEST e next ctx)
        }