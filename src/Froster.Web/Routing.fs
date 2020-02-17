module Routing

open Giraffe
open Index.Routes
open Players.Routes

let webApp: HttpFunc -> HttpFunc =
    choose [
        indexRoutes
        playerRoutes
        setStatusCode 404 >=> text "Not Found" 
    ]
