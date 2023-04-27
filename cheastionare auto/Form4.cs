using System;
using System.Windows.Forms;

namespace cheastionare_auto
{
    public partial class Form4 : Form
    {
        public Form4(bool trecut)
        {
            //prin trecut ni se comunica daca am trecut sau nu chestionarul
            InitializeComponent(); 
            if(trecut)
            {
                label1.Text = "Felicitari esti admis!";  
            } 
            else
            {
                label1.Text = "Respins!";
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.WindowState = this.WindowState;
            form.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
