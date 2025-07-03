namespace ProjectPABD_Forms
{
    partial class DashboardAdminKomun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardAdminKomun));
            this.pnlKomunitas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAktivitas = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlKomunitas
            // 
            this.pnlKomunitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlKomunitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlKomunitas.BackgroundImage")));
            this.pnlKomunitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlKomunitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKomunitas.Location = new System.Drawing.Point(77, 160);
            this.pnlKomunitas.Name = "pnlKomunitas";
            this.pnlKomunitas.Size = new System.Drawing.Size(324, 286);
            this.pnlKomunitas.TabIndex = 0;
            this.pnlKomunitas.Click += new System.EventHandler(this.pnlKomunitas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica Neue", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(152, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(682, 53);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dashboard Admin Komunitas";
            // 
            // pnlAktivitas
            // 
            this.pnlAktivitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlAktivitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAktivitas.BackgroundImage")));
            this.pnlAktivitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlAktivitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAktivitas.Location = new System.Drawing.Point(577, 161);
            this.pnlAktivitas.Name = "pnlAktivitas";
            this.pnlAktivitas.Size = new System.Drawing.Size(324, 286);
            this.pnlAktivitas.TabIndex = 2;
            this.pnlAktivitas.Click += new System.EventHandler(this.pnlAktivitas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica Neue", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Komunitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica Neue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(587, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Aktivitas dan Event";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogOut.Location = new System.Drawing.Point(21, 21);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(111, 35);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // DashboardAdminKomun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(987, 615);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlAktivitas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlKomunitas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardAdminKomun";
            this.Text = "Dashboard Admin Komunitas";
            this.Load += new System.EventHandler(this.Beranda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKomunitas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAktivitas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogOut;
    }
}