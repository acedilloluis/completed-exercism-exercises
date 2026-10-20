module Bob exposing (hey)


hey : String -> String
hey remark =
    let
        isQuestion : String -> Bool
        isQuestion string =
            String.trim string
            |> String.endsWith "?"


        isYelling : String -> Bool
        isYelling string =
            if String.isEmpty string || String.all (\c -> not (Char.isAlpha c)) string then
                False
            else
                String.all (\c -> if Char.isAlpha c then Char.isUpper c else True) string


        isSilence : String -> Bool
        isSilence string =
            String.isEmpty ( String.trim string )
    in
        if isSilence remark then
            "Fine. Be that way!"
        else if isYelling remark && isQuestion remark then
            "Calm down, I know what I'm doing!"
        else if isQuestion remark then
            "Sure."
        else if isYelling remark then
            "Whoa, chill out!"
        else
            "Whatever."
