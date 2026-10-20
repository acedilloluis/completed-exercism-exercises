module BlorkemonCards exposing
    ( Card
    , compareShinyPower
    , expectedWinner
    , isMorePowerful
    , maxPower
    , sortByCoolness
    , sortByMonsterName
    )


type alias Card =
    { monster : String, power : Int, shiny : Bool }


isMorePowerful : Card -> Card -> Bool
isMorePowerful card1 card2 =
    card1.power > card2.power


maxPower : Card -> Card -> Int
maxPower card1 card2 =
    max card1.power card2.power


sortByMonsterName : List Card -> List Card
sortByMonsterName cards =
    List.sortBy .monster cards


sortByCoolness : List Card -> List Card
sortByCoolness cards =
    let
        compareShininess : Card -> Card -> Order
        compareShininess card1 card2 =
            case ( card1.shiny, card2.shiny ) of
                ( True, False ) ->
                    GT

                ( False, True ) ->
                    LT

                ( _, _ ) ->
                    compare card1.power card2.power  
    in
        List.sortWith compareShininess cards
        |> List.reverse


compareShinyPower : Card -> Card -> Order
compareShinyPower card1 card2 =
    if card1.power > card2.power then
        GT
    else if card1.power < card2.power then
        LT
    else
        case ( card1.shiny, card2.shiny ) of
            ( True, False ) ->
                GT

            ( False, True ) ->
                LT

            ( _, _ ) ->
                EQ


expectedWinner : Card -> Card -> String
expectedWinner card1 card2 =
    case compareShinyPower card1 card2 of
        GT ->
            card1.monster

        LT ->
            card2.monster

        EQ ->
            "too close to call"
