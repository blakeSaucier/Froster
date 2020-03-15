module Froster.Web.Tests.IndexTests

open Xunit
open FSharp.Control.Tasks.V2
open TestBootstrap
open Index.Routes
open FsUnit
open Froster.Web.WebApp

[<Fact>]
let ``"/" should say 'Hello world'`` () =
    task {
        let mockContext = mockHttpContext "GET" "/"
        let index = indexRoutes indexHandlers
        let! result = index next mockContext
        match result with
        | Some ctx -> 
            getBody ctx |> should contain "Hello world"
        | None -> failWithMsg "Should have returned an Http response"
    }

[<Fact>]
let ``"/hello/James" should say 'Hello James'`` () =
    task {
        let mockContext = mockHttpContext "GET" "/hello/James"
        let index = indexRoutes indexHandlers
        let! result = index next mockContext
        match result with
        | Some context ->
            getBody context |> should contain "Hello James"
        | None -> failWithMsg "Should have produced an Http response"
    }