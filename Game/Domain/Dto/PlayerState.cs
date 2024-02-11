namespace Game.Domain.Dto;

using Primitives;

public class PlayerState
{
    public PlayerState(Position position, int landminesHit)
    {
        GetPosition = position;
        GetLandminesHit = landminesHit;
    }
    
    public Position GetPosition { get; }

    public int GetLandminesHit { get; }
}