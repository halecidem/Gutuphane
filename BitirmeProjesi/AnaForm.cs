using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BitirmeProjesi
{
    public partial class AnaForm : Form
    {
        GenelIslemler gi = new GenelIslemler();
        GirisEkrani girisEkrani = new GirisEkrani();
        public AnaForm()
        {
            InitializeComponent();

            #region Ana Form Renk
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.FromArgb(20, 20, 20);
                    break;
                }
            }
            #endregion
        }

        private void BaslangicForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BaslangicForm_Shown(object sender, EventArgs e)
        {
            lblDurum.Text = "Durum: Sunucular gontrol ediliyor...";
            if (gi.SQLControl() == true)
            {
                lblDurum.Text = "Durum: Girişe yönlendiriliyorsunuz...";
                girisEkrani.MdiParent = this;
                girisEkrani.Show();
                lblDurum.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

            }
            else
            {
                lblDurum.Text = "Durum: Sunuculara bağlantı kurulamadı!";
            }
        }
    }
}
