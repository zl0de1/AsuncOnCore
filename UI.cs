﻿using System;
using System.Threading;

namespace AsuncOnCore
{
    class UI
    {
        //public Sprite sprite { get; set; }
        public UI() { }

        public void Draw(string SpriteName)
        {
            Console.SetCursorPosition(0, 11);
            switch (SpriteName)
            {
                case "25":
                    Thread thr0 = new Thread(new ParameterizedThreadStart(DrawAddSprite));
                    thr0.Start(Add25);
                    break;
                case "100":
                    Thread thr1 = new Thread(new ParameterizedThreadStart(DrawAddSprite));
                    thr1.Start(Add100);
                    break;
                case "ProgressBar":
                    Console.SetCursorPosition(0, 11);
                    for (int i = 0; i < ProgressBarSprite.GetLength(0); i++)
                    {
                        Console.SetCursorPosition(51, (17+i));
                        Console.Write(ProgressBarSprite[i]);
                    }
                    break;
                case "UserIcon":
                    for (int c = 0; c < 4; c++)
                    {
                        for (int i = 0; i < UserIcon.GetLength(0); i++)
                        {
                            Console.SetCursorPosition((3+(c*8)), (25 + i));
                            Console.Write(UserIcon[i]);
                        }
                    }
                    break;
                case "MenuSprite":
                    for (int n = 0; n < MenuSprite.GetLength(0); n++)
                    {
                        //Console.Clear();
                        for (int i = 0; i < n+1; i++)
                        {
                            Console.SetCursorPosition(27, (27 - n));
                            Console.Write(MenuSprite[i]);
                        }
                        Thread.Sleep(200);
                    }
                    break;
            }
        }

        private void DrawAddSprite(object sprite)
        {
            //параметрезированный поток в качестве параметра 
            //может принимать только объект типа object, по мне так херь какая-то
            string[] sprite_ = (string[])sprite;
            for (int i = 0; i < sprite_.GetLength(0); i++)
            {
                Console.SetCursorPosition(0, 11+i);
                Console.Write(sprite_[i] + "\n");
                Thread.Sleep(90);
            }
            Thread.Sleep(600);
            for (int i = 0; i < sprite_.GetLength(0); i++)
            {
                Console.SetCursorPosition(0, 11+i);
                for (int n = 0; n < sprite_[i].Length; n++)
                {
                    Console.Write(" ");
                }
                Thread.Sleep(90);
                Console.Write("\n");
            }
        }

        public void CheckBar(int generatorCount, int progress, int scores)
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
            Console.SetCursorPosition(2, 23);
            Console.Write("scores: " + scores);
            Console.SetCursorPosition(19, 23);
            Console.Write("Генераторов: " + generatorCount + "\n  -------------------------------");
            ui.Draw("UserIcon");
        }

        private static readonly string[] simbols = new string[]
            {
            "┌ ┐└ ┘├ ┤ ═ ║ ╒ ╓ ╔ ╕ ╖ ╗ ╘ ╙ ╚ ╛ ╜ ╝ ╞ ╟ ╠ ╡ ╢ ╣ ╤ ╥ ╦ ╧ ╨ ╩ ╪ ╫ ╬ ▀ ▄ █ ▌▐ ░ ▒ ▓"
            };
        private static readonly string[] Add25 = new string[]
            {
            "   ■   █ ▀▀█ █▀▀ █▀█ ",
            " ■■■■■ █ █▀▀ ▀▀█ █ █ ",
            "   ■   █ █▄▄ ▄▄█ █▄█ ",
            };
        private static readonly string[] Add100 = new string[]
            {
            "   ■    █ █▀█ █▀█ ",
            " ■■■■■  █ █ █ █ █ ",
            "   ■    █ █▄█ █▄█ ",
            };
        private static readonly string[] ProgressBarSprite = new string[]
        {
            " -------------------- ",
            "|                    |",
            " -------------------- ",
        };
        private static readonly string[] UserIcon = new string[]
        {
            " ▄▄▄ ",
            " ███ ",
            "  ▀  ",
            "▀▀▀▀▀",
        };
        private static readonly string[] MenuSprite = new string[]
        {
            "╔═══════════╗    ╔═══════════╗    ╔═══════════╗    ╔═══════════╗",
            "║     x     ║    ║    ▄║▄    ║    ║           ║    ║           ║",
            "║   .   o   ║    ║   █ ║ ▀   ║    ║  ▀ ════   ║    ║   ▄▀▀▀▄   ║",
            "║     .     ║    ║    ▀║▀▄   ║    ║  ▀ ════   ║    ║  █ ▀▄  █  ║",
            "║    ▄▄▄    ║    ║   ▀▄║▄▀   ║    ║  ▀ ════   ║    ║  ▀▄  ▀▄▀  ║",
            "║ ══        ║    ║     ║     ║    ║           ║    ║    ▀▀▀    ║",
            "╚═══════════╝    ╚═══════════╝    ╚═══════════╝    ╚═══════════╝",
            "  Новая игра        Магазин         Сатистика          Выход",
        };

    }
}
