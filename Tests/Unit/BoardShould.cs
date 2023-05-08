using MineGame.Domain;
using MineGame.Player;
using NSubstitute;
using NSubstitute.ClearExtensions;
using NUnit.Framework.Constraints;

namespace Tests.Unit
{
    using MineGame.Board;
    using NUnit.Framework;

    [TestFixture]
    public class BoardShould
    {
        private IBoard board;
        private IPopulateBoard populateBoard;
        private BoardSize boardSize;

        [SetUp]
        public void Before()
        {
            populateBoard = Substitute.For<IPopulateBoard>();
            populateBoard.PopulateLandmines(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
                .Returns(new List<Landmine>());
            boardSize = new BoardSize(4, 4);
            board = new Board(new Player(new Position(1, 1)), populateBoard, boardSize);
        }

        [TestCase(Move.Up, 2, 1)]
        [TestCase(Move.Right, 1, 2)]
        [TestCase(Move.Left, 1, 0)]
        [TestCase(Move.Down, 0, 1)]
        public void MovePlayer(Move move, int row, int column)
        {
            MovePlayer(move);
            var position = board.GetPlayerPosition();
            Assert.AreEqual(row, position.GetRow());
            Assert.AreEqual(column, position.GetColumn());
        }

        [Test]
        public void LetPlayerHitLandmine()
        {
            SetupAllLandmineBoard();
            MovePlayer(Move.Up);
            Assert.AreEqual(1, board.GetLandminesHit());
        }

        private void MovePlayer(Move move)
        {
            switch(move)
            {
                case Move.Up:
                    board.MovePlayerUp();
                    break;                
                case Move.Down:
                    board.MovePlayerDown();
                    break;                
                case Move.Left:
                    board.MovePlayerLeft();
                    break;                
                case Move.Right:
                    board.MovePlayerRight();
                    break;
                default:
                    throw new NotImplementedException();
            };
        }

        private void SetupAllLandmineBoard()
        {
            var landmines = new PopulateBoard().PopulateLandmines(
                boardSize.GetWidth(), boardSize.GetLength(),
                boardSize.GetWidth() * boardSize.GetLength());
            populateBoard.ClearSubstitute();
            populateBoard.PopulateLandmines(boardSize.GetWidth(), boardSize.GetLength(), 2).Returns(landmines);
            board = new Board(new Player(new Position(1, 1)), populateBoard, boardSize);
        }
        
        public enum Move
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}