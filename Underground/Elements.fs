namespace Underground

open Underground.StationData
open Underground.WriteEx

[<RequireQualifiedAccess>]
module Elements =
    let logo =
        writeAscii ("UNDERGROUND", Fonts.speed)

    let scoreDisplay (score: int) =
        writeAscii ("CONGLATURATIONS !", Fonts.speed)

        let score = sprintf "%dm , %ds" (score / 60) (score % 60)
        writeAscii (score, Fonts.cosmic)

    let header (startS: Station, endS: Station, currentS: Station, score: int) =
        writeHighlights (
            sprintf " Score: %06i - Objective: %s --> %s - Current: %s" score startS.name endS.name currentS.name,
            [|
                startS.name
                endS.name
                currentS.name
                sprintf "%06i" score
            |])

    let linesDisplay (lines: Lines list) =
        writeLine ("\n What line do you want to change to?")
        lines
        |> List.iteri (fun i l -> writeColouredLine (sprintf " %d - %s" i (fullLineName (l)), lineColour (l)))

        lines

    let trainsDisplay (trains: Train list) =
        writeLine ("\n What train do you want to catch?")
        trains
        |> List.iteri (fun i l -> writeLine(sprintf " %d - %s" i (l.destination)))

        trains

    let interchange (station: Station) =
        let lines = TrainData.findLinesForStation (station)
        writeMultiStyled (
            sprintf " -> Change for %s services" (
                lines
                |> List.map (fun m -> fullLineName (m))
                |> join),
            lines
            |> List.map (fun f -> (fullLineName (f), lineColour (f)))
            |> Array.ofList)

    let stationInfo (currentStation: Station) =
        writeLine(sprintf "\n This station is %s" currentStation.name)
        //interchange (currentStation)

    let trainInfo (currentStation: Station, train: Train) =
        writeLine (sprintf "\n This is a %s train terminating at: %s" train.line train.destination)
        findNextStation (currentStation, train)
        |> (fun (s, _) ->
            match currentStation <> s with
            | true ->
                writeLine (sprintf " The next station is: %s" s.name)
                interchange (s)
            | false -> ()
        )