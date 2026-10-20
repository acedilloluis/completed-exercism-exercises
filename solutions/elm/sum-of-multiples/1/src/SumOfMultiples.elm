module SumOfMultiples exposing (sumOfMultiples)


getMultiples : Int -> Int -> List Int
getMultiples limit n =
    let
        getMultiple : Int -> Int
        getMultiple m =
            n * m

        range =
            case modBy n limit == 0 of
                True ->
                    List.range 1 (limit // n - 1)
                False ->
                    List.range 1 (limit // n)
    in
        List.map getMultiple range


getUniqueValues : List Int -> List Int
getUniqueValues list = 
    let
        isUnique : Int -> List Int -> List Int
        isUnique n l =
            case List.member n l of
                True ->
                    l
                False ->
                    n :: l
    in
        List.foldr isUnique [] list

sumOfMultiples : List Int -> Int -> Int
sumOfMultiples divisors limit =
    List.sum (getUniqueValues (List.concat (List.map (getMultiples limit) divisors)))
    
