using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;// Lislteleme yaparken datatable veri tipine ulaşmak için. ekledik....
namespace WindowsFormsApp51.Class
{
    class TB_Musteriler //1
    {
        SqlBaglantisi SqlBaglantisi = new SqlBaglantisi();
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string MusteriAdres { get; set; }

        public bool MusteriEkle(string MusteriAdi,string MusteriSoyadi,string MusteriAdres)
        {
            SqlCommand MusteriEkleme = new SqlCommand("INSERT INTO TB_Musteriler (MusteriAdi,MusteriSoyadi,MusteriAdres) VALUES (@P1,@P2,@P3)", SqlBaglantisi.SqlBaglantiMetot());
            MusteriEkleme.Parameters.AddWithValue("@P1", MusteriAdi);
            MusteriEkleme.Parameters.AddWithValue("@P2", MusteriSoyadi);
            MusteriEkleme.Parameters.AddWithValue("@P3", MusteriAdres);
            MusteriEkleme.ExecuteNonQuery();
            return true;
        }

        public DataTable MusteriListeleme()
        {
            SqlDataAdapter MusteriListele = new SqlDataAdapter("SELECT * FROM TB_Musteriler", SqlBaglantisi.SqlBaglantiMetot());
            DataTable dt = new DataTable(); 
            MusteriListele.Fill(dt);
            return dt;
        }

        public bool MusteriGuncelle(int MusteriID,string MusteriAdi, string MusteriSoyadi, string MusteriAdres)
        {
            SqlCommand MusteriGuncel = new SqlCommand("UPDATE TB_Musteriler SET MusteriAdi = @P1, MusteriSoyadi=@P2 , MusteriAdres=@P3 WHERE MusteriID=@P4 ", SqlBaglantisi.SqlBaglantiMetot());
            MusteriGuncel.Parameters.AddWithValue("@P1", MusteriAdi);
            MusteriGuncel.Parameters.AddWithValue("@P2", MusteriSoyadi);
            MusteriGuncel.Parameters.AddWithValue("@P3", MusteriAdres);
            MusteriGuncel.Parameters.AddWithValue("@P4", MusteriID);
            MusteriGuncel.ExecuteNonQuery();
            return true;
        }

        public bool MusteriSil(int MusteriID)
        {
            SqlCommand MusteriSilme = new SqlCommand("DELETE FROM TB_Musteriler WHERE MusteriID=@P1", SqlBaglantisi.SqlBaglantiMetot());
            MusteriSilme.Parameters.AddWithValue("@P1", MusteriID);
            MusteriSilme.ExecuteNonQuery();
            return true;
        }
    }
}
