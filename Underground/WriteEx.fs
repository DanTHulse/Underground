namespace Underground

open System.Drawing
open Colorful

module Colours =
    let district = Color.FromArgb(0, 125, 50)
    let circle = Color.FromArgb(255, 211, 41)
    let metropolitan = Color.FromArgb(155, 0, 88)
    let waterloo = Color.FromArgb(147, 206, 186)
    let victoria = Color.FromArgb(0, 152, 216)
    let jubilee = Color.FromArgb(161, 165, 167)
    let central = Color.FromArgb(220, 36, 31)
    let bakerloo = Color.FromArgb(178, 99, 0)
    let hammersmith = Color.FromArgb(244, 169, 190)
    let piccadilly = Color.FromArgb(55, 73, 176)
    let elizabeth = Color.FromArgb(147, 100, 204)
    let overground = Color.FromArgb(239, 123, 16)
    let trams = Color.FromArgb(0, 189, 25)
    let dlr = Color.FromArgb(0, 175, 173)
    let northern = Color.FromArgb(255, 255, 255)
    let airline = central

    let textColour = northern
    let highlightColour = hammersmith
    let accentColour = jubilee

module WriteEx =
    let loadFont (font: string) =
        FigletFont.Load (sprintf "Data/Fonts/%s.flf" font)

    let writeAscii (message: string) =
        Console.WriteAscii (message, loadFont ("cosmic"), Colours.highlightColour)

    let writeLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeColouredLine (message: string, color: Color) =
        Console.WriteLine (message, color)

    let writeAccentedLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeHighlightedLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeStyled (message: string, highlights: string[]) =
        let styleSheet = StyleSheet (Colours.textColour)
        highlights
        |> Array.distinct
        |> Array.iter (fun f -> styleSheet.AddStyle(f, Colours.highlightColour))

        Console.WriteLineStyled(message, styleSheet)

    let writeMultiStyled (message: string, styleSheet: StyleSheet) =
        Console.WriteLineStyled (message, styleSheet)

    let writeMultiStyled2 (message: string, highlights: (string * Color) []) =
        let styleSheet = StyleSheet (Colours.textColour)
        highlights
        |> Array.iter (fun (f, l) -> styleSheet.AddStyle(f, l))

        Console.WriteLineStyled (message, styleSheet)