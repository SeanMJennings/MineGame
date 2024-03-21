namespace Game.Domain.Entities.Board;

using Dtos;
using Entities;
using Enums;

public class Board(BoardDimensions boardDimensions, IAmAMineCreator mineCreator, Player player)
{
    private readonly List<Landmine> landmines = mineCreator.CreateMines(boardDimensions).ToList();

    public void MovePlayer(Direction direction)
    {
        if (MoveIsValid(direction))
        {
            player.Move(direction);
            DetonateLandmine();
        }
    }

    public bool IsPlayerAtTopOfBoard()
    {
        return boardDimensions.BoardLength == player.Position.GetRow() + 1;
    }
    
    public PlayerState GetPlayerState()
    {
        return new PlayerState(player.Position, player.GetLandminesHit());
    }
    
    private void DetonateLandmine()
    {
        var landmine = landmines.Find(l => l.InSamePosition(player) && !l.IsExploded());
        if (landmine is not null)
        {
            player.HitLandmine(landmine);
        }
    }

    private bool MoveIsValid(Direction direction)
    {
        return direction switch
        {
            Direction.Up => player.Position.GetRow() + 1 < boardDimensions.BoardLength,
            Direction.Right => player.Position.GetColumn() + 1 < boardDimensions.BoardWidth,
            Direction.Left => player.Position.GetColumn() - 1 >= 0,
            Direction.Down => player.Position.GetRow() - 1 >= 0,
            _ => false
        };
    }
}