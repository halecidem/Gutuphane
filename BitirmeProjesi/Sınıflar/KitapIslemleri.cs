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

        public int TaslagiKaydet(string KullaniciAdi, string KitapAdi,string KitapTuru, string Icerik, string Etiketler)
        {
            SqlCommand cmd = new SqlCommand("insert into Kitaplar (KullaniciAdi, KitapAdi, KitapTuru, KitapKonusu, Etiketler) values (@ka, @kit, @kt,@kk, @et)", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            cmd.Parameters.AddWithValue("@kit", KitapAdi);
            cmd.Parameters.AddWithValue("@kt", KitapTuru);
            cmd.Parameters.AddWithValue("@kk", Icerik);
            cmd.Parameters.AddWithValue("@et", Etiketler);

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

        public int KisininKitaplari(string KullaniciAdi, Form form, GroupBox Grup, Label yok, Label Paylasim)
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
                return lb.Items.Count;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return 0;
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

        public int ChapterSayisi(string YazarAdi, string KitapAdi)
        {
            SqlCommand cmd = new SqlCommand("select * from Chapterlar where Yazar = @ya and KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);

            ListBox lb = new ListBox();

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lb.Items.Add(reader.GetString(4));
                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                return lb.Items.Count + 1;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int ChapterKaydet(string YazarAdi, string KitapAdi, int ChapterSayisi, TextBox Baslik, TextBox Chapter)
        {
            SqlCommand cmd = new SqlCommand("insert into Chapterlar (Yazar, KitapAdi, ChapterSayisi, Baslik, Chapter) values (@ya, @ka, @cs, @bas, @ch)", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);
            cmd.Parameters.AddWithValue("@cs", ChapterSayisi);
            cmd.Parameters.AddWithValue("@bas", Baslik.Text);
            cmd.Parameters.AddWithValue("@ch", Chapter.Text);

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
        public int OkuSayfasi (string yazaradi , string kitapadi, ListBox lbChapterAdi, ListBox lbBolum)
        {
            SqlCommand cmd = new SqlCommand("select * from Chapterlar where Yazar = @ya and KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", kitapadi);
            cmd.Parameters.AddWithValue("@ya", yazaradi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbChapterAdi.Items.Add(reader.GetString(4));
                    lbBolum.Items.Add(reader.GetString(5));
                }

                cmd.Dispose();
                reader.Close();
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

        public int ChapterAdlari(string yazaradi, string kitapadi, ListBox lbChapterAdi)
        {
            SqlCommand cmd = new SqlCommand("select * from Chapterlar where Yazar = @ya and KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", kitapadi);
            cmd.Parameters.AddWithValue("@ya", yazaradi);

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbChapterAdi.Items.Add(reader.GetString(4));
                }

                cmd.Dispose();
                reader.Close();
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

        public int KacinciChapter(string YazarAdi, string KitapAdi, string ChapterAdi)
        {
            SqlCommand cmd = new SqlCommand("select * from Chapterlar where Yazar = @ya and KitapAdi = @ka and Baslik = @ba", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);
            cmd.Parameters.AddWithValue("@ba", ChapterAdi);

            int HangiChapter = 0;

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HangiChapter = reader.GetInt32(3);
                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                return HangiChapter;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
    
}
