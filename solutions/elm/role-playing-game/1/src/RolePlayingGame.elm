module RolePlayingGame exposing (Player, castSpell, introduce, revive)


type alias Player =
    { name : Maybe String
    , level : Int
    , health : Int
    , mana : Maybe Int
    }


introduce : Player -> String
introduce { name } =
    case name of
        Nothing ->
            "Mighty Magician"

        Just string ->
            string


revive : Player -> Maybe Player
revive player =
    if player.health == 0 then
        if player.level >= 10 then
            Just { player | health = 100, mana = Just 100 }
        else
            Just { player | health = 100, mana = Nothing }
    else
        Nothing


castSpell : Int -> Player -> ( Player, Int )
castSpell manaCost player =
    case player.mana of
        Nothing ->
            if player.health - manaCost >= 0 then
                ( { player | health = player.health - manaCost }, 0 )
            else
                ( { player | health = 0 }, 0)
        Just manaPool ->
            if manaPool >= manaCost then
                ( {player | mana = Just (manaPool - manaCost) }, manaCost * 2 )
            else 
                ( player, 0 )
