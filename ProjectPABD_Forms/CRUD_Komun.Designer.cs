namespace ProjectPABD_Forms
{
    partial class CRUD_Komun
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textJumlah = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textAlamat = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.textKategori = new System.Windows.Forms.TextBox();
            this.textTelepon = new System.Windows.Forms.TextBox();
            this.textDeskripsi = new System.Windows.Forms.TextBox();
            this.textAdmin = new System.Windows.Forms.TextBox();
            this.textNama = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgwKomun = new System.Windows.Forms.DataGridView();
            this.idKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskripsiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategoriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alamatKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailKomunitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlahAnggotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.komunitasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.management_KomunitasDataSet = new ProjectPABD_Forms.Management_KomunitasDataSet();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.komunitasTableAdapter = new ProjectPABD_Forms.Management_KomunitasDataSetTableAdapters.KomunitasTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKomun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.komunitasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.management_KomunitasDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MANAJEMEN DATA KOMUNITAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.textJumlah);
            this.panel1.Controls.Add(this.textEmail);
            this.panel1.Controls.Add(this.textAlamat);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.textKategori);
            this.panel1.Controls.Add(this.textTelepon);
            this.panel1.Controls.Add(this.textDeskripsi);
            this.panel1.Controls.Add(this.textAdmin);
            this.panel1.Controls.Add(this.textNama);
            this.panel1.Controls.Add(this.textID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 546);
            this.panel1.TabIndex = 1;
            // 
            // textJumlah
            // 
            this.textJumlah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textJumlah.Location = new System.Drawing.Point(166, 496);
            this.textJumlah.Name = "textJumlah";
            this.textJumlah.Size = new System.Drawing.Size(453, 23);
            this.textJumlah.TabIndex = 18;
            this.textJumlah.TextChanged += new System.EventHandler(this.textJumlah_TextChanged);
            this.textJumlah.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textJumlah_KeyPress);
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textEmail.Location = new System.Drawing.Point(166, 439);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(453, 23);
            this.textEmail.TabIndex = 17;
            this.textEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            this.textEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEmail_KeyPress);
            this.textEmail.Leave += new System.EventHandler(this.textEmail_Leave);
            // 
            // textAlamat
            // 
            this.textAlamat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textAlamat.Location = new System.Drawing.Point(166, 381);
            this.textAlamat.Name = "textAlamat";
            this.textAlamat.Size = new System.Drawing.Size(453, 23);
            this.textAlamat.TabIndex = 16;
            this.textAlamat.TextChanged += new System.EventHandler(this.textAlamat_TextChanged);
            this.textAlamat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAlamat_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(537, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 38);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // textKategori
            // 
            this.textKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textKategori.Location = new System.Drawing.Point(166, 323);
            this.textKategori.Name = "textKategori";
            this.textKategori.Size = new System.Drawing.Size(453, 23);
            this.textKategori.TabIndex = 15;
            this.textKategori.TextChanged += new System.EventHandler(this.textKategori_TextChanged);
            this.textKategori.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textKategori_KeyPress);
            // 
            // textTelepon
            // 
            this.textTelepon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textTelepon.Location = new System.Drawing.Point(166, 270);
            this.textTelepon.Name = "textTelepon";
            this.textTelepon.Size = new System.Drawing.Size(453, 23);
            this.textTelepon.TabIndex = 14;
            this.textTelepon.TextChanged += new System.EventHandler(this.textTelepon_TextChanged);
            this.textTelepon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTelepon_KeyPress);
            // 
            // textDeskripsi
            // 
            this.textDeskripsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textDeskripsi.Location = new System.Drawing.Point(166, 213);
            this.textDeskripsi.Name = "textDeskripsi";
            this.textDeskripsi.Size = new System.Drawing.Size(453, 23);
            this.textDeskripsi.TabIndex = 13;
            this.textDeskripsi.TextChanged += new System.EventHandler(this.textDeskripsi_TextChanged);
            // 
            // textAdmin
            // 
            this.textAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textAdmin.Location = new System.Drawing.Point(166, 159);
            this.textAdmin.Name = "textAdmin";
            this.textAdmin.Size = new System.Drawing.Size(453, 23);
            this.textAdmin.TabIndex = 12;
            this.textAdmin.TextChanged += new System.EventHandler(this.textAdmin_TextChanged);
            this.textAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAdmin_KeyPress);
            // 
            // textNama
            // 
            this.textNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textNama.Location = new System.Drawing.Point(166, 107);
            this.textNama.Name = "textNama";
            this.textNama.Size = new System.Drawing.Size(453, 23);
            this.textNama.TabIndex = 11;
            this.textNama.TextChanged += new System.EventHandler(this.textNama_TextChanged);
            // 
            // textID
            // 
            this.textID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textID.Location = new System.Drawing.Point(166, 57);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(453, 23);
            this.textID.TabIndex = 10;
            this.textID.TextChanged += new System.EventHandler(this.textID_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 496);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 9;
            this.label11.Text = "Jumlah Anggota";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Alamat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Kategori";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Nomor Telepon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Deskripsi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Admin Komunitas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nama Komunitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID Komunitas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Masukkan Data Komunitas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btnAnalyze);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.dgwKomun);
            this.panel2.Location = new System.Drawing.Point(674, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 659);
            this.panel2.TabIndex = 2;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.DimGray;
            this.btnAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAnalyze.ForeColor = System.Drawing.Color.White;
            this.btnAnalyze.Location = new System.Drawing.Point(308, 583);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(99, 38);
            this.btnAnalyze.TabIndex = 9;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Black;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(436, 583);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(99, 38);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgwKomun
            // 
            this.dgwKomun.AutoGenerateColumns = false;
            this.dgwKomun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKomun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idKomunitasDataGridViewTextBoxColumn,
            this.namaKomunitasDataGridViewTextBoxColumn,
            this.adminKomunitasDataGridViewTextBoxColumn,
            this.deskripsiDataGridViewTextBoxColumn,
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn,
            this.kategoriDataGridViewTextBoxColumn,
            this.alamatKomunitasDataGridViewTextBoxColumn,
            this.emailKomunitasDataGridViewTextBoxColumn,
            this.jumlahAnggotaDataGridViewTextBoxColumn});
            this.dgwKomun.DataSource = this.komunitasBindingSource;
            this.dgwKomun.Location = new System.Drawing.Point(0, 0);
            this.dgwKomun.Name = "dgwKomun";
            this.dgwKomun.RowHeadersWidth = 51;
            this.dgwKomun.RowTemplate.Height = 24;
            this.dgwKomun.Size = new System.Drawing.Size(556, 659);
            this.dgwKomun.TabIndex = 0;
            this.dgwKomun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwKomun_CellClick);
            // 
            // idKomunitasDataGridViewTextBoxColumn
            // 
            this.idKomunitasDataGridViewTextBoxColumn.DataPropertyName = "IdKomunitas";
            this.idKomunitasDataGridViewTextBoxColumn.HeaderText = "IdKomunitas";
            this.idKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idKomunitasDataGridViewTextBoxColumn.Name = "idKomunitasDataGridViewTextBoxColumn";
            this.idKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // namaKomunitasDataGridViewTextBoxColumn
            // 
            this.namaKomunitasDataGridViewTextBoxColumn.DataPropertyName = "NamaKomunitas";
            this.namaKomunitasDataGridViewTextBoxColumn.HeaderText = "NamaKomunitas";
            this.namaKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.namaKomunitasDataGridViewTextBoxColumn.Name = "namaKomunitasDataGridViewTextBoxColumn";
            this.namaKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // adminKomunitasDataGridViewTextBoxColumn
            // 
            this.adminKomunitasDataGridViewTextBoxColumn.DataPropertyName = "AdminKomunitas";
            this.adminKomunitasDataGridViewTextBoxColumn.HeaderText = "AdminKomunitas";
            this.adminKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adminKomunitasDataGridViewTextBoxColumn.Name = "adminKomunitasDataGridViewTextBoxColumn";
            this.adminKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // deskripsiDataGridViewTextBoxColumn
            // 
            this.deskripsiDataGridViewTextBoxColumn.DataPropertyName = "Deskripsi";
            this.deskripsiDataGridViewTextBoxColumn.HeaderText = "Deskripsi";
            this.deskripsiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deskripsiDataGridViewTextBoxColumn.Name = "deskripsiDataGridViewTextBoxColumn";
            this.deskripsiDataGridViewTextBoxColumn.Width = 125;
            // 
            // nomorTeleponKomunitasDataGridViewTextBoxColumn
            // 
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn.DataPropertyName = "NomorTeleponKomunitas";
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn.HeaderText = "NomorTeleponKomunitas";
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn.Name = "nomorTeleponKomunitasDataGridViewTextBoxColumn";
            this.nomorTeleponKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // kategoriDataGridViewTextBoxColumn
            // 
            this.kategoriDataGridViewTextBoxColumn.DataPropertyName = "Kategori";
            this.kategoriDataGridViewTextBoxColumn.HeaderText = "Kategori";
            this.kategoriDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kategoriDataGridViewTextBoxColumn.Name = "kategoriDataGridViewTextBoxColumn";
            this.kategoriDataGridViewTextBoxColumn.Width = 125;
            // 
            // alamatKomunitasDataGridViewTextBoxColumn
            // 
            this.alamatKomunitasDataGridViewTextBoxColumn.DataPropertyName = "AlamatKomunitas";
            this.alamatKomunitasDataGridViewTextBoxColumn.HeaderText = "AlamatKomunitas";
            this.alamatKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.alamatKomunitasDataGridViewTextBoxColumn.Name = "alamatKomunitasDataGridViewTextBoxColumn";
            this.alamatKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailKomunitasDataGridViewTextBoxColumn
            // 
            this.emailKomunitasDataGridViewTextBoxColumn.DataPropertyName = "EmailKomunitas";
            this.emailKomunitasDataGridViewTextBoxColumn.HeaderText = "EmailKomunitas";
            this.emailKomunitasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailKomunitasDataGridViewTextBoxColumn.Name = "emailKomunitasDataGridViewTextBoxColumn";
            this.emailKomunitasDataGridViewTextBoxColumn.Width = 125;
            // 
            // jumlahAnggotaDataGridViewTextBoxColumn
            // 
            this.jumlahAnggotaDataGridViewTextBoxColumn.DataPropertyName = "JumlahAnggota";
            this.jumlahAnggotaDataGridViewTextBoxColumn.HeaderText = "JumlahAnggota";
            this.jumlahAnggotaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.jumlahAnggotaDataGridViewTextBoxColumn.Name = "jumlahAnggotaDataGridViewTextBoxColumn";
            this.jumlahAnggotaDataGridViewTextBoxColumn.Width = 125;
            // 
            // komunitasBindingSource
            // 
            this.komunitasBindingSource.DataMember = "Komunitas";
            this.komunitasBindingSource.DataSource = this.management_KomunitasDataSet;
            // 
            // management_KomunitasDataSet
            // 
            this.management_KomunitasDataSet.DataSetName = "Management_KomunitasDataSet";
            this.management_KomunitasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.btnSimpan);
            this.panel3.Controls.Add(this.btnUbah);
            this.panel3.Controls.Add(this.btnHapus);
            this.panel3.Location = new System.Drawing.Point(12, 599);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(656, 107);
            this.panel3.TabIndex = 3;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(20, 31);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(99, 38);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnUbah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnUbah.ForeColor = System.Drawing.Color.White;
            this.btnUbah.Location = new System.Drawing.Point(150, 31);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(99, 38);
            this.btnUbah.TabIndex = 6;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = false;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(285, 31);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(99, 38);
            this.btnHapus.TabIndex = 5;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // komunitasTableAdapter
            // 
            this.komunitasTableAdapter.ClearBeforeFill = true;
            // 
            // CRUD_Komun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1242, 706);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "CRUD_Komun";
            this.Text = "Data Komunitas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwKomun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.komunitasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.management_KomunitasDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textTelepon;
        private System.Windows.Forms.TextBox textDeskripsi;
        private System.Windows.Forms.TextBox textAdmin;
        private System.Windows.Forms.TextBox textNama;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textJumlah;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textAlamat;
        private System.Windows.Forms.TextBox textKategori;
        private System.Windows.Forms.DataGridView dgwKomun;
        private Management_KomunitasDataSet management_KomunitasDataSet;
        private System.Windows.Forms.BindingSource komunitasBindingSource;
        private Management_KomunitasDataSetTableAdapters.KomunitasTableAdapter komunitasTableAdapter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn idKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskripsiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomorTeleponKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategoriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alamatKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailKomunitasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlahAnggotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
    }
}

