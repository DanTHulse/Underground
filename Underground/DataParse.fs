namespace Underground

open System

module DataParse =
    let square x = x * x;

    let findSquare (num: int) =
        if num > 0 then
            let sq = (square num);
            cprintfn ConsoleColor.Cyan "%d squared is: %d!" num sq;
        else
            cprintfn ConsoleColor.Red "Failed to square";