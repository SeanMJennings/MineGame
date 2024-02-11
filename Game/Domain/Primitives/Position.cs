namespace Game.Domain.Primitives;

public readonly record struct Position
{
    private readonly int rowPosition;
    private readonly int columnPosition;

    public Position(int rowPosition, int columnPosition)
    {
        this.rowPosition = rowPosition;
        this.columnPosition = columnPosition;
    }

    public int GetRow()
    {
        return rowPosition;
    }

    public int GetColumn()
    {
        return columnPosition;
    }
}