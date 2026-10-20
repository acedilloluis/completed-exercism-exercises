module PipersPie exposing (doubleFactorial, factorial, pipersPi)

factorialHelper : Int -> Int -> Int
factorialHelper n resultSoFar =
    if n == 0 then
        1
    else if n == 1 then
        resultSoFar
    else
        factorialHelper (n - 1) ((n - 1) * resultSoFar)


factorial : Int -> Int
factorial n =
    factorialHelper n n


doubleFactorialHelper : Int -> Int -> Int
doubleFactorialHelper n resultSoFar =
    if n == 0 then
        1
    else if n <= 2 then
        resultSoFar
    else
        doubleFactorialHelper (n - 2) ((n - 2) * resultSoFar)


doubleFactorial : Int -> Int
doubleFactorial n =
    doubleFactorialHelper n n


pipersPi : Int -> Float
pipersPi limit =
    let
        formula : Float -> Int -> Float
        formula sum n =
            let
                numerator : Int -> Float
                numerator num = toFloat ( factorial num )


                denominator : Int -> Float
                denominator num = toFloat (doubleFactorial ( 2 * num + 1 ) )
            in
                if n > limit then
                    sum
                else
                    let
                        newSum = sum + ( numerator n ) / ( denominator n )
                    in
                        if newSum == sum then
                            sum
                        else
                            formula newSum ( n + 1 )
    in
        2 * formula 0 0
