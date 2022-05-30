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

        public int TaslagiKaydet(string KullaniciAdi, string KitapAdi,string KitapTuru, string Icerik)
        {
            SqlCommand cmd = new SqlCommand("insert into Kitaplar (KullaniciAdi, KitapAdi, KitapTuru, KitapKonusu) values (@ka, @kit, @kt,@kk)", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            cmd.Parameters.AddWithValue("@kit", KitapAdi);
            cmd.Parameters.AddWithValue("@kt", KitapTuru);
            cmd.Parameters.AddWithValue("@kk", Icerik);

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

        public void KisininKitaplari(string KullaniciAdi, Form form, GroupBox Grup, Label yok, Label Paylasim)
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

                Grup.Text = "Yazdığı Kitaplar";
                Paylasim.Text = lb.Items.Count.ToString();

                if (lb.Items.Count > 0)
                {
                    yok.Visible = false;
                    Grup.Size = new Size(Grup.Width, (lb.Items.Count * 38) + 20);
                    int lblKonum = Grup.Location.Y + yok.Location.Y;
                    for (int i = 0; i < lb.Items.Count; i++)
                    {
                        Label label = new Label();
                        label.Location = new Point(Grup.Location.X + yok.Location.X, lblKonum);
                        
                        label.ForeColor = Color.White;
                        label.Text = lb.Items[i].ToString();
                        form.Controls.Add(label);
                        label.BringToFront();

                        Button btn = new Button();
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Text = "Görüntüle";
                        btn.BackColor = Color.Black;
                        btn.ForeColor = Color.White;
                        btn.Location = new Point(Grup.Location.X + Grup.Size.Width - label.Size.Width - yok.Location.X, lblKonum);
                        form.Controls.Add(btn);
                        btn.BringToFront();

                        lblKonum += 38;
                        string kitap = lb.Items[i].ToString();

                        btn.Click += new EventHandler(btn_Click);
                        void btn_Click(object sender, EventArgs e)
                        {
                            Gitap gt = new Gitap(KullaniciAdi, KullaniciAdi, kitap);
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

        public void KitabiGoruntule(string KitapAdi, string YazarKullaniciAdi, Label lblKitapAdi, Label lblYazarAdi, Label lblKitapTuru, Label lblKitapKonusu)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            string yazar = "";

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    lblYazarAdi.Text = reader.GetString(1);
                    lblKitapAdi.Text = reader.GetString(2);
                    lblKitapTuru.Text = reader.GetString(3);
                    lblKitapKonusu.Text = reader.GetString(4);
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
        public ListBox Kitaplarim (string KullaniciAdi)
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

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                return lb;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void KitabiSil(string KullaniciAdi, string KitapAdi)
        {
            SqlCommand cmd = new SqlCommand("delete from Kitaplar where KitapAdi = @ka and KullaniciAdi = @kul", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@kul", KullaniciAdi);

            try
            {
                baglanti.Open();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
