using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitirmeProjesi
{
    public partial class Gitap : Form
    {
        string kullaniciAdi = "", kitapAdi = "", yazarKullaniciAdi = "";
        int maxSize = 1;
        ListBox lbChapterAdlari = new ListBox();
        public Gitap(string KullaniciAdi, string YazarKullaniciAdi, string KitapAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.kitapAdi = KitapAdi;
            this.yazarKullaniciAdi = YazarKullaniciAdi;
        }

        private void Gitap_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            maxSize = lblKitapTuru.Size.Width;
            timer1.Enabled = true;
            KitapIslemleri ki = new KitapIslemleri();
            ki.KitabiGoruntule(kitapAdi, yazarKullaniciAdi, lblKitap, lblYazar, lblKitapTuru, lblKitapKonusu, lblEtiketler, lblOkunma);
            lblbolumsayisi.Text = (ki.ChapterSayisi(yazarKullaniciAdi, kitapAdi) - 1).ToString();
            lblDurum.Text = ki.KitapDurum(yazarKullaniciAdi, kitapAdi);
            ki.ChapterAdlari(yazarKullaniciAdi, kitapAdi, lbChapterAdlari);
            for (int i = 0; i < lbChapterAdlari.Items.Count; i++)
            {
                comboBox1.Items.Add(lbChapterAdlari.Items[i].ToString());
            }
            ki.FiyatKontrol(kullaniciAdi, yazarKullaniciAdi, kitapAdi, lblFiyat, btnOku);
            if (lblFiyat.Text.Length > 1)
            {
                lblFiyat.Location = new Point(lblFiyat.Location.X - (lblFiyat.Size.Width / 4), lblFiyat.Location.Y);
            }
            if (ki.BegeniKontrol(kullaniciAdi,yazarKullaniciAdi,kitapAdi))
            {
                btnBegen.Text = "Beğenildi";
                btnBegen.BackColor = Color.White;
                btnBegen.ForeColor = Color.Black;
            }
            lblBeğeni.Text = ki.KacBegeni(yazarKullaniciAdi, kitapAdi).ToString();
        }

        private void btnOku_Click(object sender, EventArgs e)
        {
            KitapIslemleri ki = new KitapIslemleri();
            if (ki.ChapterSayisi(yazarKullaniciAdi, kitapAdi) > 1)
            {
                if (btnOku.Text == "Oku")
                {
                    ki.EtiketleriKaydet(kullaniciAdi, yazarKullaniciAdi, lblKitapTuru.Text, lblEtiketler.Text);
                    Oku o = new Oku(kullaniciAdi, kitapAdi, yazarKullaniciAdi, 0);
                    o.MdiParent = this.MdiParent;
                    o.Show();
                }
                else if (btnOku.Text == "Satın Al")
                {
                    if (MessageBox.Show("Gitabı satın almak istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        switch (ki.SatinAl(kullaniciAdi, yazarKullaniciAdi, kitapAdi))
                        {
                            case 1:
                                MessageBox.Show("Gitap başarı ile satın alındı.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Gitap gt = new Gitap(kullaniciAdi, yazarKullaniciAdi, kitapAdi);
                                gt.MdiParent = this.MdiParent;
                                this.Close();
                                gt.Show();
                                break;

                            case -1:
                                MessageBox.Show("Gitap satın alınırken bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;

                            case -2:
                                MessageBox.Show("Yetersiz bakiye.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bu kitaba henüz chapter eklenmemiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lbChapterAdlari.Items.Count; i++)
            {
                if (comboBox1.Text == lbChapterAdlari.Items[i].ToString())
                {
                    Oku o = new Oku(kullaniciAdi, kitapAdi, yazarKullaniciAdi, i);
                    o.MdiParent = this.MdiParent;
                    o.Show();
                }

            }
        }

        private void btnBegen_Click(object sender, EventArgs e)
        {
            KitapIslemleri ki = new KitapIslemleri();
            if (btnBegen.Text == "Beğen")
            {
                ki.Begen(kullaniciAdi, yazarKullaniciAdi, kitapAdi);
                Gitap gt = new Gitap(kullaniciAdi, yazarKullaniciAdi, kitapAdi);
                gt.MdiParent = this.MdiParent;
                this.Close();
                gt.Show();
            }
            else if (btnBegen.Text == "Beğenildi")
            {
                ki.Begenmeme(kullaniciAdi, yazarKullaniciAdi, kitapAdi);
                Gitap gt = new Gitap(kullaniciAdi, yazarKullaniciAdi, kitapAdi);
                gt.MdiParent = this.MdiParent;
                this.Close();
                gt.Show();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 40, this.MdiParent.Size.Height - 45);
            lblKitapKonusu.MaximumSize = new Size(this.MdiParent.Size.Width - (maxSize * 25), 0);
            #endregion
        }
    }
}