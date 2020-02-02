module Froster.Infrastructure.Sql.PlayerRepository

open Froster.Domain
open FSharp.Data

[<Literal>]
let private connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\James\Documents\Froster.mdf;Integrated Security=True;Connect Timeout=30"

type private FindOnePlayer = SqlCommandProvider<"
    SELECT *
    FROM Players
    WHERE PlayerId = @playerId
    ", connectionString>

let mapRecord (record:FindOnePlayer.Record) =
    {
        Id = record.PlayerId 
        FirstName = record.FirstName
        LastName = record.LastName
        Position = record.Position
        Number= record.JerseyNumber
        PhoneNumber = record.PhoneNumber
        Status = record.Status
    }

let mapRecords (records:FindOnePlayer.Record list) =
    match records |> Seq.tryHead with
    | None -> None
    | Some playerRecord -> mapRecord playerRecord |> Some

let fetchPlayer:FetchPlayer = fun id ->
    let connStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\James\Documents\Froster.mdf;Integrated Security=True;Connect Timeout=30"
    use cmd = new FindOnePlayer(connStr)
    let records = cmd.Execute(id) |> Seq.toList
    mapRecords records