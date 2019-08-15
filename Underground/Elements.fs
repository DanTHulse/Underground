namespace Underground

open Colorful
open System.Drawing

module Elements =
    let logo =
        writeAscii ("UNDERGROUND")

    let header (startStation: Station, endStation: Station, score: int, previousStation: Station) =
        let styleSheet = StyleSheet (Color.FromArgb(161, 165, 167))
        let highlights = Color.FromArgb(244, 169, 190)
        [
            startStation.name
            endStation.name
            previousStation.name
            sprintf "%06i" score
        ]
        |> List.distinct
        |> List.iter (fun f -> styleSheet.AddStyle(f, highlights))

        let headerText = sprintf " Score: %06i - Objective: %s --> %s - Last Stop: %s" score startStation.name endStation.name previousStation.name
        Console.WriteLineStyled(headerText, styleSheet)

    let objective (startStation: Station, endStation: Station) =
        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name

    let changeTrains =
        printfn "\n Do you want to stay on this train? (Y/n)\n"

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

        writeAscii (score)

    let startScreen =
        logo

    let endScreen (startS: Station, endS: Station, score: int) =
        Console.Clear()
        let endMessage = sprintf "\n\n %s --> %s in:\n\n" startS.name endS.name

        writeAscii ("CONGLATURATIONS !")
        Console.WriteLine (endMessage, Color.FromArgb(0, 125, 50))
        scores (score)