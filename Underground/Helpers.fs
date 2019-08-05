namespace Underground

open System

[<AutoOpen>]
module Helpers =
    let consoleColor (fc : ConsoleColor) = 
        let current = Console.ForegroundColor
        Console.ForegroundColor <- fc
        { new IDisposable with
              member x.Dispose() = Console.ForegroundColor <- current }
    
    let cprintf color str = Printf.kprintf (fun s -> use c = consoleColor color in printf "%s" s) str
    let cprintfn color str = Printf.kprintf (fun s -> use c = consoleColor color in printfn "%s" s) str

    let enumToList<'a> = (Enum.GetValues(typeof<'a>) :?> ('a [])) |> Array.toList

    type System.String with
        member x.removePunctuation = x.Replace("'", "").Replace(",", "").Replace(".", "")