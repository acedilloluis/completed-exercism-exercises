module TopScorers exposing (..)

import Dict exposing (Dict)
import TopScorersSupport exposing (PlayerName)


updateGoalCountForPlayer : PlayerName -> Dict PlayerName Int -> Dict PlayerName Int
updateGoalCountForPlayer playerName playerGoalCounts =
    let
        playerGoals : PlayerName -> Dict PlayerName Int -> Int
        playerGoals name counts =
            case Dict.get name counts of
                Just count ->
                    count

                Nothing ->
                    0
    in
        Dict.insert playerName ( 1 + playerGoals playerName playerGoalCounts ) playerGoalCounts


aggregateScorers : List PlayerName -> Dict PlayerName Int
aggregateScorers playerNames =
    List.foldl (\name dict -> updateGoalCountForPlayer name dict) Dict.empty playerNames
    |> Dict.filter (\name _ -> List.member name playerNames)


removeInsignificantPlayers : Int -> Dict PlayerName Int -> Dict PlayerName Int
removeInsignificantPlayers goalThreshold playerGoalCounts =
    Dict.filter (\_ goalCount -> goalCount >= goalThreshold) playerGoalCounts


resetPlayerGoalCount : PlayerName -> Dict PlayerName Int -> Dict PlayerName Int
resetPlayerGoalCount playerName playerGoalCounts =
    Dict.update playerName (\_ -> Just 0) playerGoalCounts


formatPlayer : PlayerName -> Dict PlayerName Int -> String
formatPlayer playerName playerGoalCounts =
    case Dict.get playerName playerGoalCounts of
        Just goals ->
            playerName ++ ": " ++ String.fromInt goals

        Nothing ->
            playerName ++ ": 0"


formatPlayers : Dict PlayerName Int -> String
formatPlayers players =
    Dict.foldl 
        (\name goals formattedString -> 
            formattedString ++ name ++ ": " ++ String.fromInt goals ++ ", "
        ) "" players
    |> String.dropRight 2

combineGames : Dict PlayerName Int -> Dict PlayerName Int -> Dict PlayerName Int
combineGames game1 game2 =
    Dict.merge
        -- only in game1
        (\name goals mergedGames -> Dict.insert name goals mergedGames)
        -- in game1 and game2
        (\name g1Goals g2Goals mergedGames -> Dict.insert name ( g1Goals + g2Goals ) mergedGames)
        -- only in game2
        (\name goals mergedGames -> Dict.insert name goals mergedGames)
        game1
        game2
        Dict.empty
