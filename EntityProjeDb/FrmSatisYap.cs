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
    public partial class FrmSatisYap : Form
    {
        public FrmSatisYap()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        public string adsoyad;
        public int perno;
        private void button1_Click(object sender, EventArgs e)
        {
            TBLSATISLAR t = new TBLSATISLAR();
           // t.SATISID = int.Parse(textBox1.Text);
            t.URUN = int.Parse(comboBox1.SelectedValue.ToString());
            t.MUSTERI = int.Parse(comboBox2.SelectedValue.ToString());
            t.FIYAT = decimal.Parse(textBox4.Text);
            t.ADET = int.Parse(textBox5.Text);
            db.TBLSATISLAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Belirtilen satış bilgisi kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmSatisYap_Load(object sender, EventArgs e)
        {
            label9.Text = adsoyad.ToUpper();
            label10.Text = perno.ToString();

           var urunler = (from x in db.TBLURUNLER select new
           {
               x.URUNID,
               x.URUNAD
           }).ToList();
            comboBox1.ValueMember = "URUNID";
            comboBox1.DisplayMember = "URUNAD";
            comboBox1.DataSource = urunler;

            var musteriler = (from x in db.TBLMUSTERI
                              select new
                              {
                                  x.MUSTERIID,
                                  adsoyad = x.MUSTERIAD+" "+x.MUSTERISOYAD
                              }).ToList();
            comboBox2.ValueMember = "MUSTERIID";
            comboBox2.DisplayMember = "adsoyad";
            comboBox2.DataSource = musteriler;
        }
    }
}
