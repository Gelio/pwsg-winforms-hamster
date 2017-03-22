using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Hamster
{
    public partial class HamsterGame : Form
    {
        private List<ScoreboardRow> scoreboardRows = new List<ScoreboardRow>();
        private string scoreboardFileName = "Scoreboard.txt";

        public void LoadScoreboard()
        {
            scoreboard.Items.Clear();
            foreach (ScoreboardRow row in scoreboardRows.OrderByDescending(row => row.Points))
                scoreboard.Items.Add(new ListViewItem(new string[] { row.Name, row.Points.ToString() }));
        }

        public void SaveScoreboardToFile()
        {
            FileStream save = File.Open(scoreboardFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(save);

            foreach (var row in scoreboardRows)
                sw.WriteLine($"{row.Name} {row.Points}");

            sw.Close();
            save.Close();
        }

        public void LoadScoreboardFromFile()
        {
            if (!File.Exists(scoreboardFileName))
                return;

            scoreboardRows.Clear();
            string[] scoreboardLines = File.ReadAllLines(scoreboardFileName);
            foreach (var scoreboardLine in scoreboardLines)
            {
                string[] scoreboardParts = scoreboardLine.Split(' ');
                scoreboardRows.Add(new ScoreboardRow(
                    scoreboardParts.Take(scoreboardParts.Length - 1).Aggregate(
                            (part1, part2) => part1 + ' ' + part2
                        ),
                    int.Parse(scoreboardParts.Last())
                    ));
            }
            LoadScoreboard();
        }

        private void clearScoreboard_Click(object sender, EventArgs e)
        {
            scoreboardRows.Clear();
            LoadScoreboard();
            SaveScoreboardToFile();
        }
    }
}
