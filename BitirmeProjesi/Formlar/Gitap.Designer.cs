namespace BitirmeProjesi
{
    partial class Gitap
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKitap = new System.Windows.Forms.Label();
            this.lblKitapTuru = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.lblKitapKonusu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblYazar = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOku = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gitap Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gitap Türü:";
            // 
            // lblKitap
            // 
            this.lblKitap.AutoSize = true;
            this.lblKitap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitap.Location = new System.Drawing.Point(454, 103);
            this.lblKitap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKitap.Name = "lblKitap";
            this.lblKitap.Size = new System.Drawing.Size(19, 20);
            this.lblKitap.TabIndex = 2;
            this.lblKitap.Text = "0";
            // 
            // lblKitapTuru
            // 
            this.lblKitapTuru.AutoSize = true;
            this.lblKitapTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapTuru.Location = new System.Drawing.Point(455, 220);
            this.lblKitapTuru.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKitapTuru.Name = "lblKitapTuru";
            this.lblKitapTuru.Size = new System.Drawing.Size(19, 20);
            this.lblKitapTuru.TabIndex = 3;
            this.lblKitapTuru.Text = "0";
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Black;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Location = new System.Drawing.Point(16, 17);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(40, 35);
            this.btnGeri.TabIndex = 27;
            this.btnGeri.Text = "<-";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // lblKitapKonusu
            // 
            this.lblKitapKonusu.AutoSize = true;
            this.lblKitapKonusu.Location = new System.Drawing.Point(228, 320);
            this.lblKitapKonusu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKitapKonusu.Name = "lblKitapKonusu";
            this.lblKitapKonusu.Size = new System.Drawing.Size(18, 20);
            this.lblKitapKonusu.TabIndex = 29;
            this.lblKitapKonusu.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(108, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Gitap Konusu:";
            // 
            // lblYazar
            // 
            this.lblYazar.AutoSize = true;
            this.lblYazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYazar.Location = new System.Drawing.Point(453, 164);
            this.lblYazar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYazar.Name = "lblYazar";
            this.lblYazar.Size = new System.Drawing.Size(19, 20);
            this.lblYazar.TabIndex = 31;
            this.lblYazar.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Yazar Adı:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(112, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 200);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // btnOku
            // 
            this.btnOku.BackColor = System.Drawing.Color.Black;
            this.btnOku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOku.ForeColor = System.Drawing.Color.White;
            this.btnOku.Location = new System.Drawing.Point(803, 96);
            this.btnOku.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOku.Name = "btnOku";
            this.btnOku.Size = new System.Drawing.Size(96, 35);
            this.btnOku.TabIndex = 35;
            this.btnOku.Text = "Oku";
            this.btnOku.UseVisualStyleBackColor = false;
            // 
            // Gitap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(930, 788);
            this.ControlBox = false;
            this.Controls.Add(this.btnOku);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblYazar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblKitapKonusu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.lblKitapTuru);
            this.Controls.Add(this.lblKitap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Gitap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gütüphane";
            this.Load += new System.EventHandler(this.Gitap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKitap;
        private System.Windows.Forms.Label lblKitapTuru;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Label lblKitapKonusu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblYazar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOku;
    }
}