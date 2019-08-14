namespace Underground

open Colorful
open System.Drawing

module Elements =
    let logo =
        Colorful.Console.WriteAscii("UNDERGROUND", Color.Turquoise)

    let startScreen =
        ()

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
        |> List.iteri (fun i l -> printfn " %d - %s" i (l.ToString()))

        lines

    let trainsDisplay (trains: Train list) =
        printfn ""
        trains
        |> List.iteri (fun i l -> printfn " %d - %s" i (l.destination))

        trains

    let interchange (station: Station) =
        let styleSheet = StyleSheet (Color.White)
        let routeStr = sprintf " -> Change for %s" ((List.map ((fun i ->
                                                    styleSheet.AddStyle(i.ToString(), lineColour (i)) |> ignore
                                                    i) >> (fun f -> f.ToString())) (TrainData.findLinesForStation (station)))
                                                    |> Seq.ofList
                                                    |> join)

        Console.WriteLineStyled (routeStr, styleSheet)

    let trainInfo (currentStation: Station, train: Train) =
        printfn "\n This is a %s train terminating at: %s" train.line train.destination
        StationData.findNextStation (currentStation, train)
        |> (fun (s, _) ->
            printfn " The next station is: %s" s.name
            interchange (s))

    let scores (startS: Station, endS: Station, score: int) =
        Console.Clear()
        let minutes = score / 60
        let seconds = score % 60

        printfn "\n You made it from %s --> %s in:" startS.name endS.name
        printfn " %dm and %ds" minutes seconds