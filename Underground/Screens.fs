namespace Underground

open System

module Screens =
    let splashScreen =
        Console.Clear()

        Elements.logo
        WriteEx.writeLine("\n Press any key to start....\n")

    let startScreen (startS: Station, endS: Station) =
        Console.Clear()

        Elements.header (startS, endS, startS, 0)
        WriteEx.writeLine("\n Do you want to re-roll? (y/N)\n")

    let mainScreen (startS: Station, endS: Station, currentS: Station, currentT: Train, cost: int) =
        Console.Clear()

        Elements.header (startS, endS, currentS, cost)
        Elements.stationInfo (currentS)
        Elements.trainInfo (currentS, currentT)

    let endScreen (startS: Station, endS: Station, score: int) =
        Console.Clear()

        Elements.scoreDisplay (score)
        WriteEx.writeLine("\n Do you want to play again? (Y/n)\n")