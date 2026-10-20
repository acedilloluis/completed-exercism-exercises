module ComplexNumbers exposing
    ( Complex
    , abs
    , add
    , conjugate
    , div
    , exp
    , fromPair
    , fromReal
    , imaginary
    , mul
    , real
    , sub
    )


type Complex = 
    Pair Float Float


fromPair : ( Float, Float ) -> Complex
fromPair ( re, im ) =
    Pair re im


fromReal : Float -> Complex
fromReal float =
    Pair float 0


real : Complex -> Float
real ( Pair re _ ) =
    re


imaginary : Complex -> Float
imaginary ( Pair _ im ) =
    im


conjugate : Complex -> Complex
conjugate ( Pair re im ) =
    Pair re -im


abs : Complex -> Float
abs ( Pair re im ) =
    sqrt ( re^2 + im^2 )


add : Complex -> Complex -> Complex
add ( Pair re1 im1 ) ( Pair re2 im2 ) =
    Pair ( re1 + re2 ) ( im1 + im2 )


sub : Complex -> Complex -> Complex
sub ( Pair re1 im1 ) ( Pair re2 im2 ) = 
    Pair ( re1 - re2 ) ( im1 - im2 )


mul : Complex -> Complex -> Complex
mul ( Pair re1 im1 ) ( Pair re2 im2 ) =
    Pair ( re1 * re2 - im1 * im2 ) (im1 * re2 + re1 * im2 )


div : Complex -> Complex -> Complex
div ( Pair re1 im1 ) ( Pair re2 im2 ) =
    Pair (( re1 * re2 + im1 * im2 ) / ( re2^2 + im2^2 )) (( im1 * re2 - re1 * im2 ) / ( re2^2 + im2^2 ) )


exp : Complex -> Complex
exp ( Pair re im ) =
    Pair ( e^re * cos im ) ( e^re * sin im )
