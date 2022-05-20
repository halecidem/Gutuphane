using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BitirmeProjesi
{
    internal class KitapIslemleri
    {
        SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;");

        public int KitapPaylas(string KullaniciAdi, string KitapAdi, string Icerik)
        {
            SqlCommand cmd = new SqlCommand("insert into Kitaplar (KullaniciAdi, KitapAdi, KitapIcerigi) values (@ka, @kit, @ic)", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            cmd.Parameters.AddWithValue("@kit", KitapAdi);
            cmd.Parameters.AddWithValue("@ic", Icerik);

            try
            {
                baglanti.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

    }
}
