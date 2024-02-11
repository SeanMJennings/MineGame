namespace Game.Infrastructure;

using Application;
using Domain.Dto;
using Domain.Enums;

public class GameController : IGameController
{
    private readonly IGameEngine gameEngine;
    public event EventHandler<PlayerState>? PlayerState;
    public event EventHandler<GameState>? GameState;

    public GameController(IGameEngine gameEngine)
    {
        this.gameEngine = gameEngine;
    }

    public void Move(Direction move)
    {
        gameEngine.Move(move);
        OnMove(gameEngine.GetGameState(), gameEngine.GetPlayerState()); 
    }

    private void OnMove(GameState gameState, PlayerState playerState)
    {
        PlayerState?.Invoke(this, playerState);
        GameState?.Invoke(this, gameState);
    }
}