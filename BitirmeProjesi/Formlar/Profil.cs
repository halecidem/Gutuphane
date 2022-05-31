﻿using System;
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
    public partial class Profil : Form
    {
        string kullaniciAdi = "", hedefKullaniciAdi = "";
        int KitapSayisi = 0;
        public Profil(string KullaniciAdi, string HedefKullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.hedefKullaniciAdi = HedefKullaniciAdi;
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            GenelIslemler gi = new GenelIslemler();
            gi.ProfilBilgileri(kullaniciAdi, lblAdi, lblSoyadi, lblEposta, lblKayitTarihi);
            lblKullaniciAdi.Text = hedefKullaniciAdi;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            KitapIslemleri ki = new KitapIslemleri();
            KitapSayisi = ki.KisininKitaplari(kullaniciAdi, this, groupBox1, lblYok, lblPaylasim);
            if (KitapSayisi > 0)
            {
                this.Size = new Size(this.Size.Width, groupBox1.Location.Y + groupBox1.Size.Height + (KitapSayisi * 38) + 40);
            }
            else
            {
                NavBar navBar = new NavBar(kullaniciAdi);
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
