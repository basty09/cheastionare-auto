using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            form3.ShowDialog();

        }
    }
}
