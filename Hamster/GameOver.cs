using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamster
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void saveScoreButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void playerName_TextChanged(object sender, EventArgs e)
        {
            saveScoreButton.Enabled = playerName.Text.Trim().Length > 0;
        }
    }
}
