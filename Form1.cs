using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timed_math_quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int diffend1;
        int diffend2; 

        int prodend1;
        int prodnd2;

        int divend1;
        int divend2;

        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        private void dividedRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

             diffend1 = randomizer.Next(1,51);
             diffend2 = randomizer.Next(1, diffend1);

             prodend1 = randomizer.Next(1,10);
             prodnd2 = randomizer.Next(1,11);

             divend1 = randomizer.Next(1,25);
             divend2 = randomizer.Next(1,10);
            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
           

           
            

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;
            
            /***************************************/
            minusLeftLabel.Text = diffend1.ToString();
            minusRightLabel.Text = diffend2.ToString();
            /***************************************/
         
            difference.Value = 0;
            timesLeftLabel.Text = prodend1.ToString();
            timesRightLabel.Text = prodnd2.ToString();
            /***************************************/
            product.Value = 0;
            /***************************************/
            dividedLeftLabel.Text = divend1.ToString();
            dividedRightLabel.Text = divend2.ToString();
            /***************************************/
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 150;
            timeLabel.Text = "150 seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
             else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = diffend1 - diffend2;
                product.Value = prodend1 * prodnd2;
                quotient.Value = divend1 / divend2;
                startButton.Enabled = true;
            }
        }
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value
                && diffend1-diffend2==difference.Value
                && prodend1*prodnd2==product.Value
                && divend1/divend2==quotient.Value
                )
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
