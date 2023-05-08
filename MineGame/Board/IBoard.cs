using MineGame.Domain;

namespace MineGame.Board;
using MineGame.Player;
public interface IBoard
{
    void MovePlayerUp();
    void MovePlayerRight();
    void MovePlayerLeft();
    void MovePlayerDown();

    Position GetPlayerPosition();

    int GetLandminesHit();
}