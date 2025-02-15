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
    public partial class PersonelBil : Form
    {
        public PersonelBil()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void PersonelBil_Load(object sender, EventArgs e)
        {
            var personel = (from x in db.TBLPERSONEL select new
            {
                x.PERSONID,
                x.PERSONADSOYAD,
                x.PERSONSEHIR
            }).ToList();
            dataGridView1.DataSource = personel;
            dataGridView1.Columns["PERSONID"].HeaderText = "PERSONEL NUMARASI";
            dataGridView1.Columns["PERSONADSOYAD"].HeaderText = "ADI-SOYADI";
            dataGridView1.Columns["PERSONSEHIR"].HeaderText = "ŞEHİR";

            var per = (from x in db.TBLSEHIRLER select new
            {
                x.SEHIRAD
            }).ToList();
            comboBox1.ValueMember = "PLAKA";
            comboBox1.DisplayMember = "SEHIRAD".ToUpper();
            comboBox1.DataSource = per;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifre fr = new FrmSifre();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.PERSONADSOYAD = textBox1.Text;
            t.PERSONSEHIR = comboBox1.Text;
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Kaydı Tamamlandı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
