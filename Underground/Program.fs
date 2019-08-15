namespace Underground

open System

module Entry =
    [<EntryPoint>]
    let main _ =
        Elements.header (StationData.findStationById(148), StationData.findStationById(148), StationData.findStationById(148), 1)

        Console.ReadKey() |> ignore
        let mutable mainLoop = true

        while mainLoop do
            mainLoop <- Game.start ()
            |> Game.main
            |> Game.finish
        0;
