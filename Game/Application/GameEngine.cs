namespace Game.Application;

using Domain.Dtos;
using Domain.Entities.Board;
using Domain.Enums;

public interface IGameEngine
{
    void Move(Direction up);
    PlayerState PlayerState { get; }
    GameState GameState { get; }
}

public class GameEngine(Board board) : IGameEngine
{
    public void Move(Direction direction)
    {
        if (GameState != GameState.InPlay) return;
        board.MovePlayer(direction);
        CalculateGameState();
    }

    public GameState GameState { get; private set; }

    public PlayerState PlayerState => board.GetPlayerState();

    private void CalculateGameState()
    {
        if (board.GetPlayerState().LandminesHit == 3) GameState = GameState.Lost;
        else if (board.IsPlayerAtTopOfBoard()) GameState = GameState.Won;
    }
}