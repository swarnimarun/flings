﻿open System.Diagnostics
open FSharp.CommandLine

let programs =
    [ "exercises/001_intro", "Hello, world!"; "exercises/002_let", "I am let!" ]

let executeCommand (executable: string) (args: string) =
    let startInfo = ProcessStartInfo(executable, args)
    startInfo.RedirectStandardError <- true
    startInfo.RedirectStandardOutput <- true
    use p = new Process()
    p.StartInfo <- startInfo
    p.Start() |> ignore
    let outerr = (p.StandardOutput.ReadToEnd(), p.StandardError.ReadToEnd())
    if p.ExitCode = 0 then outerr |> Ok else outerr |> Error

let runProject project =
    sprintf "run --project %s" project |> executeCommand "dotnet"

let rec runProjects projects =
    match projects with
    | [] -> ()
    | (project, expectedOutput) :: rest ->
        match runProject project with
        | Ok(output, err) when output.Trim() = expectedOutput ->
            printfn "success - %s" project
            printfn "error =>\n%s" err
            printfn "output =>\n%s" output
            printfn "error =>\n%s%s" err "\n--------------------------------"
            runProjects rest
        | Ok(output, err) ->
            printfn "failed - output didn't match expected output - %s%s" project "\nvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv"
            printfn "error =>\n%s" err
            printfn "output =>\n%s" output
            printfn "expectedOutput =>\n%s%s" expectedOutput "\n--------------------------------"
            exit -1
        | Error(output, err) ->
            printfn "failed - %s%s" project "\nvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv"
            printfn "error =>\n%s" err
            printfn "output =>\n%s%s" output "\n--------------------------------"
            exit -1

// TODO: add more options for flings for users
let mainCommand =
    command {
        name "flings"
        description "Simple exercises for learning to write some F#"
        do runProjects programs
        return 0
    }


[<EntryPoint>]
let main argv =
    mainCommand |> Command.runAsEntryPoint argv