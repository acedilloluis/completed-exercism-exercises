module MariosMarvellousLasagna exposing (remainingTimeInMinutes)

-- TODO: define the remainingTimeInMinutes function
remainingTimeInMinutes : Int -> Int -> Int
remainingTimeInMinutes layersOfLasagna minutesSinceStartCooking =
    let
        expectedMinutesInOven = 40
        preparationTimeInMinutes x = x * 2
    in
        (preparationTimeInMinutes layersOfLasagna) + (expectedMinutesInOven - minutesSinceStartCooking) 