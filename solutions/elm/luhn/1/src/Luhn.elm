module Luhn exposing (valid)


valid : String -> Bool
valid input =
    let
        trimmedInput = 
            String.replace " " "" input

            
        isDigit : Char -> Bool
        isDigit char =
            Char.isDigit char


        changeCharToInt : Char -> Int
        changeCharToInt char =
            Char.toCode char - Char.toCode '0'
        

        mapEverySecondElem : (Char -> Int) -> List Char -> List Int
        mapEverySecondElem f list =
            List.indexedMap 
                (\index item ->
                    if modBy 2 index == 1 then
                        f item
                    else
                        changeCharToInt item
                )
                list


        doubleDigit : Char -> Int
        doubleDigit char =
            if ( changeCharToInt char ) * 2 > 9 then
                ( changeCharToInt char ) * 2 - 9 
            else
                ( changeCharToInt char ) * 2
    in
        if ( String.all isDigit trimmedInput ) && ( String.length trimmedInput ) > 1 then
            String.toList trimmedInput
                |> List.reverse
                |> mapEverySecondElem doubleDigit
                |> List.sum
                |> modBy 10
                |> (==) 0
        else    
            False
            
