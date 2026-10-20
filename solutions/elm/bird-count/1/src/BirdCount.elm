module BirdCount exposing (busyDays, hasDayWithoutBirds, incrementDayCount, today, total)


today : List Int -> Maybe Int
today counts =
    case counts of
        head :: _ ->
            Just head

        [] ->
            Nothing


incrementDayCount : List Int -> List Int
incrementDayCount counts =
    case counts of
        head :: tail ->
            ( head + 1 ) :: tail

        [] ->
            [1]


hasDayWithoutBirds : List Int -> Bool
hasDayWithoutBirds counts =
    case counts of
        head :: tail ->
            if head == 0 then
                True
            else
                hasDayWithoutBirds tail

        [] ->
            False


total : List Int -> Int
total counts =
    case counts of
        head :: tail ->
            head + total tail

        [] ->
            0


busyDays : List Int -> Int
busyDays counts =
    case counts of
        head :: tail ->
            if head >= 5 then
                1 + busyDays tail
            else
                busyDays tail

        [] ->
            0
