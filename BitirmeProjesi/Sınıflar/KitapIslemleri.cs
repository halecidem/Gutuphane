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
        public int Kitaplarim (string KullaniciAdi, GroupBox groupBox, Form form)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KullaniciAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KullaniciAdi);
            ListBox lb = new ListBox();
            int aralikX = 55;
            int aralikY = 55;
            int konumX = groupBox.Location.X + groupBox.Size.Width + aralikX;
            int konumY = groupBox.Location.Y;

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
                    for (int i = 0; i < lb.Items.Count; i++)
                    {
                        if(konumX+groupBox.Size.Width > form.Size.Width)
                        {
                            konumX = groupBox.Location.X;
                            konumY = groupBox.Location.Y + groupBox.Size.Height + aralikY;
                        }
                        
                        GroupBox gb = new GroupBox();
                        gb.ForeColor = Color.White;
                        gb.Text = lb.Items[i].ToString();
                        gb.Size= new Size(groupBox.Size.Width, groupBox.Size.Height);
                        gb.Location = new Point(konumX, konumY);
                        konumX += groupBox.Size.Width + aralikX;
                        form.Controls.Add(gb);

                        string kitap = lb.Items[i].ToString();

                        gb.Click += new EventHandler(gb_Click);
                        void gb_Click(object sender, EventArgs e)
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
                return konumY + groupBox.Size.Height + (2 * aralikY) + groupBox.Location.Y;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
