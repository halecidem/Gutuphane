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
    public partial class AramaSonuc : Form
    {
        string kullaniciAdi;
        string arama;
        int aramaTuru;

        ListBox lbKitapAdi = new ListBox();
        ListBox lbYazarAdi = new ListBox();
        int aralikX = 45;
        int aralikY = 35;
        int[] konumX = new int[50];
        int konumXYedek = 0;
        int konumYYedek = 0;
        int[] konumY = new int[50];
        GroupBox[] gb = new GroupBox[50];
        Label[] lblYazar = new Label[50];

        public AramaSonuc(string KullaniciAdi,int AramaTuru,string Arama)
        {
            InitializeComponent();
            this.kullaniciAdi = KullaniciAdi;
            this.aramaTuru = AramaTuru;
            this.arama = Arama;

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AramaSonuc_Load(object sender, EventArgs e)
        {
            #region NavBar'a Yanaştırma
            NavBar navBar = new NavBar(kullaniciAdi);
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Location = new Point(navBar.Size.Width, this.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion
            
            AramaIslemleri ai = new AramaIslemleri();
            if (aramaTuru == 1)
            {
                ai.KitapAra(arama, lbKitapAdi, lbYazarAdi);
            }
            else if (aramaTuru == 2)
            {
                
            }
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
                        gb[i].Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height);
                        this.Controls.Add(gb[i]);

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBaslik.Location = new Point((this.Size.Width / 2) - (lblBaslik.Size.Width / 2), lblBaslik.Location.Y);
            lblSayfaAciklama.Location = new Point((this.Size.Width / 2) - (lblSayfaAciklama.Size.Width / 2), lblSayfaAciklama.Location.Y);

            #region Otomatik Boyutlandırma
            konumXYedek = groupBox1.Location.X;
            konumYYedek = groupBox1.Location.Y;

            for (int i = 0; i < gb.Length; i++)
            {
                if (gb[i] != null)
                {
                    if (konumXYedek + groupBox1.Size.Width >= this.Size.Width)
                    {
                        konumYYedek += groupBox1.Size.Height + aralikY;
                        konumXYedek = groupBox1.Location.X;
                    }
                    konumX[i] = konumXYedek;
                    konumY[i] = konumYYedek;

                    gb[i].Location = new Point(konumX[i], konumY[i]);
                    lblYazar[i].Location = new Point(gb[i].Location.X + (gb[i].Size.Width / 2) - (lblYazar[i].Size.Width / 4), gb[i].Location.Y + gb[i].Size.Height - (lblYazar[i].Size.Height / 2));
                    konumXYedek += groupBox1.Size.Width + aralikX;
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
    }
}
