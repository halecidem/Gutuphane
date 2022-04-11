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
        SqlConnection baglanti = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;");
        public bool SQLControl() //Sunucunun açık olduğunu kontrol eden fonksiyon
        {
            bool sunucuDurum = false;
            try
            {
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

        public int Giris(string kullaniciAdi, string sifre) //Giriş yapmak için kullanılan algoritma
        {
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

        public int Kayit(string kullaniciAdi, string sifre, string eposta, string adi, string soyadi, DateTime dogumTarihi, long telno )
        {
            int no1, no2;
            for (int i = 0; i < 6; i++)
            {
                no1[i] = telno[i];
            }
            for (int i = 0; i < 4; i++)
            {
                no1[i] = telno[i + 6];
            }

            SqlCommand cmd = new SqlCommand("insert into Kullanicilar (KullaniciAdi, Sifre, E-Posta, Adi, Soyadi, [Dogum Tarihi], NO1, NO2 [Kayit Tarihi], Yetki)" +
                "values (@ka, @si, @ep, @a, @so, @dt, @no1, @no2, @kt, @yt)", baglanti);
            cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
            cmd.Parameters.AddWithValue("@si", sifre);
            cmd.Parameters.AddWithValue("@ep", eposta);
            cmd.Parameters.AddWithValue("@a", adi);
            cmd.Parameters.AddWithValue("@so", soyadi);
            cmd.Parameters.AddWithValue("@dt", dogumTarihi);
            cmd.Parameters.AddWithValue("@no1", no1);
            cmd.Parameters.AddWithValue("@no2", no2);
            cmd.Parameters.AddWithValue("@kt", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@yt", "Kullanici");

            baglanti.Open();

            baglanti.Close();
            return 0;
        }
    }
}
