namespace Game;

using Application;
using Domain;
using Domain.Board;
using Domain.Primitives;
using Infrastructure;
using UI;

public static class Services
{
    private static IGameConsole? gameConsole;
    private static GameController? gameController;
    private static IGameEngine? gameEngine;
    private static Board? board;
    private static readonly BoardDimensions BoardSize = new(8, 8);
    private static readonly Position Position = new (0, 0);
    
    public static IGameConsole GetGameConsole()
    {
        return gameConsole ??= new GameConsole(GetGameController());
    }    
    
    private static GameController GetGameController()
    {
        return gameController ??= new GameController(GetGameEngine());
    }

    private static IGameEngine GetGameEngine()
    {
        return gameEngine ??= new GameEngine(GetBoard(), new Player(Position));
    }

    private static Board GetBoard()
    {
        return board ??= new Board(BoardSize, new MineCreator());
    }
}