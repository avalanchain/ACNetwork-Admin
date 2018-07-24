namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

module BigNumber = 
    type [<AllowNullLiteral>] Format =
        abstract decimalSeparator: string option with get, set
        abstract groupSeparator: string option with get, set
        abstract groupSize: float option with get, set
        abstract secondaryGroupSize: float option with get, set
        abstract fractionGroupSeparator: string option with get, set
        abstract fractionGroupSize: float option with get, set

    and [<AllowNullLiteral>] Configuration =
        abstract DECIMAL_PLACES: float option with get, set
        abstract ROUNDING_MODE: RoundingMode option with get, set
        abstract EXPONENTIAL_AT: U2<float, float * float> option with get, set
        abstract RANGE: U2<float, float * float> option with get, set
        abstract ERRORS: U2<bool, float> option with get, set
        abstract CRYPTO: U2<bool, float> option with get, set
        abstract MODULO_MODE: RoundingMode option with get, set
        abstract POW_PRECISION: float option with get, set
        abstract FORMAT: Format option with get, set

    and RoundingMode =
        (** Rounds away from zero *)
        | ROUND_UP = 0
        (** Rounds towards zero *)
        | ROUND_DOWN = 1
        (** Rounds towards Infinity *)
        | ROUND_CEIL = 2
        (** Rounds towards -Infinity *)
        | ROUND_FLOOR = 3
        (** Rounds towards nearest neighbour. If equidistant, rounds away from zero *)
        | ROUND_HALF_UP = 4
        (** Rounds towards nearest neighbour. If equidistant, rounds towards zero *)
        | ROUND_HALF_DOWN = 5
        (** Rounds towards nearest neighbour. If equidistant, rounds towards even neighbour *)
        | ROUND_HALF_EVEN = 6
        (** Rounds towards nearest neighbour. If equidistant, rounds towards `Infinity` *)
        | ROUND_HALF_CEIL = 7
        (** Rounds towards nearest neighbour. If equidistant, rounds towards `-Infinity` *)
        | ROUND_HALF_FLOOR = 8
        (** The remainder is always positive. Euclidian division: `q = sign(n) * floor(a / abs(n))` *)
        | EUCLID = 9

    and [<AllowNullLiteral>] [<Import("*","bn.js")>] BigNumber(value: U3<float, string, BigNumber>, ?``base``: float) =
        member __.ROUND_UP with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_DOWN with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_CEIL with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_FLOOR with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_HALF_UP with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_HALF_DOWN with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_HALF_EVEN with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_HALF_CEIL with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.ROUND_HALF_FLOOR with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.EUCLID with get(): RoundingMode = jsNative and set(v: RoundingMode): unit = jsNative
        member __.c with get(): ResizeArray<float> = jsNative and set(v: ResizeArray<float>): unit = jsNative
        member __.e with get(): float = jsNative and set(v: float): unit = jsNative
        member __.s with get(): float = jsNative and set(v: float): unit = jsNative
        static member another(?config: Configuration): obj = jsNative
        static member config(?config: Configuration): Configuration = jsNative
        static member config(?decimalPlaces: float, ?roundingMode: RoundingMode, ?exponentialAt: U2<float, float * float>, ?range: U2<float, float * float>, ?errors: U2<bool, float>, ?crypto: U2<bool, float>, ?moduloMode: RoundingMode, ?powPrecision: float, ?format: Format): Configuration = jsNative
        static member max([<ParamArray>] args: U3<float, string, BigNumber>[]): BigNumber = jsNative
        static member min([<ParamArray>] args: U3<float, string, BigNumber>[]): BigNumber = jsNative
        static member random(?dp: float): BigNumber = jsNative
        member __.absoluteValue(): BigNumber = jsNative
        member __.abs(): BigNumber = jsNative
        member __.ceil(): BigNumber = jsNative
        member __.comparedTo(n: U3<float, string, BigNumber>, ?``base``: float): float = jsNative
        member __.cmp(n: U3<float, string, BigNumber>, ?``base``: float): float = jsNative
        member __.decimalPlaces(): float = jsNative
        member __.dp(): float = jsNative
        member __.dividedBy(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.div(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.dividedToIntegerBy(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.divToInt(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.equals(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.eq(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.floor(): BigNumber = jsNative
        member __.greaterThan(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.gt(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.greaterThanOrEqualTo(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.gte(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.isFinite(): bool = jsNative
        member __.isInteger(): bool = jsNative
        member __.isInt(): bool = jsNative
        member __.isNaN(): bool = jsNative
        member __.isNegative(): bool = jsNative
        member __.isNeg(): bool = jsNative
        member __.isZero(): bool = jsNative
        member __.lessThan(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.lt(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.lessThanOrEqualTo(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.lte(n: U3<float, string, BigNumber>, ?``base``: float): bool = jsNative
        member __.minus(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.modulo(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.``mod``(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.negated(): BigNumber = jsNative
        member __.neg(): BigNumber = jsNative
        member __.plus(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.precision(?z: U2<bool, float>): float = jsNative
        member __.sd(?z: U2<bool, float>): float = jsNative
        member __.round(?dp: float, ?rm: float): BigNumber = jsNative
        member __.shift(n: float): BigNumber = jsNative
        member __.squareRoot(): BigNumber = jsNative
        member __.sqrt(): BigNumber = jsNative
        member __.times(n: U3<float, string, BigNumber>, ?``base``: float): BigNumber = jsNative
        member __.toDigits(?sd: float, ?rm: float): BigNumber = jsNative
        member __.toExponential(?dp: float, ?rm: float): string = jsNative
        member __.toFixed(?dp: float, ?rm: float): string = jsNative
        member __.toFormat(?dp: float, ?rm: float): string = jsNative
        member __.toFraction(?max: U3<float, string, BigNumber>): string * string = jsNative
        member __.toJSON(): string = jsNative
        member __.toNumber(): float = jsNative
        member __.toPower(n: float, ?m: U3<float, string, BigNumber>): BigNumber = jsNative
        member __.pow(n: float, ?m: U3<float, string, BigNumber>): BigNumber = jsNative
        member __.toPrecision(?sd: float, ?rm: float): string = jsNative
        member __.toString(?``base``: float): string = jsNative
        member __.truncated(): BigNumber = jsNative
        member __.trunc(): BigNumber = jsNative
        member __.valueOf(): string = jsNative


