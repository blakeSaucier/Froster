module Froster.Infrastructure.Sql.PlayerRepository

open Froster.Domain
open FSharp.Data
open CompileTimeConnection
open Froster.Application.Players.Requests

type private FindOnePlayer = SqlCommandProvider<"
    SELECT *
    FROM Players
    WHERE PlayerId = @playerId
    ", connectionString>

type private AllPlayers = SqlCommandProvider<"
    SELECT *
    FROM Players
    ", connectionString>

type private InsertPlayer = SqlCommandProvider<"
    INSERT INTO Players (FirstName, LastName, Position, PhoneNumber, JerseyNumber, Status)
    VALUES (@FirstName, @LastName, @Position, @PhoneNumber, @JerseyNumber, @Status)
    ", connectionString>

type private UpdatePlayer = SqlCommandProvider<"
    Update Players
    Set FirstName = @FirstName, LastName = @LastName, Position = @Position, JerseyNumber = @JerseyNumber, PhoneNumber = @PhoneNumber, Status = @Status
    Where PlayerId = @PlayerId
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

let writePlayer (connection:string) (newPlayer:CreatePlayerCommand) =
    use cmd = new InsertPlayer(connection)
    let { 
        CreatePlayerCommand.FirstName = first
        LastName = last
        Position = position
        JerseyNumber = jerseyNumber
        PhoneNumber = phoneNumber
        Status = status
        } = newPlayer
    cmd.Execute(first, last, position, phoneNumber, jerseyNumber, status) |> ignore

let writePlayerUpdate (connection:string) command =
    use cmd = new UpdatePlayer(connection)
    cmd.Execute(
        command.FirstName,
        command.LastName,
        command.Position,
        command.JerseyNumber,
        command.PhoneNumber,
        command.Status,
        command.PlayerId) |> ignore
    