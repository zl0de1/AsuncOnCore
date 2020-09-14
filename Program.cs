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
            UI ui = new UI();
            User user = new User();



            Console.ReadKey();
            Game game = new Game(5, 25);
            user.Scores = 0;
            user.Scores = await game.Play();
            
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("End game Scores: " + user.Scores);
            Console.ReadKey();
        }
    }
}