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

        let currentStation = startStation

        printfn "Current Station: %s" currentStation.name
        0;
