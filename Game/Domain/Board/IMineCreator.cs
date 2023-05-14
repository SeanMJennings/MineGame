namespace Game.Domain.Board;

public interface IMineCreator
{
    IEnumerable<Landmine> CreateMines(BoardDimensions boardDimensions);
}

