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

        public void KisininKitaplari(string KullaniciAdi, Form form, GroupBox Grup, Label yok)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KullaniciAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            ListBox lb = new ListBox();

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    lb.Items.Add(reader.GetString(2));
                }

                if (lb.Items.Count > 0)
                {
                    yok.Visible = false;
                    Grup.Size = new Size(Grup.Width, (lb.Items.Count * 38) + 20);
                    int lblKonum = Grup.Location.Y + yok.Location.Y;
                    for (int i = 0; i < lb.Items.Count; i++)
                    {
                        Label label = new Label();
                        label.Location = new Point(Grup.Location.X + yok.Location.X, lblKonum);
                        lblKonum += 38;
                        label.ForeColor = Color.White;
                        label.Text = lb.Items[i].ToString();
                        form.Controls.Add(label);
                        label.BringToFront();

                        string kitap = lb.Items[i].ToString();

                        label.Click += new EventHandler(label_Click);
                        void label_Click(object sender, EventArgs e)
                        {
                            Gitap gt = new Gitap(KullaniciAdi, kitap);
                            gt.MdiParent = form.MdiParent;
                            gt.Show();
                        }
                    }
                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void KitabiGoruntule(string KitapAdi, Label lblKitapAdi, Label lblKitapIcerigi)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    lblKitapAdi.Text = reader.GetString(2);
                    lblKitapIcerigi.Text = reader.GetString(3);
                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
            }
            catch(Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }

    }
}
