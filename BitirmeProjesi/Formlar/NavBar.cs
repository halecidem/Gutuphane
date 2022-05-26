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
    public partial class NavBar : Form
    {
        string kullaniciAdi = "";
        public NavBar(string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
        }

        private void NavBar_Load(object sender, EventArgs e)
        {
            #region Sol Üst Köşeye Konumlandırma
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Size = new Size(this.Size.Width, this.MdiParent.Size.Height - 45);
            #endregion
            AnaSayfa ana = new AnaSayfa(kullaniciAdi, 0);
            ana.MdiParent = this.MdiParent;
            ana.Show();
            timer1.Enabled = true;
        }

        private void btnKitapligim_Click(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, this.MdiParent.Size.Height - 45);
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa(kullaniciAdi, 1);
            ana.MdiParent = this.MdiParent;
            ana.Show();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Gitaplarım git = new Gitaplarım(kullaniciAdi);
            git.MdiParent = this.MdiParent;
            git.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
