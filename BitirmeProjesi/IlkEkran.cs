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
    public partial class IlkEkran : Form
    {
        GirisEkrani girisEkrani = new GirisEkrani();
        public IlkEkran()
        {
            InitializeComponent();
        }

        private void IlkEkran_Load(object sender, EventArgs e)
        {
            #region Merkeze Konumlandırma
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 5;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 3;
            this.Location = new Point(x, y);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            girisEkrani.Show();
        }
    }
}
