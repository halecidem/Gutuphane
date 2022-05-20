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
    public partial class KitapYaz : Form
    {
        string kullaniciAdi = "";
        public KitapYaz(string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
        }

        private void KitapYaz_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapIslemleri ki = new KitapIslemleri();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                ki.KitapPaylas(kullaniciAdi, textBox1.Text, textBox2.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
