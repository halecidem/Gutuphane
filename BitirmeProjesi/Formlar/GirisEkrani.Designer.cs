namespace BitirmeProjesi
{
    partial class GirisEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.kullaniciAdi = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.lblHataMesaji = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(102, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gütüphane";
            // 
            // kullaniciAdi
            // 
            this.kullaniciAdi.BackColor = System.Drawing.Color.Black;
            this.kullaniciAdi.ForeColor = System.Drawing.Color.White;
            this.kullaniciAdi.Location = new System.Drawing.Point(91, 92);
            this.kullaniciAdi.MaxLength = 30;
            this.kullaniciAdi.Name = "kullaniciAdi";
            this.kullaniciAdi.Size = new System.Drawing.Size(219, 23);
            this.kullaniciAdi.TabIndex = 3;
            // 
            // sifre
            // 
            this.sifre.BackColor = System.Drawing.Color.Black;
            this.sifre.ForeColor = System.Drawing.Color.White;
            this.sifre.Location = new System.Drawing.Point(91, 129);
            this.sifre.MaxLength = 30;
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(219, 23);
            this.sifre.TabIndex = 5;
            this.sifre.UseSystemPasswordChar = true;
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Black;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Location = new System.Drawing.Point(139, 174);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(75, 23);
            this.btnGiris.TabIndex = 6;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // lblHataMesaji
            // 
            this.lblHataMesaji.AutoSize = true;
            this.lblHataMesaji.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHataMesaji.ForeColor = System.Drawing.Color.White;
            this.lblHataMesaji.Location = new System.Drawing.Point(12, 228);
            this.lblHataMesaji.Name = "lblHataMesaji";
            this.lblHataMesaji.Size = new System.Drawing.Size(67, 13);
            this.lblHataMesaji.TabIndex = 7;
            this.lblHataMesaji.Text = "Hata Mesajı";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.White;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(12, 95);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(73, 15);
            this.lblKullaniciAdi.TabIndex = 8;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.ForeColor = System.Drawing.Color.White;
            this.lblSifre.Location = new System.Drawing.Point(32, 132);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(30, 15);
            this.lblSifre.TabIndex = 9;
            this.lblSifre.Text = "Şifre";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(11, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 26);
            this.button2.TabIndex = 26;
            this.button2.Text = "<-";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(370, 250);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.lblHataMesaji);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullaniciAdi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GirisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gütüphane";
            this.Load += new System.EventHandler(this.GirisEkrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kullaniciAdi;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label lblHataMesaji;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button button2;
    }
}