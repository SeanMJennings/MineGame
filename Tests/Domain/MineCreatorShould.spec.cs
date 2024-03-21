namespace Tests.Domain;

using NUnit.Framework;
using Test;

[TestFixture]
public partial class MineCreatorShould
{
    [Test]
    public void CreateThreeOrMoreMines()
    {
        Specification.Given(the_mine_creator);
        Specification.When(the_mines_are_created);
        Specification.Then(there_are_at_least_three_mines);
    }

    [Test]
    public void NotCreateTwoMinesInTheSamePosition()
    {
        Specification.Given(the_mine_creator);
        Specification.When(the_mines_are_created);
        Specification.Then(no_mines_share_the_same_position);
    }
}