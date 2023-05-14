namespace Game.Infrastructure;

using Domain.Primitives;

public interface IGameController
{
    void Move(Direction move);
    event EventHandler<PlayerState> PlayerState;
    event EventHandler<GameState> GameState;
}