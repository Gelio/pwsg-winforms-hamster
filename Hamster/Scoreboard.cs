using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamster
{
    public partial class HamsterGame : Form
    {
        public List<ScoreboardRow> scoreboardRows = new List<ScoreboardRow>();

        public void LoadScoreboard()
        {
            scoreboard.Items.Clear();
            foreach (ScoreboardRow row in scoreboardRows.OrderByDescending(row => row.Points))
                scoreboard.Items.Add(new ListViewItem(new string[] { row.Name, row.Points.ToString() }));
        }
    }
}
