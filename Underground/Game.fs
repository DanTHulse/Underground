namespace Underground

open System

open Underground.StationData
open Underground.TrainData
open Underground.WriteEx

[<RequireQualifiedAccess>]
module Game =
    let rec start () =
        //let startStation = findRandomStation ()
        //let endStation = findRandomStation ()
        let startStation = findStationById (245)
        let endStation = findStationById (270)

        Screens.startScreen (startStation, endStation)

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

    let changeTrains (currentS: Station) =
        currentS
        |> findLinesForStation
        |> Elements.linesDisplay
        |> chooser
        |> (fun s ->
            currentS.routes
            |> List.collect (fun f ->
                f.fullTrains
                |> List.filter (fun x -> x.lineId = s)))
        |> Elements.trainsDisplay
        |> chooser

    let boardTrain (currentS: Station) =

        changeTrains (currentS)

    let main (startS: Station, endS: Station) =
        let mutable currentS = startS
        let mutable currentT = boardTrain (currentS)
        let mutable totalCost = 0

        while currentS <> endS do
            Screens.mainScreen (startS, endS, currentS, currentT, totalCost)

            let (nextT, lineCost) =
                match terminus (currentS, currentT) with
                    | false ->
                        writeAdvanceOption("\n Do you want to stay on this train?", true)
                        match Console.ReadKey().Key with
                        | ConsoleKey.N -> (changeTrains (currentS), 120)
                        | _ -> (currentT, 0)
                    | true ->
                        writeLine ("\n This is where this train terminates, all change\n")
                        (changeTrains (currentS), 120)

            currentT <- nextT

            let (nextS, cost) = findNextStation (currentS, currentT)
            currentS <- nextS

            totalCost <- (totalCost + cost + lineCost)

        (startS, endS, totalCost)

    let finish (startS: Station, endS: Station, totalCost: int) =
        Screens.endScreen (startS, endS, totalCost)

        match Console.ReadKey().Key with
        | ConsoleKey.N -> false
        | _ -> true