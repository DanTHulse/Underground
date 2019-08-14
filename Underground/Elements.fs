namespace Underground

open Colorful
open System.Drawing

module Elements =
    let loadFont (font: string) =
        FigletFont.Load(sprintf "Data/Fonts/%s.flf" font)

    let logo =
        Colorful.Console.WriteAscii("UNDERGROUND", Color.FromArgb(147, 206, 186))

    let objective (startStation: Station, endStation: Station) =
        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name

    let changeTrains =
        printfn "\n Do you want to stay on this train? (Y/n)"

    let reroll =
        printfn "\n Do you want to re-roll? (Y/N)\n"

    let station (station: Station) =
        printfn "\n This station is: %s" station.name

    let linesDisplay (lines: Lines list) =
        printfn ""
        lines
        |> List.iteri (fun i l -> Console.WriteLine (sprintf " %d - %s" i (fullLineName(l)), lineColour(l)))

        lines

    let trainsDisplay (trains: Train list) =
        printfn ""
        trains
        |> List.iteri (fun i l -> printfn " %d - %s" i (l.destination))

        trains

    let interchange (station: Station) =
        let styleSheet = StyleSheet (Color.White)
        let services =
            (List.map ((fun i ->
            styleSheet.AddStyle(fullLineName(i), lineColour (i)) |> ignore
            i) >> (fun f -> fullLineName(f))) (TrainData.findLinesForStation (station)))
            |> Seq.ofList
            |> join
        let routeStr = sprintf " -> Change for %s services" services

        Console.WriteLineStyled (routeStr, styleSheet)

    let trainInfo (currentStation: Station, train: Train) =
        printfn "\n This is a %s train terminating at: %s" train.line train.destination
        StationData.findNextStation (currentStation, train)
        |> (fun (s, _) ->
            printfn " The next station is: %s" s.name
            interchange (s))

    let scores (score: int) =
        let score = sprintf "%dm , %ds" (score / 60) (score % 60)

        Console.WriteAscii(score, Color.FromArgb(0, 125, 50))

    let startScreen =
        logo

    let endScreen (startS: Station, endS: Station, score: int) =
        Console.Clear()
        let endMessage = sprintf "\n\n %s --> %s in:\n\n" startS.name endS.name

        let font = loadFont ("cosmic")
        Colorful.Console.WriteAscii("CONGLATURATIONS !", font, Color.FromArgb(147, 206, 186))
        Console.WriteLine (endMessage, Color.FromArgb(0, 125, 50))
        scores (score)