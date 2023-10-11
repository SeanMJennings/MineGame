namespace Game.Application;

using Domain;
using Domain.Board;
using Domain.Dto;
using Domain.Enums;
using Domain.Primitives;

public class GameEngine : IGameEngine
{
    private readonly Board board;
    private readonly Player player;
    private GameState gameState;
    
    public GameEngine(Board board, Player player)
    {
        this.board = board;
        this.player = player;
    }
    
    public void Move(Direction direction)
    {
        if (CannotMove(direction)) return;
        
        player.Move(direction);
        board.DetonateLandmine(player);
        CalculateGameState();
    }

    public PlayerState GetPlayerState()
    {
        return new PlayerState(player.GetPosition(), player.GetLandminesHit());
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    private bool CannotMove(Direction direction)
    {
        return gameState != GameState.InPlay || !board.MoveIsValid(player.GetPosition(), direction);
    }

    private void CalculateGameState()
    {
        if (DidPlayerLose()) return;
        
        DidPlayerWin();

    }

    private bool DidPlayerLose()
    {
        if (player.GetLandminesHit() <= 2) return false;
        
        gameState = GameState.Lost;
        return true;
    }

    private void DidPlayerWin()
    {
        if (board.IsPlayerAtTopOfBoard(player))
            gameState = GameState.Won;
    }
}