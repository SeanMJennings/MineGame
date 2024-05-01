namespace Game.Domain.Entities;

using Primitives;

public abstract class BoardPiece(Position position)
{
    public Position Position { get; protected set; } = position;

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != GetType())
            return false;

        var otherBoardPiece = obj as BoardPiece;

        return InSamePosition(otherBoardPiece);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = (int) 2166136261;
            hash = (hash * 16777619) ^ Position.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(BoardPiece @this, BoardPiece that)
    {
        return Equals(@this, that);
    }

    public static bool operator !=(BoardPiece @this, BoardPiece that)
    {
        return !Equals(@this, that);
    }
    
    public bool InSamePosition(BoardPiece boardPiece)
    {
        return Position.Equals(boardPiece.Position);
    }
}