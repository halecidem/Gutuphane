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
        SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;");
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
                baglanti.Close();
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
                cmd1.Dispose();
                baglanti.Close();
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
                    cmd2.Dispose();
                    baglanti.Close();
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
        }

        public int Kayit(string kullaniciAdi, string sifre, string eposta, string adi, string soyadi, DateTime dogumTarihi, long telno )
        {
            string numara, strNo1, strNo2, kontrolStr = "";
            int no1, no2;
            numara = telno.ToString();
            strNo1 = numara.Substring(0, 6);
            strNo2 = numara.Substring(7, 3);
            no1 = Convert.ToInt32(strNo1);
            no2 = Convert.ToInt32(strNo2);

            SqlCommand cmd = new SqlCommand("insert into Kullanicilar (KullaniciAdi, Sifre, [E-Posta], Adi, Soyadi, [Dogum Tarihi], NO1, NO2, [Kayit Tarihi], Yetki)" +
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

            SqlCommand kullaniciKontrol = new SqlCommand("select KullaniciAdi from Kullanicilar where KullaniciAdi = @ka", baglanti);
            kullaniciKontrol.Parameters.AddWithValue("@ka", kullaniciAdi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = kullaniciKontrol.ExecuteReader();

                while(reader.Read())
                {
                    kontrolStr = reader.GetString(0);
                }

                reader.Close();
                kullaniciKontrol.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return 0;
            }

            if (kontrolStr == "")
            {
                try
                {
                    baglanti.Open();
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    baglanti.Close();

                    return 1;
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public string AdiNe(string kullaniciAdi)
        {
            string adi = "";

            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where KullaniciAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", kullaniciAdi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    adi = reader.GetString(4) + " " + reader.GetString(5);
                }
                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                return adi;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmd.Dispose();
                baglanti.Close();
                return "";
            }
        }

        public void ProfilBilgileri(string kullaniciAdi, Label lblAdi, Label lblSoyadi, Label lblEposta, Label lblKayitTarihi)
        {
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where KullaniciAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", kullaniciAdi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lblAdi.Text = reader.GetString(4);
                    lblSoyadi.Text = reader.GetString(5);
                    lblEposta.Text = reader.GetString(3);
                    lblKayitTarihi.Text = reader.GetDateTime(9).ToString();
                }
                cmd.Dispose();
                reader.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmd.Dispose();
                baglanti.Close();
            }
        }
    }
}