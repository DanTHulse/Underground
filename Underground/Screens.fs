namespace Underground

open Underground.WriteEx

[<RequireQualifiedAccess>]
module Screens =
    let splashScreen =
        clearScreen

        Elements.logo
        writeHighlights ("\n Press ANY key to start....\n", [| "ANY" |])

    let startScreen (startS: Station, endS: Station) =
        clearScreen

        Elements.header (startS, endS, startS, 0)
        writeAdvanceOption ("\n Do you want to re-roll?", false)

    let mainScreen (startS: Station, endS: Station, currentS: Station, currentT: Train, cost: int) =
        clearScreen

        Elements.header (startS, endS, currentS, cost)
        Elements.stationInfo (currentS)
        Elements.trainInfo (currentS, currentT)

    let endScreen (startS: Station, endS: Station, score: int) =
        clearScreen

        Elements.scoreDisplay (score)
        writeAdvanceOption ("\n Do you want to play again?", true)