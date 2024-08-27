using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp51
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class.TB_Musteriler tB_Musteriler = new Class.TB_Musteriler();
        private void btnKaydet_Click(object sender, EventArgs e)
        { 
            if(txttxtMusteriAdres.Text !="" && txtMusteriAdi.Text !="" && txtMusteriSoyadi.Text !="")
            {
                tB_Musteriler.MusteriEkle(txtMusteriAdi.Text, txtMusteriSoyadi.Text, txttxtMusteriAdres.Text);
                MessageBox.Show("Ekleme İşlemi Geçerli!");
                /*  
                 *  veya
                 *  
                if (tB_Musteriler.MusteriEkle(txtMusteriAdi.Text, txtMusteriSoyadi.Text, txttxtMusteriAdres.Text))
                {
                    MessageBox.Show("Ekleme İşlemi Geçerli!");
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Başarısız.");
                }*/
            }
            else
            {
                MessageBox.Show("Boş Bıraktığınız yerleri doldrunuz!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tB_Musteriler.MusteriListeleme();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int MusteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            tB_Musteriler.MusteriGuncelle(MusteriID, txtMusteriAdi.Text, txtMusteriSoyadi.Text, txttxtMusteriAdres.Text);
            MessageBox.Show("Müşteri Başarıyla Güncellendi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMusteriSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttxtMusteriAdres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int MusteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            tB_Musteriler.MusteriSil(MusteriID);
            MessageBox.Show("Müşteri Silindi!");
            dataGridView1.DataSource = tB_Musteriler.MusteriListeleme();
        }
    }
}