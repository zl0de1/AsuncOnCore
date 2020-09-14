﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AsuncOnCore
{
    class User
    {
        string name;
        private int progress;
        private int scores;

        public User() { }
        public User(string name) 
        {

        }

        public int Scores
        {
            get { return scores; }
            set { scores = value; }
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
