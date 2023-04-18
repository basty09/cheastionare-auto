using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace cheastionare_auto
{  
    
    public partial class Form3 : Form
    {
        private int remainingTime = 30 * 60;
        //lista cu intrebari care va citi din xml 
        private List<Intrebare> intrebari = new List<Intrebare>();
        //indexul intrebarii curente
        private int intrebareaCurenta;
        private int raspunsuriGresite=0;
        public Form3()
        {
            InitializeComponent();
            timer1Countdown.Start();
            intrebareaCurenta = 0; 
        } 

        public Form3(int id)
        {
            //constructor
            InitializeComponent();
            timer1Countdown.Start();
            intrebareaCurenta = 0;
            //pregatim citirea din XML
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("intrebari"+id.ToString()+".xml");

            XmlNodeList intrebariNode = xmlDocument.GetElementsByTagName("intrebare");
           
            //preluam fiecare intrebare din xml si o memoram in lista din memorie 
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
            //functie care afiseaza pe ecran o intrebare 
            Intrebare intrebarecurenta = intrebari[intrebareaCurenta]; 
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
                //daca a expirat timpul 
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
            //nutonul pentru urmatoarea intrebare
            int selecteditem=checkedListBox1.SelectedIndex;
            //daca nu am selectat niciun raspuns, nu facem nimic
            if (selecteditem == -1)
                return;

            //daca am selectat raspunsul gresit
            if (selecteditem != intrebari[intrebareaCurenta].RaspunsCorect)
            {
                raspunsuriGresite++;
            }
            intrebareaCurenta++;
            checkedListBox1.Items.Clear(); 
            //daca avem 5 raspunsuri gresite am picat chestionarul 
            if(raspunsuriGresite==5)
            {

                Form4 form4 = new Form4(false);
                form4.WindowState = this.WindowState;
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
            //daca am ajus la final inseamna ca am trecut chestionarul 
            if(intrebareaCurenta==26)
            {
                Form4 form4 = new Form4(true);  
                form4.WindowState = this.WindowState;
                this.Hide();
                form4.ShowDialog();
                this.Close();
            }
            showQuestion();
            label2.Text = "Raspunsuri corecte: " + (intrebareaCurenta - raspunsuriGresite).ToString() + "/26"; 
            label3.Text="Raspunsuri gresite: "+(raspunsuriGresite).ToString();
            
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
        //clasa folosita pentru memorarea unei intrebari
        public string text;
        public List<string> raspunsuri;
        public int RaspunsCorect;
    }
}

