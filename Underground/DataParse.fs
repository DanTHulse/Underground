namespace Underground

open System
open Newtonsoft.Json
open FSharp.Data

module DataParse =
    let loadData =
        let value = JsonValue.Load(__SOURCE_DIRECTORY__ + "\\LU_Data.json")
        let test = value.ToString()
        JsonConvert.DeserializeObject<Station list>(test)

    let square x = x * x;

    let findSquare (num: int) =
        if num > 0 then
            let sq = (square num);
            cprintfn ConsoleColor.Cyan "%d squared is: %d!" num sq;
        else
            cprintfn ConsoleColor.Red "Failed to square";

