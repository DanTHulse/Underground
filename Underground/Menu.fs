namespace Underground

open System

module Menu =
    let selectLine() =
        let lines = enumToList<Lines>
        
        lines
        |> (fun x -> x |> List.map(fun m -> (int m, m.ToString())))
        |> List.iter (fun x -> printfn "%d: %s" (fst x) (snd x))
                
        let selectedLine = Console.ReadLine()
        Console.Clear()

        enum<Lines> (int selectedLine)

    let selectStation() =
        let stations =
            selectLine()
            |> Data.findStations

        stations
            |> List.sortBy (fun x -> x.name)
            |> (fun x -> x |> List.iteri(fun i j -> printfn "%d: %s" i j.name))

        let selectedStation = Console.ReadLine()
        
        Data.findStationById(stations.[int selectedStation].id)

    let searchStation() =
        let search = Console.ReadLine()

        let data = Data.loadData

        let filteredData =
            data
            |> List.where(fun x -> x.name.ToLower().removePunctuation.Contains(search.ToLower().removePunctuation))
            |> List.sortBy (fun x -> x.name)
            
        filteredData
            |> (fun x -> x |> List.iteri(fun i j -> printfn "%d: %s" i j.name))

        let selectedStation = Console.ReadLine()

        Data.findStationById(filteredData.[int selectedStation].id)

    let buildRoutes() =
        Data.loadData
        |> List.filter(fun s -> s.lines |> List.exists(fun x -> x.line = Lines.Victoria))
        |> List.collect(fun s -> s.lines |> List.collect(fun sl -> sl.stations |> List.map(fun ss ->
        {
            startS = s.id
            endS = ss.id
            weight = ss.weight
            branch = ss.branch
            line = string sl.line
        })))

    let calculateWeight(startLine: Lines, currentLine: Lines, weight: int) =
        match currentLine = startLine with
        | true -> weight
        | false -> weight + 60

    let buildRoutesV2(startLine: Lines) =
        Data.loadData
        |> List.filter(fun s -> s.lines |> List.exists(fun x -> x.line = Lines.Victoria))
        |> List.collect(fun s -> s.lines |> List.collect(fun sl -> sl.stations |> List.map(fun ss ->
        {
            startS = s.id
            endS = ss.id
            weight = calculateWeight(startLine, sl.line, ss.weight)
            branch = ss.branch
            line = string sl.line
        })))