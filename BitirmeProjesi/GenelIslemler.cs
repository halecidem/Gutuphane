using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BitirmeProjesi
{
    class GenelIslemler
    {
        public bool SQLControl() //Sunucunun açık olduğunu kontrol eden fonksiyon
        {
            bool sunucuDurum = false;
            try
            {
                SqlConnection baglanti = new SqlConnection(@"Server=LAPTOP-J2VV6GEA\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;");
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
            SqlConnection baglanti = new SqlConnection(@"Server=LAPTOP-J2VV6GEA\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;");
            SqlCommand cmd1 = new SqlCommand("select KullaniciAdi from Kullanicilar where KullaniciAdi = " + kullaniciAdi, baglanti);
            SqlCommand cmd2 = new SqlCommand("select Sifre from Kullanicilar where KullaniciAdi = " + kullaniciAdi, baglanti);
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
                        sifre = reader2.GetString(0);
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
            return 0;
        }
            
    }
}
