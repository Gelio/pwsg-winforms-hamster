﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HamsterGame());
        }
    }

    public class ScoreboardRow
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public ScoreboardRow(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
