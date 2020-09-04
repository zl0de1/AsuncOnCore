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
                    for (int i = 0; i < Add25.GetLength(0); i++)
                    {
                        Console.Write(Add25[i] + "\n");
                    }
                    break;
                case "100":
                    for (int i = 0; i < Add100.GetLength(0); i++)
                    {
                        Console.Write(Add100[i] + "\n");
                    }
                    break;
                case "ProgressBar":                 
                    for (int i = 0; i < ProgressBarSprite.GetLength(0); i++)
                    {
                        Console.SetCursorPosition(51, (17+i));
                        Console.Write(ProgressBarSprite[i]);
                    }
                    break;
            }
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
    }
}
