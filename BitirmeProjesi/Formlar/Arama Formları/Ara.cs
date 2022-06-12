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
    public partial class Ara : Form
    {
        string kullaniciAdi = "";
        public Ara(string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
        }

        private void Ara_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            radioButton1.Checked = true;
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
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtAra.Text != null)
            {
                if (radioButton1.Checked == true)
                {
                    AramaSonuc ara = new AramaSonuc(kullaniciAdi, 1, txtAra.Text);
                    ara.MdiParent = this.MdiParent;
                    ara.Show();
                }
                else if (radioButton3.Checked == true)
                {
                    AramaSonuc ara = new AramaSonuc(kullaniciAdi, 2, txtAra.Text);
                    ara.MdiParent = this.MdiParent;
                    ara.Show();
                }
            }
        }
    }
}
