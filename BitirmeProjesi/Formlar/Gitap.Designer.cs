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
            this.lblIcerik = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gitap Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gitap İçeriği:";
            // 
            // lblKitap
            // 
            this.lblKitap.AutoSize = true;
            this.lblKitap.Location = new System.Drawing.Point(147, 180);
            this.lblKitap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKitap.Name = "lblKitap";
            this.lblKitap.Size = new System.Drawing.Size(18, 20);
            this.lblKitap.TabIndex = 2;
            this.lblKitap.Text = "0";
            // 
            // lblIcerik
            // 
            this.lblIcerik.AutoSize = true;
            this.lblIcerik.Location = new System.Drawing.Point(147, 237);
            this.lblIcerik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIcerik.Name = "lblIcerik";
            this.lblIcerik.Size = new System.Drawing.Size(18, 20);
            this.lblIcerik.TabIndex = 3;
            this.lblIcerik.Text = "0";
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
            // Gitap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(930, 814);
            this.ControlBox = false;
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.lblIcerik);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKitap;
        private System.Windows.Forms.Label lblIcerik;
        private System.Windows.Forms.Button btnGeri;
    }
}