module Index.Routes

open Models
open Views
open Giraffe
open Web.Common

type IndexHandlers = { Index: string -> HttpHandler }

let indexHandler name : HttpHandler =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let indexRoutes handlers : Router =
    choose [
        GET >=>
            choose [
                route "/" >=> handlers.Index "world"
                routef "/hello/%s" handlers.Index
            ]
    ]