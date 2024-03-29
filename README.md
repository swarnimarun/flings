# fsharp exercises for quickly learning syntax and basic library features

The project is WIP and any contributions are welcome.

The LICENSE for the entire project code is Apache 2.0.

And if there is any bugs or issues with the code let me know.

## Usage

1. Clone the project, shallow clone works as well.
2. `cd` into the dir we cloned to.
3. Ensure dotnet 8 is installed.
4. Run the flings project `dotnet run`.
5. Fix the errors you may get until output and expectedOutput are identical, as per the comments.
6. Use the comments are hints for solving the exercises.

```sh
git clone https://github.com/swarnimarun/flings.git
cd flings
# ensure dotnet version 8.0.0 is installed.
dotnet run
# it will output an error fix the code until the error is resolved and we get expectedOutput
# for each of the exercises 

# NOTE: edit code directly in excercises folder mentioned by the failed message.
```

## Roadmap

- Add more exercises.
  - Cover the basics of F# syntax.
    - if, then, else
    - for..in/to, while..do
    - values & mutability
    - functions, recursion, inline & lambda 
    - function composition & pipelining
    - constants and literals
    - tuples, lists, array, sequence
    - sequence expressions & reference cells
    - concat and append to lists
    - strings
    - string interpolation
    - records, anonymous records, structs and enums
    - discriminated unions & algebraic types
    - pattern matching & active patterns 
    - types, unit, enum, cast, inference
    - option and result 
    - generics & auto-generalization
    - flexible types 
    - byrefs (managed pointers)
    - type providers
    - exception handling, try..with/finally & raise/reraise
    - `use`
    - failwith, invalidArg & assertions
    - classes, abstract & inferfaces
    - type extension, delegates & inheritance 
    - members, overloading & object expressions 
    - computation expression
    - query expression
    - namespaces
    - modules
    - access control
    - async, lazy & tasks
    - attributes, reflection & code quotation
    - metaprogramming
  - Cover simple F# programs.
    - cli application
    - calculator
    - fibonacci 
    - memoization in fib
    - parsing prefix expr 
    - TODO: list more...
  - Cover essential design/functional patterns.
    - Builder with "Computation expressions" 
    - TODO: list more...
  - Cover new features from F# 6, 7, and 8.
  - Cover fable and setup and usage of popular common ecosystem libraries.
- Improve usability.
  - Add autosolver for solving problems, in case people get stuck.
  - Add better testing suite.
  - Provide a cross platform usage guide. 
  - If possible setup dev-env scripts with nix, docker and etc. for people.
  - Split into meaningful sections and chapters.
  - Provide simple katas for praticing after each section.
- Write a contribution doc
- Write workflow doc for updating for each new version of F#.
