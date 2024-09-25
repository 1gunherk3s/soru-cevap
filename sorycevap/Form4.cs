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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip1.SetToolTip(pictureBox2, "Bu buton soruların ekrana gelmesini sağlar.\r\nProje default olarak ekranı boş açar, butona tıklamazsanız sorular gelmez.");
            toolTip1.SetToolTip(pictureBox1, "Tüm uygulamayı kapatır");

        }
    }
}
