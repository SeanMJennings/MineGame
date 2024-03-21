using NUnit.Framework;
using Test;

namespace Acceptance;

public partial class GameScenarios : Specification
{
    [Test]
    public void A_player_can_win_the_game()
    {
        Given(there_are_no_mines);
        And(a_game_has_started);
        When(the_player_moves_to_top_of_the_board);
        Then(the_player_wins_the_game);
    }

    [Test]
    public void A_player_can_lose_the_game()
    {
        Given(the_board_is_full_of_mines);
        And(a_game_has_started);
        When(the_player_moves_three_spaces_up);
        Then(the_player_loses_the_game);
    }
}