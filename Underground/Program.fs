namespace Underground

open System
open Data

module Entry =
    [<EntryPoint>]
    let main _ =
        let routes = Menu.buildRoutes()
        let routesV2 = Menu.buildRoutesV2(Lines.Victoria)
        Console.Clear()
        0;
