namespace Underground

open System

module Entry =
    [<EntryPoint>]
    let main _ =
        Elements.interchange (StationData.findStationById(148))

        //Elements.logo
        Console.ReadKey() |> ignore
        let mutable mainLoop = true

        while mainLoop do
            Menus.gameLoop()

            printfn "\n Do you want to play again? (Y/N)"                        
            mainLoop <-match Console.ReadKey().Key with
                       | ConsoleKey.Y -> true
                       | _ -> false
            ()
        0;
