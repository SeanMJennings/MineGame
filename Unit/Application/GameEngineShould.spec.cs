namespace Unit.Application;

using Game.Domain.Primitives;
using NUnit.Framework;
using Test;

public partial class GameEngineShould : Specification
{
    [TestCase(Direction.Up, 2, 1)]
    [TestCase(Direction.Right, 1, 2)]
    [TestCase(Direction.Left, 1, 0)]
    [TestCase(Direction.Down, 0, 1)]
    public void MovePlayerOneSpace(Direction direction, int rowPosition, int columnPosition)
    {
        Given(there_are_no_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(direction));
        Then(() => then_the_player_is_in_the_new_position(rowPosition, columnPosition));
    }

    [Test]
    public void LetPlayerHitLandmine()
    {
        Given(there_are_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(Direction.Up));
        Then(the_player_has_hit_a_landmine);
    }

    [Test]
    public void LetPlayerHitTwoLandminesAndKeepGameInPlay()
    {
        Given(there_are_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        Then(the_game_is_still_in_play);
    }

    [Test]
    public void LetPlayerHitThreeLandminesAndLoseGame()
    {
        Given(there_are_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        Then(the_game_is_lost);
    }

    [Test]
    public void LetPlayerReachTopOfBoardAndWinGame()
    {
        Given(there_are_no_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        Then(the_game_is_won);
    }

    [Test]
    public void NotMovePlayerIfGameIsNotInPlay()
    {
        Given(there_are_no_landmines);
        And(the_game_has_ended);
        When(() => a_player_moves(Direction.Right));
        Then(the_player_does_not_move);
    }

    [Test]
    public void NotLetPlayerHitSameLandmineTwice()
    {
        Given(there_are_landmines);
        And(the_game_has_started);
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Up));
        When(() => a_player_moves(Direction.Down));
        Then(the_game_is_still_in_play);
    }

    [TestCase(Direction.Left, 1,0 )]
    [TestCase(Direction.Right, 1,4 )]
    [TestCase(Direction.Up, 4,1 )]
    [TestCase(Direction.Down, 0,1 )]
    public void NotLetPlayerLeaveBoard(Direction direction, int row, int column)
    {
        Given(there_are_no_landmines);
        And(() => the_player_is_repositioned(row, column));
        And(the_game_has_started);
        When(() => a_player_moves(direction));
        Then(() => the_player_is_still_on_the_board(row, column));
    }
}