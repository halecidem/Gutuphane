﻿namespace BitirmeProjesi
{
    partial class Oku
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
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnOnceki = new System.Windows.Forms.Button();
            this.btnSonraki = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblBolum = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblSayi = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Black;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.ForeColor = System.Drawing.Color.White;
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(40, 35);
            this.btnGeri.TabIndex = 28;
            this.btnGeri.Text = "X";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnOnceki
            // 
            this.btnOnceki.BackColor = System.Drawing.Color.Black;
            this.btnOnceki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnceki.ForeColor = System.Drawing.Color.White;
            this.btnOnceki.Location = new System.Drawing.Point(158, 12);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(40, 35);
            this.btnOnceki.TabIndex = 40;
            this.btnOnceki.Text = "<-";
            this.btnOnceki.UseVisualStyleBackColor = false;
            this.btnOnceki.Click += new System.EventHandler(this.btnOnceki_Click);
            // 
            // btnSonraki
            // 
            this.btnSonraki.BackColor = System.Drawing.Color.Black;
            this.btnSonraki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSonraki.ForeColor = System.Drawing.Color.White;
            this.btnSonraki.Location = new System.Drawing.Point(729, 12);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(40, 35);
            this.btnSonraki.TabIndex = 41;
            this.btnSonraki.Text = "->";
            this.btnSonraki.UseVisualStyleBackColor = false;
            this.btnSonraki.Click += new System.EventHandler(this.btnSonraki_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(204, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(519, 28);
            this.comboBox1.TabIndex = 42;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // lblBolum
            // 
            this.lblBolum.AutoSize = true;
            this.lblBolum.ForeColor = System.Drawing.Color.White;
            this.lblBolum.Location = new System.Drawing.Point(38, 191);
            this.lblBolum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(54, 20);
            this.lblBolum.TabIndex = 43;
            this.lblBolum.Text = "Bölüm";
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(33, 109);
            this.lblBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(133, 54);
            this.lblBaslik.TabIndex = 44;
            this.lblBaslik.Text = "Başlık";
            // 
            // lblSayi
            // 
            this.lblSayi.AutoSize = true;
            this.lblSayi.ForeColor = System.Drawing.Color.White;
            this.lblSayi.Location = new System.Drawing.Point(74, 12);
            this.lblSayi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSayi.Name = "lblSayi";
            this.lblSayi.Size = new System.Drawing.Size(18, 20);
            this.lblSayi.TabIndex = 45;
            this.lblSayi.Text = "0";
            this.lblSayi.Visible = false;
            this.lblSayi.TextChanged += new System.EventHandler(this.lblSayi_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Oku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(930, 814);
            this.Controls.Add(this.lblSayi);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.lblBolum);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSonraki);
            this.Controls.Add(this.btnOnceki);
            this.Controls.Add(this.btnGeri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Oku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Oku";
            this.Load += new System.EventHandler(this.Oku_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnOnceki;
        private System.Windows.Forms.Button btnSonraki;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblBolum;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblSayi;
        private System.Windows.Forms.Timer timer1;
    }
}