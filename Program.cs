using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsuncOnCore
{
    class Program
    { 
        static async Task Main()
        {
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;
            User user = new User();
            Game game = new Game(5);
            //game.GeneratorCount = 1;
            user.Scores = 1;
            user.Scores = await game.Play();
            
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("End game Scores: " + user.Scores);
            Console.ReadKey();
        }
    }
}