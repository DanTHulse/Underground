namespace Underground

open System

module ReadEx =
    let readOption (validOptions: int[]) =
        // Seq.initInfinite (fun _ ->
        //     )
        // |> Seq.find id
        // |> ignore

        let readResult =
            Console.ReadLine ()
            |> TryParse.parseInt

        ()
