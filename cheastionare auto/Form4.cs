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
    public partial class Form4 : Form
    {
        public Form4(bool trecut)
        {
            InitializeComponent(); 
            if(trecut)
            {
                label1.Text = "Felicitari ai trecut!";  
            } 
            else
            {
                label1.Text = "Din pacate ai picat!";
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.WindowState=this.WindowState;
            form.Show();
            this.Close();
        }
    }
}
