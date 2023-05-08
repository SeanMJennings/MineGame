using MineGame.Board;
using MineGame.Domain;

namespace MineGame.Game;

public interface IGame
{
    public event EventHandler<Position>? PlayerMoved;
    public void MoveUp();
    public void MoveRight();
}