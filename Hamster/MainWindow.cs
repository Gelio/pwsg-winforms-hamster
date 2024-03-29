﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamster
{
    public partial class HamsterGame : Form
    {
        private int pointsPerHit = 50;
        private int pointsPerMiss = -100;


        private int rows = 4;
        private int columns = 4;
        private int maxActiveButtons = 5;
        private int maxClicks = 20;
        private int currentClicks = 0;
        private int score = 0;
        private bool roundButtons = false;
        private List<Button> activeButtons;
        private Settings settings;

        public HamsterGame()
        {
            settings = new Settings(rows, columns, maxActiveButtons, maxClicks, roundButtons);
            InitializeComponent();
            splitContainer1.BackColor = Color.Green;
            splitContainer1.Panel1.BackColor = DefaultBackColor;
            splitContainer1.Panel2.BackColor = DefaultBackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateGameTable();
            UpdateTimerInterval();
            UpdateScore();
            LoadScoreboardFromFile();
        }

        private void GenerateGameTable()
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
                    currentButton.Paint += roundButton_Paint;
                    gameTable.Controls.Add(currentButton, column, row);
                }

            activeButtons = new List<Button>();
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (!gameTimer.Enabled)
                return;

            currentClicks++;
            Button button = sender as Button;
            if (activeButtons.Contains(button))
            {
                // Hit!
                activeButtons.Remove(button);
                SetButtonState(button, false);
                score += pointsPerHit;
                scoreStatus.BackColor = DefaultBackColor;
            }
            else
            {
                score += pointsPerMiss;
                scoreStatus.BackColor = Color.Red;
            }
            UpdateScore();

            if (currentClicks >= maxClicks)
                GameOver();
        }

        public void GameOver()
        {
            PauseGame();

            GameOver gameOverScreen = new Hamster.GameOver();
            gameOverScreen.playerScore.Text = score.ToString();
            gameOverScreen.ShowDialog();

            if (gameOverScreen.DialogResult == DialogResult.OK)
            {
                string playerName = gameOverScreen.playerName.Text;
                scoreboardRows.Add(new ScoreboardRow(playerName, score));
                LoadScoreboard();
                SaveScoreboardToFile();
            }

            RestartGame();
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
                button.BackColor = Color.Blue;
            else
                button.BackColor = DefaultBackColor;
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

            if (settings.DialogResult == DialogResult.Cancel)
                return;

            ReloadSettings();
            RestartGame();
        }

        private void ReloadSettings()
        {
            rows = settings.rows;
            columns = settings.columns;
            maxActiveButtons = settings.maxActiveButtons;
            maxClicks = settings.maxClicks;
            roundButtons = settings.roundButtons;
        }

        private void RestartGame()
        {
            PauseGame();
            score = 0;
            UpdateScore();
            currentClicks = 0;
            scoreStatus.BackColor = DefaultBackColor;
            GenerateGameTable();
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
            this.scoreStatus.Text = $"Score: {score}";
        }

        private void roundButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!roundButtons)
                return;

            System.Drawing.Drawing2D.GraphicsPath buttonPath =
                new System.Drawing.Drawing2D.GraphicsPath();

            // Set a new rectangle to the same size as the button's 
            // ClientRectangle property.
            System.Drawing.Rectangle newRectangle = (sender as Button).ClientRectangle;

            // Decrease the size of the rectangle.
            newRectangle.Inflate(-5, -5);

            // Draw the button's border.
            e.Graphics.DrawEllipse(System.Drawing.Pens.Gray, newRectangle);

            // Increase the size of the rectangle to include the border.
            newRectangle.Inflate(1, 1);

            // Create a circle within the new rectangle.
            buttonPath.AddEllipse(newRectangle);

            // Set the button's Region property to the newly created 
            // circle region.
            (sender as Button).Region = new Region(buttonPath);

        }
    }
}
