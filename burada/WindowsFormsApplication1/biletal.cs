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
    public partial class biletal : Form
    {
        public biletal()
        {
            InitializeComponent();
        }
  int fiyat1 = 0, fiyat2 = 0, ogrkisi = 0, tamkisi = 0;

  int biletpara = 0;


  filmseccs filmsec = new filmseccs();
  public static string ad, soyad, telnu, secilenfilm, seansimiz, fiyatt;
        
        public static int koltuksayisitiklanan = 0;
       
        cls vtislem = new cls();
        private void biletal_Load(object sender, EventArgs e)
        {

            string sqlfilm = "select filmleradi from film where filmid= '" + filmseccs.filmidxx + "'";
            txtfilmadi.Text = vtislem.filmadicek(sqlfilm);
            txtseans.Text = filmseccs.saat;
          

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button6_Click_1(object sender, EventArgs e)
        {
            koltuksayisitiklanan++;
            biletpara++;
            ogrkisi++;
            label22.Text = ogrkisi.ToString();

            fiyat1 = (ogrkisi * 5);
            label24.Text = (fiyat1 + fiyat2).ToString();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            koltuksayisitiklanan--;
            biletpara++;
            if (ogrkisi > 0)
            {
                ogrkisi--;
            }
            label22.Text = ogrkisi.ToString();

            fiyat1 = (ogrkisi * 5);
            label24.Text = (fiyat1 + fiyat2).ToString();


        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            koltuksayisitiklanan++;
            biletpara++;

            tamkisi++;
            label23.Text = tamkisi.ToString();
            fiyat2 = (tamkisi * 10);
            label24.Text = (fiyat1 + fiyat2).ToString();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            koltuksayisitiklanan--;

            biletpara++;
            if (tamkisi > 0)
            {
                tamkisi--;
            }
            label23.Text = tamkisi.ToString();
            fiyat2 = (tamkisi * 10);
            label24.Text = (fiyat1 + fiyat2).ToString();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            filmseccs flc = new filmseccs();
            flc.Show();
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (txttelnu.Text == "" || txtsoyisim.Text == "" || txtisim.Text == "")
            {
                MessageBox.Show("HİÇBİR VERİ BOŞ GEÇİLEMEZ !");
            }
            else if (koltuksayisitiklanan == 0)
            {
                MessageBox.Show("Lütfen bir koltuk seçiniz...");
            }
            else
            {
                ad = txtisim.Text;
                soyad = txtsoyisim.Text;
                telnu = txttelnu.Text;
                secilenfilm = txtfilmadi.Text;
                seansimiz = txtseans.Text;
                fiyatt = label24.Text;


                cls.frm.Show();
                this.Hide();
            }

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            kayitgiris kyt = new kayitgiris();
            kyt.Show();
            this.Hide();
        }

      

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        

      
        

       
    }
}
