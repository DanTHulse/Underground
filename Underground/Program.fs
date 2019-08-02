namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let result = findStationById(5)
        Menu.menu
        0;
