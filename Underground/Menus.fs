namespace Underground

open System
open StationData
open TrainData
open Screens

module Menus =
    let rec start () =
        // let startStation = findRandomStation()
        // let endStation = findRandomStation()
        let startStation = findStationById(35)
        let endStation = findStationById(270)

        startScreen (startStation, endStation)

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

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
            mainScreen (startS, endS, currentS, currentT, totalCost)

            let (nextT, lineCost) =
                match Console.ReadKey().Key with
                | ConsoleKey.N -> (boardTrain (currentS), 120)
                | _ -> (currentT, 0)

            let (nextS, cost) = findNextStation (currentS, nextT)
            currentS <- nextS
            totalCost <- (totalCost + cost + lineCost)

        endScreen (startS, endS, totalCost)