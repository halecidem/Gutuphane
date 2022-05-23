using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BitirmeProjesi
{
    public partial class GitapYaz : Form
    {
        string kullaniciAdi = "";
        public GitapYaz(string KullaniciAdi)
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
                switch (ki.KitapPaylas(kullaniciAdi, textBox1.Text, textBox2.Text))
                {
                    case 1:
                        MessageBox.Show("Kitap başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Gitaplarım git = new Gitaplarım(kullaniciAdi);
                        git.MdiParent = this.MdiParent;
                        this.Close();
                        git.Show();
                        break;
                    case -1:
                        MessageBox.Show("Kitap kaydedilemedi.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gitaplarım git = new Gitaplarım(kullaniciAdi);
            git.MdiParent = this.MdiParent;
            this.Close();
            git.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Tüm Dosyalar |*.*";
            string fotoKonum = "";

            if (file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(file.FileName);
                if (fi.Exists)
                {
                    pictureBox1.ImageLocation = file.FileName;
                    fotoKonum = file.FileName;
                }
                else
                {
                    //Hata
                }
            }

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && fotoKonum.Length > 0)
            {
                //Taslağı kaydet kodu
            }
        }
    }
}
