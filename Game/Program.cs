namespace Game;

using Application;
using Domain;
using Domain.Board;
using Domain.Primitives;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using UI;

public static class Program
{
    public static void Main()
    {
        var serviceProvider = SetupServiceProvider();
        var gameConsole = serviceProvider.GetService<IGameConsole>();
        gameConsole!.Play();
    }

    private static ServiceProvider SetupServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<IGameConsole, GameConsole>();
        serviceCollection.AddScoped<IGameController, GameController>();
        serviceCollection.AddScoped<IGameEngine, GameEngine>();
        serviceCollection.AddScoped<IMineCreator, MineCreator>();
        serviceCollection.AddScoped<Board, Board>();
        serviceCollection.AddScoped<BoardDimensions, BoardDimensions>(_ => new BoardDimensions(8, 8));
        serviceCollection.AddScoped<Player, Player>(_ => new Player(new Position(0,0)));
        return serviceCollection.BuildServiceProvider();
    }
}