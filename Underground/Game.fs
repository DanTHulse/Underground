namespace Underground

open System
open StationData
open TrainData
open Screens

module Game =
    let rec start () =
        // let startStation = findRandomStation()
        // let endStation = findRandomStation()
        let startStation = findStationById(198)
        let endStation = findStationById(270)

        startScreen (startStation, endStation)

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

    let changeTrains (currentS: Station) =
        currentS
        |> findLinesForStation
        |> Elements.linesDisplay
        |> chooser
        |> (fun s -> currentS.routes |> List.collect(fun f -> f.fullTrains |> List.filter(fun x -> x.lineId = s)))
        |> Elements.trainsDisplay
        |> chooser

    let boardTrain (currentS: Station) =

        changeTrains (currentS)

    let main (startS: Station, endS: Station) =
        let mutable currentS = startS
        let mutable currentT = boardTrain (currentS)
        let mutable totalCost = 0

        while currentS <> endS do
            mainScreen (startS, endS, currentS, currentT, totalCost)

            let (nextT, lineCost) =
                match Console.ReadKey().Key with
                | ConsoleKey.N -> (changeTrains (currentS), 120)
                | _ -> (currentT, 0)

            let (nextS, cost) = findNextStation (currentS, nextT)
            currentS <- nextS
            totalCost <- (totalCost + cost + lineCost)

        (startS, endS, totalCost)

    let finish (startS: Station, endS: Station, totalCost: int) =
        endScreen (startS, endS, totalCost)

        match Console.ReadKey().Key with
        | ConsoleKey.N -> false
        | _ -> true