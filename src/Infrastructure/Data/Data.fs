module Froster.Infrastructure.Data

open Froster.Domain

let players =
    Map.empty
        .Add(1, { Id = 1; FirstName = "James"; LastName = "Saucier"; Number = 89; PhoneNumber = "6048982828"; Position = Center; Status = Fulltime })
        .Add(2, { Id = 1; FirstName = "Don"; LastName = "Ma"; Number = 88; PhoneNumber = "6048982828"; Position = LeftWing; Status = Fulltime })