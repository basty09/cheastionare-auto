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
    
    public partial class Form2 : Form 
    {  
        
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
           
            for(int i = 0; i < 10; i++)
            {
                ButonChestionar buton =new ButonChestionar(i+1);
                buton.Location = new Point(200+i*100,400); 
                this.Controls.Add(buton); 
                
            }
         
        }
        public System.Windows.Forms.Label Timer1Countdown;


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
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
            
            Form1 form1 = new Form1(); 
            form1.WindowState = this.WindowState;
            form1.Show();
            this.Hide();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            FormManager.formStack.Push(this);
            Form3 form3 = new Form3(); 
            form3.WindowState = this.WindowState;
            form3.Show();
            this.Hide();
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
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.formStack.Push(this);
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
    public class FormManager
    {
        static public Stack<Form> formStack = new Stack<Form>();
    }
}