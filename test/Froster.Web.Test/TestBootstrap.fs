module TestBootstrap

open Giraffe
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open NSubstitute
open System.IO

let next: HttpFunc = Some >> Task.FromResult

let initializeMockHttpContext () =
    let ctx = Substitute.For<HttpContext>()
    ctx.Response.Body <- new MemoryStream()
    ctx

let mockHttpContext (method:string) path =
    let context = initializeMockHttpContext ()
    context.Request.Method.ReturnsForAnyArgs method |> ignore
    context.Request.Path.ReturnsForAnyArgs (PathString(path)) |> ignore
    context

let getBody (ctx: HttpContext) =
    ctx.Response.Body.Position <- 0L
    use reader = new StreamReader(ctx.Response.Body, System.Text.Encoding.UTF8)
    reader.ReadToEnd()

let getStatusCode (ctx: HttpContext) =
    ctx.Response.StatusCode

let failWithMsg msg =
    failwith msg |> ignore
