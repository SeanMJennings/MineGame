using MineGame.Domain;

namespace MineGame.Board;
public class PopulateBoard : IPopulateBoard
{
    private Random randomNumberGenerator;
    public PopulateBoard()
    {
        randomNumberGenerator = new Random();
    }

    public List<Landmine> PopulateLandmines(int rows, int columns, int numberOfLandmines)
    {
        if (rows * columns < numberOfLandmines)
        {
            throw new ArgumentException("Cannot create more landmines than board squares");
        }
        
        List<Landmine> landmines = new List<Landmine>();
        while (landmines.Count < numberOfLandmines)
        {
            Position position = new Position(randomNumberGenerator.Next(rows), randomNumberGenerator.Next(columns));
            if (landmines.Find(l => l.GetPosition().Equals(position)) != null)
                continue;
            landmines.Add(new Landmine(position));
        }

        return landmines;
    }
}