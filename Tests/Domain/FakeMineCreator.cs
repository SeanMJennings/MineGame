namespace Tests.Domain;

using Game.Domain.Entities;
using Game.Domain.Entities.Board;
using Game.Domain.Primitives;

public class FakeAmAMineCreator : IAmAMineCreator
{
    public IEnumerable<Landmine> CreateMines(BoardDimensions boardDimensions)
    {
        var landmines = new List<Landmine>();
        for (var row = 0; row < boardDimensions.BoardWidth; row++)
        {
            for (var column = 0; column < boardDimensions.BoardLength; column++)
            {
                if (row == 0 && column == 0)
                    continue;
                landmines.Add(new Landmine(new Position(row, column)));
            }
        }

        return landmines;
    }
}