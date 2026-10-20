module EliudsEggs exposing (eggCount)


eggCount : Int -> Int
eggCount n =
    let
        convertToBinary : Int -> List Int -> List Int
        convertToBinary quotient binaryValue =
            if quotient == 0 then
                binaryValue
            else
                convertToBinary ( quotient // 2 ) ( ( modBy 2 quotient ) :: binaryValue )
    in
        convertToBinary n []
        |> List.foldl (\bit -> if bit == 1 then (+) 1 else identity) 0
                
