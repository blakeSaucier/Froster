module Index.Routes

open Models
open Views
open Giraffe

let indexHandler name =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = index model
    htmlView view

let indexRoutes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
            ]
    ]