module Views

open Giraffe
open GiraffeViewEngine
open Models

let layout (content: XmlNode list) =
    html [] [
        head [] [
            title []  [ encodedText "Froster.Web" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/main.css" ]
        ]
        body [] content
    ]

let partial () =
    h1 [] [ encodedText "Froster.Web" ]

let index (model : Message) =
    [
        partial()
        p [] [ encodedText model.Text ]
    ] |> layout
