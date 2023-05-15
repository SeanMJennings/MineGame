namespace Acceptance;

using Game.Application;
using Game.Domain.Board;
using NUnit.Framework;
using Game.Domain;
using Game.Domain.Primitives;
using Game.Infrastructure;
using NSubstitute;
using Unit.Domain;
using Player = Game.Domain.Player;

public partial class GameControllerScenarios
{
    private IMineCreator mineCreator;
    private IGameController gameController;
    private GameState gameState;
    private Board board;
    private IGameEngine gameEngine;
    private BoardDimensions boardDimensions;
    private Player player;

    [SetUp]
    public void Before()
    {
        gameState = default;
        player = new Player(new Position(0, 0));
    }

    private void there_are_no_mines()
    {
        boardDimensions = new BoardDimensions(8, 8);
        mineCreator = Substitute.For<IMineCreator>();
        mineCreator.CreateMines(Arg.Any<BoardDimensions>()).Returns(new List<Landmine>());
        board = new Board(boardDimensions, mineCreator);
        gameEngine = new GameEngine(board, player);
        gameController = new GameController(gameEngine);
    }    
    
    private void the_board_is_full_of_mines()
    {
        boardDimensions = new BoardDimensions(8, 8);
        mineCreator = new FakeMineCreator();
        board = new Board(boardDimensions, mineCreator);
        gameEngine = new GameEngine(board, player);
        gameController = new GameController(gameEngine);
    }

    private void a_game_has_started()
    {
        gameController.GameState += (sender,e) =>
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