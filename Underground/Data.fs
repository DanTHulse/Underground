namespace Underground

open System
open Newtonsoft.Json
open FSharp.Data

module Data =
    let loadData =
        let value = JsonValue.Load(__SOURCE_DIRECTORY__ + "\\LU_Data.json").ToString()
        JsonConvert.DeserializeObject<Station list>(value)

    let findStation (stations: Station list, id: int) =
        stations
        |> List.find (fun s -> s.id = id)

