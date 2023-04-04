using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cheastionare_auto
{
    public partial class Form3 : Form
    {
        private int remainingTime = 30 * 60;
        public Form3()
        {
            InitializeComponent();
            timer1Countdown.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
            if (FormManager.formStack.Count > 0)
            {
                Form previousForm = FormManager.formStack.Pop(); 
                FormManager.formStack.Push(this);
                previousForm.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1Countdown_Tick(object sender, EventArgs e)
        {

            if (remainingTime > 0)
            {
                remainingTime--;
                int minutes = remainingTime / 60;
                int seconds = remainingTime % 60;
                label1Countdown.Text = $"{minutes:00}:{seconds:00}";
            }
            else
            {
                timer1Countdown.Stop();
                label1Countdown.Text = "S-a terminat timpul!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (FormManager.formStack.Count > 0)
            {
                Form previousForm = FormManager.formStack.Pop();
                previousForm.Show();
            }
            this.Hide();
        }
    }
}

