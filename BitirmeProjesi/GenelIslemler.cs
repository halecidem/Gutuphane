using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace BitirmeProjesi
{
    class GenelIslemler
    {
        public bool SQLControl() //Sunucunun açık olduğunu kontrol eden fonksiyon
        {
            bool sunucuDurum = false;
            try
            {
                SqlConnection baglanti = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;");
                baglanti.Open();
                sunucuDurum = true;
                baglanti.Close();
            }
            catch
            {
                //sunucuDurum = false;
            }
            return sunucuDurum;
        }

        public int Giris(string kullaniciAdi, string sifre)
        {
            SqlConnection baglanti = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;");
            SqlCommand cmd1 = new SqlCommand("select KullaniciAdi from Kullanicilar where KullaniciAdi = @user", baglanti);
            cmd1.Parameters.AddWithValue("@user", kullaniciAdi);
            SqlCommand cmd2 = new SqlCommand("select Sifre from Kullanicilar where KullaniciAdi = @user", baglanti);
            cmd2.Parameters.AddWithValue("@user", kullaniciAdi);
            string kullanici = "", sifresi = "";

            try
            {
                baglanti.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    kullanici = reader1.GetString(0);
                }

                reader1.Close();
                cmd1.Dispose();
                baglanti.Close();
            }
            catch
            {
                return 1;
            }

            if (kullanici != "" && kullanici == kullaniciAdi)
            {
                try
                {
                    baglanti.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        sifresi = reader2.GetString(0);
                    }

                    reader2.Close();
                    cmd2.Dispose();
                    baglanti.Close();
                }
                catch
                {
                    return 2;
                }
            }

            if (kullanici == kullaniciAdi && sifresi == sifre)
            {
                return 3;
            }
            else if (kullanici == kullaniciAdi && sifresi != sifre)
            {
                return 4;
            }
            else
            {
                return 5;
            }
            return 0;
        }
    }
}
