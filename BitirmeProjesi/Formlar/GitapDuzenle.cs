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
    public partial class GitapDuzenle : Form
    {
        string kullaniciAdi = "", kitapAdi = "", yazarAdi = "";
        public GitapDuzenle(string KullaniciAdi, string KitapAdi, string YazarAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.kitapAdi = KitapAdi;
            this.yazarAdi = YazarAdi;
        }

        private void GitapDuzenle_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            DuzenlemeIslemleri di = new DuzenlemeIslemleri();
            di.DuzenleBilgileri(kitapAdi, yazarAdi, pictureBox1, txtKitapAdi, cbKitapTuru, txtKitapKonusu, txtEtiket);
            KitapIslemleri ki = new KitapIslemleri();
            ListBox lb = new ListBox();
            ki.ChapterAdlari(yazarAdi, kitapAdi, lb);
            for (int i = 0; i < lb.Items.Count; i++)
            {
                cbBolumler.Items.Add(lb.Items[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DuzenlemeIslemleri di = new DuzenlemeIslemleri();
            switch (di.DuzenlemeleriKaydet(kitapAdi, yazarAdi, pictureBox1, txtKitapAdi, cbKitapTuru, txtKitapKonusu, txtEtiket))
            {
                case 1:
                    MessageBox.Show("Kitap başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Gitaplarım git = new Gitaplarım(kullaniciAdi);
                    git.MdiParent = this.MdiParent;
                    this.Close();
                    git.Show();
                    break;
                case -1:
                    MessageBox.Show("Kitap güncellenemedi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        private void cbBolumler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChapterDuzenle cd = new ChapterDuzenle(yazarAdi, kitapAdi, cbBolumler.Text);
            cd.MdiParent = this.MdiParent;
            cd.Show();
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
    }
}
