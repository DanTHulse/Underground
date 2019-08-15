namespace Underground

open System

module Screens =
    let splashScreen =
        Console.Clear()

        writeAscii ("UNDERGROUND")

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
        writeAscii ("CONGLATURATIONS !")

        let score = sprintf "%dm , %ds" (score / 60) (score % 60)
        writeAscii (score)