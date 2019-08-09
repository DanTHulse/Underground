﻿namespace Underground

open System

module Menu =
    let mutable startStation: Station = Data.findRandomStation()
    let mutable endStation: Station = Data.findRandomStation()
    let mutable currentStation: Station = startStation
    let mutable currentTrain: Train = Data.findTrainById(0)

    let header () =
        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name

    let destinations (trains: Train list) =
        trains
        |> List.iteri(fun i t -> printfn " %d: %s - %s" i t.line t.destination)

    let trainInfo (currentS: Station, currentT: Train) = 
        let (nextS, cost) = Data.findNextStation (currentS, currentT)

        printfn "\n This is a %s train to: %s" currentT.line currentT.destination
        printfn " The next station is: %s" nextS.name

    let generateStart () =
        Console.Clear()
        startStation <- Data.findStationById(35) // Brixton
        endStation <- Data.findStationById(270) // Walthamstow Central

        header ()

    let start () =
        let mutable loop = true
        generateStart()

        while loop do
            printfn "\n Do you want to re-roll? (Y/N)\n"
            let answer = Console.ReadKey()
            if answer.Key = ConsoleKey.Y then
                generateStart()
            else
                loop <- false

        let trains =
            startStation.routes
            |> List.collect(fun s -> s.fullTrains)
        
        printfn "\n You can catch the following trains from this station:"
        destinations (trains)

        let currentT =
            Console.ReadLine()
            |> Int32.Parse
            |> fun s -> trains.[s]

        (startStation, endStation, currentT)

    let mainDisplay (startS: Station, endS: Station, currentS: Station, currentT: Train) =
        Console.Clear()
        
        header ()
        printfn "\n Current Station: %s" currentS.name
        trainInfo (currentS, currentT)

    let interchange (currentS: Station, currentT: Train) =
        printfn "\n\n What would you like to do?"
        printfn " X - Stay on the current train\n"

        let trains =
            currentS.routes
            |> List.collect(fun s -> s.fullTrains |> List.filter(fun f -> f.id <> currentT.id))
        
        destinations (trains)

        match Console.ReadLine() with
        | Int i -> (trains.[i], 120)
        | _ -> (currentT, 0)

    let loadDisplay (startS: Station, endS: Station, currentS: Station, currentT: Train) = 
        mainDisplay (startS, endS, currentS, currentT)
        let (train, lineCost) = interchange (currentS, currentT)
        let (nextS, cost) = Data.findNextStation(currentS, train)
        
        (nextS, train, cost + lineCost)

    let scoreDisplay (startS: Station, endS: Station, score: int) =
        Console.Clear()
        let minutes = score / 60
        let seconds = score % 60

        printfn "\n You made it from %s --> %s in:" startS.name endS.name
        printfn " %dm and %ds" minutes seconds