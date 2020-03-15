module Web.Common

open Giraffe

type Router = HttpFunc -> HttpFunc
