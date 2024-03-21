namespace Acceptance;

using Game.Application;
using NUnit.Framework;
using Game.Domain.Entities;
using Game.Domain.Entities.Board;
using Game.Domain.Enums;
using Game.Domain.Primitives;
using Game.Infrastructure;
using NSubstitute;
using Tests.Domain;
using Player = Game.Domain.Entities.Player;

public partial class GameScenarios
{
    private IAmAMineCreator mineCreator = null!;
    private GameController gameController = null!;
    private GameState gameState;
    private Board board = null!;
    private IAmAGameEngine gameEngine = null!;
    private BoardDimensions boardDimensions = null!;
    private Player player = null!;

    [SetUp]
    public void Before()
    {
        gameState = default;
        player = new Player(new Position(0, 0));
    }

    private void there_are_no_mines()
    {
        boardDimensions = new BoardDimensions(8, 8);
        mineCreator = Substitute.For<IAmAMineCreator>();
        mineCreator.CreateMines(Arg.Any<BoardDimensions>()).Returns(new List<Landmine>());
        board = new Board(boardDimensions, mineCreator, player);
        gameEngine = new GameEngine(board);
        gameController = new GameController(gameEngine);
    }    
    
    private void the_board_is_full_of_mines()
    {
        boardDimensions = new BoardDimensions(8, 8);
        mineCreator = new FakeAmAMineCreator();
        board = new Board(boardDimensions, mineCreator, player);
        gameEngine = new GameEngine(board);
        gameController = new GameController(gameEngine);
    }

    private void a_game_has_started()
    {
        gameController.GameState += (_,e) =>
        {
            gameState = e;
        };
    }

    private void the_player_moves_to_top_of_the_board()
    {
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
    }    
    
    private void the_player_moves_three_spaces_up()
    {
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
        gameController.Move(Direction.Up);
    }

    private void the_player_wins_the_game()
    {
        Assert.AreEqual(GameState.Won, gameState);
    }    
    
    private void the_player_loses_the_game()
    {
        Assert.AreEqual(GameState.Lost, gameState);
    }
}