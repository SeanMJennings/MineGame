namespace Game.Domain;

using Enums;
using Primitives;

public class Player : GameEntity
{
    private int landminesHit;

    public Player(Position position) : base(position)
    {
    }

    public int GetLandminesHit()
    {
        return landminesHit;
    }

    public void Move(Direction direction)
    {
        if (direction == Direction.Up)
            Position = new Position(Position.GetRow() + 1, Position.GetColumn());
        if (direction == Direction.Right)
            Position = new Position(Position.GetRow(), Position.GetColumn() + 1);        
        if (direction == Direction.Left)
            Position = new Position(Position.GetRow(), Position.GetColumn() - 1);        
        if (direction == Direction.Down)
            Position = new Position(Position.GetRow() - 1, Position.GetColumn());
    }

    public void HitLandmine(Landmine landmine)
    {
        landminesHit++;
        landmine.Explode();
    }
}