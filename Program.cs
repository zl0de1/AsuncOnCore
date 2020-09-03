using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsuncOnCore
{
    class Program
    {
        public static bool Terminate = false;
        public static int rnd_point = 0;
        public static int progress = 0;
        static async Task Main()
        {
            int[] w = new int[] { 63, 65, 66, 67, 67, 67, 66, 65, 63, 61, 59, 58, 57, 57, 57, 58, 59, 61 };
            int[] h = new int[] { 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8 };
            Random rnd = new Random();
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;           
            CheckKeyAsunc();
            

            while (!Terminate & progress < 100)
            {
                rnd_point = rnd.Next(4, (w.GetLength(0)-1));
                
                await GameAsunc(w, h);
                await Task.Delay(1500);           
                if(progress >= 100)
                {
                    Console.WriteLine("Генератор починен");
                    Terminate = true;
                    break;
                }
                else if (progress < 100)
                {
                    Terminate = false;
                }
            }
            Console.WriteLine("End game");
            Console.ReadKey();
        }
        static async Task GameAsunc(int[] w, int[] h)
        {
            await Task.Run(() => Game(w, h));
        }
        static async Task CheckKeyAsunc()
        {
            await Task.Run(() => CheckKey());
        }
        static async Task ProgressLineAsunc()
        {
            await Task.Run(() => ProgressLine());
        }

        static async Task Game(int[] w, int[] h)
        {
            UI ui = new UI();
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
                for (int c = 0; c < (progress/5); c++)
                {
                    Console.SetCursorPosition((52+c), 18);
                    Console.Write("■");
                }
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
                        progress += 50;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("     ");
                        Console.SetCursorPosition(60, 11);
                        Console.Write("ПОПАЛ");
                        ui.Draw("100");
                        break;
                    }
                    else
                    {
                        progress -= 25;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("     ");
                        Console.SetCursorPosition(61, 11);
                        Console.Write("МИМО");
                        break;
                    }
                }
            }
            if (!Terminate)
            {
                progress -= 25;
                Console.WriteLine("Бум генератора");
            }
        }

        static void CheckKey()
        {
            while(progress < 100)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("CheckKey");
                    Terminate = true;
                }
            } 
        }
        static async Task ProgressLine()
        {
            UI ui = new UI();
            do
            {
                await Task.Delay(200);
                
            } while (progress < 100);
        }
    }
}