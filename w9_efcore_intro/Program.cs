using w9_efcore_intro.Data;
using w9_efcore_intro.Services;

namespace W09;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new GameContext();
        var game = new GameEngine(context);

        game.Run();

    }
}