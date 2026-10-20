module Pangram exposing (isPangram)


isPangram : String -> Bool
isPangram sentence =
    let
        checkIfAllLettersPresent : List Char -> Bool
        checkIfAllLettersPresent letters =
            List.all (\letter -> List.member letter letters) ['a','b','c','d','e','f','g','e','f','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z']
            
    in
        String.toList sentence
        |> List.filter Char.isAlpha
        |> List.map Char.toLower
        |> checkIfAllLettersPresent