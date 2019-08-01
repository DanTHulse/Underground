namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let luData = loadData
        let result = findStation(luData, 5)
        0;
