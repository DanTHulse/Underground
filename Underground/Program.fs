namespace Underground

open System

module Entry =
    [<EntryPoint>]
    let main _ =
        //Elements.logo
        //Console.ReadKey() |> ignore
        let mutable mainLoop = true

        while mainLoop do
            Menus.gameLoop()

            printfn "\n Do you want to play again? (Y/N)"                        
            mainLoop <-match Console.ReadKey().Key with
                       | ConsoleKey.Y -> true
                       | _ -> false
            ()
        0;
