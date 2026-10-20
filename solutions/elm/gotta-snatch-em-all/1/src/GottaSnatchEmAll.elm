module GottaSnatchEmAll exposing (..)

import Set exposing (Set)


type alias Card =
    String


newCollection : Card -> Set Card
newCollection card =
    Set.singleton card


addCard : Card -> Set Card -> ( Bool, Set Card )
addCard card collection =
    ( Set.member card collection, Set.insert card collection )


tradeCard : Card -> Card -> Set Card -> ( Bool, Set Card )
tradeCard yourCard theirCard collection =
    ( ( Set.member yourCard collection ) && not ( Set.member theirCard collection )
    , Set.insert theirCard ( Set.remove yourCard collection )
    )


removeDuplicates : List Card -> List Card
removeDuplicates cards =
    Set.fromList cards
    |> Set.toList


extraCards : Set Card -> Set Card -> Int
extraCards yourCollection theirCollection =
    Set.size ( Set.diff yourCollection theirCollection )


boringCards : List (Set Card) -> List Card
boringCards collections =
    List.foldl 
        (\collection intersection -> Set.intersect collection intersection) 
        (case collections of 
            head :: _ ->
                head
    
            _ ->
                Set.empty
        )
        collections
    |> Set.toList
    

totalCards : List (Set Card) -> Int
totalCards collections =
    List.foldl
        (\collection union -> Set.union collection union)
        Set.empty
        collections
    |> Set.size


splitShinyCards : Set Card -> ( List Card, List Card )
splitShinyCards collection =
    Set.partition (\card -> String.startsWith "Shiny" card) collection
    |> Tuple.mapBoth Set.toList Set.toList
