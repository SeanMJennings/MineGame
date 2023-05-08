using MineGame.Domain;

namespace MineGame.Board;
using MineGame.Player;
public class Board : IBoard
{
    private Player player;
    private readonly IPopulateBoard populateBoard;
    private List<Landmine> landmines;
    private BoardSize boardSize;

    public Board(Player player, IPopulateBoard populateBoard, BoardSize boardSize)
    {
        this.player = player;
        this.populateBoard = populateBoard;
        this.boardSize = boardSize;
        landmines = this.populateBoard.PopulateLandmines(boardSize.GetWidth(), boardSize.GetLength(), 2);
    }

    public void MovePlayerUp()
    {
        player.MovePlayerVertically(1);
        CalculateLandmineHits();
    }

    public void MovePlayerRight()
    {
        player.MovePlayerHorizontally(1);
        CalculateLandmineHits();
    }

    public void MovePlayerLeft()
    {
        player.MovePlayerHorizontally(-1);
        CalculateLandmineHits();
    }

    public void MovePlayerDown()
    {
        player.MovePlayerVertically(-1);
        CalculateLandmineHits();
    }

    public Position GetPlayerPosition()
    {
        return player.GetPosition();
    }

    public int GetLandminesHit()
    {
        return player.GetHits();
    }

    private void CalculateLandmineHits()
    {
        if (landmines.Any(landmine => player.GetPosition().Equals(landmine.GetPosition())))
        {
            player.PlayerHit();
        }
    }
}