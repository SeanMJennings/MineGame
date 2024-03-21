namespace Game;

using Application;
using Domain.Entities;
using Domain.Entities.Board;
using Domain.Primitives;
using Infrastructure;
using UI;

public static class Services
{
    private static GameConsole? gameConsole;
    private static GameController? gameController;
    private static IGameEngine? gameEngine;
    private static Board? board;
    private static readonly BoardDimensions BoardSize = new(8, 8);
    private static readonly Position Position = new (0, 0);
    
    public static GameConsole GetGameConsole()
    {
        return gameConsole ??= new GameConsole(GetGameController());
    }    
    
    private static GameController GetGameController()
    {
        return gameController ??= new GameController(GetGameEngine());
    }

    private static IGameEngine GetGameEngine()
    {
        return gameEngine ??= new GameEngine(GetBoard());
    }

    private static Board GetBoard()
    {
        return board ??= new Board(BoardSize, new MineCreator(), new Player(Position));
    }
}