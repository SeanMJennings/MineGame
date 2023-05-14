namespace Game.Domain;

using Primitives;

public abstract class GameEntity
{
    protected Position Position;

    public GameEntity(Position position)
    {
        Position = position;
    }

    public Position GetPosition()
    {
        return Position;
    }

    public bool InSamePosition(GameEntity gameEntity)
    {
        return Position.Equals(gameEntity.GetPosition());
    }
}