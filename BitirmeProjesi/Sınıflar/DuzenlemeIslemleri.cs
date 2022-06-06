using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BitirmeProjesi
{
    internal class DuzenlemeIslemleri
    {
        SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;");

        public void DuzenleBilgileri(string KitapAdi, string YazarAdi, PictureBox resimKutusu, TextBox txtKitapAdi, ComboBox txtKitapTuru, TextBox txtKitapKonusu, TextBox txtEtiketler)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KitapAdi = @ka and KullaniciAdi = @ya", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);

            string Etiketler = "";

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtKitapAdi.Text = reader.GetString(2);
                    txtKitapTuru.Text = reader.GetString(3);
                    txtKitapKonusu.Text = reader.GetString(4);
                    Etiketler = reader.GetString(6);
                }

                txtEtiketler.Text = Etiketler;

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
            }
        }
    }
}
