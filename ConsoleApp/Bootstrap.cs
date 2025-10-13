using ConsoleApp.Classes;

namespace ConsoleApp
{
    internal class Bootstrap
    {
        static void Main(string[] args)
        {
            GameCycle gameCycle = new();
            gameCycle.StartGame();
        }
    }
}
