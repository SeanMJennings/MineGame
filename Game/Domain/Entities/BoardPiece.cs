namespace Game.Domain.Entities;

using Primitives;

public abstract class BoardPiece(Position position)
{
    public Position Position { get; protected set; } = position;

    public bool InSamePosition(BoardPiece boardPiece)
    {
        return Position.Equals(boardPiece.Position);
    }
}