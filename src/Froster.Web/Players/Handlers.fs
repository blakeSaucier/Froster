module Players.Handlers

open Giraffe
open Bootstrap
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2
open Froster.Application.Players.Requests

let playersHandler: HttpHandler = json getPlayers

let playerHandler playerId =
    let player = getPlayer playerId
    match player with
    | Some p -> json p
    | None -> RequestErrors.notFound (json None)

let submitPlayer =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        task {
            let! createPlayerCommand = ctx.BindModelAsync<CreatePlayerCommand>()
            let result = createPlayer createPlayerCommand
            return!
                (match result with
                | Ok _ -> Successful.OK () next ctx
                | Error e -> RequestErrors.BAD_REQUEST e next ctx)
        }