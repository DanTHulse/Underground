namespace Underground

open System

open Underground.ReadEx

module Entry =
    [<EntryPoint>]
    let main _ =

        // HACK: This shouldn't be necessary
        Console.SetWindowSize (160, 45)

        Screens.splashScreen
        waitForInput ()

        Seq.initInfinite (fun _ ->
           Game.start ()
           |> Game.main
           |> Game.finish)
        |> Seq.find id
        |> ignore

        0
