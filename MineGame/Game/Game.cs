using MineGame.Board;
using MineGame.Domain;

namespace MineGame.Game;

public class Game : IGame
{
    public event EventHandler<Position>? PlayerMoved;
    private IBoard board;
    
    public Game(IBoard board)
    {
        this.board = board;
    }

    public void MoveUp()
    {
        board.MovePlayerUp();
        OnPlayerMoved(board.GetPlayerPosition());
    }

    public void MoveRight()
    {
        board.MovePlayerRight();
        OnPlayerMoved(board.GetPlayerPosition());
    }

    private void OnPlayerMoved(Position position) { PlayerMoved?.Invoke(this, position); }
}