namespace Tests.Infrastructure;

using Game.Application;
using Game.Domain.Dtos;
using Game.Domain.Enums;
using Game.Domain.Primitives;
using Game.Infrastructure;
using NSubstitute;
using NUnit.Framework;

public partial class GameControllerShould
{
    private GameState gameState;
    private Position playerPosition;
    private int landMinesHit;
    
    private GameController gameController = null!;
    private IAmAGameEngine gameEngine = null!;

    [SetUp]
    public void Before()
    {
        gameEngine = Substitute.For<IAmAGameEngine>();
        gameController = new GameController(gameEngine);
        gameState = default;
        playerPosition = default;
        landMinesHit = default;
        
        gameController.PlayerState += (_, e) =>
        {
            playerPosition = e.Position;
            landMinesHit = e.LandminesHit;
        };
        gameController.GameState += (_, e) =>
        {
            gameState = e;
        };
    }

    private void the_game_has_started()
    {
        gameEngine.PlayerState.Returns( new PlayerState(new Position(1,0), 0));
    }

    private void there_are_landmines()
    {
        gameEngine.PlayerState.Returns( new PlayerState(new Position(0,1), 1));
    }

    private void the_player_moves_up()
    {
        gameController.Move(Direction.Up);
    }

    private void the_player_reaches_the_top_of_the_board()
    {
        gameEngine.PlayerState.Returns( new PlayerState(new Position(7,0), 0));
        gameEngine.GameState.Returns(GameState.Won);
        gameController.Move(Direction.Up);
    }

    private void the_player_hits_three_landmines()
    {
        gameEngine.PlayerState.Returns( new PlayerState(new Position(3,0), 3));
        gameEngine.GameState.Returns(GameState.Lost);
        gameController.Move(Direction.Up);
    }

    private void the_player_location_is_one_square_up()
    {
        Assert.IsTrue(playerPosition.Equals(new Position(1,0)));
    }

    private void the_player_hits_a_landmine()
    {
        Assert.AreEqual(1,landMinesHit);
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