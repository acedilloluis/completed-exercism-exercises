module Raindrops exposing (raindrops)


raindrops : Int -> String
raindrops number =
    let
        divisibleBy3 : Int -> String
        divisibleBy3 num =
            if modBy 3 num == 0 then
                "Pling"
            else
                ""


        divisibleBy5 : Int -> String
        divisibleBy5 num =
            if modBy 5 num == 0 then
                "Plang"
            else
                ""


        divisibleBy7 : Int -> String
        divisibleBy7 num =
            if modBy 7 num == 0 then
                "Plong"
            else
                ""
    in
        if String.isEmpty (divisibleBy3 number ++ divisibleBy5 number ++ divisibleBy7 number) then
            String.fromInt number
        else
            divisibleBy3 number ++ divisibleBy5 number ++ divisibleBy7 number

            