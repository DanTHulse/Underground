namespace Underground

open System
open StationData
open TrainData

module Menus =
    let rec start () =
        // let startStation = findRandomStation()
        // let endStation = findRandomStation()
        let startStation = findStationById(35)
        let endStation = findStationById(270)

        Console.Clear()
        Elements.objective (startStation, endStation)
        Elements.reroll

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

    let mainDisplay (startS: Station, endS: Station, currentS: Station, currentT: Train) =
        Console.Clear()

        Elements.objective (startS, endS)
        Elements.trainInfo (currentS, currentT)
        Elements.station (currentS)
        Elements.interchange (currentS)
        Elements.changeTrains

    let boardTrain (currentS: Station) =
        currentS
        |> findLinesForStation
        |> Elements.linesDisplay
        |> chooser
        |> (fun s -> currentS.routes |> List.collect(fun f -> f.fullTrains |> List.filter(fun x -> x.lineId = s)))
        |> Elements.trainsDisplay
        |> chooser

    let gameLoop () =
        let (startS, endS) = start ()
        let mutable currentS = startS
        let mutable currentT = boardTrain (currentS)
        let mutable totalCost = 0

        while currentS <> endS do
            mainDisplay (startS, endS, currentS, currentT)

            let (nextT, lineCost) =
                match Console.ReadKey().Key with
                | ConsoleKey.N -> (boardTrain (currentS), 120)
                | _ -> (currentT, 0)

            let (nextS, cost) = findNextStation (currentS, nextT)
            currentS <- nextS
            totalCost <- (totalCost + cost + lineCost)

        Elements.endScreen (startS, endS, totalCost)