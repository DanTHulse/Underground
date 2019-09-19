namespace Underground

open System

module TryParse =
    let tryParseWith (tryParseFunc: string -> bool * _) =
        tryParseFunc >> function
        | true, v -> Some v
        | false, _ -> None

    let parseInt = tryParseWith Int32.TryParse

    let (|Int|_|) = parseInt
