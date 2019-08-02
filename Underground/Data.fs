namespace Underground

open System
open Newtonsoft.Json
open FSharp.Data

module Data =
    let loadData =
        let value = JsonValue.Load(__SOURCE_DIRECTORY__ + "\\Data\\LU_Data.json").ToString()
        JsonConvert.DeserializeObject<Station list>(value)

    let findStationById (id: int) =
        loadData
        |> List.find (fun s -> s.id = id)

    let findStations (line: Lines) =
        loadData
        |> List.filter (fun s -> s.lines |> List.exists (fun x -> x.line = line))