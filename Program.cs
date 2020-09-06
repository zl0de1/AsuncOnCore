using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsuncOnCore
{
    class Program
    {
        public static bool Terminate = false;

        static async Task Main()
        {
            int[] w = new int[] { 63, 65, 66, 67, 67, 67, 66, 65, 63, 61, 59, 58, 57, 57, 57, 58, 59, 61 };
            int[] h = new int[] { 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8 };
            Game game = new Game();
            UI ui = new UI();
            Random rnd = new Random();
            
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;

            game.Progress = 0;
            game.GeneratorCount = 5;

            while (game.GeneratorCount > 0)
            {
                game.Progress = 0;
                ui.Draw("ProgressBar");
                CheckBar(game.GeneratorCount, game.Progress);
                while (!Terminate)
                {
                    int rnd_point = rnd.Next(4, (w.GetLength(0) - 1));
                    CheckKeyAsunc();
                    game.Progress = await GameAsunc(w, h, rnd_point, game.Progress);

                    ui.Draw("ProgressBar");
                    CheckBar(game.GeneratorCount, game.Progress);

                    if (game.Progress >= 100)
                    {
                        Terminate = true;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Генератор починен");
                        game.GeneratorCount--;
                        CheckBar(game.GeneratorCount, game.Progress);
                        await Task.Delay(30);
                        Console.Beep();
                        await Task.Delay(30);
                        Console.Beep();
                        await Task.Delay(1800);
                        Terminate = false;
                        break;
                    }
                    else if (game.Progress < 100)
                    {
                        await Task.Delay(700);
                        Terminate = false;
                    }
                }  
            }
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("End game");
            Console.ReadKey();
        }
        static async Task<int> GameAsunc(int[] w, int[] h, int rnd_point, int progress)
        {
            int progress_ = await Task.Run(() => Game(w, h, rnd_point, progress));
            return progress_;
        }
        static async Task CheckKeyAsunc()
        {
            await Task.Run(() => CheckKey());
        }

        static async Task<int> Game(int[] w, int[] h, int rnd_point, int progress)
        {
            UI ui = new UI();
            for (int i = 0; i < w.GetLength(0); i++)
            {
                //Console.Clear();
                for (int a = 0; a < w.GetLength(0); a++) 
                {
                    Console.SetCursorPosition(w[a], h[a]);
                    Console.Write(".");
                }
                Console.SetCursorPosition(w[rnd_point], h[rnd_point]);
                Console.Write("o");
                Console.SetCursorPosition(60, 11);
                Console.Write("SPACE");
                if (!Terminate)
                {
                    Console.SetCursorPosition(w[i], h[i]);
                    Console.Write("x");
                    await Task.Delay(100);
                }
                else
                {
                    if ((--i) == rnd_point)
                    {
                        progress += 10;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("ПОПАЛ");
                        ui.Draw("100");
                        Console.Beep();
                        return progress;
                        //break;
                    }
                    else
                    {
                        progress -= 25;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("МИМО ");
                        return progress;
                        //break;
                    }
                }
            }
            progress -= 25;
            Console.WriteLine("Бум генератора");
            return progress;
        }

        static void CheckKey()
        {
            while(!Terminate)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    //Console.WriteLine("CheckKey");
                    Terminate = true;
                }
            } 
        }
        static void CheckBar(int generatorCount, int progress)
        {
            UI ui = new UI();
            Console.SetCursorPosition(70, 16);
            Console.Write(progress + "%  ");
            for (int c = 0; (c < progress / 5); c++)
            {       
                if ((progress / 5) <= 20)
                {
                    Console.SetCursorPosition((52 + c), 18);
                    Console.Write("■");
                }
            }
            Console.SetCursorPosition(10, 23);
            Console.Write("Генераторов починить: " + generatorCount + "\n  -------------------------------");
            ui.Draw("UserIcon");
        }
    }
}