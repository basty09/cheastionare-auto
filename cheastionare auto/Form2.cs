﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cheastionare_auto
{   
    
    public partial class Form2 : Form 
    {  
        public Label Timer1Countdown;
        //lista cu butoanele cu chestionare
        //o folosim pentru a le centra in centrul ecranului 
        private List<Button> butoane = new List<Button>();
        public Form2()
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            
            for(int i = 0; i < 10; i++)
            {
                ButonChestionar buton =new ButonChestionar(i+1);
                butoane.Add(buton);           
                this.Controls.Add(buton);    
            }
        }

        public void seteazaLocatia()
        {
            //functie care se asigura ca butoanele sunt asezate in centrul ecranului 
            int latimeEcran = this.Width;
            ButonChestionar butonAux = new ButonChestionar(1);
            int latimeButon = butonAux.Width;
            int spatiuIntreButoane = 20;
            int latimeNecesara = 10 * (latimeButon + spatiuIntreButoane);
            // ds + 10 * button width + ds = latime ecran
            int disStanga = (latimeEcran - latimeNecesara) / 2;
            int spatiuSus = (this.Height - butonAux.Height) / 2;
            int i = 0;
            foreach (Button buton in butoane)
            {
                buton.Location = new Point(disStanga + i * (latimeButon + spatiuIntreButoane), spatiuSus);
                i++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //butonul pentru home 
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
            Application.Exit();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form1 form = new Form1();
            this.Hide();
            form.WindowState = this.WindowState;
            form.Show();
            this.Close();
        }
    }
}