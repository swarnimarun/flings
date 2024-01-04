// predefinition doesn't work for recursion, consider using `rec` after let
let printReverse s =
    match s with
    | [] -> ()
    | head :: tail ->
        printReverse tail
        printf "%c" head

Seq.toList "I am recursive!" |> printReverse
