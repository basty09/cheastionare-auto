using System;
using System.Drawing;
using System.Windows.Forms;

namespace cheastionare_auto
{   
    
    public partial class Form2 : Form 
    {  
        public System.Windows.Forms.Label Timer1Countdown;        
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
           
            for(int i = 0; i < 10; i++)
            {
                ButonChestionar buton =new ButonChestionar(i+1);
                                        //distanta stanga     distanta dintre butoane    distanta sus
                buton.Location = new Point(    200      +i*        100,                     400); 
                this.Controls.Add(buton);    
            }
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           this.Close();
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.WindowState = this.WindowState;
            form.Show();
            this.Close();
        }
    }
}