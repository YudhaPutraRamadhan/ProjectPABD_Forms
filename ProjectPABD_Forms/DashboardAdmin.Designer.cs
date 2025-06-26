namespace ProjectPABD_Forms
{
    partial class DashboardAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardAdmin));
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAktivitas = new System.Windows.Forms.Panel();
            this.pnlKomunitas = new System.Windows.Forms.Panel();
            this.pnlPengguna = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlAdminKomunitas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogOut.Location = new System.Drawing.Point(22, 22);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(111, 35);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica Neue", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(200, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 53);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dashboard Super Admin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica Neue", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(556, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Aktivitas dan Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(138, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Data Komunitas";
            // 
            // pnlAktivitas
            // 
            this.pnlAktivitas.BackColor = System.Drawing.Color.Transparent;
            this.pnlAktivitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAktivitas.BackgroundImage")));
            this.pnlAktivitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlAktivitas.Location = new System.Drawing.Point(161, 304);
            this.pnlAktivitas.Name = "pnlAktivitas";
            this.pnlAktivitas.Size = new System.Drawing.Size(138, 143);
            this.pnlAktivitas.TabIndex = 9;
            // 
            // pnlKomunitas
            // 
            this.pnlKomunitas.BackColor = System.Drawing.Color.Transparent;
            this.pnlKomunitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlKomunitas.BackgroundImage")));
            this.pnlKomunitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlKomunitas.Location = new System.Drawing.Point(622, 304);
            this.pnlKomunitas.Name = "pnlKomunitas";
            this.pnlKomunitas.Size = new System.Drawing.Size(141, 143);
            this.pnlKomunitas.TabIndex = 8;
            // 
            // pnlPengguna
            // 
            this.pnlPengguna.BackColor = System.Drawing.Color.Transparent;
            this.pnlPengguna.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPengguna.BackgroundImage")));
            this.pnlPengguna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlPengguna.Location = new System.Drawing.Point(161, 94);
            this.pnlPengguna.Name = "pnlPengguna";
            this.pnlPengguna.Size = new System.Drawing.Size(138, 143);
            this.pnlPengguna.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica Neue", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(556, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kelola Admin Komunitas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Helvetica Neue", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(138, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "Kelola Pengguna";
            // 
            // pnlAdminKomunitas
            // 
            this.pnlAdminKomunitas.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdminKomunitas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAdminKomunitas.BackgroundImage")));
            this.pnlAdminKomunitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlAdminKomunitas.Location = new System.Drawing.Point(622, 94);
            this.pnlAdminKomunitas.Name = "pnlAdminKomunitas";
            this.pnlAdminKomunitas.Size = new System.Drawing.Size(141, 143);
            this.pnlAdminKomunitas.TabIndex = 12;
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(946, 554);
            this.Controls.Add(this.pnlPengguna);
            this.Controls.Add(this.pnlAktivitas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlAdminKomunitas);
            this.Controls.Add(this.pnlKomunitas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardAdmin";
            this.Text = "DashboardAdmin";
            this.Load += new System.EventHandler(this.DashboardAdmin_Load);
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
        private System.Windows.Forms.Panel pnlPengguna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlAdminKomunitas;
    }
}