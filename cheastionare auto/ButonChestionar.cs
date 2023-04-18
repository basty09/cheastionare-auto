using System;
using System.Windows.Forms;

namespace cheastionare_auto
{
    internal class ButonChestionar : Button
    {
        private int id;
        public ButonChestionar(int id)
        {
            this.id =  id; 
            this.Text=id.ToString()+"/10"; 
            this.Click += new EventHandler(this.OnClick);
        } 
        private void OnClick(object sender, EventArgs e)
        {   
            Form form=this.FindForm();  
            Form3 form3 = new Form3(id);
            form3.WindowState=form.WindowState;
            form.Hide();
            form3.ShowDialog();
            form.Close();
        }
    }
}
