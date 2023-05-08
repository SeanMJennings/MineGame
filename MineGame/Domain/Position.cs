namespace MineGame.Domain;

public readonly struct Position : IEquatable<Position>
{
    private readonly int _row;
    private readonly int _column;

    public Position(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public int GetRow()
    {
        return _row;
    }

    public int GetColumn()
    {
        return _column;
    }

    public bool Equals(Position other)
    {
        return _row == other._row && _column == other._column;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_row, _column);
    }
}