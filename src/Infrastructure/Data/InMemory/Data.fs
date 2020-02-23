module Froster.Infrastructure.Data

open Froster.Domain

let players =
    Map.empty
        .Add(1, { PlayerId = 1; FirstName = "James"; LastName = "Saucier"; Number = 89; PhoneNumber = "6048982828"; Position = Some "Center"; Status = "Fulltime" })
        .Add(2, { PlayerId = 2; FirstName = "Don"; LastName = "Ma"; Number = 88; PhoneNumber = "6048982828"; Position = None; Status = "Fulltime" })