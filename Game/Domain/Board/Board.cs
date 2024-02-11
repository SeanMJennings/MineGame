namespace Game.Domain.Board;

using Enums;
using Primitives;

public class Board
{
    private readonly BoardDimensions boardDimensions;
    private readonly List<Landmine> landmines;

    public Board(BoardDimensions boardDimensions, IMineCreator mineCreator)
    {
        this.boardDimensions = boardDimensions;
        landmines = mineCreator.CreateMines(boardDimensions).ToList();
    }

    public void DetonateLandmine(Player player)
    {
        var landmine = landmines.Find(l => l.InSamePosition(player) && !l.IsExploded());
        if (landmine is not null)
        {
            player.HitLandmine(landmine);
        }
    }

    public bool MoveIsValid(Position playerPosition, Direction direction)
    {
        return direction switch
        {
            Direction.Up => playerPosition.GetRow() + 1 < boardDimensions.BoardLength,
            Direction.Right => playerPosition.GetColumn() + 1 < boardDimensions.BoardWidth,
            Direction.Left => playerPosition.GetColumn() - 1 >= 0,
            Direction.Down => playerPosition.GetRow() - 1 >= 0,
            _ => false
        };
    }

    public bool IsPlayerAtTopOfBoard(Player player)
    {
        return boardDimensions.BoardLength == player.GetPosition().GetRow() + 1;
    }
}