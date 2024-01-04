// TODO: implement fizzbuzz with if then else
// correctly
// below is the example code with FizzBuzz case removed
//    // if i % 3 = 0 then "Fizz"
//    // else if i % 5 = 0 then "Buzz"
//    // else sprintf "%d" i
let fizzBuzz (i: int) : string =
    System.NotImplementedException "implement this with it-then else-if else"
    |> raise

match
    System.Environment.GetCommandLineArgs()
    |> Seq.toList
    |> List.skip 1
    |> List.tryHead
with
| None -> System.ArgumentException "Atleast 1 argument required for FizzBuzz" |> raise
| Some(x) -> x |> int |> fizzBuzz |> printfn "%s"
