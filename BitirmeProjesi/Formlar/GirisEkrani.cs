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
    public partial class GirisEkrani : Form
    {
        GenelIslemler gi = new GenelIslemler();
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            lblHataMesaji.Text = "";
            #region Merkeze Konumlandırma
            this.Anchor = AnchorStyles.None;
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 5;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3;
            this.Location = new Point(x, y);
            #endregion
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (kullaniciAdi.Text != "" && sifre.Text != "")
            {
                switch (gi.Giris(kullaniciAdi.Text, sifre.Text))
                {
                    case 0:
                        lblHataMesaji.Text = "Sistemsel bir hata oluştu.";
                        break;
                    case 1:
                        lblHataMesaji.Text = "Kullanıcı adı ile ilgili bir hata oluştu.";
                        break;
                    case 2:
                        lblHataMesaji.Text = "Şifre ile ilgili bir hata oluştu.";
                        break;
                    case 3:
                        lblHataMesaji.Text = "Giriş başarılı.";
                        this.Hide();
                        //Yeni formu yükle
                        break;
                    case 4:
                        lblHataMesaji.Text = "Hatalı sifre.";
                        break;
                    case 5:
                        lblHataMesaji.Text = "Böyle bir kullanıcı bulunamadı.";
                        break;
                }
            }
            else
            {
                lblHataMesaji.Text = "Kullanıcı adı ve şifre alanı boş bırakılamaz.";
            }
            sifre.Text = "";
        }
    }
}
