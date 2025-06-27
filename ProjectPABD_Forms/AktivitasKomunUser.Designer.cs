namespace ProjectPABD_Forms
{
    partial class AktivitasKomunUser
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
            this.btnKembali = new System.Windows.Forms.Button();
            this.dgvAktivitasUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivitasUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.Red;
            this.btnKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.ForeColor = System.Drawing.Color.White;
            this.btnKembali.Location = new System.Drawing.Point(358, 593);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(245, 40);
            this.btnKembali.TabIndex = 3;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // dgvAktivitasUser
            // 
            this.dgvAktivitasUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAktivitasUser.Location = new System.Drawing.Point(79, 47);
            this.dgvAktivitasUser.Name = "dgvAktivitasUser";
            this.dgvAktivitasUser.RowHeadersWidth = 51;
            this.dgvAktivitasUser.RowTemplate.Height = 24;
            this.dgvAktivitasUser.Size = new System.Drawing.Size(834, 524);
            this.dgvAktivitasUser.TabIndex = 2;
            // 
            // AktivitasKomunUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(993, 680);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.dgvAktivitasUser);
            this.Name = "AktivitasKomunUser";
            this.Text = "AktivitasKomunUser";
            this.Load += new System.EventHandler(this.AktivitasKomunUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivitasUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.DataGridView dgvAktivitasUser;
    }
}