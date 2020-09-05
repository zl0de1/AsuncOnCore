using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsuncOnCore
{
    class Program
    {
        public static bool Terminate = false;
        public static int rnd_point = 0;
        //public static int progress = 0;
        static async Task Main()
        {
            int[] w = new int[] { 63, 65, 66, 67, 67, 67, 66, 65, 63, 61, 59, 58, 57, 57, 57, 58, 59, 61 };
            int[] h = new int[] { 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8 };
            Game game = new Game();
            game.Progress = 0;
            Random rnd = new Random();
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;           
            CheckKeyAsunc();
            
            //сделать так чтоб изменение прогрес гейм было только тут, через возвращение?
            while (!Terminate)
            {
                rnd_point = rnd.Next(4, (w.GetLength(0)-1));
                game.Progress += await GameAsunc(w, h, game.Progress);
                          
                if(game.Progress >= 100)
                {
                    Terminate = true;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Генератор починен");
                    CheckBar(game.Progress);
                    break;
                }
                else if (game.Progress < 100)
                {
                    //тут чекпрогрес бар
                    await Task.Delay(1000);
                    Terminate = false;
                }
            }
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("End game");
            Console.ReadKey();
        }
        static async Task<int> GameAsunc(int[] w, int[] h, int progress)
        {
            int progress_ = await Task.Run(() => Game(w, h, progress));
            return progress_;
        }
        static async Task CheckKeyAsunc()
        {
            await Task.Run(() => CheckKey());
        }
        static async Task ProgressLineAsunc(int progress)
        {
            await Task.Run(() => ProgressLine(progress));
        }

        static async Task<int> Game(int[] w, int[] h, int progress)
        {
            UI ui = new UI();
            Game game = new Game();
            for (int i = 0; i < w.GetLength(0); i++)
            {
                Console.Clear();
                for (int a = 0; a < w.GetLength(0); a++) 
                {
                    Console.SetCursorPosition(w[a], h[a]);
                    Console.Write(".");
                }
                Console.SetCursorPosition(w[rnd_point], h[rnd_point]);
                Console.Write("o");
                Console.SetCursorPosition(60, 11);
                Console.Write("SPACE");

                Console.SetCursorPosition(0, 0);
                Console.Write("Progress: {0}", progress);
                ui.Draw("ProgressBar");
                CheckBar(progress);
                //ProgressLineAsunc();

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
                        game.Progress += 25;
                        //if (progress > 100) { progress = 100; }
                        Console.SetCursorPosition(60, 11);
                        Console.Write("     ");
                        Console.SetCursorPosition(60, 11);
                        Console.Write("ПОПАЛ");
                        ui.Draw("100");
                        CheckBar(progress+25);
                        Console.Beep();
                        return game.Progress;
                        //break;
                    }
                    else
                    {
                        game.Progress -= 25;
                        //if (progress<0) { progress = 0; }
                        Console.SetCursorPosition(60, 11);
                        Console.Write("     ");
                        Console.SetCursorPosition(61, 11);
                        Console.Write("МИМО");
                        CheckBar(progress-25);
                        return game.Progress;
                        //break;
                    }
                }
            }
            if (!Terminate)
            {
                game.Progress -= 25;
                //if (progress < 0) { progress = 0; }
                Console.WriteLine("Бум генератора");
                CheckBar(game.Progress-25);
                return game.Progress;
            }
            return game.Progress;
        }

        static void CheckKey()
        {
            while(true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    //Console.WriteLine("CheckKey");
                    Terminate = true;
                }
            } 
        }
        static void CheckBar(int progress)
        {
            for (int c = 0; (c < progress / 5); c++)
            {       
                if ((progress / 5) <= 20)
                {
                    Console.SetCursorPosition((52 + c), 18);
                    Console.Write("■");
                }
            }
        }
        static async Task ProgressLine(int progress)
        {
            UI ui = new UI();
            do
            {
                await Task.Delay(200);
                
            } while (progress < 100);
        }
    }
}