module HttpHandlers

open Models
open Views
open Giraffe
open Froster.Application.GetPlayers
open Froster.Domain

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let playersHandler =
    let fetch = fun () -> [{ Id = 1; FirstName = "James"; LastName = "Saucier"; Position = Center; Number = 89; PhoneNumber = "7789952549"; Status = Fulltime; }]

    let players = getPlayers fetch
    players