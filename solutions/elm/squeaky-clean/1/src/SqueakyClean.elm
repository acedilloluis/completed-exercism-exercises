module SqueakyClean exposing (clean, clean1, clean2, clean3, clean4)


clean1 : String -> String
clean1 str =
    String.replace " " "_" str


clean2 : String -> String
clean2 str =
    clean1 str
    |> String.replace "\n" "[CTRL]"
    |> String.replace "\t" "[CTRL]"
    |> String.replace "\r" "[CTRL]"


clean3 : String -> String
clean3 str =
    let
        capitalizeFirstLetter : String -> String
        capitalizeFirstLetter string =
            case String.uncons string of
                Just ( head, tail ) ->
                    String.cons ( Char.toUpper head ) tail

                Nothing ->
                    ""
    in
        clean2 str
        |> String.split "-"
        |> List.indexedMap (\index item -> if index /= 0 then capitalizeFirstLetter item else item)
        |> String.concat


clean4 : String -> String
clean4 str =
    clean3 str
    |> String.filter (\c -> not ( Char.isDigit c ))


clean : String -> String
clean str =
    clean4 str
    |> String.filter (\c -> c < 'α' || c > 'ω')
