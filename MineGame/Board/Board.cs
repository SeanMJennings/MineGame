using MineGame.Domain;

namespace MineGame.Board;

public class Board : IBoard
{
    private Player player;
    private readonly IPopulateBoard populateBoard;
    private List<Landmine> landmines;

    public Board(Player player, IPopulateBoard populateBoard, BoardSize boardSize)
    {
        this.player = player;
        this.populateBoard = populateBoard;
        landmines = this.populateBoard.PopulateLandmines(boardSize.GetWidth(), boardSize.GetLength(), 2);
    }

    public void MovePlayerUp()
    {
        player.MovePlayerVertically(1);
        CheckLandmineHits();
    }

    public void MovePlayerRight()
    {
        player.MovePlayerHorizontally(1);
        CheckLandmineHits();
    }

    public void MovePlayerLeft()
    {
        player.MovePlayerHorizontally(-1);
        CheckLandmineHits();
    }

    public void MovePlayerDown()
    {
        player.MovePlayerVertically(-1);
        CheckLandmineHits();
    }

    public Position GetPlayerPosition()
    {
        return player.GetPosition();
    }

    public int GetLandminesHit()
    {
        return player.GetHits();
    }

    private void CheckLandmineHits()
    {
        foreach (var landmine in landmines)
        {
            if (player.GetPosition().Equals(landmine.GetPosition()) && landmine.IsNotDetonated())
            {
                player.PlayerHit();
                landmine.Detonate();
                break;
            }
        }
    }
}