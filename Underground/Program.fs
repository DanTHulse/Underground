namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let start = Menu.searchStation()
        Console.Clear()
        0;
