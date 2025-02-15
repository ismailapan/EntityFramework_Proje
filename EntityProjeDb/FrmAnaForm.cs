using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeDb
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrunler fr = new FrmUrunler();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMusteriler fr = new FrmMusteriler();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSatislar fr = new FrmSatislar();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PersonelBil fr = new PersonelBil();
            fr.Show();
        }
    }
}
