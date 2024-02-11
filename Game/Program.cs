namespace Game;

public static class Program
{
    public static void Main()
    {
        var gameConsole = Services.GetGameConsole();
        gameConsole.Play();
    }
}