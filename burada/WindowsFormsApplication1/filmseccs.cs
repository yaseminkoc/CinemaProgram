using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Imaging;


namespace WindowsFormsApplication1
{
    public partial class filmseccs : Form
    {
        public filmseccs()
        {
            InitializeComponent();
        }

        cls islem = new cls();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabaninimiz.accdb");
        int sayac = 0;
        public static string salonidxx, filmidxx;
     
        private void salon1_Click(object sender, EventArgs e)
        {
           
            salon1.Enabled = false;
            salon1.BackColor = Color.Maroon;
            salon2.Enabled = true;
            salon2.BackColor = Color.Black;
            salon3.Enabled = true;
            salon3.BackColor = Color.Black;
            salon4.Enabled = true;
            salon4.BackColor = Color.Black;
            salon5.Enabled = true;
            salon5.BackColor = Color.Black;
            sayac = 0;
            salon = "salon1";
            islem.resimcekv1("salon1", this.resimfilm);

            islem.fragmancek("salon1");
            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon1.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);

            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);
           islem.resimcek(salonid, this.resimfilm);
            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;
            }
           

            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }
            islem.seansyoket();
        }
        private void salon2_Click(object sender, EventArgs e)
        {
            salon = "salon2";
            islem.resimcekv1("salon2", this.resimfilm);
            islem.fragmancek("salon2");
            salon2.Enabled = false;
            salon2.BackColor = Color.Maroon;
            salon1.Enabled = true;
            salon1.BackColor = Color.Black;
            salon3.Enabled = true;
            salon3.BackColor = Color.Black;
            salon4.Enabled = true;
            salon4.BackColor = Color.Black;
            salon5.Enabled = true;
            salon5.BackColor = Color.Black;
            sayac = 0;

            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon2.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);
            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);

            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;
            }

           
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = i+1; j < dizi.Length; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }

            islem.seansyoket();
        }

        private void salon3_Click(object sender, EventArgs e)
        {
            salon = "salon3";

            islem.resimcekv1("salon3", this.resimfilm);
            islem.fragmancek("salon3");
            salon3.Enabled = false;
            salon3.BackColor = Color.Maroon;
            salon2.Enabled = true;
            salon2.BackColor = Color.Black;
            salon1.Enabled = true;
            salon1.BackColor = Color.Black;
            salon4.Enabled = true;
            salon4.BackColor = Color.Black;
            salon5.Enabled = true;
            salon5.BackColor = Color.Black;
            sayac = 0;
            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon3.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);
            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);
            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;

            }
           
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }

            islem.seansyoket();
        }
       
        private void salon4_Click(object sender, EventArgs e)
        {
            salon = "salon4";
           
            islem.resimcekv1("salon4", this.resimfilm);
            islem.fragmancek("salon4");
            salon4.Enabled = false;
            salon4.BackColor = Color.Maroon;
            salon2.Enabled = true;
            salon2.BackColor = Color.Black;
            salon3.Enabled = true;
            salon3.BackColor = Color.Black;
            salon1.Enabled = true;
            salon1.BackColor = Color.Black;
            salon5.Enabled = true;
            salon5.BackColor = Color.Black;
            sayac = 0;
            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon4.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);
            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);
            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;

            }
           
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }
            islem.seansyoket();
        }

        public static string filmadi;

        private void salon5_Click(object sender, EventArgs e)
        {
            salon = "salon5";
           

            islem.resimcekv1("salon5", this.resimfilm);
            islem.fragmancek("salon5");
            salon5.Enabled = false;
            salon5.BackColor = Color.Maroon;
            salon2.Enabled = true;
            salon2.BackColor = Color.Black;
            salon3.Enabled = true;
            salon3.BackColor = Color.Black;
            salon4.Enabled = true;
            salon4.BackColor = Color.Black;
            salon1.Enabled = true;
            salon1.BackColor = Color.Black;
            sayac = 0;

            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon5.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);
            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);
            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;

            }
           
            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }

            islem.seansyoket();
        }

        int[] seansid = new int[999];
        public static string salon = "";
        private void filmseccs_Load(object sender, EventArgs e)
        {
            salon = "salon1";
            timer1.Start();

            /* string seanslar = "select * from seanslar";
             islem.listele(seanslar, dataGridView2);
             this.dataGridView2.Sort(this.dataGridView2.Columns["seansid"], ListSortDirection.Descending);
          
            

             for (int i = 0; i < dataGridView2.RowCount - 1; i++)
             {

                 seansid[i] = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value.ToString());
             }

             for (int i = 0; i <dataGridView2.RowCount; i++)
             {
                 for (int k = 0; k <dataGridView2.RowCount; k++)
                 {
                     if (seansid[i] > seansid[k])
                     {
                         int tut = seansid[i];
                         seansid[i] = seansid[k];
                         seansid[k] = Convert.ToInt32(tut);
                     }
                 }
             }
             int kapasite = seansid[0];
             
             for (int i = 1; i <= kapasite; i++)
             {string seanstarih="select seans_tarihi from seanslar where seansid= '"+i+"'";
                 string gun = DateTime.Now.Day.ToString();
                 if (seanstarih>gun)
                 {
                     string yoket = "delete from seanslar where seansid='"+i+"'";
                    
                 }
                
             }
              */
            islem.resimcekv1("salon1", this.resimfilm);
            islem.fragmancek("salon1");
            salon1.Enabled = false;
            salon1.BackColor = Color.Maroon;
            salon2.Enabled = true;
            salon2.BackColor = Color.Black;
            salon3.Enabled = true;
            salon3.BackColor = Color.Black;
            salon4.Enabled = true;
            salon4.BackColor = Color.Black;
            salon5.Enabled = true;
            salon5.BackColor = Color.Black;
            sayac = 0;

            Button[] dizi = { seans1, seans2, seans3, seans4, seans5, seans6 };
            string salonid = "SELECT salonid FROM salonlar WHERE salonadi='" + salon1.Text + "'";
            islem.filmsec(salonid, comboBox1);
            salonidxx = comboBox1.Text;
            islem.filmadi(salonid, label1);
            islem.filmsec1(comboBox1);
            filmidxx = comboBox1.Text;
            islem.filmsec2(comboBox1);
            //islem.resimcek(salonid,pictureBox1);
            while (sayac <= comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = sayac;
                dizi[sayac].Text = comboBox1.SelectedItem.ToString();
                sayac++;

            }

            for (int i = 0; i < dizi.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Convert.ToDateTime(dizi[i].Text) < Convert.ToDateTime(dizi[j].Text))
                    {
                        string bos = dizi[i].Text;
                        dizi[i].Text = dizi[j].Text;
                        dizi[j].Text = bos;
                    }
                }
            }
            islem.seansyoket();

        }

        cls sinif = new cls();

        public static string seanslar;
        private void button1_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.pause();
            filmadi = label1.Text;
            filmbilgileri fi = new filmbilgileri();
            this.Hide();
            fi.Show();

        }
        public static string saat = " ";
      //  public static DateTime seans_saati; 
        private void seans1_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans1.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans1.Text;
            biletal fi = new biletal();
            fi.Show();
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
          //  seans_saati = Convert.ToDateTime(seans1.Text);
           

        }


        private void seans2_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans2.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans2.Text;
            biletal fi = new biletal();
            fi.Show();
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
           // seans_saati = Convert.ToDateTime(seans2.Text);
        }

        private void seans3_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans3.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans3.Text;
            biletal fi = new biletal();
          
            fi.Show();
           
            
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
         //   seans_saati = Convert.ToDateTime(seans3.Text);
        }

        private void seans4_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans4.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans4.Text;
            biletal fi = new biletal();
            fi.Show();
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
           // seans_saati = Convert.ToDateTime(seans4.Text);
        }

        private void seans5_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans5.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans5.Text;
            biletal fi = new biletal();
            fi.Show();
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
          //  seans_saati = Convert.ToDateTime(seans5.Text);
        }

        private void seans6_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            string seansidxx = " select seansid from seanslar where seans_saati = #" + seans6.Text + "#";
            sinif.listele(seansidxx, dataGridView1);
            seanslar = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            saat = seans6.Text;

            biletal fi = new biletal();
            fi.Show();
            kayitgiris fi1 = new kayitgiris();
            WindowsFormsApplication1.cls.frm = fi1;
            this.Hide();
            //seans_saati = Convert.ToDateTime(seans6.Text);
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            filmadi = label1.Text;
            filmbilgileri fi = new filmbilgileri();
            this.Hide();
            fi.Show();
        }
        int sn = 0;
        int x = -5, x1 = 952;

        private void timer1_Tick(object sender, EventArgs e)
        {
  
            sn++;

          if (sn < 190)
            {

                pictureBox1.Location = new Point(x, 466);
                pictureBox2.Location = new Point(x1, 466);

                x -= 5;
                x1 -= 5;
                
            }
             if (sn>=190)
             {
                x = 945;
               
                sn = 0;
                x1 =12;

            }


             
            
                
          }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string tarih = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            string gun = DateTime.Now.ToShortDateString();
            if (Convert.ToDateTime(tarih) < Convert.ToDateTime(gun))
            {
                MessageBox.Show("Geçmiş tarihe bilet alamazsınız...");
            }
            islem.seansyoket();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            kullanicigiris kl = new kullanicigiris();
          
            kl.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
    }
}

