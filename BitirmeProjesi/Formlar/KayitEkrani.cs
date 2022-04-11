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
    }
}
