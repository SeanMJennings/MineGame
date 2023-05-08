using MineGame.Board;
using MineGame.Domain;
using MineGame.Game;
using MineGame.Player;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Unit;

[TestFixture]
public class GameShould
{
   private IGame game;
   private IBoard board;

   [SetUp]
   public void Before()
   {
      board = Substitute.For<IBoard>();
   }

   [Test]
   public void NotifyPlayerMovedUp()
   {
      Position playerPosition = default;
      board.GetPlayerPosition().Returns(new Position(0,1));
      game = new Game(board);
      game.PlayerMoved += (_, position) =>
      {
         playerPosition = position;
      };
      
      game.MoveUp();
      
      Assert.AreEqual(0, playerPosition.GetRow());
      Assert.AreEqual(1, playerPosition.GetColumn());
   }
   
   [Test]
   public void NotifyPlayerMovedRight()
   {
      Position playerPosition = default;
      board.GetPlayerPosition().Returns(new Position(1,0));
      game = new Game(board);
      game.PlayerMoved += (sender, position) =>
      {
         playerPosition = position;
      };
      
      game.MoveRight();
      
      Assert.AreEqual(1, playerPosition.GetRow());
      Assert.AreEqual(0, playerPosition.GetColumn());
   }
}