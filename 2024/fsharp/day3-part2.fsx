open System.Text.RegularExpressions

let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/day3-input.txt"""
    |> Array.map (fun s -> s.Trim())
    // |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

let example =
    """xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)do()?mul(8,5))"""
        .Split("\n")
    |> Array.map (fun s -> s.Trim())
    // |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

// parse out all the instances of the following pattern "mul(number, number)"
// and put them into a list with the first number and second number 
// the numbers can only be 1, or 2 or 3 digits.
// two new instructions you'll need to handle:
//  -The do() instruction enables future mul instructions.
//  -The don't() instruction disables future mul instructions.

let parseMulInstructions (input: string list) : int =
    let inputString = String.concat "" input
    let regex = Regex(@"(do\(\)|don't\(\)|mul\((\d+),(\d+)\))")

    regex.Matches(inputString)
    |> Seq.fold (fun (acc, enabled) m ->
        match m.Groups.[1].Value with
        | "do()" -> (acc, true)
        | "don't()" -> (acc, false)
        | _ when enabled ->
            let product = int m.Groups.[2].Value * int m.Groups.[3].Value
            (acc + product, enabled)
        | _ -> (acc, enabled)
    ) (0, true)
    |> fst  // Return only the accumulated sum

let result = parseMulInstructions input

printfn "%d" result
