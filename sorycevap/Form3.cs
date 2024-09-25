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


namespace sorycevap
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=Billie\\SQLEXPRESS;Initial Catalog=SoruCevap;Integrated Security=True");

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblsoru", baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "SoruID") // "SoruID" sütunu dışındaki tüm sütunları gizle
                {
                    column.Visible = false;
                }
            }


            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from tblcevap", baglan);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Name != "CevapID") // "CevapID" sütunu dışındaki tüm sütunları gizle
                {
                    column.Visible = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutekle = new SqlCommand("insert into tblsoru (soru) values (@p1)", baglan);
            komutekle.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komutekle.ExecuteNonQuery();

            SqlCommand komutcevap = new SqlCommand("insert into tblcevap (CevapA,CevapB,CevapC,CevapD,DogruCevap) values(@p1,@p2,@p3,@p4,@p5)", baglan);
            komutcevap.Parameters.AddWithValue("@p1", textBox1.Text);
            komutcevap.Parameters.AddWithValue("@p2", textBox3.Text);
            komutcevap.Parameters.AddWithValue("@p3", textBox2.Text);
            komutcevap.Parameters.AddWithValue("@p4", textBox4.Text);
            komutcevap.Parameters.AddWithValue("@p5", textBox5.Text);
            komutcevap.ExecuteNonQuery();
            MessageBox.Show("Soru ve Cevaplar eklendi", "İyi eğlenceler.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            baglan.Open();  
            SqlCommand komutgüncelle = new SqlCommand("update tblsoru set soru = @p1 where SoruID = @p2", baglan);
            komutgüncelle.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komutgüncelle.Parameters.AddWithValue("@p2", label4.Text);
            komutgüncelle.ExecuteNonQuery();

            SqlCommand komutcevap = new SqlCommand("update tblcevap set CevapA = @p1, CevapB = @p2, CevapC = @p3, CevapD = @p4, DogruCevap = @p5 where cevapID = @p6", baglan);
            komutcevap.Parameters.AddWithValue("@p1", textBox1.Text);
            komutcevap.Parameters.AddWithValue("@p2", textBox3.Text);
            komutcevap.Parameters.AddWithValue("@p3", textBox2.Text);
            komutcevap.Parameters.AddWithValue("@p4", textBox4.Text);
            komutcevap.Parameters.AddWithValue("@p5", textBox5.Text);
            komutcevap.Parameters.AddWithValue("@p6", label3.Text);
            komutcevap.ExecuteNonQuery();
            MessageBox.Show("Seçtiğiniz soru ve cevaplar güncellenmiştir!", "Güncelleme bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            label4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }
       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            label3.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

            if (label3.Text == label4.Text)
            {
                textBox1.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
                textBox2.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
                textBox4.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
                textBox5.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz cevap, ilgili soruya ait değildir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult sorununcevabi = MessageBox.Show("Soruları güncellemek ister misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sorununcevabi == DialogResult.Yes)
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                button4.Visible = true;
                button7.Visible = false;
                Form5 fr = new Form5();
                fr.Show();

            }
            else if (sorununcevabi != DialogResult.Yes)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
