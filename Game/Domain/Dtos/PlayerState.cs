namespace Game.Domain.Dtos;

using Primitives;

public class PlayerState(Position position, int landminesHit)
{
    public Position Position { get; } = position;

    public int LandminesHit { get; } = landminesHit;
}