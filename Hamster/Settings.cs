﻿using System;
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
        public bool roundButtons = false;

        public Settings(int _rows, int _columns, int _maxActiveButtons, int _maxClicks, bool _roundButtons)
        {
            rows = _rows;
            columns = _columns;
            maxActiveButtons = _maxActiveButtons;
            maxClicks = _maxClicks;
            roundButtons = _roundButtons;

            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            SaveSettingsFromControls();
            DialogResult = DialogResult.OK;
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            RestoreControlValuesFromSettings();
        }

        private void RestoreControlValuesFromSettings()
        {
            this.boardSize.SelectedItem = $"{rows} x {columns}";
            this.activeButtons.Value = maxActiveButtons;
            this.clicksToEnd.Value = maxClicks;
            this.buttonsRound.Checked = roundButtons;
            this.buttonsRectangular.Checked = !roundButtons;
        }

        private void SaveSettingsFromControls()
        {
            string boardSize = this.boardSize.SelectedItem as string;
            string[] boardSizes = boardSize.Split('x');
            rows = int.Parse(boardSizes[0]);
            columns = int.Parse(boardSizes[1]);
            maxActiveButtons = (int)this.activeButtons.Value;
            if (maxActiveButtons <= 0)
                maxActiveButtons = 1;
            if (maxActiveButtons > rows * columns)
                maxActiveButtons = rows * columns;

            maxClicks = (int)this.clicksToEnd.Value;
            if (maxClicks <= 0)
                maxClicks = 1;

            roundButtons = buttonsRound.Checked;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                confirm.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                cancel.PerformClick();
        }
    }
}
