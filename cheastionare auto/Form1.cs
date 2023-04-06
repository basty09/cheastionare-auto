using System;
using System.Windows.Forms;

namespace cheastionare_auto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); 
            form2.WindowState = this.WindowState;
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e){}
        private void button2_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
    }
}
