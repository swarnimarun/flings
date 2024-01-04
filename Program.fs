open System.Diagnostics
open FSharp.CommandLine

let programs = [
    "exercises/001_intro", "", "Hello, world!"
    "exercises/002_let", "", "I am let!"
    "exercises/003_rec", "", "!evisrucer ma I"
    "exercises/004_ifthen", "393", "Fizz"
    "exercises/004_ifthen", "250", "Buzz"
    "exercises/004_ifthen", "2010", "FizzBuzz"
    "exercises/004_ifthen", "11", "11"
]

let executeCommand (executable: string) (args: string) =
    let startInfo = ProcessStartInfo(executable, args)
    startInfo.RedirectStandardError <- true
    startInfo.RedirectStandardOutput <- true
    use p = new Process()
    p.StartInfo <- startInfo
    p.Start() |> ignore
    let outerr = (p.StandardOutput.ReadToEnd(), p.StandardError.ReadToEnd())
    p.WaitForExit()
    outerr |> if p.ExitCode = 0 then Ok else Error

let runProject project args =
    sprintf "run --project %s -- %s" project args |> executeCommand "dotnet"

let rec runProjects projects =
    match projects with
    | [] -> ()
    | (project, args, expectedOutput) :: rest ->
        match runProject project args with
        | Ok(output, err) when output.Trim() = expectedOutput ->
            printfn "success - %s" project
            if args.Length = 0 |> not then
                args.Trim() |> printfn "(args)\"\"\"\n%s\n\"\"\""
            if err.Length = 0 |> not then
                err.Trim() |> printfn "(err)\"\"\"\n%s\n\"\"\""
            output.Trim() |> printfn "(out)\"\"\"\n%s\n\"\"\""
            printfn "\n--------------------------------"
            runProjects rest
        | Ok(output, err) ->
            printfn "failed - output didn't match expected output - %s%s" project "\n++++++++++++++++++++++++++++++++"
            args.Trim() |> printfn "(args)\"\"\"\n%s\n\"\"\""
            err.Trim() |> printfn "(err)\"\"\"\n%s\n\"\"\""
            output.Trim() |> printfn "(output)\"\"\"\n%s\n\"\"\""
            expectedOutput.Trim() |> printfn "(expectedOutput)\"\"\"\n%s\n\"\"\""
            printfn "\n--------------------------------"
            exit -1
        | Error(output, err) ->
            printfn "failed - %s%s" project "\n++++++++++++++++++++++++++++++++"
            args.Trim() |> printfn "(args)\"\"\"\n%s\n\"\"\""
            err.Trim() |> printfn "(err)\"\"\"\n%s\n\"\"\""
            output.Trim() |> printfn "(output)\"\"\"\n%s\n\"\"\""
            expectedOutput.Trim() |> printfn "(expectedOutput)\"\"\"\n%s\n\"\"\""
            printfn "\n--------------------------------"
            exit -1

let congrats _ =
    printfn
        "Congratulations you have successfully completed the flings project,
        now consider contributing some exercises and with other contributions :3"

// TODO: add more options for flings for users
let mainCommand =
    command {
        name "flings"
        description "Simple exercises for learning to write some F#"
        do runProjects programs |> congrats
        return 0
    }


[<EntryPoint>]
let main argv =
    mainCommand |> Command.runAsEntryPoint argv
