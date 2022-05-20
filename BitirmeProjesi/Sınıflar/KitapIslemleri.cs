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

        public void KisininKitaplari(string KullaniciAdi, Form form, GroupBox Grup, Label yok)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KullaniciAdi = @ka", baglanti);
            SqlCommand count = new SqlCommand("select COUNT(*) from Kitaplar where KullaniciAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            count.Parameters.AddWithValue("@ka", KullaniciAdi);

            try
            {
                baglanti.Open();
                int kacTane = (int)count.ExecuteScalar();
                SqlDataReader reader = cmd.ExecuteReader();
                ListBox lb = new ListBox();
                
                while (reader.Read())
                {
                    lb.Items.Add(reader.GetString(2));
                }

                if (kacTane > 0)
                {
                    yok.Visible = false;
                    Grup.Size = new Size(Grup.Width, kacTane * 42);
                    int lblKonum = Grup.Location.Y + yok.Location.Y;
                    for (int i = 0; i < kacTane; i++)
                    {
                        Label label = new Label();
                        label.Location = new Point(Grup.Location.X + yok.Location.X, lblKonum);
                        lblKonum += 38;
                        label.ForeColor = Color.White;
                        label.Text = lb.Items[i].ToString();
                        form.Controls.Add(label);
                        label.BringToFront();
                    }
                }

                reader.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }

    }
}
