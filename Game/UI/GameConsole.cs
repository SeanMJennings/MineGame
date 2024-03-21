namespace Game.UI;

using Domain.Primitives;
using Infrastructure;
using System;
using Application;
using Domain.Dtos;
using Domain.Enums;

public class GameConsole
{
    private readonly GameController gameController;
    private GameState _gameState;

    public GameConsole(GameController gameController)
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
        Direction? input;
        do
        {
            var consoleValue = Console.ReadLine();
            input = ConvertToDirection(consoleValue!.Length > 0 ? consoleValue[0] : null);
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

    private static void OnPlayerState(object? sender, PlayerState playerState)
    {
        Console.WriteLine($"Mines hit: {playerState.LandminesHit}");
        Console.WriteLine($"Player position: row {playerState.Position.GetRow()}, column {playerState.Position.GetColumn()}");
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