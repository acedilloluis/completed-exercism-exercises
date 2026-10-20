module SumOfMultiples exposing (sumOfMultiples)


getMultiples : Int -> Int -> List Int
getMultiples limit n =
    let
        getMultiple : Int -> Int
        getMultiple m =
            n * m

        range =
            if modBy n limit == 0 then
                List.range 1 (limit // n - 1)
            else
                List.range 1 (limit // n)
    in
        List.map getMultiple range


getUniqueValues : List Int -> List Int
getUniqueValues list = 
    let
        isUnique : Int -> List Int -> List Int
        isUnique n l =
            if List.member n l then
                l
            else
                n :: l
    in
        List.foldr isUnique [] list

sumOfMultiples : List Int -> Int -> Int
sumOfMultiples divisors limit =
    List.sum (getUniqueValues (List.concatMap (getMultiples limit) divisors))
    
