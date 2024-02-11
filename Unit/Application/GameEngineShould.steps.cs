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
    private IGameEngine gameEngine = null!;
    private Board board = null!;
    private IMineCreator mineCreator = null!;
    private Player player = null!;
    private BoardDimensions boardDimensions = null!;

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

    private Action the_player_is_repositioned(int row, int column)
    {
        return () =>
        {
            player = new Player(new Position(row, column));
        };
    }

    private void there_are_landmines()
    {
        mineCreator = new FakeMineCreator();
    }

    private void there_are_no_landmines()
    {
        mineCreator.CreateMines(boardDimensions).Returns(new List<Landmine>());
    }

    private Action a_player_moves(Direction direction)
    {
        return () =>
        {
            gameEngine.Move(direction);
        };

    }
    
    private void the_game_is_still_in_play()
    {
        Assert.AreEqual(GameState.InPlay, gameEngine.GetGameState());
    }

    private Action the_player_is_still_on_the_board(int row, int column)
    {
        return () =>
        {
            Assert.AreEqual(row, gameEngine.GetPlayerState().GetPosition.GetRow());
            Assert.AreEqual(column, gameEngine.GetPlayerState().GetPosition.GetColumn());
        };

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
        board = new Board(boardDimensions, mineCreator);
        gameEngine = new GameEngine(board, player);
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
    }

    private Action then_the_player_is_in_the_new_position(int rowPosition, int columnPosition)
    {
        return () =>
        {
            Assert.AreEqual(new Position(rowPosition, columnPosition), gameEngine.GetPlayerState().GetPosition);
        };
    }

    private void the_player_has_hit_a_landmine()
    {
        Assert.AreEqual(1, gameEngine.GetPlayerState().GetLandminesHit);
    }

    private void the_player_does_not_move()
    {
        Assert.AreEqual(4, gameEngine.GetPlayerState().GetPosition.GetRow());
        Assert.AreEqual(1, gameEngine.GetPlayerState().GetPosition.GetColumn());
    }
}