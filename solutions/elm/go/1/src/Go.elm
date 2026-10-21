module Go exposing (..)

import GoSupport exposing (..)


applyRules : Game -> Rule -> NonValidatingRule -> Rule -> Rule -> Game
applyRules game oneStonePerPointRule captureRule libertyRule koRule =
    let
        applyRule : Rule -> Game -> Game
        applyRule rule ogGame =
            case rule ( ogGame ) of
                Ok newGame ->
                    captureRule newGame

                Err err ->
                    { game | error = err }


        gameWithRulesApplied =  
            [oneStonePerPointRule, libertyRule, koRule]
            |> List.foldl applyRule game
    in
        if gameWithRulesApplied.error /= "" then
            gameWithRulesApplied
        else
            changePlayer gameWithRulesApplied