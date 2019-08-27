﻿namespace Underground

open System

open FSharp.Data

open Newtonsoft.Json

module TrainData =
    let trainData =
        let value = JsonValue.Load (__SOURCE_DIRECTORY__ + "\\Data\\LU_Trains.json")
        JsonConvert.DeserializeObject<Train list> (value.ToString ())

    let findTrainById (id: int) =
        trainData
        |> List.find (fun s -> s.id = id)

    let findLinesForStation (station: Station) =
        station.routes
        |> List.collect (fun c -> c.fullTrains)
        |> List.map (fun t -> t.lineId)
        |> List.distinct

module StationData =
    let loadData =
        let value = JsonValue.Load(__SOURCE_DIRECTORY__ + "\\Data\\LU_Data.json").ToString()
        JsonConvert.DeserializeObject<Station list>(value)
        |> List.map(fun c -> {
            id = c.id
            name = c.name
            routes = c.routes |> List.map(fun r -> {
                station = r.station
                weight = r.weight
                trains = r.trains
                fullTrains = TrainData.trainData |> List.filter(fun f -> r.trains |> Array.contains(f.id))})})

    let findStationById (id: int) =
        loadData
        |> List.find (fun s -> s.id = id)

    let findRandomStation () =
        loadData
        |> shuffleList(fun _ -> Random().Next())
        |> Seq.take 1
        |> Seq.item 0

    let findNextStation (station: Station, train: Train) =
        let route =
            station.routes
            |> List.tryFind (fun f ->
                f.fullTrains
                |> List.exists (fun s -> s.destination = train.destination && s.lineId = train.lineId))

        match route with
        | Some value -> (value.station |> findStationById, value.weight)
        | None -> (station, 0)

    let terminus (currentS: Station, currentT: Train) =
        let (nextS, _) = findNextStation (currentS, currentT)

        nextS = currentS