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
    public partial class FrmHareketlercs : Form
    {
        public FrmHareketlercs()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmHareketlercs_Load(object sender, EventArgs e)
        {
            var satislar = (from x in db.TBLSATISLAR select new
            {
                x.SATISID,
                x.TBLURUNLER.URUNAD,
                MUSTERI = x.TBLMUSTERI.MUSTERIAD+" "+x.TBLMUSTERI.MUSTERISOYAD,
                x.FIYAT,
                x.ADET
            }).ToList();
            dataGridView1.DataSource = satislar;
            dataGridView1.Columns["SATISID"].HeaderText = "Satış Numarası";
            dataGridView1.Columns["URUNAD"].HeaderText = "Ürün Adı";
            dataGridView1.Columns["FIYAT"].HeaderText = "Fiyat Bilgisi";
            dataGridView1.Columns["ADET"].HeaderText = "Adet Bilgisi";
            dataGridView1.Columns["MUSTERI"].HeaderText = "Müşteri Ad-Soyad";
        }
    }
}
