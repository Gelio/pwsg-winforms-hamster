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
    public partial class Settings : Form
    {
        public int rows = 4;
        public int columns = 4;
        public int maxActiveButtons = 5;
        public int maxClicks = 20;
        public bool wasCancelled = false;

        public Settings()
        {
            InitializeComponent();
            RestoreSettings();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string boardSize = this.boardSize.SelectedItem as string;
            string[] boardSizes = boardSize.Split('x');
            rows = int.Parse(boardSizes[0]);
            columns = int.Parse(boardSizes[1]);
            maxActiveButtons = (int)this.activeButtons.Value;
            maxClicks = (int)this.clicksToEnd.Value;
            Close();
            wasCancelled = false;
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            RestoreSettings();
        }

        private void RestoreSettings()
        {
            this.boardSize.SelectedItem = $"{rows} x {columns}";
            this.activeButtons.Value = maxActiveButtons;
            this.clicksToEnd.Value = maxClicks;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            RestoreSettings();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
            wasCancelled = true;
        }

        private void cancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                cancel.PerformClick();
        }

        private void confirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                confirm.PerformClick();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            wasCancelled = true;
        }
    }
}
