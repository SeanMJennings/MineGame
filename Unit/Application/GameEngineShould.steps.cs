namespace Unit.Application;

using Domain;
using Game.Application;
using Game.Domain;
using Game.Domain.Board;
using Game.Domain.Enums;
using Game.Domain.Primitives;
using NSubstitute;
using NUnit.Framework;

public partial class GameEngineShould
{
    private IGameEngine gameEngine;
    private Board board;
    private IMineCreator mineCreator;
    private Player player;
    private BoardDimensions boardDimensions;

    [SetUp]
    public void Before()
    {
        boardDimensions = new BoardDimensions(5, 5);
        mineCreator = Substitute.For<IMineCreator>();
        player = new Player(new Position(1, 1));
    }
    
    private void the_game_has_started()
    {
        board = new Board(boardDimensions, mineCreator);
        gameEngine = new GameEngine(board, player);
    }

    private void the_player_is_repositioned(int row, int column)
    {
        player = new Player(new Position(row, column));
    }

    private void there_are_landmines()
    {
        mineCreator = new FakeMineCreator();
    }

    private void there_are_no_landmines()
    {
        mineCreator.CreateMines(boardDimensions).Returns(new List<Landmine>());
    }

    private void a_player_moves(Direction direction)
    {
        gameEngine.Move(direction);
    }
    
    private void the_game_is_still_in_play()
    {
        Assert.AreEqual(GameState.InPlay, gameEngine.GetGameState());
    }

    private void the_player_is_still_on_the_board(int row, int column)
    {
        Assert.AreEqual(row, gameEngine.GetPlayerState().GetPosition().GetRow());
        Assert.AreEqual(column, gameEngine.GetPlayerState().GetPosition().GetColumn());
    }

    private void the_game_is_lost()
    {
        Assert.AreEqual(GameState.Lost, gameEngine.GetGameState());
    }

    private void the_game_is_won()
    {
        Assert.AreEqual(GameState.Won, gameEngine.GetGameState());
    }

    private void the_game_has_ended()
    {
        a_player_moves(Direction.Up);
        a_player_moves(Direction.Up);
        a_player_moves(Direction.Up);
        a_player_moves(Direction.Up);
    }

    private void then_the_player_is_in_the_new_position(int rowPosition, int columnPosition)
    {
        Assert.AreEqual(new Position(rowPosition, columnPosition), gameEngine.GetPlayerState().GetPosition());
    }

    private void the_player_has_hit_a_landmine()
    {
        Assert.AreEqual(1, gameEngine.GetPlayerState().GetLandminesHit());
    }

    private void the_player_does_not_move()
    {
        Assert.AreEqual(4, gameEngine.GetPlayerState().GetPosition().GetRow());
        Assert.AreEqual(1, gameEngine.GetPlayerState().GetPosition().GetColumn());
    }
}