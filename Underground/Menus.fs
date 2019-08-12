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
        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name
        printfn "\n Do you want to re-roll? (Y/N)\n"

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

    let scoreDisplay (startS: Station, endS: Station, score: int) =
        Console.Clear()
        let minutes = score / 60
        let seconds = score % 60

        printfn "\n You made it from %s --> %s in:" startS.name endS.name
        printfn " %dm and %ds" minutes seconds

    let interchangeDisplay (station: Station) =
        printfn " -> Change for %s" (findLinesForStation (station)
                                      |> List.map (fun f -> f.ToString())
                                      |> Seq.ofList
                                      |> join)     

    let display (startS: Station, endS: Station, currentS: Station, currentT: Train) =
        printfn " Traveling between: %s ---> %s" startS.name endS.name
        printfn "\n This is a %s train terminating at: %s" currentT.line currentT.destination

        findNextStation (currentS, currentT)
        |> (fun (s, _) ->
            printfn " The next station is: %s" s.name
            interchangeDisplay (s))

        printfn "\n This station is: %s" currentS.name
        interchangeDisplay (currentS)

    let boardTrain (currentS: Station) =
        currentS
        |> findLinesForStation
        |> chooser
        |> (fun s -> currentS.routes |> List.collect(fun f -> f.fullTrains |> List.filter(fun x -> x.lineId = s)))
        |> chooser

    let gameLoop () =
        let (startS, endS) = start ()
        let mutable currentS = startS
        let mutable currentT = boardTrain (currentS)
        let mutable totalCost = 0

        while currentS <> endS do
            Console.Clear()
            display (startS, endS, currentS, currentT)

            printfn "\n Do you want to stay on this train? (Y/n)"

            let (nextT, lineCost) =
                match Console.ReadKey().Key with
                | ConsoleKey.N -> (boardTrain (currentS), 120)
                | _ -> (currentT, 0)

            let (nextS, cost) = findNextStation (currentS, nextT)
            currentS <- nextS
            totalCost <- (totalCost + cost + lineCost)
        
        scoreDisplay (startS, endS, totalCost)