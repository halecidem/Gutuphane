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
        int maxSize = 0;
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
            ki.KitabiGoruntule(kitapAdi, yazarKullaniciAdi, lblKitap, lblYazar, lblKitapTuru, lblKitapKonusu);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            lblKitapTuru.MaximumSize = new Size(this.MdiParent.Size.Width - (maxSize * 25), 0);
            #endregion
        }
    }
}
