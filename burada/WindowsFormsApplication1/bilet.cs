using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class bilet : Form
    {
        public bilet()
        {
            InitializeComponent();
        }
        filmseccs flm = new filmseccs();
        private void bilet_Load(object sender, EventArgs e)
        {
            label11.Text = biletal.ad ;
            label12.Text = biletal.soyad;
            label13.Text = biletal.telnu;
            label14.Text = biletal.secilenfilm;
            label15.Text = biletal.seansimiz;
            label16.Text = filmseccs.salonidxx;
            label17.Text = kayitgiris.koltuklar;
            label18.Text = biletal.fiyatt;
            label19.Text = flm.dateTimePicker1.Text;





        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           this.Close();
        }

       
        

        

        
        

       
    }
}
