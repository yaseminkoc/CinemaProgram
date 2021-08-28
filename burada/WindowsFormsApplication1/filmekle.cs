using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class filmekle : Form
    {
        public filmekle()
        {
            InitializeComponent();
        }

        int silerseartir = 0;
        cls sinif = new cls();
       
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            DialogResult result = ac.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image bmpp3 = Bitmap.FromFile(ac.FileName);
                Bitmap kopyaa3 = new Bitmap(bmpp3);
               pcbresimekle.Image = kopyaa3;
                bmpp3.Dispose();
                string resimyeri = @"resimler\" +dtgfilm.RowCount.ToString()  + ".jpg";
                pcbresimekle.Image.Save(resimyeri, ImageFormat.Jpeg);
                txtresimyol.Text =   ac.FileName;
            }
          }
        int[] deneme = new int[999];
        int[] deneme2 = new int[999];
        private void btnekle_Click(object sender, EventArgs e)
        {
          

        }
        int[] deneme3 = new int[999];
       
        private void filmekle_Load(object sender, EventArgs e)
        { 
           
            axWindowsMediaPlayer1.Visible = false;
            string sql = "select * from film ";
            sinif.listele(sql, this.dtgfilm);
            string sql1 = "select * from seanslar ";
            sinif.listele(sql1, this.dtgseans);
            string sql2 = "select * from  kullanicibilgileri";
            sinif.listele(sql2, this.dtgkulbilgileri);


     
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open1 = new OpenFileDialog();
            open1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.dat;*.avi;*.wmv";
            open1.InitialDirectory = Application.StartupPath;
            open1.Title = "Dosya Seç";
            open1.ShowDialog();
            txtvideo.Text = open1.FileName;
            axWindowsMediaPlayer1.URL = txtvideo.Text;
            axWindowsMediaPlayer1.Visible = true;

        }

       

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            kullanicigiris kl = new kullanicigiris();
            kl.Show();
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.dtgfilm.Sort(this.dtgfilm.Columns["filmid"], ListSortDirection.Descending);
            this.dtgseans.Sort(this.dtgseans.Columns["seansid"], ListSortDirection.Descending);

            //   MessageBox.Show(dtgfilm.CurrentRow.Cells[0].Value.ToString ());

            for (int i = 0; i < dtgseans.RowCount - 1; i++)
            {

                deneme[i] = Convert.ToInt32(dtgseans.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 0; i < dtgseans.RowCount; i++)
            {
                for (int k = 0; k < dtgseans.RowCount; k++)
                {
                    if (deneme[i] > deneme[k])
                    {
                        int tut = deneme[i];
                        deneme[i] = deneme[k];
                        deneme[k] = tut;
                    }
                }
            }
            int seansid = deneme[0] + 1;



            for (int i = 0; i < dtgfilm.RowCount - 1; i++)
            {

                deneme2[i] = Convert.ToInt32(dtgfilm.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 0; i < dtgfilm.RowCount; i++)
            {
                for (int k = 0; k < dtgfilm.RowCount; k++)
                {
                    if (deneme2[i] > deneme2[k])
                    {
                        int tut = deneme2[i];
                        deneme2[i] = deneme2[k];
                        deneme2[k] = tut;
                    }
                }
            }
            int filmid = deneme2[0] + 1;

            try
            {
                //  MessageBox.Show(filmid.ToString ());
                string tarih = dateTimePicker1.Value.ToString("MM-dd-yyyy");

                string filmekle = "insert into film (filmid,filmleradi,filmtur,sure, salonid, resimyol , yerliyabanci,puan,konusu,fragmanyol,puanverenkisisayisi) values ('" + filmid + "','" + txtfilmadi.Text + "','" + cmdtur.Text + "', #" + txtfilmsure.Text + "# ,'" + cmbsalonid.Text + "','..\\\\Debug\\\\resimler\\\\" + filmid + ".jpg','" + cmbyerliyabanci.Text + "'," + txtpuan.Text + ",'" + txtfilmkonu.Text + "','fragmanlar\\" + filmid + " " + ".wmv',0)";

                sinif.calistir(filmekle);
                File.Copy(txtvideo.Text, Application.StartupPath + "\\fragmanlar\\" + filmid + " " + ".wmv");

                string seanstarihi = "insert into seanslar (seansid, seans_tarihi , filmid, seans_saati) values ('" + seansid + "',#" + tarih + "#,'" + filmid + "',#" + txtseanssaati.Text + "#)";
                sinif.calistir(seanstarihi);


                MessageBox.Show("FİLM EKLENMİŞTİR ");
                string sql = "select * from film ";
                sinif.listele(sql, this.dtgfilm);
                string sql1 = "select * from seanslar ";
                sinif.listele(sql1, this.dtgseans);
                string sql2 = "select * from  kullanicibilgileri";
                sinif.listele(sql2, this.dtgkulbilgileri);

                txtfilmadi.Text = "";
                cmdtur.Text = "";
                txtfilmsure.Text = "";
                txtseanssaati.Text = "";
                cmbsalonid.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                cmbyerliyabanci.Text = "";
                txtpuan.Text = "";
                txtvideo.Text = "";
                txtresimyol.Text = "";
                txtfilmkonu.Text = "";

            }

            catch
            {
                MessageBox.Show("BİLGİLERİ EKSİK YA DA HATALI GİRDİNİZ...");

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string filmidcek = "select filmid from film where filmleradi = '" + txtfilmadi.Text + "'";
            string a = sinif.filmadicek(filmidcek);
            string filmsil = "delete * from film where filmleradi = '" + txtfilmadi.Text + "'";
            sinif.calistir(filmsil);
            string seanssil = "delete * from seanslar where filmid = '" + a + "' and seans_saati = #" + txtseanssaati.Text + "#";
            sinif.calistir(seanssil);
            MessageBox.Show("film silindi :)");

            silerseartir++;
            string sql = "select * from film ";
            sinif.listele(sql, this.dtgfilm);
            string sql1 = "select * from seanslar ";
            sinif.listele(sql1, this.dtgseans);
            string sql2 = "select * from  kullanicibilgileri";
            sinif.listele(sql2, this.dtgkulbilgileri);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgkulbilgileri.RowCount - 1; i++)
            {

                deneme3[i] = Convert.ToInt32(dtgkulbilgileri.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 0; i < dtgkulbilgileri.RowCount; i++)
            {
                for (int k = 0; k < dtgkulbilgileri.RowCount; k++)
                {
                    if (deneme3[i] > deneme3[k])
                    {
                        int tut = deneme3[i];
                        deneme3[i] = deneme3[k];
                        deneme3[k] = tut;
                    }
                }
            }
            int kullid = deneme3[0] + 1;
            try
            {


                string tarih = dateTimePicker2.Value.ToString("MM-dd-yyyy");
               
                if (txtsifre.Text == txtsifreonayla.Text && txtkuladi.Text != "" && txtkulsoyad.Text != "" && txttc.Text != "" && dateTimePicker2.Text != "" && txtkullaniciadi.Text != "" && txtsifre.Text != "" && txtsifreonayla.Text != "")
                {
                    string sql = "insert into kullanicibilgileri(kullaniciid,adi,soyadi,TC,dogum_tarihi) values('" + kullid + "','" + txtkuladi.Text + "','" + txtkulsoyad.Text + "','" + txttc.Text + "',#" + tarih + "#)";
                    sinif.calistir(sql);
                    string sql2 = "insert into kulanicigiris(kullaniciid,kullanici_adi,sifre) values('" + kullid + "','" + txtkullaniciadi.Text + "','" + txtsifre.Text + "')";
                    sinif.calistir(sql2);
                    MessageBox.Show("KAYIT BAŞARIYLA EKLENDİ");
                }
               
                else if (txtkuladi.Text == "" || txtkulsoyad.Text == "" || txttc.Text == "" || dateTimePicker2.Text == "" || txtkullaniciadi.Text == "" || txtsifre.Text == "" || txtsifreonayla.Text == "")
                {
                    MessageBox.Show("Hata ! Hiçbir alan boş geçilemez!");
                    string sql3 = "select * from  kullanicibilgileri";
                    sinif.listele(sql3, this.dtgkulbilgileri);
                }
                else if (txtsifre.Text != txtsifreonayla.Text)
                {

                    MessageBox.Show("şifreler eşleşmiyor");
                }

               

                string sql4 = "select * from  kullanicibilgileri";
                sinif.listele(sql4, this.dtgkulbilgileri);

            }
            catch (Exception)
            {
                MessageBox.Show("HATA! KULLANICI KAYIT EDİLEMEDİ");
                string sql5 = "select * from  kullanicibilgileri";
                sinif.listele(sql5, this.dtgkulbilgileri);

            }

            finally
            {
                string sql6 = "select * from  kullanicibilgileri";
                sinif.listele(sql6, this.dtgkulbilgileri);
            }
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            filmseccs f1 = new filmseccs();
            cls.frm1 = f1;
            f1.Show();
            WindowsFormsApplication1.cls.frm1 = f1;
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            kullanicigiris kl = new kullanicigiris();
            kl.Show();
            this.Close();
            
        }

        
             
         
       
      

       

       
}
}


       


            
         
        

       

       

      
       

