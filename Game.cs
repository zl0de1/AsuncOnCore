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
            set  { progress = value; } 
            
        }
    }
}
