namespace Game.Infrastructure;

using Domain.Dto;
using Domain.Enums;
using Domain.Primitives;

public interface IGameController
{
    void Move(Direction move);
    event EventHandler<PlayerState> PlayerState;
    event EventHandler<GameState> GameState;
}