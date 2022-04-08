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
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            lblHataMesaji.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            GenelIslemler gi = new GenelIslemler();
            if (kullaniciAdi.Text != "" && sifre.Text != "")
            {
                switch (gi.Giris(kullaniciAdi.Text, sifre.Text))
                {
                    case 0:
                        lblHataMesaji.Text = "Hatalı bir durum oluştu.";
                        break;
                    case 1:
                        lblHataMesaji.Text = "Böyle bir kullanıcı bulunamadı.";
                        break;
                    case 2:
                        lblHataMesaji.Text = "Hatalı sifre";
                        break;
                    case 3:
                        //Yeni formu yükle
                        break;
                }
            }
            else
            {
                lblHataMesaji.Text = "Kullanıcı adı veya şifre alanı boş bırakılamaz.";
            }
        }
    }
}
