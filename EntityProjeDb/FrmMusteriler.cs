using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeDb
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLMUSTERI select new
            {
                x.MUSTERIID,
                x.MUSTERIAD,
                x.MUSTERISOYAD,
                x.SEHIR
            }).ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TBLMUSTERI t = new TBLMUSTERI();
            t.MUSTERIAD = textBox1.Text;
            t.MUSTERISOYAD = textBox2.Text;
            t.SEHIR = textBox3.Text;
            db.TBLMUSTERI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Müşteri Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox4.Text);
            var musteri = db.TBLMUSTERI.Find(x);
            musteri.MUSTERIAD = textBox1.Text;
            musteri.MUSTERISOYAD = textBox2.Text;
            musteri.SEHIR = textBox3.Text;
            db.SaveChanges();
            MessageBox.Show("Seçilen müşteri bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox4.Text);
            var mus = db.TBLMUSTERI.Find(x);
            db.TBLMUSTERI.Remove(mus);
            db.SaveChanges();
            MessageBox.Show("Belirlenen müşteri bilgisi silindi", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
