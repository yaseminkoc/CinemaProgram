using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace WindowsFormsApplication1
{

    class cls
    {
      
        public static kayitgiris frm;
        public static filmseccs frm1;
        public static biletal frmbiletal ;
      
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=veritabaninimiz.accdb");
        public void listele(string sql, DataGridView dtg)
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtg.DataSource = ds.Tables[0];
            baglanti.Close();
         }
        public void calistir(string sql2)
        {
            baglanti.Open();
            OleDbCommand komud = new OleDbCommand(sql2, baglanti);
            
            komud.ExecuteNonQuery();
            baglanti.Close();
        }
       

        Button[] btndizisi = new Button[49];
        public static int koltuksayisi1 = 0;
        public void btnOlustur(Form f1, string salon)
        {  int left = 20;
            int top = 100;
            string[] deneme = { "G", "F", "E", "D", "C", "B", "A" };
            int sayac = 0;
           if (salon == "Salon1")
            {for (int i = 0; i < 7; i++)
                { for (int j = 0; j < 7; j++)
                    {
                       left += 90;
                       Button dugme = new Button();
                        dugme.Font = new Font(dugme.Font.FontFamily, 10);
                       dugme.Top = top;
                        dugme.Left = left;
                        dugme.Width = 50;
                        dugme.Height = 50;
                        dugme.BackColor = Color.Black;
                       dugme.Name = deneme[i] + (j + 1);
                        dugme.Click += new EventHandler(dugme_Click); //buttona olay vermef
                      f1.Controls.Add(dugme);
                        dugme.BackColor = Color.White;
                        dugme.BackgroundImage = Image.FromFile("..\\Debug\\bos1.png");
                        dugme.BackgroundImageLayout = ImageLayout.Stretch;
                        btndizisi[sayac] = dugme;
                        sayac++;
                     }

                    left = 20;
                    top += 60; ;
                }
            }
        }
             
        
  
        public void koltukDoldur(ComboBox combo)
        {
           
            int s = 0;
            while (s <  combo.Items.Count)
            {
                combo.SelectedIndex = s;
                for (int i = 0; i < 49; i++)
                {
                    if (btndizisi[i].Name == combo.SelectedItem.ToString())
                    {
                       
                        btndizisi[i].BackgroundImage = Image.FromFile("..\\Debug\\dolu1.png");
                        btndizisi[i].BackgroundImageLayout = ImageLayout.Stretch;
                        btndizisi[i].Text = "  ";
                        btndizisi[i].BackColor = Color.Black;

                    }
                }
                s++;
            }
        }
        
    
        private void dugme_Click(object sender, System.EventArgs e)//Olusturduğumuz butonun click olayı hepsinde çalışır
        {
             if ((sender as Button).Text == "  ") // 2 boşluk, dolu 
            {
                kayitgiris.koltuknu1 = (sender as Button).Name;
                string adi = "select musteriadi from bilet where koltuknu= '" + kayitgiris.koltuknu1 + "' and filmid = '" + filmseccs.filmidxx + "' and  salonid ='" + filmseccs.salonidxx + "' and seansid = '" + filmseccs.seanslar + "'";
                string soyadi = "select musterisoyadi from bilet where koltuknu= '" + kayitgiris.koltuknu1 + "' and filmid = '" + filmseccs.filmidxx + "' and  salonid ='" + filmseccs.salonidxx + "' and seansid = '" + filmseccs.seanslar + "'";
                string telnu = "select tel_nu from bilet where koltuknu= '" + kayitgiris.koltuknu1 + "' and filmid = '" + filmseccs.filmidxx + "' and  salonid ='" + filmseccs.salonidxx + "' and seansid = '" + filmseccs.seanslar + "'";
              
                 DialogResult yesno = MessageBox.Show("Biletinizi iptal etmek istediğinizden emin misiniz ?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                string isim = (sender as Button).Name;
                if (yesno == DialogResult.Yes)
                {
                    string biletiptal = "delete * from bilet where  koltuknu='" + kayitgiris.koltuknu1 + "' and salonid = '"+filmseccs.salonidxx+"' and filmid = '"+filmseccs.filmidxx+"'";

                    calistir(biletiptal);
                   

                    for (int i = 0; i < 49; i++)
                    {
                        if (btndizisi[i].Name == isim)
                        {
                            btndizisi[i].BackgroundImage = Image.FromFile("..\\Debug\\bos1.png"); // doluysa boşalt
                            btndizisi[i].BackgroundImageLayout = ImageLayout.Stretch;
                            btndizisi[i].Text = "";

                            btndizisi[i].BackColor = Color.White;

                        }

                    }
                }

            }

            else if ((sender as Button).Text == "   ") // 3 boşluk  seçileni boşalt
            {
                for (int i = 0; i < frm.listBox1.Items.Count; i++)
                {
                    if (frm.listBox1.Items[i].ToString() == (sender as Button).Name)
                    {
                        frm.listBox1.Items.RemoveAt(i);
                    }
                }
                
               
                (sender as Button).BackgroundImage = Image.FromFile("..\\Debug\\bos1.png");
                (sender as Button).Text = "";
                koltuksayisi1--;
                (sender as Button).BackColor = Color.White;
            }
            else 
            {
              //boş olanı seç
                if ( koltuksayisi1 < biletal.koltuksayisitiklanan)
                {
                kayitgiris.koltuknu = (sender as Button).Name;
                (sender as Button).BackColor = Color.Black; 
                (sender as Button).BackgroundImage = Image.FromFile("..\\Debug\\secilen1.png");
                (sender as Button).BackgroundImageLayout = ImageLayout.Stretch;
                (sender as Button).Text = "   ";
                frm.listBox1.Items.Add((sender as Button).Name);
                koltuksayisi1++;
               
                }
                else

                {
                    MessageBox.Show("Seçilen koltuk sayısı ile ücreti ödenecek koltuk sayısı eşleşmemektedir...");
                }

         }
   }
        
        
        public static int sayac = 1;

        public void filmsec(string sql, ComboBox combo)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            OleDbDataReader datareader;
            datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                combo.Text = datareader["salonid"].ToString();
            }


            baglanti.Close();
        }
        
        public void filmsec1(ComboBox combo)
        {

            baglanti.Open();
            string sqL = "SELECT filmid FROM film WHERE salonid='" + combo.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            OleDbDataReader dtrdr;
            dtrdr = cmd.ExecuteReader();
            while (dtrdr.Read())
            {
                combo.Text = dtrdr["filmid"].ToString();
            }

            baglanti.Close();
        }

        public void filmsec2(ComboBox combo)
        {
            combo.Items.Clear();
            baglanti.Open();
            string sqL = "SELECT seans_saati FROM seanslar WHERE filmid='" + combo.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            OleDbDataReader dtrdr;
            dtrdr = cmd.ExecuteReader();
            DateTime saat;
            while (dtrdr.Read())
            {
                saat = Convert.ToDateTime( dtrdr["seans_saati"]);
                combo.Items.Add(saat.ToShortTimeString());
            }

            baglanti.Close();
            combo.Text = " ";
        }

        public void filmadi(string sql, Label label)
        {

            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();

            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid1 + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string filmid1 = cmd1.ExecuteScalar().ToString();

            string filmadi = "SELECT filmleradi FROM film WHERE filmid='" + filmid1 + "'";
            OleDbCommand cmd2 = new OleDbCommand(filmadi, baglanti);
            string filmadi2 = cmd2.ExecuteScalar().ToString();
            label.Text = filmadi2;
            baglanti.Close();


        }


        public string filmadicek(string sqL)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            string geriDonus = cmd.ExecuteScalar().ToString();
            baglanti.Close();
            return geriDonus.ToString();
        }

        public void resimcek(string sql, PictureBox pc)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();
            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid1 + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string filmid1 = cmd1.ExecuteScalar().ToString();
            string filmadi = "SELECT  resimyol FROM film WHERE filmid='" + filmid1 + "'";
            OleDbCommand cmd2 = new OleDbCommand(filmadi, baglanti);
            string filmadi1 = cmd2.ExecuteScalar().ToString();
          
            Image Img = Image.FromFile(@filmadi1);
            pc.Image = Img;
            baglanti.Close();
        }


        public void resimcekv1(string salon,PictureBox pB)
        {
            baglanti.Open();
            string sqL = "select salonid from salonlar where salonadi='"+salon+"'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            string salonid = cmd.ExecuteScalar().ToString();
           
            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();

            string res = "SELECT resimyol FROM film WHERE filmid='" + salonid1 + "'";
            OleDbCommand cmd2 = new OleDbCommand(res, baglanti);
            string path = cmd2.ExecuteScalar().ToString ();
            pB.ImageLocation = path;
            baglanti.Close();

        }
        public void resimcekv2(string salon, PictureBox pB)
        {
            baglanti.Open();
            string sqL = "select salonid from salonlar where salonadi='" + salon + "'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            string salonid = cmd.ExecuteScalar().ToString();

            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();

            string res = "SELECT resimyol1 FROM film WHERE filmid='" + salonid1 + "'";
            OleDbCommand cmd2 = new OleDbCommand(res, baglanti);
            string path = cmd2.ExecuteScalar().ToString();
            pB.ImageLocation = path;
            baglanti.Close();

        }
        string path1;
         public void fragmancek(string salon )
        {
            baglanti.Open();
            string sqL = "select salonid from salonlar where salonadi='" + salon + "'";
            OleDbCommand cmd = new OleDbCommand(sqL, baglanti);
            string salonid = cmd.ExecuteScalar().ToString();

            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();

            string res = "SELECT fragmanyol FROM film WHERE filmid='" + salonid1 + "'";
            OleDbCommand cmd2 = new OleDbCommand(res, baglanti);
            string path = cmd2.ExecuteScalar().ToString();
            path1 = Application.StartupPath;
            frm1.wmp.URL = @"" + path1 + "\\" + path; 
           
             //  frm1.wmp.URL = path;
            baglanti.Close();

        }
        
        public void koltuk(ComboBox combo)
        {
            combo.Items.Clear();
            baglanti.Open();
            string koltukname = "select koltuknu from bilet where salonid= '" + filmseccs.salonidxx + "' and seansid= '" + filmseccs.seanslar + "' and filmid= '" + filmseccs.filmidxx + "'";
            OleDbCommand cmd = new OleDbCommand(koltukname, baglanti);
            OleDbDataReader dtrdr;
            dtrdr = cmd.ExecuteReader();
            string saat;
            while (dtrdr.Read())
            {
                saat = Convert.ToString(dtrdr["koltuknu"]);
                combo.Items.Add(saat);
            }

            baglanti.Close();
       
        }
        string bugunsaat, gun;
        public void seansyoket()
        {  string tarih  = frm1.dateTimePicker1.Value.ToString("dd.MM.yyyy");

          bugunsaat = DateTime.Now.ToShortTimeString();
            gun = DateTime.Now.ToShortDateString();
           
   

            if (Convert.ToDateTime(frm1.seans1.Text) < Convert.ToDateTime(bugunsaat) && tarih==gun)
            {
                frm1.seans1.BackColor = Color.Gray;
                frm1.seans1.Enabled = false;
            }
            if(Convert.ToDateTime(frm1.seans1.Text) > Convert.ToDateTime(bugunsaat)&& tarih==gun)
            { frm1.seans1.BackColor = Color.Gainsboro;
                frm1.seans1.Enabled = true;
            }
            if (Convert.ToDateTime(frm1.seans2.Text) < Convert.ToDateTime(bugunsaat) && tarih==gun)
            {
                frm1.seans2.BackColor = Color.Gray;
                frm1.seans2.Enabled = false;
            }
            if (Convert.ToDateTime(frm1.seans2.Text) > Convert.ToDateTime(bugunsaat)&& tarih==gun)
            {
                frm1.seans2.BackColor = Color.Gainsboro;
                frm1.seans2.Enabled = true;

            }
            if (Convert.ToDateTime(frm1.seans3.Text) < Convert.ToDateTime(bugunsaat)&& tarih== gun)
            {
                frm1.seans3.BackColor = Color.Gray;
                frm1.seans3.Enabled = false;
            }
            if (Convert.ToDateTime(frm1.seans3.Text) > Convert.ToDateTime(bugunsaat)&& tarih==gun)
            {
                frm1.seans3.BackColor = Color.Gainsboro;
                frm1.seans3.Enabled = true;

            }
            if (Convert.ToDateTime(frm1.seans4.Text) < Convert.ToDateTime(bugunsaat)&& tarih==gun)
            {
               frm1.seans4.BackColor = Color.Gray;
                frm1.seans4.Enabled = false;
            }
            if (Convert.ToDateTime(frm1.seans4.Text) > Convert.ToDateTime(bugunsaat)&& tarih== gun)
            {
                frm1.seans4.BackColor = Color.Gainsboro;
                frm1.seans4.Enabled = true;

            }
            if (Convert.ToDateTime(frm1.seans5.Text) < Convert.ToDateTime(bugunsaat)&& tarih==gun)
            {
                frm1.seans5.BackColor = Color.Gray;
               frm1.seans5.Enabled = false;
            }
            if (Convert.ToDateTime(frm1.seans5.Text) > Convert.ToDateTime(bugunsaat)&& tarih== gun)
            {
                frm1.seans5.BackColor = Color.Gainsboro;
                frm1.seans5.Enabled = true;

            }
            if (Convert.ToDateTime(frm1.seans6.Text) < Convert.ToDateTime(bugunsaat)&& tarih== gun)
            {
                frm1.seans6.BackColor = Color.Gray;
                frm1.seans6.Enabled = false;

            }
            if (Convert.ToDateTime(frm1.seans6.Text) > Convert.ToDateTime(bugunsaat) && tarih == gun)
            {
                frm1.seans6.BackColor = Color.Gainsboro;
                frm1.seans6.Enabled = true;

            }
            else if (Convert.ToDateTime(tarih) > Convert.ToDateTime( gun))
            {
                frm1.seans1.BackColor = Color.Gainsboro;
                frm1.seans1.Enabled = true;
                frm1.seans2.BackColor = Color.Gainsboro;
                frm1.seans2.Enabled = true;
                frm1.seans4.BackColor = Color.Gainsboro;
                frm1.seans4.Enabled = true;
                frm1.seans3.BackColor = Color.Gainsboro;
                frm1.seans3.Enabled = true;
                frm1.seans5.BackColor = Color.Gainsboro;
                frm1.seans5.Enabled = true;
                frm1.seans6.BackColor = Color.Gainsboro;
                frm1.seans6.Enabled = true;
            }

        }
        public void filmid(string sql)
        {

            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            string salonid1 = cmd.ExecuteScalar().ToString();

            string filmid = "SELECT filmid FROM film WHERE salonid='" + salonid1 + "'";
            OleDbCommand cmd1 = new OleDbCommand(filmid, baglanti);
            string filmid1 = cmd1.ExecuteScalar().ToString();

        }
       
       }
}