namespace Underground

open System
open StationData
open TrainData

module Menus =
    let rec start () =
        let startStation = findRandomStation()
        let endStation = findRandomStation()

        printfn "\n Find the quickest route between the two stations:"
        printfn "\n %s --> %s" startStation.name endStation.name
        printfn "\n Do you want to re-roll? (Y/N)\n"

        match Console.ReadKey().Key with
        | ConsoleKey.Y -> start ()
        | _ -> (startStation, endStation)

    let boardTrain (currentS: Station) =
        currentS.routes
        |> List.collect (fun c -> c.fullTrains)
        |> List.map (fun t -> t.lineId)
        |> List.distinct
        |> chooser
        |> (fun s -> currentS.routes |> List.collect(fun f -> f.fullTrains |> List.filter(fun x -> x.lineId = s)))
        |> chooser

    let gameLoop () =
        let (startS, endS) = start ()
        ()