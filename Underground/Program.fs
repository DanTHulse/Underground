namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let startStation = findRandomStation()
        let endStation = findRandomStation()

        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name
        printfn "\n You can catch the following trains from this station:"

        let trains =
            startStation.routes
            |> List.collect(fun s -> s.fullTrains |> List.map(fun m -> (m.lineId, m.destination)))
        
        trains
        |> List.iteri(fun i (l, s) -> printfn "%d: %s - %s" i (l.ToString()) s)

        let chosenTrain =
            Console.ReadLine()
            |> Int32.Parse
            |> fun s -> trains.[s]
        
        while true do
            let currentStation = startStation
            let currentLine, currentTrain = chosenTrain
            
            Console.Clear()
            printfn "\n Find the quickest route between the two stations:"
            printfn "%s --> %s" startStation.name endStation.name

            printfn "\n Current Station: %s" currentStation.name
            
            printfn " This is a %s train to: %s" (currentLine.ToString()) currentTrain 

            let nextStation =
                currentStation.routes
                |> List.find(fun f -> f.fullTrains |> List.exists(fun c -> c.lineId = currentLine))
                |> (fun s -> s.fullTrains |> List.find(fun l -> l.destination = currentTrain))
                |> (fun x -> x.id)
                |> Data.findStationById

            printfn " The next station is: %s" nextStation.name

            Console.ReadLine() |> ignore
            
            ()
        0;
