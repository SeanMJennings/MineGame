namespace Game.Domain.Entities.Board;

using Entities;
using Primitives;

public interface IAmAMineCreator
{
    IEnumerable<Landmine> CreateMines(BoardDimensions boardDimensions);
}

public class MineCreator : IAmAMineCreator
{
    private readonly Random random = new();

    public IEnumerable<Landmine> CreateMines(BoardDimensions boardDimensions)
    {
        var landmines = new List<Landmine>();
        while (landmines.Count < 3)
        {
            LandmineCreationLoop(landmines, boardDimensions);
        }

        return landmines;
    }

    private void LandmineCreationLoop(List<Landmine> landmines, BoardDimensions boardDimensions)
    {
        for (var row = 0; row < boardDimensions.BoardLength; row++)
        {
            for (var column = 0; column < boardDimensions.BoardWidth; column++)
            {
                var newLandmine = new Landmine(new Position(row, column));
                if (ShouldCreateLandmine(boardDimensions) && !LandmineAlreadyExists(newLandmine, landmines)) 
                    landmines.Add(newLandmine);
            }
        }
    }

    private bool ShouldCreateLandmine(BoardDimensions boardDimensions)
    {
        var uniquePositions = boardDimensions.BoardLength * boardDimensions.BoardWidth;
        return random.Next(uniquePositions) % 5 == 0;
    }

    private static bool LandmineAlreadyExists(Landmine landMine, IEnumerable<Landmine> landmines)
    {
        return landmines.Any(l => l.Equals(landMine));
    }
}