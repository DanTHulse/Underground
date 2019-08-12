namespace Underground

open System

module Entry =
    [<EntryPoint>]
    let main _ =
        let mutable mainLoop = true
        let mutable score = 0

        while mainLoop do
            let (startS, endS) = Menu.start()

            let mutable currentS = startS

            while currentS <> endS do
                let (nextS, cost) = Menu.loadDisplay()
                score <- score + cost
                currentS <- nextS

            Menu.scoreDisplay(score)

            printfn "\n Do you want to play again? (Y/N)"                        
            mainLoop <-match Console.ReadKey().Key with
                       | ConsoleKey.Y -> true
                       | _ -> false
            ()
        0;
