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
    public partial class NavBar : Form
    {
        public NavBar()
        {
            InitializeComponent();
        }

        private void NavBar_Load(object sender, EventArgs e)
        {
            #region Sol Kenara Konumlandırma
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            #endregion
        }
    }
}
