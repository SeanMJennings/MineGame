namespace Game.Domain.Dto;

using Primitives;

public class PlayerState
{
    private readonly Position position;
    private readonly int landminesHit;

    public PlayerState(Position position, int landminesHit)
    {
        this.position = position;
        this.landminesHit = landminesHit;
    }
    
    public Position GetPosition() => position;
    public int GetLandminesHit() => landminesHit;
}