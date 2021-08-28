using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class kayitgiris : Form
    {
        public kayitgiris()
        {
            InitializeComponent();
          
        }
       
        public static biletal blt;
        cls vtislem = new cls();
        private void button5_Click(object sender, EventArgs e)
        {
            filmseccs fs = new filmseccs();
            fs.Show();
            this.Hide();
        }
        public static string koltuknu = "",koltuknu1="";
        string[] dizi = new string[49];
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veritabaninimiz.accdb");
        Button[] btndizisi = new Button[49];
     
        private void kayitgiris_Load(object sender, EventArgs e)
        {
           
           vtislem.btnOlustur(this, "Salon1");
            vtislem.koltuk(combo);
            vtislem.koltukDoldur(combo);
            
        }
        filmseccs filmsec = new filmseccs();

        public static string koltuklar = "";
        

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            biletal flm = new biletal();
            flm.Show();
            this.Close();
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           if (cls.koltuksayisi1 != biletal.koltuksayisitiklanan)
            {
                MessageBox.Show("Seçilen koltuk sayısı ile ücreti ödenecek koltuk sayısı eşleşmemektedir...");
            }
            else if (cls.koltuksayisi1 == 0)
            {
                MessageBox.Show("Lütfen bir koltuk seçiniz...");
            }
            else
            {
              string tarih = filmsec.dateTimePicker1.Value.ToString("MM-dd-yyyy");

                string[] biletnu = new string[1000];

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    biletnu[i] = listBox1.Items[i].ToString();
                }

               for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    koltuklar = listBox1.Items[i] + "-" + koltuklar;
                    string sql = "insert into bilet(filmid,film_adi, salonid,seansid,tarih,koltuknu, musteriadi, musterisoyadi, fiyat, tel_nu,seans_saati) values('" + filmseccs.filmidxx + "','" + biletal.secilenfilm + "','" + filmseccs.salonidxx + "','" + filmseccs.seanslar + "', #" + tarih + "#,'" + listBox1.Items[i] + "','" + biletal.ad + "','" + biletal.soyad + "'," + biletal.fiyatt + ",'" + biletal.telnu + "',#" + biletal.seansimiz + "#)";
                    vtislem.calistir(sql);
                 }
                MessageBox.Show("BİLET SATILDI...");
                vtislem.koltuk(combo);
                vtislem.koltukDoldur(combo);

                bilet bilet = new bilet();
                bilet.Show();
                this.Hide();

            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
       

        
        



        }

     

    }

