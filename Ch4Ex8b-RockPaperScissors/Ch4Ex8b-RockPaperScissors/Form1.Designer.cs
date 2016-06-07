namespace Ch4Ex8b_RockPaperScissors
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnRock = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.btnScissors = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChoice = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imgRPS = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgRPS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRock
            // 
            this.btnRock.Location = new System.Drawing.Point(78, 668);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(179, 45);
            this.btnRock.TabIndex = 0;
            this.btnRock.Text = "Rock";
            this.btnRock.UseVisualStyleBackColor = true;
            this.btnRock.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.Location = new System.Drawing.Point(373, 668);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(179, 45);
            this.btnPaper.TabIndex = 1;
            this.btnPaper.Text = "Paper";
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);
            // 
            // btnScissors
            // 
            this.btnScissors.Location = new System.Drawing.Point(672, 668);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(179, 45);
            this.btnScissors.TabIndex = 2;
            this.btnScissors.Text = "Scissors";
            this.btnScissors.UseVisualStyleBackColor = true;
            this.btnScissors.Click += new System.EventHandler(this.btnScissors_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(373, 763);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(179, 45);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCountdown.Location = new System.Drawing.Point(395, 29);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(157, 46);
            this.lblCountdown.TabIndex = 5;
            this.lblCountdown.Text = "Ready?";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 614);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Your choice:";
            // 
            // lblChoice
            // 
            this.lblChoice.AutoSize = true;
            this.lblChoice.Location = new System.Drawing.Point(414, 614);
            this.lblChoice.Name = "lblChoice";
            this.lblChoice.Size = new System.Drawing.Size(329, 25);
            this.lblChoice.TabIndex = 7;
            this.lblChoice.Text = "Choose Rock, Paper, or Scissors";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imgRPS
            // 
            this.imgRPS.Location = new System.Drawing.Point(215, 87);
            this.imgRPS.Name = "imgRPS";
            this.imgRPS.Size = new System.Drawing.Size(528, 524);
            this.imgRPS.TabIndex = 4;
            this.imgRPS.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(956, 844);
            this.Controls.Add(this.lblChoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.imgRPS);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnScissors);
            this.Controls.Add(this.btnPaper);
            this.Controls.Add(this.btnRock);
            this.Name = "Form1";
            this.Text = "RockPaperScissors";
            ((System.ComponentModel.ISupportInitialize)(this.imgRPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox imgRPS;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChoice;
        private System.Windows.Forms.Timer timer1;
    }
}

