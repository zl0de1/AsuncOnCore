using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsuncOnCore
{
    class Game
    {
        private static int[] w = new int[] { 63, 65, 66, 67, 67, 67, 66, 65, 63, 61, 59, 58, 57, 57, 57, 58, 59, 61 };
        private static int[] h = new int[] { 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8 };
        private int generatorCount;
        private int scores;
        private int addProgress;
        public static bool Terminate = true;

        //public User user { get; set; }

        public Game() { }

        public Game(int generatorCount, int addProgress)
        {
            this.addProgress = addProgress;
            this.generatorCount = generatorCount; 
        }

        public async Task<int> Play()
        {
            Random rnd = new Random();
            UI ui = new UI();
            User user = new User();

            for (int i = 0; i < w.GetLength(0); i++)
            {
                Console.SetCursorPosition(w[i], h[i]);
                Console.Write(".");
                Wait(60);
            }
            Terminate = false;
            while (GeneratorCount > 0)
            {
                user.Progress = 0;
                ui.Draw("ProgressBar");
                ui.CheckBar(GeneratorCount, user.Progress, Scores);
                while (!Terminate)
                {
                    CheckKeyAsunc(); //??
                    int rnd_point = rnd.Next(4, (w.GetLength(0) - 1));
                    user.Progress = await GameLogicAsunc(rnd_point, user.Progress);
                    ui.Draw("ProgressBar");
                    ui.CheckBar(GeneratorCount, user.Progress, Scores);

                    if (user.Progress >= 100)
                    {
                        Terminate = true;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Генератор починен");
                        GeneratorCount--;
                        Scores += 1250;
                        ui.CheckBar(GeneratorCount, user.Progress, Scores);
                        Wait(1000);
                        ui.Draw("25");
                        Wait(20);
                        Console.Beep();
                        Wait(20);
                        Console.Beep();
                        Wait(1000);
                        Terminate = false;
                        break;
                    }
                    else if (user.Progress < 100)
                    {
                        Wait(700);
                        Terminate = false;
                    }
                }
            }
            return Scores;
        }

        public int Scores { get; set; }
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

        async Task<int> GameLogicAsunc(int rnd_point, int progress)
        {
            int progress_ = await Task.Run(() => GameLogic(rnd_point, progress));
            return progress_;
        }
        static async Task CheckKeyAsunc()
        {
            await Task.Run(() => CheckKey());
        }

        private async Task<int> GameLogic(int rnd_point, int progress)
        {
            UI ui = new UI();
            for (int i = 0; i < w.GetLength(0); i++)
            {
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
                        progress += addProgress;
                        Scores += 100;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("ПОПАЛ");
                        ui.Draw("100");
                        Console.Beep();
                        return progress;
                    }
                    else
                    {
                        progress -= 25;
                        Console.SetCursorPosition(60, 11);
                        Console.Write("МИМО ");
                        return progress;
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
        static void Wait(int sec)
        {
            Thread.Sleep(sec);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
