namespace MineGame.Domain;

public class Player
{
    private Position _position;
    private int _hits;
    
    public Player(Position position)
    {
        _position = position;
        _hits = 0;
    }

    public Position GetPosition()
    {
        return _position;
    }

    public int GetHits()
    {
        return _hits;
    }

    public void MovePlayerVertically(int move)
    {
        _position = new Position(_position.GetRow() + move, _position.GetColumn());
    }
    
    public void MovePlayerHorizontally(int move)
    {
        _position = new Position(_position.GetRow(), _position.GetColumn() + move);
    }

    public void PlayerHit()
    {
        _hits++;
    }
}