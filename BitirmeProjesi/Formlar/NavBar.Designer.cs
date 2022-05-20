namespace BitirmeProjesi
{
    partial class NavBar
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnaSayfa = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnKitapligim = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gütüphane";
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.BackColor = System.Drawing.Color.Black;
            this.btnAnaSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnaSayfa.ForeColor = System.Drawing.Color.White;
            this.btnAnaSayfa.Location = new System.Drawing.Point(20, 73);
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.Size = new System.Drawing.Size(140, 23);
            this.btnAnaSayfa.TabIndex = 7;
            this.btnAnaSayfa.Text = "Ana Sayfa";
            this.btnAnaSayfa.UseVisualStyleBackColor = false;
            this.btnAnaSayfa.Click += new System.EventHandler(this.btnAnaSayfa_Click);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.Black;
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(20, 112);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(140, 23);
            this.btnAra.TabIndex = 8;
            this.btnAra.Text = "Kitap Yaz";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnKitapligim
            // 
            this.btnKitapligim.BackColor = System.Drawing.Color.Black;
            this.btnKitapligim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapligim.ForeColor = System.Drawing.Color.White;
            this.btnKitapligim.Location = new System.Drawing.Point(20, 150);
            this.btnKitapligim.Name = "btnKitapligim";
            this.btnKitapligim.Size = new System.Drawing.Size(140, 23);
            this.btnKitapligim.TabIndex = 9;
            this.btnKitapligim.Text = "Kitaplığım";
            this.btnKitapligim.UseVisualStyleBackColor = false;
            this.btnKitapligim.Click += new System.EventHandler(this.btnKitapligim_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(180, 530);
            this.Controls.Add(this.btnKitapligim);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.btnAnaSayfa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NavBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gütüphane";
            this.Load += new System.EventHandler(this.NavBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnaSayfa;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnKitapligim;
        private System.Windows.Forms.Timer timer1;
    }
}