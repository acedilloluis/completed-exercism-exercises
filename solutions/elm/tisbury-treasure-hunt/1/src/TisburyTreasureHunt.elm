module TisburyTreasureHunt exposing (..)

-- Consider defining a type alias for TreasureLocation,
-- Treasure, PlaceLocation and Place,
-- and using them in the function type annotations
type alias TreasureLocation =
    ( Int
    , Char
    )


type alias Treasure =
    ( String
    , TreasureLocation
    )


type alias PlaceLocation =
    ( Char
    , Int
    )


type alias Place =
    ( String
    , PlaceLocation
    )


placeLocationToTreasureLocation : PlaceLocation -> TreasureLocation
placeLocationToTreasureLocation ( char, int ) =
    ( int, char )
            

treasureLocationMatchesPlaceLocation : PlaceLocation -> TreasureLocation -> Bool
treasureLocationMatchesPlaceLocation ( charp, intp ) ( intt, chart ) =
    ( charp, intp ) == ( chart, intt )


countPlaceTreasures : Place -> List Treasure -> Int
countPlaceTreasures place treasures =
    treasures
    |> List.foldl 
        (\treasure accumulator -> 
            if ( treasureLocationMatchesPlaceLocation ( Tuple.second place ) ( Tuple.second treasure ) )             then 
                accumulator + 1 
            else 
                0
        ) 0
    

specialCaseSwapPossible : Treasure -> Place -> Treasure -> Bool
specialCaseSwapPossible ( foundTreasure, _ ) ( place, _ ) ( desiredTreasure, _ ) =
    case ( foundTreasure, place, desiredTreasure ) of
        ( "Brass Spyglass", "Abandoned Lighthouse", _ ) ->
            True

        ( "Amethyst Octopus", "Stormy Breakwater", "Crystal Crab" ) ->
            True

        ( "Amethyst Octopus", "Stormy Breakwater", "Glass Starfish" ) ->
            True

        ( "Vintage Pirate Hat", "Harbor Managers Office", "Model Ship in Large Bottle") ->
            True

        ( "Vintage Pirate Hat", "Harbor Managers Office", "Antique Glass Fishnet Float") ->
            True

        _ ->
            False