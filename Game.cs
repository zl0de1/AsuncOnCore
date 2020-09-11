﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AsuncOnCore
{
    class Game
    {
        private static int[] w = new int[] { 63, 65, 66, 67, 67, 67, 66, 65, 63, 61, 59, 58, 57, 57, 57, 58, 59, 61 };
        private static int[] h = new int[] { 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8 };
        private int generatorCount;
        public static bool Terminate = false;

        public User user { get; set; }

        public Game() { }

        public Game(int generatorCount) 
        {
            this.generatorCount = generatorCount; 
        }

        public async Task Play()
        {
            Random rnd = new Random();
            UI ui = new UI();
            User user = new User();
            
            while (GeneratorCount > 0)
            {
                user.Progress = 0;
                ui.Draw("ProgressBar");
                ui.CheckBar(GeneratorCount, user.Progress);
                while (!Terminate)
                {
                    CheckKeyAsunc(); //??
                    int rnd_point = rnd.Next(4, (w.GetLength(0) - 1));
                    user.Progress = await GameLogicAsunc(w, h, rnd_point, user.Progress);
                    ui.Draw("ProgressBar");
                    ui.CheckBar(GeneratorCount, user.Progress);

                    if (user.Progress >= 100)
                    {
                        Terminate = true;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Генератор починен");
                        GeneratorCount--;
                        ui.CheckBar(GeneratorCount, user.Progress);
                        await Task.Delay(20);
                        Console.Beep();
                        await Task.Delay(20);
                        Console.Beep();
                        await Task.Delay(1800);
                        Terminate = false;
                        break;
                    }
                    else if (user.Progress < 100)
                    {
                        await Task.Delay(700);
                        Terminate = false;
                    }
                }
            }
        }

        public int GeneratorCount
        {
            get { return generatorCount; }
            set
            {
                if (value < 0) { generatorCount = 0; }
                else if (value > 5) { generatorCount = 5; }
                else { generatorCount = value; }
            }
        }

        static async Task<int> GameLogicAsunc(int[] w, int[] h, int rnd_point, int progress)
        {
            int progress_ = await Task.Run(() => GameLogic(w, h, rnd_point, progress));
            return progress_;
        }
        static async Task CheckKeyAsunc()
        {
            await Task.Run(() => CheckKey());
        }

        static async Task<int> GameLogic(int[] w, int[] h, int rnd_point, int progress)
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
            while (!Terminate)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    //Console.WriteLine("CheckKey");
                    Terminate = true;
                }
            }
        }
    }
}
