namespace Game.Domain.Entities;

using Enums;
using Primitives;

public class Player(Position position) : BoardPiece(position)
{
    private int landminesHit;

    public int GetLandminesHit()
    {
        return landminesHit;
    }

    public void Move(Direction direction)
    {
        Position = direction switch
        {
            Direction.Up => new Position(Position.GetRow() + 1, Position.GetColumn()),
            Direction.Right => new Position(Position.GetRow(), Position.GetColumn() + 1),
            Direction.Left => new Position(Position.GetRow(), Position.GetColumn() - 1),
            Direction.Down => new Position(Position.GetRow() - 1, Position.GetColumn()),
            _ => Position
        };
    }

    public void HitLandmine(Landmine landmine)
    {
        landminesHit++;
        landmine.Explode();
    }
}