namespace Game.Infrastructure;

using Application;
using Domain.Dtos;
using Domain.Enums;

public class GameController(IAmAGameEngine amAGameEngine)
{
    public event EventHandler<PlayerState>? PlayerState;
    public event EventHandler<GameState>? GameState;

    public void Move(Direction move)
    {
        amAGameEngine.Move(move);
        OnMove(amAGameEngine.GameState, amAGameEngine.PlayerState); 
    }

    private void OnMove(GameState gameState, PlayerState playerState)
    {
        PlayerState?.Invoke(this, playerState);
        GameState?.Invoke(this, gameState);
    }
}