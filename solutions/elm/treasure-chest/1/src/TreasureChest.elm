module TreasureChest exposing (..)


type TreasureChest a
    = TreasureChest String a


getTreasure : String -> TreasureChest a -> Maybe a
getTreasure passwordAttempt treasureChest =
    case treasureChest of
        TreasureChest str treasure ->
            if str == passwordAttempt then
                Just treasure
            else
                Nothing


multiplyTreasure : (a -> List a) -> TreasureChest a -> TreasureChest (List a)
multiplyTreasure multiplier treasureChest =
    case treasureChest of
        TreasureChest str treasure ->
            TreasureChest str ( multiplier treasure )
