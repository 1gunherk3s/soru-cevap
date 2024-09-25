using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace sorycevap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SqlConnection baglan = new SqlConnection("Data Source=Billie\\SQLEXPRESS;Initial Catalog=SoruCevap;Integrated Security=True");
       SqlConnection baglan = new SqlConnection(" Data Source = Billie\\SQLEXPRESS;Initial Catalog = SoruCevap; Integrated Security = True; ");
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label1.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;



        }

        //int = secilensoruid = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

            baglan.Open();
            SqlCommand sifirla = new SqlCommand("update tblsoru set kullanildi = 0", baglan);
            sifirla.ExecuteNonQuery();
            baglan.Close();
        }

        int sorus = 0;
        int sorusayi = 0;
        int sorusec;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Butona basınca form üzerinde değişenler
            sorus = sorus + 1;
            label2.Text = sorusec.ToString();
            label1.Visible=true;
            label1.MaximumSize = new Size(panel1.Width, 0); 
            label1.TextAlign = ContentAlignment.TopLeft;
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button6.Enabled = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            sorusayi++;
            label9.Text = sorusayi.ToString();
            //int sorusec;

            //soruların sql'den çekilmesi
            baglan.Open();
            SqlCommand komutsoru = new SqlCommand("SELECT TOP 1 SoruID, soru FROM tblsoru where Kullanildi = 0 ORDER BY NEWID();", baglan);
            SqlDataReader soruyazdir = komutsoru.ExecuteReader();

            while (soruyazdir.Read())
            {
                label1.Text = soruyazdir[1].ToString();
                sorusec = (int)soruyazdir[0];
                label2.Text = sorusec.ToString();   
                
            }
            baglan.Close();

            // Random seçilen sorular arasından aynı soruları seçmemesi için
            baglan.Open();
            SqlCommand soruyutekrarcekme = new SqlCommand("update tblsoru set kullanildi = 1 where SoruID = @p1", baglan);
            soruyutekrarcekme.Parameters.AddWithValue("@p1", label2.Text);
            soruyutekrarcekme.ExecuteNonQuery();
            baglan.Close();

            // Soru sayısından daha fazla bir soru açılmaya çalışırsa uyarı versin!
            baglan.Open();
            SqlCommand maxIdKomut = new SqlCommand("select MAX(SoruID) from tblsoru", baglan);
            int maxSoruID = Convert.ToInt32(maxIdKomut.ExecuteScalar());

            if (sorus > maxSoruID)
            {
                MessageBox.Show("Daha fazla soru yok!", "Soru sınırı aşıldı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                
                

            }

            if(sorus > maxSoruID)
            {
                linkLabel1.Visible = true;
                pictureBox4.Visible = true;
            }
            if(dogrusayi > maxSoruID / 2)
            {
                zekaseviye = "Bir şeyler biliyorsun.";
            }
            else if (dogrusayi < maxSoruID / 2)
            {
                zekaseviye = "Kendi yazdığın soruları çözemiyor musun?";
                    
            }
            

            baglan.Close();

            // Cevapların label'a çekilmesi
            baglan.Open();
            SqlCommand komutcevap = new SqlCommand("select CevapA,CevapB,CevapC,CevapD,DogruCevap from tblcevap where CevapID = @p1", baglan);
            komutcevap.Parameters.AddWithValue("@p1", label2.Text);
            SqlDataReader cevapyaz = komutcevap.ExecuteReader();
            while(cevapyaz.Read())
            {
                label5.Text = cevapyaz[0].ToString();
                label6.Text = cevapyaz[1].ToString();
                label7.Text = cevapyaz[2].ToString();
                label8.Text = cevapyaz[3].ToString();
                label3.Text = cevapyaz[4].ToString();
            }
            baglan.Close();

            cevapdogru = label3.Text;

        }

        public string cevapdogru, zekaseviye;
        public int dogrusayi, yanlissayi;

        private void button2_Click(object sender, EventArgs e)
        {
            sorus = sorus++;
            if (label7.Text == cevapdogru)
            {
                MessageBox.Show("cevap dogru!");
                dogrusayi++;
            }
            else
            {
                MessageBox.Show("cevap yanlis!");
                yanlissayi++;
            }
            button2.Enabled = false;
            button1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sorus = sorus++;
            if (label5.Text == cevapdogru)
            {
                MessageBox.Show("cevap dogru!");
                dogrusayi++;
            }
            else
            {
                MessageBox.Show("cevap yanlis!");
                yanlissayi++;
            }
            button1.Enabled=false;  
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sorus = sorus++;
            if (label6.Text == cevapdogru)
            {
                MessageBox.Show("cevap dogru!");
                dogrusayi++;
            }
            else
            {
                MessageBox.Show("cevap yanlis!");
                yanlissayi++;        
            }

            button5.Enabled=false;
            button1.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Close();

            baglan.Open();
            SqlCommand sifirla = new SqlCommand("update tblsoru set kullanildi = 0", baglan);
            sifirla.ExecuteNonQuery();
            baglan.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Dogru sayınız: " + dogrusayi + "\n" + "Yanlıs Sayınız: " + yanlissayi + "\n" + "Zeka Baremi: " + zekaseviye);

            baglan.Open();
            SqlCommand sifirla = new SqlCommand("update tblsoru set kullanildi = 0", baglan);
            sifirla.ExecuteNonQuery();
            baglan.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sorus = sorus++;
            if (label8.Text == cevapdogru)
            {
                MessageBox.Show("cevap dogru!");
                dogrusayi++;
            }
            else
            { 
                MessageBox.Show("cevap yanlis!");
                yanlissayi++;
            }
            button6.Enabled= false; 
            button1.Enabled = false;
            button5.Enabled = false;
            button2.Enabled = false;

        }
    }
}
