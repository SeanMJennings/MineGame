namespace Unit.Infrastructure;

using NUnit.Framework;
using Test;

[TestFixture]
public partial class GameControllerShould : Specification
{
    [Test]
    public void NotifyPlayerLocation()
    {
        Given(the_game_has_started);
        When(the_player_moves_up);
        Then(the_player_location_is_one_square_up);
    }

    [Test]
    public void NotifyLandmineHit()
    {
        Given(the_game_has_started);
        And(there_are_landmines);
        When(the_player_moves_up);
        Then(the_player_hits_a_landmine);
    }

    [Test]
    public void NotifyGameWon()
    {
        Given(the_game_has_started);
        When(the_player_reaches_the_top_of_the_board);
        When(the_player_wins_the_game);
    }

    [Test]
    public void NotifyGameLost()
    {
        Given(the_game_has_started);
        When(the_player_hits_three_landmines);
        Then(the_player_loses_the_game);
    }
}