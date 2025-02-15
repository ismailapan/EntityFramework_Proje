using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeDb
{
    public partial class FrmSifre : Form
    {
        public FrmSifre()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        Class1 bgl = new Class1();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar= true;
            }
        }
        private void PersonelGuncelleme()
        {
            int x = Convert.ToInt32(textBox1.Text);
            var pe = db.TBLPERSONEL.Find(x);
            pe.PERSONID = int.Parse(textBox1.Text);
            pe.PERSONADSOYAD = textBox2.Text;
            pe.PERSONSIFRE = int.Parse(textBox4.Text);
            db.SaveChanges();
            MessageBox.Show("Personel Şifre Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
                 ("Şifre Değişikliğini Onaylıyor Musunuz?",
                 "ONAY",
                 MessageBoxButtons.YesNo,MessageBoxIcon.Question
                 );
            if(result == DialogResult.Yes)
            {
                PersonelGuncelleme();
                MessageBox.Show("Şifreniz Değiştirildi","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Şifreniz Değiştirilemedi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void FrmSifre_Load(object sender, EventArgs e)
        {
            var per = (from x in db.TBLPERSONEL select new
            {
                x.PERSONID,
                x.PERSONADSOYAD,
            }).ToList();
            dataGridView1.DataSource=per;

            dataGridView1.Columns["PERSONID"].HeaderText = "SİCİL NO";
            dataGridView1.Columns["PERSONADSOYAD"].HeaderText = "AD-SOYAD";
        }
    }
}
