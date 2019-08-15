namespace Underground

open System
open TrainData

module Screens =
    let splashScreen =
        Console.Clear()

        Elements.logo
        printfn "\n Press any key to start....\n"

    let startScreen (startS: Station, endS: Station) =
        Console.Clear()

        Elements.header (startS, endS, startS, 0)
        printfn "\n Do you want to re-roll? (Y/N)\n"

    let mainScreen (startS: Station, endS: Station, currentS: Station, currentT: Train, cost: int) =
        Console.Clear()

        Elements.header (startS, endS, currentS, cost)
        Elements.trainInfo (currentS, currentT)
        Elements.interchange (currentS)
        printfn "\n Do you want to stay on this train? (Y/n)\n"

    let endScreen (startS: Station, endS: Station, score: int) =
        Console.Clear()

        Elements.scoreDisplay (score)
        printfn "\n Do you want to play again? (Y/N)\n"