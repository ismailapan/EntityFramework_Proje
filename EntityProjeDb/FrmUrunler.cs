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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var urunler  = (from x in db.TBLURUNLER select new
            {
                x.URUNID,
                x.URUNAD,
                x.MARKA,
                x.STOK,
                x.FIYAT,
                x.DURUM,
                x.TBLKATEGORI.AD
            }).ToList();
            dataGridView1.DataSource = urunler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBLURUNLER t = new TBLURUNLER();
            t.URUNAD=textBox2.Text;
            t.MARKA=textBox3.Text;
            t.STOK=short.Parse(textBox4.Text);
            t.FIYAT=decimal.Parse(textBox5.Text);
            t.DURUM=true;
            t.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            db.TBLURUNLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Belirtlen ürün eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text); 
            var urun = db.TBLURUNLER.Find(x);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Belirlenen ürün silindi", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urn = db.TBLURUNLER.Find(x);
            urn.URUNAD = textBox2.Text;
            urn.MARKA = textBox3.Text;
            urn.STOK = short.Parse(textBox4.Text);
            urn.FIYAT = decimal.Parse(textBox5.Text);
            db.SaveChanges();
            MessageBox.Show("Seçilen ürün bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            var kategoriler =(from x in db.TBLKATEGORI
                              select new
                              {

                                  x.ID,
                                  x.AD

                              }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }

        
    }
}
