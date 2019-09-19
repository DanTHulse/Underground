namespace Underground

open System

module ReadEx =
    let private isValidOption (read: int, validOptions: int[]) =
        let valid =
            validOptions
            |> Array.contains (read)

        match valid with
        | true -> ()
        | false -> WriteEx.writeLine (sprintf "%d is not a valid option" read)

        (valid, read)

    let private isNotNumber =
        WriteEx.writeLine ("Only numbers are accepted for this input")
        (false, 0)

    let private isValidKey (key: ConsoleKey, accepted: string[]) =
        let valid =
            accepted
            |> Array.contains (key.ToString ())

        match valid with
        | true -> ()
        | false -> WriteEx.writeLine (sprintf "%s is not a valid option" (key.ToString()))

        (valid, key)

    let readOption (validOptions: int[]) =
        Seq.initInfinite (fun _ ->
            Console.ReadLine ()
            |> TryParse.parseInt
            |> function
                | None -> isNotNumber
                | Some i -> isValidOption (i, validOptions))
        |> Seq.find (fun (b, _) -> b)
        |> (fun (_, i) -> i)

    let readKeyChoice (accepted: string[]) =
        Seq.initInfinite (fun _ ->
            Console.ReadKey().Key
            |> (fun k -> isValidKey (k, accepted)))
        |> Seq.find (fun (b, _) -> b)
        |> (fun (_, i) -> i)

    let readYesNo () =
        match readKeyChoice ([| "Y"; "N" |]) with
        | ConsoleKey.Y -> true
        | _ -> false

    let inline waitForInput () = Console.ReadKey() |> ignore