using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace cheastionare_auto
{  
    
    public partial class Form3 : Form
    {
        private int remainingTime = 30 * 60;
        private List<Intrebare> intrebari = new List<Intrebare>();
        private int index;
        private int ct=0;
        public Form3()
        {
            InitializeComponent();
            timer1Countdown.Start();
            index = 0;
        } 

        public Form3(int id)
        {
            InitializeComponent();
            timer1Countdown.Start();
            index = 0;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("intrebari1.xml");

            XmlNodeList intrebariNode = xmlDocument.GetElementsByTagName("intrebare");
            Console.WriteLine(intrebariNode.Count);
            foreach(XmlNode xmlNode in intrebariNode)
            {
                Intrebare intrebare = new Intrebare();  
                intrebare.text = xmlNode.SelectSingleNode("text").InnerText;
                intrebare.raspunsuri = new List<string>();
                XmlNodeList xmlNodeList = xmlNode.SelectNodes("raspuns"); 
                for(int i = 0;i<xmlNodeList.Count;i++)
                {
                    intrebare.raspunsuri.Add(xmlNodeList[i].InnerText);
                    if (xmlNodeList[i].Attributes["corect"].Value=="true")
                    {
                        intrebare.RaspunsCorect = i;

                    }
                } 
                intrebari.Add(intrebare);
               
            }
            showQuestion();
        } 
        private void showQuestion()
        {
            Intrebare intrebarecurenta = intrebari[index]; 
            label1.Text=intrebarecurenta.text;
            foreach(string raspuns in intrebarecurenta.raspunsuri)
            {
                checkedListBox1.Items.Add(raspuns); 
            }
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
                Form4 form4 = new Form4(false);
                form4.WindowState = this.WindowState;
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   

            int selecteditem=checkedListBox1.SelectedIndex;
            if (selecteditem == -1)
                return;
            if (selecteditem != intrebari[index].RaspunsCorect)
            {
                ct++;
            }
            index++;
            checkedListBox1.Items.Clear(); 
            if(ct==5)
            {

                Form4 form4 = new Form4(false);
                form4.WindowState = this.WindowState;
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
            if(index==26)
            {
                Form4 form4 = new Form4(true);  
                form4.WindowState = this.WindowState;
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
            showQuestion();
            label2.Text = "Raspunsuri corecte: " + (index - ct).ToString() + "/26"; 
            label3.Text="Raspunsuri gresite: "+(ct).ToString();
            
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
    }
    public class Intrebare
    {
        public string text;
        public List<string> raspunsuri;
        public int RaspunsCorect;
    }
}

