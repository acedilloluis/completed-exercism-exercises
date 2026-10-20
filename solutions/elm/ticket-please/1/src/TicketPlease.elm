module TicketPlease exposing (..)

import TicketPleaseSupport exposing (Status(..), Ticket(..), User(..))


emptyComment : ( User, String ) -> Bool
emptyComment ( _, str ) =
    String.isEmpty str


numberOfCreatorComments : Ticket -> Int
numberOfCreatorComments (Ticket { createdBy, comments }) =
    let
         ( creator, _ ) = createdBy
    in
        comments
        |> List.foldl (\( writer, _ ) -> if creator == writer then (+) 1 else identity) 0


assignedToDevTeam : Ticket -> Bool
assignedToDevTeam (Ticket { assignedTo }) =
    case assignedTo of
        Just (User "Alice" ) ->
            True

        Just (User "Bob") ->
            True

        Just (User "Charlie") ->
            True

        _ ->
            False


assignTicketTo : User -> Ticket -> Ticket
assignTicketTo user (Ticket ({ status } as ticket)) =
    case status of
        New ->
            Ticket { ticket | status = InProgress, assignedTo = Just user }

        Archived ->
            Ticket ticket

        _ ->
            Ticket { ticket | assignedTo = Just user }
            
    
