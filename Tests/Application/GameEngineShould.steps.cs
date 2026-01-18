namespace Tests.Application;

using Domain;
using Game.Application;
using Game.Domain.Entities;
using Game.Domain.Entities.Board;
using Game.Domain.Enums;
using Game.Domain.Primitives;
using NSubstitute;
using NUnit.Framework;

public partial class GameEngineShould
{
    private GameEngine gameEngine = null!;
    private Board board = null!;
    private IAmAMineCreator mineCreator = null!;
    private Player player = null!;
    private BoardDimensions boardDimensions = null!;

    [SetUp]
    public void Before()
    {
        boardDimensions = new BoardDimensions(5, 5);
        mineCreator = Substitute.For<IAmAMineCreator>();
        player = new Player(new Position(1, 1));
    }
    
    private void the_game_has_started()
    {
        board = new Board(boardDimensions, mineCreator, player);
        gameEngine = new GameEngine(board);
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
        mineCreator = new FakeAmAMineCreator();
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
        Assert.That(GameState.InPlay, Is.EqualTo(gameEngine.GameState));
    }

    private Action the_player_is_still_on_the_board(int row, int column)
    {
        return () =>
        {
            Assert.That(row, Is.EqualTo(gameEngine.PlayerState.Position.GetRow()));
            Assert.That(column, Is.EqualTo(gameEngine.PlayerState.Position.GetColumn()));
        };

    }

    private void the_game_is_lost()
    {
        Assert.That(GameState.Lost, Is.EqualTo(gameEngine.GameState));
    }

    private void the_game_is_won()
    {
        Assert.That(GameState.Won, Is.EqualTo(gameEngine.GameState));
    }

    private void the_game_has_ended()
    {
        board = new Board(boardDimensions, mineCreator, player);
        gameEngine = new GameEngine(board);
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
        a_player_moves(Direction.Up).Invoke();
    }

    private Action then_the_player_is_in_the_new_position(int rowPosition, int columnPosition)
    {
        return () =>
        {
            Assert.That(new Position(rowPosition, columnPosition), Is.EqualTo(gameEngine.PlayerState.Position));
        };
    }

    private void the_player_has_hit_a_landmine()
    {
        Assert.That(1, Is.EqualTo(gameEngine.PlayerState.LandminesHit));
    }

    private void the_player_does_not_move()
    {
        Assert.That(4, Is.EqualTo(gameEngine.PlayerState.Position.GetRow()));
        Assert.That(1, Is.EqualTo(gameEngine.PlayerState.Position.GetColumn()));
    }
}