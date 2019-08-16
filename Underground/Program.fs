namespace Underground
open System

module Entry =
    [<EntryPoint>]
    let main _ =
        Console.SetWindowSize(160, 45)

        Screens.splashScreen
        Console.ReadKey() |> ignore

        Seq.initInfinite (fun _ ->
           Game.start ()
           |> Game.main
           |> Game.finish)
        |> Seq.find id
        |> ignore

        0