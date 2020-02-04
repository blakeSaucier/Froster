module Froster.Infrastructure.Sql.PlayerRepository

open Froster.Domain
open FSharp.Data
open CompileTimeConnection

type private FindOnePlayer = SqlCommandProvider<"
    SELECT *
    FROM Players
    WHERE PlayerId = @playerId
    ", connectionString>

type private AllPlayers = SqlCommandProvider<"
    SELECT *
    FROM Players
    ", connectionString>

let private mapRecord (record:FindOnePlayer.Record) =
    {
        Id = record.PlayerId 
        FirstName = record.FirstName
        LastName = record.LastName
        Position = record.Position
        Number= record.JerseyNumber
        PhoneNumber = record.PhoneNumber
        Status = record.Status
    }

let private mapAllPlayersRecord (record:AllPlayers.Record) =
    {
        Id = record.PlayerId 
        FirstName = record.FirstName
        LastName = record.LastName
        Position = record.Position
        Number= record.JerseyNumber
        PhoneNumber = record.PhoneNumber
        Status = record.Status
    }

let private mapSingle (records:FindOnePlayer.Record list) =
    match records |> Seq.tryHead with
    | None -> None
    | Some playerRecord -> mapRecord playerRecord |> Some

let fetchPlayer (connection:string) id =
    use cmd = new FindOnePlayer(connection)
    let records = cmd.Execute(id) |> Seq.toList
    mapSingle records

let fetchPlayers (connection:string) () =
    use cmd = new AllPlayers(connection)
    let res = cmd.Execute () |> Seq.toList
    res |> List.map mapAllPlayersRecord