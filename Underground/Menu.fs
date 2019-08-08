namespace Underground

open System

module Menu =
    let header (startS: Station, endS: Station) =
        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startS.name endS.name

    let destinations (trains: Train list) =
        trains
        |> List.iteri(fun i t -> printfn " %d: %s - %s" i t.line t.destination)

    let trainInfo (currentS: Station, currentT: Train) = 
        let (nextS, cost) = Data.findNextStation (currentS, currentT)

        printfn "\n This is a %s train to: %s" currentT.line currentT.destination
        printfn " The next station is: %s" nextS.name

    let start () =
        Console.Clear()
        let startStation = Data.findRandomStation()
        let endStation = Data.findRandomStation()

        header (startStation, endStation)

        printfn "\n You can catch the following trains from this station:"
        let trains =
            startStation.routes
            |> List.collect(fun s -> s.fullTrains)

        destinations (trains)

        let currentT =
            Console.ReadLine()
            |> Int32.Parse
            |> fun s -> trains.[s]  

        (startStation, endStation, currentT)

    let mainDisplay (startS: Station, endS: Station, currentS: Station, currentT: Train) =
        Console.Clear()
        
        header (startS, endS)
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