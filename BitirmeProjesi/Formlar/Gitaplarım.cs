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
    public partial class Gitaplarım : Form
    {
        string kullaniciAdi = "";
        int yukseklik = 0;
        public Gitaplarım(string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }

        private void Gitaplarım_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            KitapIslemleri ki = new KitapIslemleri();
            yukseklik = ki.Kitaplarim(kullaniciAdi, groupBox1, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            if (yukseklik > this.MdiParent.Size.Height - 45)
            {
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, yukseklik); //Burada kaldık
            }
            else
            {
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            }
            #endregion
            lblBaslik.Location = new Point((this.Size.Width / 2) - (lblBaslik.Size.Width / 2), lblBaslik.Location.Y);
            lblAciklama.Location = new Point((this.Size.Width / 2) - (lblAciklama.Size.Width / 2), lblAciklama.Location.Y);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }
    }
}
