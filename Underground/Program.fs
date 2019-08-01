namespace Underground

open System
open DataParse

module Entry =
    [<EntryPoint>]
    let main argv =
        let input = Console.ReadLine();
        let num, numVal = Int32.TryParse(input)

        if num then
            findSquare(numVal)
        else
            cprintfn ConsoleColor.Red "Failed to parse argument %s" input;
        0;
