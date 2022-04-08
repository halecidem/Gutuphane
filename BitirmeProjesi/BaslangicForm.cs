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
    public partial class BaslangicForm : Form
    {
        public BaslangicForm()
        {
            InitializeComponent();
        }

        private void BaslangicForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenelIslemler gi = new GenelIslemler();
            GirisEkrani ge = new GirisEkrani();
            if (gi.SQLControl() != true)
            {
                this.Hide();
                ge.Show();
            }
            timer1.Enabled = false;
        }
    }
}
