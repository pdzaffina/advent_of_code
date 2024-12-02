
let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/day1-input.txt"""
    |> List.ofSeq

let example =
    """ 3 4
        4 3
        2 5
        1 3
        3 9
        3 3"""
        .Split("\n")
    |> Array.map (fun s -> s.Trim())
    |> List.ofSeq

// split lists into two lists first and second
// sort each list descending
// re pair up the lists
// calculate the different between a pair
// sum the differences

let firstNumbers = 
  input
  |> List.map (fun s -> s.Split(' ') |> Array.head |> int)
  |> List.sort

let secondNumbers =
  input
  |> List.map (fun s -> s.Split(' ') |> Array.item 3 |> int)
  |> List.sort

let combinedLists =
  List.zip firstNumbers secondNumbers
  |> List.map (fun (a,b) -> [a;b])
  
let sumDifferences =
  List.zip firstNumbers secondNumbers
  |> List.map (fun (a, b) -> abs(a - b))
  |> List.sum
