namespace Unit.Domain;

using Game.Domain;
using Game.Domain.Board;
using Game.Domain.Primitives;

public class FakeMineCreator : IMineCreator
{
    public IEnumerable<Landmine> CreateMines(BoardDimensions boardDimensions)
    {
        var landmines = new List<Landmine>();
        for (int row = 0; row < boardDimensions.BoardWidth; row++)
        {
            for (int column = 0; column < boardDimensions.BoardLength; column++)
            {
                if (row == 0 && column == 0)
                    continue;
                landmines.Add(new Landmine(new Position(row, column)));
            }
        }

        return landmines;
    }
}