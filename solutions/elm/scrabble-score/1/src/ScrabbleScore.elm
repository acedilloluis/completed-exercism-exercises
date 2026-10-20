module ScrabbleScore exposing (scoreWord)

getValue : Char -> Int
getValue c =
    if List.member c ['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'] then
        1
    else if List.member c ['D', 'G'] then
        2
    else if List.member c ['B', 'C', 'M', 'P'] then
        3
    else if List.member c ['F', 'H', 'V', 'W', 'Y'] then
        4
    else if List.member c ['K'] then
        5
    else if List.member c ['J', 'X'] then
        8
    else if List.member c ['Q', 'Z'] then
        10
    else
        0

scoreWord : String -> Int
scoreWord x =
    String.toUpper x
        |> String.toList
        |> List.map getValue
        |> List.sum
