namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let mutable mainLoop = true
        let mutable score = 0

        while mainLoop do            
            let (startS, endS, train) = Menu.start()

            let mutable (currentS, currentT) = (startS, train)

            while currentS <> startS do
                let (newCurrentS, newCurrentT, cost) = Menu.loadDisplay(startS, endS, currentS, currentT)
                currentS <- newCurrentS
                currentT <- newCurrentT
                score <- score + cost
            ()
        0;
