using System;
using System.Collections.Generic;
using System.Text;

namespace AsuncOnCore
{
    class Game
    {
        private int progress;
        private int generatorCount;

        public Game() { }

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
