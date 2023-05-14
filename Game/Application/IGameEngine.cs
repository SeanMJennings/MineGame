namespace Game.Application;

using Domain;
using Domain.Primitives;

public interface IGameEngine
{
    void Move(Direction up);
    PlayerState GetPlayerState();
    GameState GetGameState();
}