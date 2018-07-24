[<AutoOpen>] 
module ServerFableMocks
open System

[<AttributeUsage(AttributeTargets.Method)>]
type PassGenericsAttribute() =
    inherit Attribute()

module Fable =
    module Core =
        let ``just a placeholder`` = ()