using MineGame.Domain;

namespace MineGame.Board;

public interface IPopulateBoard
{
    public List<Landmine> PopulateLandmines(int row, int columns, int numberOfLandmines);
}