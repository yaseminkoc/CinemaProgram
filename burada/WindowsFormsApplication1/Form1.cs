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
    public partial class kullanicigiris : Form
    {
        public kullanicigiris()
        {
            InitializeComponent();
        }
       
        string bosluk = "";
        Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
           
            timer1.Start();
            for (int i = 0; i <= 4; i++)
            {
               
                int rastgele = rnd.Next(0, 10);
                bosluk = bosluk + rastgele;
            }

            label6.Text = bosluk.ToString();


           
        }
        
      
  
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {sayac++;
        if (sayac == 2)
        {
            label1.ForeColor = Color.Yellow;
          
        }
        else if (sayac == 4)
        {
            label1.ForeColor = Color.Blue;
        }
        else if (sayac == 6)
        {
            label1.ForeColor = Color.Pink;
        }
        else if (sayac == 8)
        {
            label1.ForeColor = Color.Green;
        }
        else if (sayac == 10)
        {
            label1.ForeColor = Color.Orange;
        }
        else if (sayac == 12)
        {
            label1.ForeColor = Color.Turquoise;
        }
        else if (sayac == 14)
        {
            label1.ForeColor = Color.White;
        }
        else if (sayac == 16)
        {
            label1.ForeColor = Color.Violet;
        }
        else if (sayac == 18)
        {
            label1.ForeColor = Color.Tomato;
        }

        else if (sayac == 20)
        {
            label1.ForeColor = Color.Purple;
            sayac = 0;
        
        }
        }
      

        
        cls sinif = new cls();
      
       private void button1_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       
       private void pictureBox5_Click(object sender, EventArgs e)
       {
         
           string sql = "select * from kulanicigiris where kullanici_adi='" + txtadi.Text + "'and sifre='" + txtsifre1.Text + "'";
           sinif.listele(sql, this.dataGridView1);
           string sql2 = "select yetki from kulanicigiris where kullanici_adi='" + txtadi.Text + "' and sifre= '" + txtsifre1.Text + "'";
           sinif.listele(sql2, this.dataGridView2);
           if (dataGridView1.RowCount == 1 || txtkodu.Text != label6.Text || txtsifre1.Text != txtsifre2.Text)
           {
               MessageBox.Show("HATALI GİRİŞ...");
           }
           else
           {
               string yetki = dataGridView2.CurrentRow.Cells[0].Value.ToString();

               if (yetki == "1")
               {
                   filmekle f1 = new filmekle();
                   f1.Show();
                   f1.pictureBox6.Visible = false;
                   this.Hide();

               }
               else if (yetki == "0")
               {

                   filmseccs f1 = new filmseccs();
                   cls.frm1 = f1;
                   f1.Show();
                   WindowsFormsApplication1.cls.frm1 = f1;
                   this.Hide();
               }
           }
               
       }
       filmekle f1 = new filmekle();
       private void pictureBox6_Click(object sender, EventArgs e)
       {
          
          
         
           f1.Show();
           this.Hide();
           f1.Size = new Size(370, 515);
           f1.groupBox2.Location = new Point(0, 0);
           f1.groupBox1.Visible = false;
           f1.pictureBox6.Visible = true;
           f1.label1.Visible = false;
           f1.label7.Visible = false;
           f1.label11.Visible = false;
           f1.label3.Visible = false;
           f1.label4.Visible = false;

           f1.label2.Visible = false;
           f1.label9.Visible = false;
           f1.label10.Visible = false;
           f1.label8.Visible = false;
           f1.pcbresimekle.Visible = false;


           f1.txtfilmadi.Visible = false;
           f1.cmdtur.Visible = false;
           f1.txtfilmsure.Visible = false;
           f1.txtseanssaati.Visible = false;
           f1.cmbsalonid.Visible = false;
           f1.txtseanssaati.Visible = false;
           f1.dateTimePicker1.Visible = false;
           f1.cmbyerliyabanci.Visible = false;
           f1.txtpuan.Visible = false;
           f1.txtfilmkonu.Visible = false;
           f1.pictureBox1.Visible = false;
   

       }

       
     

       

     
      

    

       

        

       

       
    }
}
