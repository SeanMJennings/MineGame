namespace Game.Domain.Primitives;

public readonly struct Position : IEquatable<Position>
{
    private readonly int _rowPosition;
    private readonly int _columnPosition;

    public Position(int rowPosition, int columnPosition)
    {
        _rowPosition = rowPosition;
        _columnPosition = columnPosition;
    }

    public int GetRow()
    {
        return _rowPosition;
    }

    public int GetColumn()
    {
        return _columnPosition;
    }

    # region equality
    public bool Equals(Position other)
    {
        return _rowPosition == other._rowPosition && _columnPosition == other._columnPosition;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_rowPosition, _columnPosition);
    }
    #endregion
}