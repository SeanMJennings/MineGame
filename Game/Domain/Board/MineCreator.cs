namespace Game.Domain.Board;

using Primitives;

public class MineCreator : IMineCreator
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
                if (ShouldCreateLandmine(boardDimensions) && !LandmineAlreadyExists(new Position(row, column), landmines)) 
                    landmines.Add(new Landmine(new Position(row, column)));
            }
        }
    }

    private bool ShouldCreateLandmine(BoardDimensions boardDimensions)
    {
        var uniquePositions = boardDimensions.BoardLength * boardDimensions.BoardWidth;
        return random.Next(uniquePositions) % 5 == 0;
    }

    private static bool LandmineAlreadyExists(Position landMinePosition, IEnumerable<Landmine> landmines)
    {
        return landmines.Any(l => l.GetPosition().Equals(landMinePosition));
    }
}