namespace MineGame.Domain;

public class Landmine
{
    private Position _position;
    private bool _detonated;
    
    public Landmine(Position position)
    {
        _position = position;
        _detonated = false;
    }

    public Position GetPosition()
    {
        return _position;
    }

    public bool IsDetonated()
    {
        return _detonated;
    }
}