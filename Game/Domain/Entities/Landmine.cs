namespace Game.Domain.Entities;

using Primitives;

public class Landmine(Position position) : BoardPiece(position)
{
    private bool exploded;

    public bool IsExploded()
    {
        return exploded;
    }

    public void Explode()
    {
        exploded = true;
    }
}