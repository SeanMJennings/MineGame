namespace Game.Domain;

using Primitives;

public class Landmine : GameEntity
{
    private bool exploded;
    public Landmine(Position position) : base(position)
    {
    }

    public bool IsExploded()
    {
        return exploded;
    }

    public void Explode()
    {
        exploded = true;
    }
}