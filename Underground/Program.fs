namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let statingStation = Menu.selectStation()
        Console.Clear()
        let endingStation = Menu.selectStation()
        Console.Clear()
        0;
