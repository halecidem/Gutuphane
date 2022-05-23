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
    public partial class AnaSayfa : Form
    {
        string kullaniciAdi = "";
        int durum = 0;
        public AnaSayfa(string KullaniciAdi, int Durum) //İlk açılan sayfa 0, sonradan açılanlar 1 ile başlatılacak
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.durum = Durum;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            GenelIslemler gi = new GenelIslemler();
            btnProfil.Text = gi.AdiNe(kullaniciAdi);
            if (durum == 0)
            {
                btnGeri.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            Profil pr = new Profil(kullaniciAdi);
            pr.MdiParent = this.MdiParent;
            pr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
