namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let startStation = Data.findRandomStation()
        let endStation = Data.findRandomStation()

        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name
        printfn "\n You can catch the following trains from this station:"

        let trains =
            startStation.lines
            |> List.collect(fun s -> s.stations |> List.map(fun m -> (s.line, m.branch)))
        
        trains
        |> List.iteri(fun i (l, s) -> printfn "%d: %s - %s" i (l.ToString()) s)

        let chosenTrain =
            Console.ReadLine()
            |> Int32.Parse
            |> fun s -> trains.[s]
        
        while true do
            Console.Clear()
            printfn "\n Find the quickest route between the two stations:"
            printfn "\n %s --> %s" startStation.name endStation.name

            let currentStation = startStation
            let currentLine, currentTrain = chosenTrain

            printfn "Current Station: %s" currentStation.name

        0;
