namespace Game.UI;

using Domain.Primitives;
using Infrastructure;
using System;
using Application;
using Domain.Dto;
using Domain.Enums;

public class GameConsole : IGameConsole
{
    private readonly IGameController gameController;
    private GameState _gameState;

    public GameConsole(IGameController gameController)
    {
        this.gameController = gameController;
        ListenToGame();
    }

    public void Play()
    {
        while (_gameState == GameState.InPlay)
        {
            PlayPrompt();
        }
    }

    private void PlayPrompt()
    {
        Console.WriteLine("Press: U,L,R,D");
        Direction? input = null;
        do
        {
            input = ConvertToDirection(Console.ReadLine()[0]);
        } while (input is null);
        
        gameController.Move(input.Value);
    }

    private void ListenToGame()
    {
        gameController.GameState += OnGameState;
        gameController.PlayerState += OnPlayerState;
    }

    private void OnGameState(object? sender, GameState gameState)
    {
        _gameState = gameState;
        if (gameState != GameState.InPlay)
        {
            Console.WriteLine($"Game result: {gameState}");
        }
    }

    private void OnPlayerState(object? sender, PlayerState playerState)
    {
        Console.WriteLine($"Mines hit: {playerState.GetLandminesHit()}");
        Console.WriteLine($"Player position: row {playerState.GetPosition().GetRow()}, column {playerState.GetPosition().GetColumn()}");
    }
    
    private static Direction? ConvertToDirection(char? input)
    {
        if (input != null)
            return char.ToLower(input.Value) switch
            {
                'u' => Direction.Up,
                'r' => Direction.Right,
                'l' => Direction.Left,
                'd' => Direction.Down,
                _ => null
            };
        return null;
    }
}