namespace ProjectPABD_Forms
{
    partial class Transaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transaction));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKembali = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.dateTanggalEvent = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamaEvent = new System.Windows.Forms.TextBox();
            this.txtIdEvent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboxStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboxJenis = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdAktivitas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAktivitas = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivitas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btnKembali);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 63);
            this.panel1.TabIndex = 0;
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.Red;
            this.btnKembali.ForeColor = System.Drawing.Color.White;
            this.btnKembali.Location = new System.Drawing.Point(29, 17);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(108, 30);
            this.btnKembali.TabIndex = 1;
            this.btnKembali.Text = "Back";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(628, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Event dan Aktivitas Komunitas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.txtLokasi);
            this.panel2.Controls.Add(this.dateTanggalEvent);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNamaEvent);
            this.panel2.Controls.Add(this.txtIdEvent);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 179);
            this.panel2.TabIndex = 1;
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(661, 112);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(298, 22);
            this.txtLokasi.TabIndex = 7;
            this.txtLokasi.TextChanged += new System.EventHandler(this.txtLokasi_TextChanged);
            this.txtLokasi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLokasi_KeyPress);
            // 
            // dateTanggalEvent
            // 
            this.dateTanggalEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTanggalEvent.Location = new System.Drawing.Point(661, 40);
            this.dateTanggalEvent.Name = "dateTanggalEvent";
            this.dateTanggalEvent.Size = new System.Drawing.Size(298, 24);
            this.dateTanggalEvent.TabIndex = 6;
            this.dateTanggalEvent.ValueChanged += new System.EventHandler(this.dateTanggalEvent_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(498, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Lokasi Event     :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(489, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tanggal Event     :";
            // 
            // txtNamaEvent
            // 
            this.txtNamaEvent.Location = new System.Drawing.Point(170, 111);
            this.txtNamaEvent.Name = "txtNamaEvent";
            this.txtNamaEvent.Size = new System.Drawing.Size(290, 22);
            this.txtNamaEvent.TabIndex = 4;
            this.txtNamaEvent.TextChanged += new System.EventHandler(this.txtNamaEvent_TextChanged);
            // 
            // txtIdEvent
            // 
            this.txtIdEvent.Location = new System.Drawing.Point(170, 39);
            this.txtIdEvent.Name = "txtIdEvent";
            this.txtIdEvent.Size = new System.Drawing.Size(290, 22);
            this.txtIdEvent.TabIndex = 3;
            this.txtIdEvent.TextChanged += new System.EventHandler(this.txtIdEvent_TextChanged);
            this.txtIdEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEvent_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nama Event     :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "ID Event     :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Event";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.comboxStatus);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.comboxJenis);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtIdAktivitas);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(998, 179);
            this.panel3.TabIndex = 2;
            // 
            // comboxStatus
            // 
            this.comboxStatus.FormattingEnabled = true;
            this.comboxStatus.Items.AddRange(new object[] {
            "Sedang Berlangsung",
            "Selesai",
            "Dibatalkan"});
            this.comboxStatus.Location = new System.Drawing.Point(661, 48);
            this.comboxStatus.Name = "comboxStatus";
            this.comboxStatus.Size = new System.Drawing.Size(298, 24);
            this.comboxStatus.TabIndex = 13;
            this.comboxStatus.SelectedIndexChanged += new System.EventHandler(this.comboxStatus_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(499, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Status Aktivitas :";
            // 
            // comboxJenis
            // 
            this.comboxJenis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxJenis.FormattingEnabled = true;
            this.comboxJenis.Items.AddRange(new object[] {
            "Buka Booth",
            "Gathering",
            "Lainnya"});
            this.comboxJenis.Location = new System.Drawing.Point(170, 121);
            this.comboxJenis.Name = "comboxJenis";
            this.comboxJenis.Size = new System.Drawing.Size(290, 26);
            this.comboxJenis.TabIndex = 11;
            this.comboxJenis.SelectedIndexChanged += new System.EventHandler(this.comboxJenis_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Jenis Aktivitas :";
            // 
            // txtIdAktivitas
            // 
            this.txtIdAktivitas.Location = new System.Drawing.Point(170, 48);
            this.txtIdAktivitas.Name = "txtIdAktivitas";
            this.txtIdAktivitas.Size = new System.Drawing.Size(290, 22);
            this.txtIdAktivitas.TabIndex = 9;
            this.txtIdAktivitas.TextChanged += new System.EventHandler(this.txtIdAktivitas_TextChanged);
            this.txtIdAktivitas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdAktivitas_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "ID Aktivitas     :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Data Aktivitas";
            // 
            // dgvAktivitas
            // 
            this.dgvAktivitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAktivitas.Location = new System.Drawing.Point(12, 493);
            this.dgvAktivitas.Name = "dgvAktivitas";
            this.dgvAktivitas.RowHeadersWidth = 51;
            this.dgvAktivitas.RowTemplate.Height = 24;
            this.dgvAktivitas.Size = new System.Drawing.Size(998, 222);
            this.dgvAktivitas.TabIndex = 3;
            this.dgvAktivitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAktivitas_CellClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(24, 810);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(64, 16);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(27, 740);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(101, 37);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Simpan";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHapus.Location = new System.Drawing.Point(182, 740);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(101, 37);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(347, 740);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 37);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(514, 740);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 37);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Purple;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(756, 740);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(243, 37);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "  Data Komunitas   ->";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.Location = new System.Drawing.Point(817, 667);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(167, 34);
            this.btnLaporan.TabIndex = 10;
            this.btnLaporan.Text = "Lihat Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 835);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvAktivitas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transaction";
            this.Text = "HobbyYK";
            this.Load += new System.EventHandler(this.Transaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaEvent;
        private System.Windows.Forms.TextBox txtIdEvent;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.DateTimePicker dateTanggalEvent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboxJenis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdAktivitas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboxStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvAktivitas;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnKembali;
    }
}