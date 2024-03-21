namespace Tests.Domain;

using Game.Domain.Entities;
using Game.Domain.Entities.Board;
using NUnit.Framework;
using Test;

[TestFixture]
public partial class MineCreatorShould : Specification
{
    private IAmAMineCreator amAMineCreator = null!;
    private IEnumerable<Landmine> landmines = null!;
    private BoardDimensions boardDimensions = null!;

    [SetUp]
    public void Before()
    {
        landmines = null!;
        boardDimensions = new BoardDimensions(4, 4);
    }
    
    private void the_mines_are_created()
    {
        landmines = amAMineCreator.CreateMines(boardDimensions).ToList();
    }

    private void the_mine_creator()
    {
        amAMineCreator = new MineCreator();
    }

    private void there_are_at_least_three_mines()
    {
        Assert.IsTrue(landmines.Count() >= 3);
    }

    private void no_mines_share_the_same_position()
    {
        Assert.IsTrue(landmines.Distinct().Count() == landmines.Count());
    }
}