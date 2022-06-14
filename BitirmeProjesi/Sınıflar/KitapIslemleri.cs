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

        public int TaslagiKaydet(string KullaniciAdi, string KitapAdi,string KitapTuru, string Icerik, string Etiketler, double Fiyat)
        {
            SqlCommand cmd = new SqlCommand("insert into Kitaplar (KullaniciAdi, KitapAdi, KitapTuru, KitapKonusu, Etiketler, Durum, OkunmaSayisi, Fiyat) values (@ka, @kit, @kt,@kk, @et, @dr, 0, @fi)", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            cmd.Parameters.AddWithValue("@kit", KitapAdi);
            cmd.Parameters.AddWithValue("@kt", KitapTuru);
            cmd.Parameters.AddWithValue("@kk", Icerik);
            cmd.Parameters.AddWithValue("@et", Etiketler);
            cmd.Parameters.AddWithValue("@dr", "Devam Ediyor");
            cmd.Parameters.AddWithValue("@fi", Fiyat);

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

        public void KitabiGoruntule(string KitapAdi, string YazarKullaniciAdi, Label lblKitapAdi, Label lblYazarAdi, Label lblKitapTuru, Label lblKitapKonusu, Label lblEtiketler, Label lblOkunmaSayisi)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);

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
                    lblEtiketler.Text = reader.GetString(6);
                    lblOkunmaSayisi.Text = reader.GetInt64(8).ToString();
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

            SqlCommand cmd2 = new SqlCommand("update Kitaplar set OkunmaSayisi = OkunmaSayisi + 1 where KitapAdi = @ka", baglanti);
            cmd2.Parameters.AddWithValue("@ka", kitapadi);

            try
            {
                baglanti.Open();
                cmd2.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbChapterAdi.Items.Add(reader.GetString(4));
                    lbBolum.Items.Add(reader.GetString(5));
                }

                cmd.Dispose();
                cmd2.Dispose();
                reader.Close();
                baglanti.Close();
                return 1;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                cmd2.Dispose();
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

        public string KitapDurum(string YazarAdi, string KitapAdi)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KullaniciAdi = @ya and KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);

            string Durum = "";

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Durum = reader.GetString(7);
                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                return Durum;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void EtiketleriKaydet(string KullaniciAdi, string YazarAdi, string KitapTuru, string Etiketler)
        {
            SqlCommand sil = new SqlCommand("delete from Etiketler where KullaniciAdi = @ka and YazarAdi = @ya and KitapTuru = @kt", baglanti);
            sil.Parameters.AddWithValue("@ka", KullaniciAdi);
            sil.Parameters.AddWithValue("@ya", YazarAdi);
            sil.Parameters.AddWithValue("@kt", KitapTuru);

            SqlCommand cmd = new SqlCommand("insert into Etiketler (KullaniciAdi, YazarAdi, KitapTuru, Etiketler) values (@ka, @ya, @kt, @et)", baglanti);
            

            try
            {
                baglanti.Open();
                sil.ExecuteNonQuery();

                sil.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                sil.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }


            string[] Etk = Etiketler.Split(';');

            for (int i = 0; i < Etk.Length; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
                cmd.Parameters.AddWithValue("@ya", YazarAdi);
                cmd.Parameters.AddWithValue("@kt", KitapTuru);
                cmd.Parameters.AddWithValue("@et", Etk[i]);
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

        public void FiyatKontrol(string KullaniciAdi, string YazarAdi, string KitapAdi, Label lblFiyat, Button btnOku)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KullaniciAdi = @ya and KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            cmd.Parameters.AddWithValue("@ya", YazarAdi);

            double Fiyat = 0;

            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Fiyat = reader.GetSqlMoney(9).ToDouble();
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

            if (Fiyat == 0)
            {
                btnOku.Text = "Oku";
                lblFiyat.Text = "Ücretsiz";
            }
            else if (Fiyat > 0)
            {
                btnOku.Text = "Satın Al";
                lblFiyat.Text = Fiyat.ToString() + " TL";
                 
                SqlCommand cmd2 = new SqlCommand("select * from AlinanKitaplar where KullaniciAdi = @kul and Yazar = @ya and KitapAdi = @ka", baglanti);
                cmd2.Parameters.AddWithValue("@kul", KullaniciAdi);
                cmd2.Parameters.AddWithValue("@ka", KitapAdi);
                cmd2.Parameters.AddWithValue("@ya", YazarAdi);

                bool varMi = false;

                try
                {
                    baglanti.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        if (reader2.GetInt32(0) != null)
                        {
                            varMi = true;
                        }
                    }

                    cmd.Dispose();
                    reader2.Close();
                    baglanti.Close();
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show(ex.Message);
                }
                if (varMi == true)
                {
                    btnOku.Text = "Oku";
                }
            }
            else
            {
                btnOku.Text = "Seyretme Dana!";
            }
        }
    }
    
}
