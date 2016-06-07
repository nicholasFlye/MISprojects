// Filename: Form1.cs
// written by: Nicholas Flye
// Purpose: Create the game Rock Paper Scissors
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch4Ex8b_RockPaperScissors
{
    public partial class Form1 : Form
    {
        //Declare variables
        int timeLeft = 4;
        int p1Choice = 0;

        public Form1()
        {
            InitializeComponent();
            imgRPS.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //Play button starts/resets game
        private void btnPlay_Click(object sender, EventArgs e)
        {
            lblCountdown.Text = "Ready?";
            lblCountdown.ForeColor = Color.Black;
            imgRPS.Visible = false;
            timeLeft = 4;
            timer1.Enabled = true;
            timer1.Start();
        }

        //Timer for RPS that counts down when user presses play
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                imgRPS.Visible = true;
                if (lblCountdown.Text == "SCISSORS!")
                {
                    lblCountdown.Text = "SHOOT!";
                    timeLeft = 0;

                }
                if (lblCountdown.Text == "PAPER!")
                {
                    lblCountdown.Text = "SCISSORS!";
                    imgRPS.Image = Properties.Resources.Scissors;
                }
                if(lblCountdown.Text == "ROCK!")
                {
                    lblCountdown.Text = "PAPER!";
                    imgRPS.Image = Properties.Resources.Paper;
                }
                if (lblCountdown.Text == "Ready?")
                {
                    lblCountdown.Text = "ROCK!";
                    imgRPS.Image = Properties.Resources.Rock;
                }
                timeLeft--;
            }
            else
            {
                timer1.Stop();
                //Random number generator that uses a range of 0-44 for good variation
                Random rand = new Random();
                int cpuChoice = rand.Next(45);
                timer1.Enabled = false;
                //Determine if CPU won or User won
                if (cpuChoice <= 15)
                {
                    lblCountdown.Text = "ROCK!";
                    imgRPS.Image = Properties.Resources.Rock;
                    lblCountdown.ForeColor = Color.DarkOrange;
                    lblChoice.Text = (p1Choice == 15) ? "DRAW GAME" : ((p1Choice == 30) ? "WINNER" :  "YOU LOSE");
                }
                else if(cpuChoice <= 30)
                {
                    lblCountdown.Text = "PAPER!";
                    imgRPS.Image = Properties.Resources.Paper;
                    lblCountdown.ForeColor = Color.DarkOrange;
                    lblChoice.Text = (p1Choice == 15) ? "YOU LOSE" : ((p1Choice == 30) ? "DRAW GAME" : "WINNER");
                }
                else if (cpuChoice <= 45)
                {
                    lblCountdown.Text = "SCISSORS!";
                    imgRPS.Image = Properties.Resources.Scissors;
                    lblCountdown.ForeColor = Color.DarkOrange;
                    lblChoice.Text = (p1Choice == 15) ? "WINNER" : ((p1Choice == 30) ? "YOU LOSE" : "DRAW GAME");
                }
            }
        }

        //User choices
        private void btnRock_Click(object sender, EventArgs e)
        {
            p1Choice = 15;
            lblChoice.Text = "ROCK";
            lblChoice.ForeColor = Color.Green;
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            p1Choice = 30;
            lblChoice.Text = "PAPER";
            lblChoice.ForeColor = Color.Green;
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            p1Choice = 45;
            lblChoice.Text = "SCISSORS";
            lblChoice.ForeColor = Color.Green;
        }
    }
}
