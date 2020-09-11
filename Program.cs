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
            Game game = new Game();
            game.GeneratorCount = 5;

            await game.Play();
            
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("End game");
            Console.ReadKey();
        }
    }
}