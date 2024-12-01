open System

// let input =
//     System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}\input"""
    // |> List.ofSeq

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
// sum the diferences

let firstNumbers = 
  example
  |> List.map (fun s -> s.Split(' ') |> Array.head |> int)
  |> List.sort

let secondNumbers =
  example
  |> List.map (fun s -> s.Split(' ') |> Array.item 1 |> int)
  |> List.sort

firstNumbers |> printfn "%A"
secondNumbers |> printfn "%A"

let combinedLists =
  List.zip firstNumbers secondNumbers
  |> List.map (fun (a,b) -> [a;b])
  
combinedLists |> printfn "%A"
  
let sumDifferences =
  List.zip firstNumbers secondNumbers
  |> List.map (fun (a, b) -> abs(a - b))
  |> List.sum
  
sumDifferences |> printfn "%A"
  
// List.tryHead example |> printfn "%A"

// |> take 1 |> printfn "%A"

// printfn "%A" (example)
