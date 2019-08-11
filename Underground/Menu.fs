namespace Underground

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

    let trainInfo () = 
        let (nextS, cost) = Data.findNextStation (currentStation, currentTrain)

        printfn "\n This is a %s train to: %s" currentTrain.line currentTrain.destination
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

        (startStation, endStation)

    let mainDisplay () =
        Console.Clear()
        
        header ()
        printfn "\n Current Station: %s" currentStation.name
        trainInfo ()

    let interchange () =
        printfn "\n\n What would you like to do?"
        printfn " X - Stay on the current train\n"

        let trains =
            currentStation.routes
            |> List.collect(fun s -> s.fullTrains |> List.filter(fun f -> f.id <> currentTrain.id))
        
        destinations (trains)

        let (newTrain, cost) = match Console.ReadLine() with
                               | Int i -> (trains.[i], 120)
                               | _ -> (currentTrain, 0)
        
        currentTrain <- newTrain
        cost 
        

    let loadDisplay () = 
        mainDisplay ()
        let lineCost = interchange ()
        let (nextS, cost) = Data.findNextStation(currentStation, currentTrain)
        
        currentStation <- nextS
        (currentStation, cost + lineCost)

    let scoreDisplay (score: int) =
        Console.Clear()
        let minutes = score / 60
        let seconds = score % 60

        printfn "\n You made it from %s --> %s in:" startStation.name endStation.name
        printfn " %dm and %ds" minutes seconds