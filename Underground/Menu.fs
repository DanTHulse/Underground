namespace Underground

open System

module Menu =
    let selectLine () =
        let lines = enumToList<Lines>
        
        lines
        |> (fun x -> x |> List.map(fun m -> (int m, m.ToString())))
        |> List.iter (fun x -> printfn "%d: %s" (fst x) (snd x))
                
        let selectedLine = Console.ReadLine()
        Console.Clear()

        enum<Lines> (int selectedLine)
