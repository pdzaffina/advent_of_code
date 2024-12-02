
let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/day2-input.txt"""
    |> Array.map (fun s -> s.Trim())
    |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

let example =
    """ 7 6 4 2 1
        1 2 7 8 9
        9 7 6 2 1
        1 3 2 4 5
        8 6 4 4 1
        1 3 6 7 9"""
        .Split("\n")
    |> Array.map (fun s -> s.Trim())
    |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

    
// parse line is it increasing or decreasing = safe
// a report only counts as safe if _both_ of the following are true:
//   - The levels are either all increasing or all decreasing.
//   - Any two adjacent levels differ by at least one and at most three.

let parseLine (input: int list) =
  let stepCheck (diffs: int list) =
      diffs
      |> List.distinct
      |> List.forall (fun diff -> diff >= 1 && diff <= 3)
 
  let isIncOrDec input =
    let isIncreasing =
      input
      |> List.pairwise
      |> List.map (fun (a, b) -> b - a)
      |> stepCheck

    let isDecreasing = 
      input
      |> List.pairwise
      |> List.map (fun (a, b) -> a - b)
      |> stepCheck

    isIncreasing || isDecreasing
  
  if isIncOrDec input then true
  else
      input
      |> List.mapi (fun i _ ->
          let remainingNums = input |> List.removeAt i
          isIncOrDec remainingNums
      )
      |> List.exists id

  let safeReportCount =
    input
    |> List.filter parseLine
    |> List.length

