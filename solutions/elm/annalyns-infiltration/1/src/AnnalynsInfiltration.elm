module AnnalynsInfiltration exposing (canFastAttack, canFreePrisoner, canSignalPrisoner, canSpy, stealthAttackDamage)


canFastAttack : Bool -> Bool
canFastAttack knightIsAwake =
    if knightIsAwake then
        False
    else
        True


canSpy : Bool -> Bool -> Bool -> Bool
canSpy knightIsAwake archerIsAwake prisonerIsAwake =
    if knightIsAwake || archerIsAwake || prisonerIsAwake then
        True
    else
        False


canSignalPrisoner : Bool -> Bool -> Bool
canSignalPrisoner archerIsAwake prisonerIsAwake =
    if prisonerIsAwake && not archerIsAwake then
        True
    else
        False


canFreePrisoner : Bool -> Bool -> Bool -> Bool -> Bool
canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent =
    if petDogIsPresent && not archerIsAwake then
        True
    else if not petDogIsPresent && prisonerIsAwake && not knightIsAwake && not archerIsAwake then
        True
    else
        False


stealthAttackDamage : Bool -> Int
stealthAttackDamage annalynIsDetected =
    if annalynIsDetected then
        7
    else
        12
