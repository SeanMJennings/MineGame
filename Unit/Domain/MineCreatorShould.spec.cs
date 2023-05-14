namespace Unit.Domain;

using NUnit.Framework;

[TestFixture]
public partial class MineCreatorShould
{
    [Test]
    public void CreateThreeOrMoreMines()
    {
        Given(the_mine_creator);
        When(the_mines_are_created);
        Then(there_are_at_least_three_mines);
    }

    [Test]
    public void NotCreateTwoMinesInTheSamePosition()
    {
        Given(the_mine_creator);
        When(the_mines_are_created);
        Then(no_mines_share_the_same_position);
    }
}