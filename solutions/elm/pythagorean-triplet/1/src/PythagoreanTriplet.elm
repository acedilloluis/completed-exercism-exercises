module PythagoreanTriplet exposing (triplets)
import Array exposing (Array)

type alias Triplet =
    ( Int, Int, Int )


triplets : Int -> List Triplet
triplets n =
    let
        generateListInt : Int -> List Int
        generateListInt m =
            List.range ( m + 1 ) ( n - 1 )


        filterNumbers : Int -> Int -> Bool
        filterNumbers target a =
            let
                numerator = 2 * a * target - target^2
                
                denominator = a - target
                
                calculation = ( toFloat numerator ) / ( toFloat denominator )
            in
                -- check calculation i.e. 2b is int
                ( toFloat ( round calculation ) == calculation )
                && ( modBy 2 ( numerator // denominator ) == 0 )


        getB : Int -> Int -> Int
        getB target a =
            ( 2 * a * target - target^2 ) // ( 2 * ( a - target ) )


        getC : Int -> Int -> Int
        getC a b =
            a^2 + b^2
            |> toFloat
            |> sqrt
            |> truncate


        getTriplet : Int -> Int -> Triplet
        getTriplet target num =
            let
                b = getB target num
            in
                ( num, b, getC num b )
                

        filterTriplets : Triplet -> Bool
        filterTriplets ( a, b, c ) =
            a < b && b < c
    in
        if n < 12 then
            []
        else
            generateListInt 2
            |> Array.fromList
            |> Array.filter ( filterNumbers n )
            |> Array.map ( getTriplet n )
            |> Array.filter filterTriplets
            |> Array.toList