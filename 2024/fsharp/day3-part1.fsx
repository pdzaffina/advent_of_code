open System.Text.RegularExpressions

let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/day3-input.txt"""
    |> Array.map (fun s -> s.Trim())
    // |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

let example =
    """xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"""
        .Split("\n")
    |> Array.map (fun s -> s.Trim())
    // |> Array.map (fun s -> s.Split() |> Array.map int |> List.ofArray)
    |> List.ofSeq

// parse out all the instances of the following pattern "mul(number, number)"
// and put them into a list with the first number and second number 
// the numbers can only be 1, or 2 or 3 digits.

let parseMulInstructions (input: string list) =
    let inputString = String.concat "" input
    let regex = Regex(@"mul\((\d+),(\d+)\)")

    regex.Matches(inputString)
    |> Seq.map (fun m -> 
        int m.Groups.[1].Value * int m.Groups.[2].Value)
    |> Seq.sum

let result = parseMulInstructions example

printfn "%d" result
