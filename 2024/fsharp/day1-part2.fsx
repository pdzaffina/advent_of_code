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
// for each number in the left list, calculate how many times it appears in the right list
//     - multiply the left number by the number of times it appears in the right list
//     - sum the numbers
// sum the similarity scores

let firstNumbers = 
  input
  |> List.map (fun s -> s.Split(' ') |> Array.head |> int)
  |> List.sort

let secondNumbers =
  input
  |> List.map (fun s -> s.Split(' ') |> Array.item 3 |> int)
  |> List.sort

let similarityScore (list1: int list) (list2: int list) =
  list1
  |> List.map (fun item -> 
      let count = List.filter ((=) item) list2 |> List.length
      (item * count)
  )
  |> List.sum

similarityScore firstNumbers secondNumbers
