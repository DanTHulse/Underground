﻿namespace Underground

open System
open System.Text

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

    let shuffleList next xs = xs |> Seq.sortBy(fun _ -> next())

    let (|Int|_|) (str: string) =
       match Int32.TryParse(str) with
       | (true,int) -> Some(int)
       | _ -> None

    let chooser (items: 'a list) =
        Console.ReadLine()
        |> int
        |> (fun i -> items.[i])

    let join (items : seq<string>) =
        let buff = 
            Seq.fold 
                (fun (buff :StringBuilder) (s:string) -> buff.Append(s).Append(",")) 
                (StringBuilder()) 
                items
        buff.Remove(buff.Length-1, 1).ToString()