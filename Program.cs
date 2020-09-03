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
            //Console.CursorVisible = false;           
            CheckKeyAsunc();
   
            while (!Terminate & progress < 100)
            {
                rnd_point = rnd.Next(2, w.GetLength(0));
                await GameAsunc(w, h);
                await Task.Delay(1000);           
                if(progress >= 100)
                {
                    Console.WriteLine("Генератор починен");
                    Terminate = true;
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

        static async Task Game(int[] w, int[] h)
        {
            for (int i = 0; i < w.GetLength(0); i++)
            {
                if (!Terminate)
                {
                    Console.WriteLine("{0}: {1},{2}  Rnd p:{3}: {4},{5}", i, w[i], h[i], rnd_point, w[rnd_point], h[rnd_point]);
                    await Task.Delay(500);
                }
                else
                {
                    if ((--i) == rnd_point)
                    {
                        Console.WriteLine("{0}={1}? win", i, rnd_point);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0}={1}? loose", i, rnd_point);
                        break;
                    }
                }
            }
            //Terminate = true;
        }
        static async Task CheckKey()
        {
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("CheckKey");
                    Terminate = true;
                }
            } while (true);
        }
        static bool WinOrLoos(int i)
        {
            if(i == rnd_point)
            {
                return true;
            }
            else { return false; }
        }
    }
}