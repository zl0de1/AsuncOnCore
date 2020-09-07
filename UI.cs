using System;

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
                    Console.SetCursorPosition(0, 11);
                    for (int i = 0; i < Add25.GetLength(0); i++)
                    {
                        Console.Write(Add25[i] + "\n");
                    }
                    break;
                case "100":
                    Console.SetCursorPosition(0, 11);
                    for (int i = 0; i < Add100.GetLength(0); i++)
                    {
                        Console.Write(Add100[i] + "\n");
                    }
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
                        
            }
        }

        public void CheckBar(int generatorCount, int progress)
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

        private static readonly string[] Add25 = new string[]
            {
            "        ■■■  ■■■",
            "   ■      ■  ■  ",
            " ■■■■■   ■   ■■■",
            "   ■    ■      ■",
            "        ■■■  ■■■",
            };
        private static readonly string[] Add100 = new string[]
            {
            "   ■    ■ ■■■ ■■■",
            " ■■■■■  ■ ■ ■ ■ ■",
            "   ■    ■ ■■■ ■■■",
            };
        private static readonly string[] ProgressBarSprite = new string[]
        {
            " -------------------- ",
            "|                    |",
            " -------------------- ",
        };
        private static readonly string[] UserIcon = new string[]
        {
            " ■■■ ",
            " ■■■ ",
            "  ■  ",
            "■■■■■",
        };
    }
}
