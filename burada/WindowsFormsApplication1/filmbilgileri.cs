using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public partial class filmbilgileri : Form
    {
        public filmbilgileri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabaninimiz.accdb");

        cls sinif = new cls();
        private void puanhesapla()
        {
           baglanti.Open();
            string sqL = "select salonid from salonlar where salonadi='" + filmseccs.salon + "'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            string salonid = cmd.ExecuteScalar().ToString();

            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string filmid1 = cmd.ExecuteScalar().ToString();

            string sql = "update film set puan = puan + " + puan + ", puanverenkisisayisi= puanverenkisisayisi+1 where filmid= '" + filmid1 + "'";
            sinif.calistir(sql);
            baglanti.Close();
            try
            {
                MessageBox.Show("PUAN BAŞARIYLA EKLENDİ...");
            }
            catch
            {
           }
        }
        private void puanhesapla1()
        {
            baglanti.Open();
            string sayi = "SELECT puanverenkisisayisi from film where filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdsayi = new OleDbCommand(sayi, baglanti);
            int kisisayisi = Convert.ToInt32(cmdsayi.ExecuteScalar());

            string filmpuan = "SELECT puan from film where filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdpuan = new OleDbCommand(filmpuan, baglanti);
            int puani = Convert.ToInt32(cmdpuan.ExecuteScalar());

            txtpuan.Text = (puani / kisisayisi).ToString();
            baglanti.Close();
        }
        
        private void filmbilgileri_Load(object sender, EventArgs e)
        {
            puanhesapla1();
            baglanti.Open();
            txtfilmaadi.Text = filmseccs.filmadi;
            string filmtur = "SELECT filmtur FROM film WHERE filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdtur = new OleDbCommand(filmtur, baglanti);
            txttur.Text = cmdtur.ExecuteScalar().ToString();

         
           string filmoyuncu = "select oyuncular from oyuncular where filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdoyuncu = new OleDbCommand(filmoyuncu, baglanti);
            txtoyuncu.Text = cmdoyuncu.ExecuteScalar().ToString();

            string filmyonetici = "select yönetmen from oyuncular where filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdyonetmen = new OleDbCommand(filmyonetici, baglanti);
            txtyonetmen.Text = cmdyonetmen.ExecuteScalar().ToString();

            string filmkonu = "select konusu from film where filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmdkonu = new OleDbCommand(filmkonu, baglanti);
            txtkonu.Text = cmdkonu.ExecuteScalar().ToString();
          baglanti.Close();    
          
        }


       public static int puan = 0;
        private void label8_Click(object sender, EventArgs e)
        {
          groupBox1.Visible = true;
        }

        private void y1_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            puan = 1;
            y1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y1_MouseLeave(object sender, EventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y2_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 2;
        }

        private void y2_MouseLeave(object sender, EventArgs e)
        {
            y2.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y3_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 3;
        }
        private void y3_MouseLeave(object sender, EventArgs e)
        {
            y3.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void y4_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 4;
        }

        private void y4_MouseLeave(object sender, EventArgs e)
        {
            y4.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y5_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 5;
        }
        private void y5_MouseLeave(object sender, EventArgs e)
        {
            y5.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y6_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            y6.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 6;

        }

        private void y6_MouseLeave(object sender, EventArgs e)
        {
            y6.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void y7_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            y6.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
            y7.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y7.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 7;
        }

        private void y7_MouseLeave(object sender, EventArgs e)
        {
            y7.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y7.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void y8_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            y6.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
            y7.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y7.BackgroundImageLayout = ImageLayout.Stretch;
            y8.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y8.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 8;
        }

        private void y8_MouseLeave(object sender, EventArgs e)
        {
            y8.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y8.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void y9_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            y6.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
            y7.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y7.BackgroundImageLayout = ImageLayout.Stretch;
            y8.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y8.BackgroundImageLayout = ImageLayout.Stretch;
            y9.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y9.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 9;
        }

        private void y9_MouseLeave(object sender, EventArgs e)
        {
            y9.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y9.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void y10_MouseMove(object sender, MouseEventArgs e)
        {
            y1.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y1.BackgroundImageLayout = ImageLayout.Stretch;
            y2.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y2.BackgroundImageLayout = ImageLayout.Stretch;
            y3.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y3.BackgroundImageLayout = ImageLayout.Stretch;
            y4.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y4.BackgroundImageLayout = ImageLayout.Stretch;
            y5.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y5.BackgroundImageLayout = ImageLayout.Stretch;
            y6.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y6.BackgroundImageLayout = ImageLayout.Stretch;
            y7.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y7.BackgroundImageLayout = ImageLayout.Stretch;
            y8.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y8.BackgroundImageLayout = ImageLayout.Stretch;
            y9.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y9.BackgroundImageLayout = ImageLayout.Stretch;
            y10.Image = Image.FromFile("..\\Debug\\secilmis.png");
            y10.BackgroundImageLayout = ImageLayout.Stretch;
            puan = 10;
        }
        cls vtislem = new cls();
        private void y10_MouseLeave(object sender, EventArgs e)
        {
            y10.Image = Image.FromFile("..\\Debug\\secilmemis.png");
            y10.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

             filmseccs fls = new filmseccs();
            fls.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int puan1 = 0;
        private void y1_Click(object sender, EventArgs e)
        {
            puan1 = 1;
            puanhesapla();
            puanhesapla1();
        }

        private void y2_Click(object sender, EventArgs e)
        {
            puan1 = 2;
            puanhesapla();
            puanhesapla1();

        }

        private void y3_Click(object sender, EventArgs e)
        {
            puan1 = 3;
            puanhesapla();
            puanhesapla1();
        }

        private void y4_Click(object sender, EventArgs e)
        {
            puan1 = 4;
            puanhesapla();
            puanhesapla1();
        }

        private void y5_Click(object sender, EventArgs e)
        {
            puan1 = 5;
            puanhesapla();
            puanhesapla1();
        }

        private void y6_Click(object sender, EventArgs e)
        {
            puan1 = 6;
            puanhesapla();
            puanhesapla1();
        }

        private void y7_Click(object sender, EventArgs e)
        {
            puan1 = 7;
            puanhesapla();
            puanhesapla1();
        }

        private void y8_Click(object sender, EventArgs e)
        {
            puan1 = 8;
            puanhesapla();
            puanhesapla1();
        }

        private void y9_Click(object sender, EventArgs e)
        {
            puan1 = 9;
            puanhesapla();
            puanhesapla1();
        }

        private void y10_Click(object sender, EventArgs e)
        {
            puan1 = 10;
            puanhesapla();
            puanhesapla1();
        }

        
    
    }
}
