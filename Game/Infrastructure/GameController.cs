namespace Game.Infrastructure;

using Application;
using Domain.Dtos;
using Domain.Enums;

public class GameController(IAmAGameEngine gameEngine)
{
    public event EventHandler<PlayerState>? PlayerState;
    public event EventHandler<GameState>? GameState;

    public void Move(Direction move)
    {
        gameEngine.Move(move);
        OnMove(gameEngine.GameState, gameEngine.PlayerState); 
    }

    private void OnMove(GameState gameState, PlayerState playerState)
    {
        PlayerState?.Invoke(this, playerState);
        GameState?.Invoke(this, gameState);
    }
}