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
    public partial class Gitaplarım : Form
    {
        string kullaniciAdi = "";
        ListBox liste = new ListBox();
        string kitapYedek = "";
        int aralikX = 55;
        int aralikY = 55;
        int[] konumX = new int[50];
        int konumXYedek = 0;
        int konumYYedek = 0;
        int[] konumY = new int[50];
        GroupBox[] gb = new GroupBox[50];
        Button[] btn = new Button[50];
        Button[] btn2 = new Button[50];

        public Gitaplarım(string KullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }

        private void Gitaplarım_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion

            KitapIslemleri ki = new KitapIslemleri();
            liste = ki.Kitaplarim(kullaniciAdi);
            konumXYedek = groupBox1.Location.X;
            konumYYedek = groupBox1.Location.Y;

            #region Kutular
            if (liste.Items.Count > 0)
            {
                for (int i = 0; i < liste.Items.Count; i++)
                {
                    gb[i] = new GroupBox();
                    gb[i].ForeColor = Color.White;
                    gb[i].Text = liste.Items[i].ToString();
                    kitapYedek = liste.Items[i].ToString();
                    gb[i].Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height);
                    this.Controls.Add(gb[i]);

                    string kitap = liste.Items[i].ToString();

                    btn[i] = new Button();
                    btn[i].FlatStyle = FlatStyle.Flat;
                    btn[i].Text = "Sil";
                    btn[i].BackColor = Color.Black;
                    btn[i].ForeColor = Color.White;
                    btn[i].Size = new Size(gb[i].Size.Width / 4, btn[i].Size.Height);
                    this.Controls.Add(btn[i]);
                    btn[i].BringToFront();

                    btn2[i] = new Button();
                    btn2[i].FlatStyle = FlatStyle.Flat;
                    btn2[i].Text = "Düzenle";
                    btn2[i].BackColor = Color.Black;
                    btn2[i].ForeColor = Color.White;
                    this.Controls.Add(btn2[i]);
                    btn2[i].BringToFront();

                    gb[i].Click += new EventHandler(gb_Click);
                    btn[i].Click += new EventHandler(btn_Click);
                }
            }
            #endregion


            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Otomatik Boyutlandırma
            NavBar navBar = new NavBar(kullaniciAdi);
            if ((liste.Items.Count * groupBox1.Size.Height) + (liste.Items.Count * aralikY) + groupBox1.Location.Y > this.MdiParent.Size.Height - 45)
            {
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, (liste.Items.Count * groupBox1.Size.Height) + (liste.Items.Count * aralikY) + groupBox1.Location.Y); //Burada kaldık
            }
            else
            {
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            }
            #endregion
            lblBaslik.Location = new Point((this.Size.Width / 2) - (lblBaslik.Size.Width / 2), lblBaslik.Location.Y);
            lblAciklama.Location = new Point((this.Size.Width / 2) - (lblAciklama.Size.Width / 2), lblAciklama.Location.Y);

            konumXYedek = groupBox1.Location.X;
            //Konum Y ayarla

            for (int i = 0; i < gb.Length; i++)
            {
                if (gb[i] != null)
                {
                    konumXYedek += groupBox1.Size.Width + aralikX;
                    if (konumXYedek >= this.Size.Width)
                    {
                        konumYYedek += groupBox1.Size.Height + aralikY;
                    }
                    konumX[i] = konumXYedek;
                    konumY[i] = konumYYedek;
                    gb[i].Location = new Point(konumX[i], konumY[i]);
                    btn[i].Location = new Point(konumX[i] + gb[i].Size.Width - btn[i].Size.Width, konumY[i] + gb[i].Size.Height - btn[i].Size.Height);
                    btn2[i].Location = new Point(konumX[i], konumY[i] + gb[i].Size.Height - btn[i].Size.Height);
                }
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GitapYaz ky = new GitapYaz(kullaniciAdi);
            ky.MdiParent = this.MdiParent;
            this.Close();
            ky.Show();
        }

        void gb_Click(object sender, EventArgs e)
        {
            Gitap gt = new Gitap(kullaniciAdi, kitapYedek);
            gt.MdiParent = this.MdiParent;
            gt.Show();
        }
        void btn_Click(object sender, EventArgs e)
        {
            KitapIslemleri kt = new KitapIslemleri();
            kt.KitabiSil(kullaniciAdi, kitapYedek);
        }
    }
}
