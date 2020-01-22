module HttpHandlers

open Models
open Views
open Giraffe

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let weatherHandler = [
    { Temperature = 8; Conditions = "Rain" };
    { Temperature = 10; Conditions = "Rain Showers" };
    { Temperature = 10; Conditions = "Rain" };
]