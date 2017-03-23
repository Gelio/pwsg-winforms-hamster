namespace Hamster
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boardSize = new System.Windows.Forms.ComboBox();
            this.activeButtons = new System.Windows.Forms.NumericUpDown();
            this.clicksToEnd = new System.Windows.Forms.NumericUpDown();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.activeButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clicksToEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of active buttons:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of clicks to end:";
            // 
            // boardSize
            // 
            this.boardSize.FormattingEnabled = true;
            this.boardSize.Items.AddRange(new object[] {
            "4 x 4",
            "6 x 6",
            "8 x 8"});
            this.boardSize.Location = new System.Drawing.Point(150, 9);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(121, 21);
            this.boardSize.TabIndex = 3;
            this.boardSize.Text = "4 x 4";
            // 
            // activeButtons
            // 
            this.activeButtons.Location = new System.Drawing.Point(150, 51);
            this.activeButtons.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.activeButtons.Name = "activeButtons";
            this.activeButtons.Size = new System.Drawing.Size(120, 20);
            this.activeButtons.TabIndex = 4;
            this.activeButtons.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // clicksToEnd
            // 
            this.clicksToEnd.Location = new System.Drawing.Point(150, 96);
            this.clicksToEnd.Name = "clicksToEnd";
            this.clicksToEnd.Size = new System.Drawing.Size(120, 20);
            this.clicksToEnd.TabIndex = 5;
            this.clicksToEnd.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(115, 125);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(197, 125);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "OK";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.clicksToEnd);
            this.Controls.Add(this.activeButtons);
            this.Controls.Add(this.boardSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.activeButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clicksToEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        public System.Windows.Forms.ComboBox boardSize;
        public System.Windows.Forms.NumericUpDown activeButtons;
        public System.Windows.Forms.NumericUpDown clicksToEnd;
    }
}