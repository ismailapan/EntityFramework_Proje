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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Class1 bgl = new Class1();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBLPERSONEL Where PERSONID=@p1 and PERSONADSOYAD=@p2 and PERSONSIFRE=@p3",bgl.Connection());
            komut.Parameters.AddWithValue("@p1",textBox3.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            komut.Parameters.AddWithValue("@p3",textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSatisYap fr = new FrmSatisYap();
                fr.adsoyad = textBox1.Text;
                fr.perno = int.Parse(textBox3.Text);
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRİLEN BİLGİLERDEN BİRİ YA DA BİRİLERİ YANLIŞTIR", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.Connection().Close();
        }
    }
}
