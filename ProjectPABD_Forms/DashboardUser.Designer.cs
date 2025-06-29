namespace ProjectPABD_Forms
{
    partial class DashboardUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardUser));
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAktivitas = new System.Windows.Forms.Panel();
            this.pnlKomunitas = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGrafik = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogOut.Location = new System.Drawing.Point(23, 21);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(111, 35);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica Neue", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 53);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dashboard Pengguna";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica Neue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(515, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Data Aktivitas dan Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica Neue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(137, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data Komunitas";
            // 
            // pnlAktivitas
            // 
            this.pnlAktivitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlAktivitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAktivitas.BackgroundImage")));
            this.pnlAktivitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlAktivitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAktivitas.Location = new System.Drawing.Point(560, 370);
            this.pnlAktivitas.Name = "pnlAktivitas";
            this.pnlAktivitas.Size = new System.Drawing.Size(206, 189);
            this.pnlAktivitas.TabIndex = 10;
            this.pnlAktivitas.Click += new System.EventHandler(this.pnlAktivitas_Click);
            // 
            // pnlKomunitas
            // 
            this.pnlKomunitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlKomunitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlKomunitas.BackgroundImage")));
            this.pnlKomunitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlKomunitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKomunitas.Location = new System.Drawing.Point(135, 370);
            this.pnlKomunitas.Name = "pnlKomunitas";
            this.pnlKomunitas.Size = new System.Drawing.Size(204, 189);
            this.pnlKomunitas.TabIndex = 9;
            this.pnlKomunitas.Click += new System.EventHandler(this.pnlKomunitas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica Neue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(311, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 28);
            this.label4.TabIndex = 14;
            this.label4.Text = "Grafik Kategori Komunitas";
            // 
            // pnlGrafik
            // 
            this.pnlGrafik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlGrafik.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlGrafik.BackgroundImage")));
            this.pnlGrafik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlGrafik.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGrafik.Location = new System.Drawing.Point(365, 103);
            this.pnlGrafik.Name = "pnlGrafik";
            this.pnlGrafik.Size = new System.Drawing.Size(206, 189);
            this.pnlGrafik.TabIndex = 13;
            this.pnlGrafik.Click += new System.EventHandler(this.pnlGrafik_Click);
            // 
            // DashboardUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(947, 660);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlGrafik);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlAktivitas);
            this.Controls.Add(this.pnlKomunitas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardUser";
            this.Text = "Dashboard User";
            this.Load += new System.EventHandler(this.DashboardUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAktivitas;
        private System.Windows.Forms.Panel pnlKomunitas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGrafik;
    }
}