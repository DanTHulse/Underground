namespace Underground

module Elements =
    let logo =
        WriteEx.writeAscii ("UNDERGROUND")

    let scoreDisplay (score: int) =
        //writeAscii ("CONGLATURATIONS !")

        let score = sprintf "%dm , %ds" (score / 60) (score % 60)
        WriteEx.writeAscii (score)

    let header (startS: Station, endS: Station, currentS: Station, score: int) =
        WriteEx.writeStyled(
            sprintf " Score: %06i - Objective: %s --> %s - Current: %s" score startS.name endS.name currentS.name,
            [|
                startS.name
                endS.name
                currentS.name
                sprintf "%06i" score
            |])

    let linesDisplay (lines: Lines list) =
        WriteEx.writeLine("\n What line do you want to change to?")
        lines
        |> List.iteri (fun i l -> WriteEx.writeColouredLine (sprintf " %d - %s" i (fullLineName(l)), lineColour(l)))

        lines

    let trainsDisplay (trains: Train list) =
        WriteEx.writeLine("\n What train do you want to catch?")
        trains
        |> List.iteri (fun i l -> WriteEx.writeLine(sprintf " %d - %s" i (l.destination)))

        trains

    let interchange (station: Station) =
        let lines = TrainData.findLinesForStation (station)
        WriteEx.writeMultiStyled (
            sprintf " -> Change for %s services" (
                lines
                |> List.map (fun m -> fullLineName (m))
                |> join),
            lines
            |> List.map (fun f -> (fullLineName (f), lineColour (f)))
            |> Array.ofList)

    let stationInfo (currentStation: Station) =
        WriteEx.writeLine(sprintf "\n This station is %s" currentStation.name)
        interchange (currentStation)

    let trainInfo (currentStation: Station, train: Train) =
        WriteEx.writeLine(sprintf "\n This is a %s train terminating at: %s" train.line train.destination)
        StationData.findNextStation (currentStation, train)
        |> (fun (s, _) ->
            match currentStation <> s with
            | true ->
                WriteEx.writeLine(sprintf " The next station is: %s" s.name)
                interchange (s)
            | false -> ()
        )