namespace Underground

open System
open System.Text
open System.Drawing
open Colorful

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

    let lineColour (line: Lines) =
        match line with
        | Lines.District -> Color.FromArgb(0, 125, 50)
        | Lines.Circle -> Color.FromArgb(255, 211, 41)
        | Lines.Metropolitan -> Color.FromArgb(155, 0, 88)
        | Lines.WaterlooCity -> Color.FromArgb(147, 206, 186)
        | Lines.Victoria -> Color.FromArgb(0, 152, 216)
        | Lines.Jubilee -> Color.FromArgb(161, 165, 167)
        | Lines.Central -> Color.FromArgb(220, 36, 31)
        | Lines.Bakerloo -> Color.FromArgb(178, 99, 0)
        | Lines.HammersmithCity -> Color.FromArgb(244, 169, 190)
        | Lines.Piccadilly -> Color.FromArgb(0, 25, 168)
        | Lines.Elizabeth -> Color.FromArgb(147, 100, 204)
        | Lines.Overground -> Color.FromArgb(239, 123, 16)
        | Lines.Trams -> Color.FromArgb(0, 189, 25)
        | Lines.AirLine -> Color.FromArgb(220, 36, 31)
        | Lines.DLR -> Color.FromArgb(0, 175, 173)
        | _ -> Color.FromArgb(255, 255, 255)