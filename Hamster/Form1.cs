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
    public partial class Form1 : Form
    {
        private int rows = 4;
        private int columns = 4;
        private int maxActiveButtons = 5;
        private int maxClicks = 20;
        private int currentClicks = 0;
        private int score = 0;
        private List<Button> activeButtons;
        private Settings settings = new Settings();

        public Form1()
        {
            InitializeComponent();
            splitContainer1.BackColor = Color.Green;
            splitContainer1.Panel1.BackColor = DefaultBackColor;
            splitContainer1.Panel2.BackColor = DefaultBackColor;
            settings.FormClosed += Settings_FormClosed;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (settings.wasCancelled)
                return;

            PauseGame();
            score = 0;
            rows = settings.rows;
            columns = settings.columns;
            maxActiveButtons = settings.maxActiveButtons;
            maxClicks = settings.maxClicks;
            currentClicks = 0;
            activeButtons = new List<Button>();
            GenerateGame();
            UpdateScore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateGame();
            activeButtons = new List<Button>();
            UpdateTimerInterval();
            UpdateScore();
            // gameTimer.Enabled = true;
        }

        private void GenerateGame()
        {
            float columnWidth = 100 / columns;
            float rowHeight = 100 / rows;

            gameTable.Controls.Clear();
            gameTable.ColumnStyles.Clear();
            gameTable.ColumnCount = columns;
            for (int column = 0; column < columns; column++)
                gameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidth));

            gameTable.RowStyles.Clear();
            gameTable.RowCount = rows;
            for (int row = 0; row < rows; row++)
                gameTable.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));

            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    Button currentButton = new Button();
                    currentButton.Dock = DockStyle.Fill;
                    currentButton.Click += CurrentButton_Click;
                    gameTable.Controls.Add(currentButton, column, row);
                }
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (!gameTimer.Enabled)
                return;

            Button button = sender as Button;
            if (activeButtons.Contains(button))
            {
                // Deactivate
                activeButtons.Remove(button);
                SetButtonState(button, false);
                score += 50;
            }
            else
            {
                score -= 100;
                if (score < 0)
                    score = 0;
            }
            UpdateScore();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimerInterval();
        }

        private void UpdateTimerInterval()
        {
            this.gameTimer.Interval = trackBar1.Maximum + trackBar1.Minimum - trackBar1.Value;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (activeButtons.Count > 0)
            {
                Button buttonToDeactivate = activeButtons.First();
                activeButtons.RemoveAt(0);
                SetButtonState(buttonToDeactivate, false);
            }

            int i = 0;
            while (activeButtons.Count < maxActiveButtons)
            {
                i++;
                Button button = GetRandomInactiveButton();
                activeButtons.Add(button);
                SetButtonState(button, true);
            }
        }

        private void SetButtonState(Button button, bool isActive)
        {
            if (isActive)
            {
                button.BackColor = Color.Blue;
            }
            else
            {
                button.BackColor = DefaultBackColor;
            }
        }

        private void SetButtonState(int row, int column, bool isActive)
        {
            Button button = gameTable.GetControlFromPosition(column, row) as Button;
            SetButtonState(button, isActive);
        }

        private Button GetRandomInactiveButton()
        {
            Random r = new Random();
            int index;
            do
            {
                index = r.Next(rows * columns);
            }
            while (activeButtons.Contains(gameTable.Controls[index]));
            return gameTable.Controls[index] as Button;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
                PauseGame();
            else
                StartGame();
        }

        private void StartGame()
        {
            gameTimer.Enabled = true;
            startButton.Text = "Pause";
        }

        private void PauseGame()
        {
            gameTimer.Enabled = false;
            startButton.Text = "Start";
        }

        private void UpdateScore()
        {
            this.toolStripStatusLabel1.Text = $"Score: {score}";
        }
    }
}
