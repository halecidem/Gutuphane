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
        int aralikX = 45;
        int aralikY = 35;
        int[] konumX = new int[50];
        int konumXYedek = 0;
        int konumYYedek = 0;
        int[] konumY = new int[50];
        GroupBox[] gb = new GroupBox[50];
        Button[] btn = new Button[50];
        Button[] btn2 = new Button[50];
        Button[] btn3 = new Button[50];

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
            this.Location = new Point(navBar.Size.Width, navBar.Location.Y);
            this.Size = new Size(this.MdiParent.Size.Width - navBar.Size.Width - 20, this.MdiParent.Size.Height - 45);
            #endregion

            KitapIslemleri ki = new KitapIslemleri();
            liste = ki.Kitaplarim(kullaniciAdi);

            #region Kutular
            if (liste.Items.Count > 0)
            {
                for (int i = 0; i < liste.Items.Count; i++)
                {
                    if (liste.Items[i] != null)
                    {
                        string kitap = liste.Items[i].ToString();

                        gb[i] = new GroupBox();
                        gb[i].ForeColor = Color.White;
                        gb[i].Text = liste.Items[i].ToString();
                        gb[i].Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height);
                        this.Controls.Add(gb[i]);

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

                        btn3[i] = new Button();
                        btn3[i].FlatStyle = FlatStyle.Flat;
                        btn3[i].Text = "Yaz";
                        btn3[i].BackColor = Color.Black;
                        btn3[i].ForeColor = Color.White;
                        btn3[i].Size = new Size(gb[i].Size.Width / 4, btn[i].Size.Height);

                        if (ki.KitapDurum(kullaniciAdi, kitap) == "Devam Ediyor")
                        {
                            this.Controls.Add(btn2[i]);
                            btn2[i].BringToFront();
                            this.Controls.Add(btn3[i]);
                            btn3[i].BringToFront();
                        }

                        void gb_Click(object sendr, EventArgs a)
                        {
                            Gitap gt = new Gitap(kullaniciAdi, kullaniciAdi, kitap);
                            gt.MdiParent = this.MdiParent;
                            gt.Show();
                        }
                        void btn_Click(object sendr, EventArgs a)
                        {
                            KitapIslemleri kt = new KitapIslemleri();
                            kt.KitabiSil(kullaniciAdi, kitap);
                            Gitaplarım gt = new Gitaplarım(kullaniciAdi);
                            gt.MdiParent = this.MdiParent;
                            this.Close();
                            gt.Show();
                        }
                        void btn2_Click(object sendr, EventArgs a)
                        {
                            GitapDuzenle gd = new GitapDuzenle(kullaniciAdi, kitap, kullaniciAdi);
                            gd.MdiParent = this.MdiParent;
                            gd.Show();
                        }
                        void btn3_Click(object sendr, EventArgs a)
                        {
                            ChapterYaz cy = new ChapterYaz(kullaniciAdi, kitap, kullaniciAdi);
                            cy.MdiParent = this.MdiParent;
                            cy.Show();
                        }

                        gb[i].Click += new EventHandler(gb_Click);
                        btn[i].Click += new EventHandler(btn_Click);
                        btn2[i].Click += new EventHandler(btn2_Click);
                        btn3[i].Click += new EventHandler(btn3_Click);
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
                    konumXYedek += groupBox1.Size.Width + aralikX;
                    if (konumXYedek + groupBox1.Size.Width >= this.Size.Width)
                    {
                        konumYYedek += groupBox1.Size.Height + aralikY;
                        konumXYedek = groupBox1.Location.X;
                    }
                    konumX[i] = konumXYedek;
                    konumY[i] = konumYYedek;

                    gb[i].Location = new Point(konumX[i], konumY[i]);
                    btn[i].Location = new Point(konumX[i] + gb[i].Size.Width - btn[i].Size.Width, konumY[i] + gb[i].Size.Height - btn[i].Size.Height);
                    btn2[i].Location = new Point(konumX[i] + (gb[i].Size.Width / 2) - (btn2[i].Size.Width / 2), konumY[i] + gb[i].Size.Height - btn[i].Size.Height);
                    btn3[i].Location = new Point(konumX[i], konumY[i] + gb[i].Size.Height - btn[i].Size.Height);
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

        
    }
}
