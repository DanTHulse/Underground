namespace Underground

open System.Drawing

open Colorful

module WriteEx =
    let loadFont (font: string) =
        FigletFont.Load (sprintf "Data/Fonts/%s" font)

    let writeAscii (message: string, font: string) =
        Console.WriteAscii (message, loadFont (font), Colours.highlightColour)

    let writeLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeColouredLine (message: string, colour: Color) =
        Console.WriteLine (message, colour)

    let writeLineBackground (message: string, backgroundColour: Color) =
        Console.BackgroundColor <- backgroundColour
        Console.WriteLine (message, Color.White)
        Console.BackgroundColor <- Color.Black

    let writeAccentedLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeHighlightedLine (message: string) =
        Console.WriteLine (message, Colours.textColour)

    let writeHighlights (message: string, highlights: string[]) =
        let styleSheet = StyleSheet (Colours.textColour)
        highlights
        |> Array.distinct
        |> Array.iter (fun f -> styleSheet.AddStyle (f, Colours.highlightColour))

        Console.WriteLineStyled (message, styleSheet)

    let writeAdvanceOption (message: string, defaultPositive: bool) =
        let options =
            match defaultPositive with
            | false -> " - (y/N)\n"
            | true -> " - (Y/n)\n"

        writeHighlights (message + options, [| options |])

    let writeMultiStyled (message: string, highlights: (string * Color) []) =
        let styleSheet = StyleSheet (Colours.textColour)
        highlights
        |> Array.iter (fun (f, l) -> styleSheet.AddStyle (f, l))

        Console.WriteLineStyled (message, styleSheet)

    let clearScreen () =
        Console.Clear ()