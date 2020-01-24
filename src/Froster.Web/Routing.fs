module Routing

open Giraffe
open HttpHandlers

let webApp: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
                route "/players" >=> json playersHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]
