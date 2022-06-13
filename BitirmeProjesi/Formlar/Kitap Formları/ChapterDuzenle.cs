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
    public partial class ChapterDuzenle : Form
    {
        string kullaniciAdi, kitapAdi, chapterAdi;

        private void txtChapter_TextChanged(object sender, EventArgs e)
        {
            lblHarf.Text = txtChapter.TextLength.ToString();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DuzenlemeIslemleri di = new DuzenlemeIslemleri();
            switch (di.BolumDuzenlemeleriKaydet(kitapAdi,kullaniciAdi, chapterAdi, txtChapterAdi,txtChapter))
            {
                case 1:
                    MessageBox.Show("Bölüm başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case -1:
                    MessageBox.Show("Bölüm güncellenemedi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DuzenlemeIslemleri di = new DuzenlemeIslemleri();
            switch(di.BolumSil(kitapAdi, kullaniciAdi, chapterAdi))
            {
                case 1:
                    MessageBox.Show("Bölüm başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GitapDuzenle gd = new GitapDuzenle(kullaniciAdi, kitapAdi, kullaniciAdi);
                    gd.MdiParent = this.MdiParent;
                    this.Close();
                    gd.Show();
                    break;
                case -1:
                    MessageBox.Show("Bölüm silinemedi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        public ChapterDuzenle(string YazarAdi, string KitapAdi, string ChapterAdi)
        {
            InitializeComponent();
            this.kitapAdi = KitapAdi;
            this.chapterAdi = ChapterAdi;
            this.kullaniciAdi = YazarAdi;
            this.kitapAdi = KitapAdi;
            this.chapterAdi = ChapterAdi;
        }

        private void ChapterDuzenle_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            timer1.Enabled = true;
            KitapIslemleri ki = new KitapIslemleri();
            lblChapter.Text = ki.KacinciChapter(kullaniciAdi, kitapAdi, chapterAdi).ToString();
            lblHarf.Text = txtChapter.TextLength.ToString();
            DuzenlemeIslemleri di = new DuzenlemeIslemleri();
            di.BolumDuzenleBilgileri(kitapAdi, kullaniciAdi, chapterAdi, txtChapterAdi, txtChapter, lblKitap, lblChapter);
        }
    }
}
