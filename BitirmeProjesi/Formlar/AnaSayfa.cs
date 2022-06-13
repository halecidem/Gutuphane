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
    public partial class AnaSayfa : Form
    {
        string kullaniciAdi = "";
        int durum = 0;

        ListBox lbKitapAdi = new ListBox();
        ListBox lbYazarAdi = new ListBox();
        int aralikX = 20;
        int aralikY = 35;
        int[] konumX = new int[10];
        int konumXYedek = 0;
        int konumYYedek = 0;
        int[] konumY = new int[10];
        GroupBox[] gb = new GroupBox[10];
        Label[] lblYazar = new Label[10];

        public AnaSayfa(string KullaniciAdi, int Durum) //İlk açılan sayfa 0, sonradan açılanlar 1 ile başlatılacak
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.durum = Durum;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            AlgoritmikIslemler ai = new AlgoritmikIslemler();
            ai.SonEklenenler(lbKitapAdi, lbYazarAdi);
            #region Kutular
            if (lbKitapAdi.Items.Count > 0)
            {
                for (int i = 0; i < lbKitapAdi.Items.Count; i++)
                {
                    if (lbKitapAdi.Items[i] != null)
                    {
                        string kitap = lbKitapAdi.Items[i].ToString();
                        string yazar = lbYazarAdi.Items[i].ToString();

                        gb[i] = new GroupBox();
                        gb[i].ForeColor = Color.White;
                        gb[i].Text = kitap;
                        gb[i].Size = new Size(groupBox2.Size.Width, groupBox2.Size.Height);
                        this.Controls.Add(gb[i]);
                        gb[i].BringToFront();

                        lblYazar[i] = new Label();
                        lblYazar[i].Text = yazar;
                        lblYazar[i].ForeColor = Color.White;
                        this.Controls.Add(lblYazar[i]);
                        lblYazar[i].BringToFront();

                        void gb_Click(object sendr, EventArgs a)
                        {
                            Gitap gt = new Gitap(kullaniciAdi, yazar, kitap);
                            gt.MdiParent = this.MdiParent;
                            gt.Show();
                        }

                        gb[i].Click += new EventHandler(gb_Click);
                    }
                }
            }
            #endregion

            timer1.Enabled = true;
            GenelIslemler gi = new GenelIslemler();
            btnProfil.Text = gi.AdiNe(kullaniciAdi);
            if (durum == 0)
            {
                btnGeri.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBaslik.Location = new Point((this.Size.Width / 2) - (lblBaslik.Size.Width / 2), lblBaslik.Location.Y);
            lblSayfaAciklama.Location = new Point((this.Size.Width / 2) - (lblSayfaAciklama.Size.Width / 2), lblSayfaAciklama.Location.Y);

            #region Otomatik Boyutlandırma
            konumXYedek = groupBox2.Location.X;
            konumYYedek = groupBox2.Location.Y;

            for (int i = 0; i < gb.Length; i++)
            {
                if (gb[i] != null)
                {
                    konumX[i] = konumXYedek;
                    konumY[i] = konumYYedek;

                    gb[i].Location = new Point(konumX[i] + groupBox1.Location.X, konumY[i] + groupBox1.Location.Y);
                    lblYazar[i].Size = new Size(lblYazar[i].Text.Length * 10, lblYazar[i].Size.Height);
                    lblYazar[i].Location = new Point(gb[i].Location.X + (gb[i].Size.Width / 2) - (lblYazar[i].Size.Width / 2), gb[i].Location.Y + gb[i].Size.Height - (lblYazar[i].Size.Height / 2));
                    konumXYedek += groupBox2.Size.Width + aralikX;
                }
            }

            NavBar navBar = new NavBar(kullaniciAdi);
            if (konumYYedek + groupBox1.Size.Height + aralikY > this.MdiParent.Size.Height - 20)
            {
                this.MaximumSize = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 40, konumYYedek + groupBox1.Size.Height + aralikY);
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 40, konumYYedek + groupBox1.Size.Height + aralikY);

            }
            else
            {
                this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 40, this.MdiParent.Size.Height - 45);
            }
            #endregion
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            Profil pr = new Profil(kullaniciAdi, kullaniciAdi);
            pr.MdiParent = this.MdiParent;
            pr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
