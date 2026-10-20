module LuciansLusciousLasagna exposing (elapsedTimeInMinutes, expectedMinutesInOven, preparationTimeInMinutes)

-- DONE: define the expectedMinutesInOven constant
expectedMinutesInOven : Int
expectedMinutesInOven =
    40
    
-- DONE: define the preparationTimeInMinutes function
preparationTimeInMinutes : Int -> Int
preparationTimeInMinutes layersOfLasagna =
    layersOfLasagna * 2
    
-- DONE: define the elapsedTimeInMinutes function
elapsedTimeInMinutes : Int -> Int -> Int
elapsedTimeInMinutes layersOfLasagna minutesInOven =
    preparationTimeInMinutes layersOfLasagna + minutesInOven