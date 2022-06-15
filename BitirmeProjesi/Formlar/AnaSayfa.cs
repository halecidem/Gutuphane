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

        int aralikX = 20;
        int aralikY = 35;
        int konumXYedek = 0;
        int konumYYedek = 0;

        ListBox lbSonYazilanKitapAdi = new ListBox();
        ListBox lbSonYazilanYazarAdi = new ListBox();
        int[] SonYazilanKonumX = new int[10];
        int[] SonYazilanKonumY = new int[10];
        GroupBox[] gbSonYazilan = new GroupBox[10];
        Label[] lblSonYazilanYazar = new Label[10];

        ListBox lbEnCokOkunanKitapAdi = new ListBox();
        ListBox lbEnCokOkunanYazarAdi = new ListBox();
        int[] EnCokOkunanKonumX = new int[10];
        int[] EnCokOkunanKonumY = new int[10];
        GroupBox[] gbEnCokOkunan = new GroupBox[10];
        Label[] lblEnCokOkunanYazar = new Label[10];

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
            ai.SonEklenenler(lbSonYazilanKitapAdi, lbSonYazilanYazarAdi);
            ai.EnCokOkunanlar(lbEnCokOkunanKitapAdi, lbEnCokOkunanYazarAdi);

            #region Son Yazılanlar Kutuları
            if (lbSonYazilanKitapAdi.Items.Count > 0)
            {
                for (int i = 0; i < lbSonYazilanKitapAdi.Items.Count; i++)
                {
                    if (lbSonYazilanKitapAdi.Items[i] != null)
                    {
                        string kitap = lbSonYazilanKitapAdi.Items[i].ToString();
                        string yazar = lbSonYazilanYazarAdi.Items[i].ToString();

                        gbSonYazilan[i] = new GroupBox();
                        gbSonYazilan[i].ForeColor = Color.White;
                        gbSonYazilan[i].Text = kitap;
                        gbSonYazilan[i].Size = new Size(groupBox2.Size.Width, groupBox2.Size.Height);
                        this.Controls.Add(gbSonYazilan[i]);
                        gbSonYazilan[i].BringToFront();

                        lblSonYazilanYazar[i] = new Label();
                        lblSonYazilanYazar[i].Text = yazar;
                        lblSonYazilanYazar[i].ForeColor = Color.White;
                        this.Controls.Add(lblSonYazilanYazar[i]);
                        lblSonYazilanYazar[i].BringToFront();

                        void gb_Click(object sendr, EventArgs a)
                        {
                            Gitap gt = new Gitap(kullaniciAdi, yazar, kitap);
                            gt.MdiParent = this.MdiParent;
                            gt.Show();
                        }

                        gbSonYazilan[i].Click += new EventHandler(gb_Click);
                    }
                }
            }
            #endregion

            #region En Çok Okunanlar Kutuları
            if (lbEnCokOkunanKitapAdi.Items.Count > 0)
            {
                for (int i = 0; i < lbEnCokOkunanKitapAdi.Items.Count; i++)
                {
                    if (lbEnCokOkunanKitapAdi.Items[i] != null)
                    {
                        string kitap = lbEnCokOkunanKitapAdi.Items[i].ToString();
                        string yazar = lbEnCokOkunanYazarAdi.Items[i].ToString();

                        gbEnCokOkunan[i] = new GroupBox();
                        gbEnCokOkunan[i].ForeColor = Color.White;
                        gbEnCokOkunan[i].Text = kitap;
                        gbEnCokOkunan[i].Size = new Size(groupBox2.Size.Width, groupBox2.Size.Height);
                        this.Controls.Add(gbEnCokOkunan[i]);
                        gbEnCokOkunan[i].BringToFront();

                        lblEnCokOkunanYazar[i] = new Label();
                        lblEnCokOkunanYazar[i].Text = yazar;
                        lblEnCokOkunanYazar[i].ForeColor = Color.White;
                        this.Controls.Add(lblEnCokOkunanYazar[i]);
                        lblEnCokOkunanYazar[i].BringToFront();

                        void gb_Click(object sendr, EventArgs a)
                        {
                            Gitap gt = new Gitap(kullaniciAdi, yazar, kitap);
                            gt.MdiParent = this.MdiParent;
                            gt.Show();
                        }

                        gbEnCokOkunan[i].Click += new EventHandler(gb_Click);
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

            for (int i = 0; i < gbSonYazilan.Length; i++)
            {
                if (gbSonYazilan[i] != null)
                {
                    SonYazilanKonumX[i] = konumXYedek;
                    SonYazilanKonumY[i] = konumYYedek;

                    gbSonYazilan[i].Location = new Point(SonYazilanKonumX[i] + groupBox1.Location.X, SonYazilanKonumY[i] + groupBox1.Location.Y);
                    lblSonYazilanYazar[i].Size = new Size(lblSonYazilanYazar[i].Text.Length * 10, lblSonYazilanYazar[i].Size.Height);
                    lblSonYazilanYazar[i].Location = new Point(gbSonYazilan[i].Location.X + (gbSonYazilan[i].Size.Width / 2) - (lblSonYazilanYazar[i].Size.Width / 2), gbSonYazilan[i].Location.Y + gbSonYazilan[i].Size.Height - (lblSonYazilanYazar[i].Size.Height / 2));
                    konumXYedek += groupBox2.Size.Width + aralikX;
                }
            }

            konumXYedek = groupBox6.Location.X;
            konumYYedek = groupBox6.Location.Y;

            for (int i = 0; i < gbEnCokOkunan.Length; i++)
            {
                if (gbEnCokOkunan[i] != null)
                {
                    EnCokOkunanKonumX[i] = konumXYedek;
                    EnCokOkunanKonumY[i] = konumYYedek;

                    gbEnCokOkunan[i].Location = new Point(EnCokOkunanKonumX[i] + groupBox5.Location.X, EnCokOkunanKonumY[i] + groupBox5.Location.Y);
                    lblEnCokOkunanYazar[i].Size = new Size(lblEnCokOkunanYazar[i].Text.Length * 10, lblEnCokOkunanYazar[i].Size.Height);
                    lblEnCokOkunanYazar[i].Location = new Point(gbEnCokOkunan[i].Location.X + (gbEnCokOkunan[i].Size.Width / 2) - (lblEnCokOkunanYazar[i].Size.Width / 2), gbEnCokOkunan[i].Location.Y + gbEnCokOkunan[i].Size.Height - (lblEnCokOkunanYazar[i].Size.Height / 2));
                    konumXYedek += groupBox6.Size.Width + aralikX;
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
            Cuzdan cd = new Cuzdan(kullaniciAdi);
            cd.MdiParent = this.MdiParent;
            cd.Show();
        }
    }
}
