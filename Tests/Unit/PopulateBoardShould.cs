using MineGame.Domain;

namespace Tests.Unit;
using NUnit.Framework;
using MineGame.Board;

[TestFixture]
public class PopulateBoardShould
{
    private IPopulateBoard _populateBoard;

    [SetUp]
    public void Before()
    {
        _populateBoard = new PopulateBoard();
    }
    
    [Test]
    public void PopulateLandmines()
    {
        var landmines = _populateBoard.PopulateLandmines(2, 2, 4);
        Assert.IsNotNull(landmines.Find(l => l.GetPosition().Equals(new Position(0,0))));
        Assert.IsNotNull(landmines.Find(l => l.GetPosition().Equals(new Position(0,1))));
        Assert.IsNotNull(landmines.Find(l => l.GetPosition().Equals(new Position(1,0))));
        Assert.IsNotNull(landmines.Find(l => l.GetPosition().Equals(new Position(1,1))));
        Assert.AreEqual(4, landmines.Count);
    }

    [Test]
    public void NotPopulateMoreLandminesThanBoardPositions()
    {
        TestDelegate action = () => _populateBoard.PopulateLandmines(1, 1, 2);
        var exception = Assert.Catch(action);
        Assert.AreEqual(exception!.Message, "Cannot create more landmines than board squares");
    }
}