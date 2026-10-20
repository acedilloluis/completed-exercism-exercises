module PhoneNumber exposing (getNumber)


getNumber : String -> Maybe String
getNumber phoneNumber =
    let
        cleanNumber : String -> String -> String
        cleanNumber string number =
            String.replace string "" number


        isAllDigits : String -> Bool
        isAllDigits number =
            String.all (\c -> Char.isDigit c) number


        isValidCountryCode : String -> Bool
        isValidCountryCode number =
            if String.length number == 11 then
                case String.uncons number of
                    Just ( head, tail ) ->
                        head == '1'
                    Nothing ->
                        False
            else
                True


        checkAreValidDigits : String -> Int -> Bool
        checkAreValidDigits number index =
            String.toList number
            |> List.indexedMap (\i digit -> if i == index || i == index + 3 then digit > '1' else True)
            |> List.all (\bool -> bool)


        areValidDigits : String -> Bool
        areValidDigits number =
            if String.length number == 10 then
                checkAreValidDigits number 0
            else
                checkAreValidDigits number 1

        isValidNumber : String -> Maybe String
        isValidNumber number =
            if 
                (String.length number == 10 
                || String.length number == 11) 
                && isAllDigits number
                && isValidCountryCode number
                && areValidDigits number
            then
                if String.length number == 10 then
                    Just number
                else
                    Just (String.slice 1 11 number)    
            else
                Nothing
    in
        cleanNumber " " phoneNumber
        |> cleanNumber "-"
        |> cleanNumber "."
        |> cleanNumber "("
        |> cleanNumber ")"
        |> cleanNumber "+"
        |> isValidNumber
