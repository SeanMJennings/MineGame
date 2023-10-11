namespace Game.Application;

using Domain;
using Domain.Dto;
using Domain.Enums;
using Domain.Primitives;

public interface IGameEngine
{
    void Move(Direction up);
    PlayerState GetPlayerState();
    GameState GetGameState();
}