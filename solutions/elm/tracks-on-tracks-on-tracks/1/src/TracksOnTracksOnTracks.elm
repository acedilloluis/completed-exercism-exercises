module TracksOnTracksOnTracks exposing (..)

import List as L

newList : List String
newList =
    []


existingList : List String
existingList =
        [ "Elm"
        , "Clojure"
        , "Haskell"
        ]
    

addLanguage : String -> List String -> List String
addLanguage language languages =
    language :: languages


countLanguages : List String -> Int
countLanguages languages =
    L.length languages


reverseList : List String -> List String
reverseList languages =
    L.reverse languages


excitingList : List String -> Bool
excitingList languages =
    case languages of
        "Elm" :: _ -> 
            True

        [ _, "Elm", _ ] -> 
            True

        [ _, "Elm" ] ->
            True

        _ ->
            False
