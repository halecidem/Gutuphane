using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitirmeProjesi.Formlar
{
    public partial class KayitEkrani : Form
    {
        GenelIslemler gi = new GenelIslemler();
        public KayitEkrani()
        {
            InitializeComponent();
        }

        private void KayitEkrani_Load(object sender, EventArgs e)
        {
            #region Merkeze Konumlandırma
            this.Anchor = AnchorStyles.None;
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 10;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 5;
            this.Location = new Point(x, y);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "" && txtSifre.Text != "" && txtEposta.Text != "" && txtAdi.Text != "" && txtSoyadi.Text != "" && txtTelNo.Text != "")
            {
                gi.Kayit(txtKullaniciAdi.Text, txtSifre.Text, txtEposta.Text, txtAdi.Text, txtSoyadi.Text, dateTimePicker1.Value, Convert.ToInt64(txtTelNo.Text));
            }
            else
            {

            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelNo.Text, "[^0-9]"))
            {
                txtTelNo.Text = txtTelNo.Text.Remove(txtTelNo.Text.Length - 1);
            }
        }
    }
}
