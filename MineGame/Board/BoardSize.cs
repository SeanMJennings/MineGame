namespace MineGame.Board;

public readonly struct BoardSize
{
    private readonly int boardWidth;
    private readonly int boardLength;

    public BoardSize(int width, int length)
    {
        boardWidth = width;
        boardLength = length;
    }

    public int GetWidth()
    {
        return boardWidth;
    }

    public int GetLength()
    {
        return boardLength;
    }
}