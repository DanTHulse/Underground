namespace Underground

open System
open System.Text

open Underground.ReadEx

[<AutoOpen>]
module Helpers =
    let enumToList<'a> = (Enum.GetValues (typeof<'a>) :?> ('a [])) |> Array.toList

    let shuffleSeq next (xs: seq<'a>) = xs |> Seq.sortBy (fun _ -> next ())

    let chooser (items: 'a seq) =
        [|0..(items |> Seq.length) - 1|]
        |> readOption
        |> (fun i -> items |> Seq.item (i))

    let join (items: seq<string>) =
        let buff =
            Seq.fold
                (fun (buff: StringBuilder) (s: string) -> buff.Append(s).Append(", "))
                (StringBuilder ())
                items
        buff.Remove(buff.Length-2, 2).ToString ()

    let lineColour (line: Lines) =
        match line with
        | Lines.District -> Colours.district
        | Lines.Circle -> Colours.circle
        | Lines.Metropolitan -> Colours.metropolitan
        | Lines.WaterlooCity -> Colours.waterloo
        | Lines.Victoria -> Colours.victoria
        | Lines.Jubilee -> Colours.jubilee
        | Lines.Central -> Colours.central
        | Lines.Bakerloo -> Colours.bakerloo
        | Lines.HammersmithCity -> Colours.hammersmith
        | Lines.Piccadilly -> Colours.piccadilly
        | Lines.Elizabeth -> Colours.elizabeth
        | Lines.Overground -> Colours.overground
        | Lines.Trams -> Colours.trams
        | Lines.AirLine -> Colours.airline
        | Lines.DLR -> Colours.dlr
        | _ -> Colours.textColour

    let fullLineName (line: Lines) =
        match line with
        | Lines.WaterlooCity -> "Waterloo & City"
        | Lines.HammersmithCity -> "Hammersmith & City"
        | Lines.Overground -> "London Overground"
        | Lines.AirLine -> "Emirates Air Line"
        | Lines.Trams -> "London Trams"
        | _ -> line.ToString ()
