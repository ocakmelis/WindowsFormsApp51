using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp51
{
    class SqlBaglantisi
    {
        public SqlConnection SqlBaglantiMetot()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=MusteriDB;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
