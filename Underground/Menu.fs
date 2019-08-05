﻿namespace Underground

open System

module Menu =
    let menu =
        let lines = enumToList<Lines>

        lines
        |> (fun x -> x |> List.map(fun m -> (int m, m.ToString())))
        |> List.iter (fun x -> printfn "%d: %s" (fst x) (snd x))
        
        let selectedLine = Console.ReadLine()
        Console.Clear()

        let stations = Data.findStations(Enum.Parse(typeof<Lines>, selectedLine) :?> Lines)

        stations
        |> List.sortBy (fun x -> x.name)
        |> (fun x -> x |> List.iteri(fun i j -> printfn "%d: %s" i j.name))

        let selectedStation = Console.ReadLine()
        
        let station = Data.findStationById(stations.[int selectedStation].id)
        
        ()