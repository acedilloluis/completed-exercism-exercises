module AllYourBase exposing (rebase)


rebase : Int -> List Int -> Int -> Maybe (List Int)
rebase inBase digits outBase =
    let
        isNotValid : Int -> Bool
        isNotValid n =
            n < 0 || n >= inBase


        convertToOutBase : List Int -> Int -> List Int
        convertToOutBase outBaseDigits num =
            if num < outBase then
                num :: outBaseDigits
            else
                convertToOutBase (modBy outBase num :: outBaseDigits) (num // outBase)
    in
        if 
            inBase <= 1 
            || outBase <= 1 
            || digits == [] 
            || List.any isNotValid digits 
            || List.all (\d -> d == 0) digits 
        then
            Nothing
        else
            List.foldl (\digit accumulator -> digit + inBase * accumulator) 0 digits
            |> convertToOutBase []
            |> Just