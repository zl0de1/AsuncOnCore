using System;
using System.Collections.Generic;
using System.Text;

namespace AsuncOnCore
{
    class Game
    {
        private int progress;
        public Game() { }

        public int Progress
        {
            get { return progress; }
            set  
            {
                if (value < 0) { progress = 0; }
                else if (value > 100) { progress = 100; }
                else { progress = value; }
            } 
        }
    }
}
