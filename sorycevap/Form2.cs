using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorycevap
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();

            Form4 fr1 = new Form4();
            fr1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
            this.Hide();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Soru cevaplama ekranına gider");
            toolTip2.SetToolTip(button2, "Soru yazma ekranına gider");
        }
    }
}
