﻿using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Caching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ProjectPABD_Forms
{
    public partial class DataKomunitas : Form
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "KomunitasData";

        public DataKomunitas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadKategori();
            LoadData();
        }

        private void EnsureIndexes()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.Komunitas', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Komunitas_NamaKomunitas_NomorTeleponKomunitas_AdminKomunitas')
                    CREATE NONCLUSTERED INDEX idx_Komunitas_NamaKomunitas_NomorTeleponKomunitas_AdminKomunitas ON dbo.Komunitas(NamaKomunitas, NomorTeleponKomunitas, AdminKomunitas);
                END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ClearForm()
        {
            textID.Clear();
            textNama.Clear();
            textAdmin.Clear();
            textDeskripsi.Clear();
            textTelepon.Clear();
            if (cmbKategori.Items.Count > 0)
            {
                cmbKategori.SelectedIndex = 0;
            }
            textAlamat.Clear();
            textEmail.Clear();
            textJumlah.Clear();
            dgwKomun.ClearSelection();

            textID.Focus();
        }

        private void LoadData()
        {
            DataTable dt;
            if (_cache.Contains(CacheKey))
            {
                dt = _cache.Get(CacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT
                            K.IdKomunitas AS [ID],
                            K.NamaKomunitas,
                            K.AdminKomunitas,
                            K.Deskripsi,
                            K.NomorTeleponKomunitas,
                            TK.NamaKategori AS Kategori,
                            K.AlamatKomunitas,
                            K.EmailKomunitas,
                            K.JumlahAnggota,
                            K.IdKategori
                        FROM
                            Komunitas AS K
                        INNER JOIN
                            KategoriKomunitas AS TK ON K.IdKategori = TK.IdKategori";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }

            dgwKomun.AutoGenerateColumns = true;
            dgwKomun.DataSource = dt;

            if (dgwKomun.Columns.Contains("IdKategori"))
            {
                dgwKomun.Columns["IdKategori"].Visible = false;
            }
        }

        private void LoadKategori()
        {
            try
            {
                string query = "SELECT IdKategori, NamaKategori FROM KategoriKomunitas ORDER BY NamaKategori";
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                DataRow newRow = dataTable.NewRow();
                newRow["IdKategori"] = DBNull.Value;
                newRow["NamaKategori"] = "-- Pilih Kategori --";
                dataTable.Rows.InsertAt(newRow, 0);

                cmbKategori.DataSource = dataTable;
                cmbKategori.DisplayMember = "NamaKategori";
                cmbKategori.ValueMember = "IdKategori";
                cmbKategori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat kategori: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();
                var wrapped = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlQuery};
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void textID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textDeskripsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTelepon_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textJumlah_TextChanged(object sender, EventArgs e)
        {

        }

        // Metode baru untuk memeriksa duplikasi IdKomunitas
        private bool IsKomunitasIdExist(string idKomunitas)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Komunitas WHERE IdKomunitas = @IdKomunitas";
                SqlParameter[] parameters = { new SqlParameter("@IdKomunitas", idKomunitas) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa ID Komunitas: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Asumsikan ada untuk mencegah duplikasi jika terjadi error
            }
        }

        // Metode baru untuk memeriksa duplikasi NamaKomunitas
        private bool IsNamaKomunitasExist(string namaKomunitas)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Komunitas WHERE NamaKomunitas = @NamaKomunitas";
                SqlParameter[] parameters = { new SqlParameter("@NamaKomunitas", namaKomunitas) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa Nama Komunitas: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Asumsikan ada untuk mencegah duplikasi jika terjadi error
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textID.Text) || string.IsNullOrWhiteSpace(textNama.Text))
            {
                MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbKategori.SelectedValue == DBNull.Value || cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Harap pilih kategori!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateEmail(textEmail.Text.Trim()))
            {
                return;
            }

            // Validasi duplikasi ID Komunitas
            if (IsKomunitasIdExist(textID.Text.Trim()))
            {
                MessageBox.Show("ID Komunitas sudah ada. Mohon gunakan ID yang berbeda.", "Peringatan Duplikasi ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textID.Focus();
                return;
            }

            // Validasi duplikasi Nama Komunitas
            if (IsNamaKomunitasExist(textNama.Text.Trim()))
            {
                MessageBox.Show("Nama Komunitas sudah ada. Mohon gunakan nama yang berbeda.", "Peringatan Duplikasi Nama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNama.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddKomunitas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdKomunitas", textID.Text);
                        cmd.Parameters.AddWithValue("@NamaKomunitas", textNama.Text);
                        cmd.Parameters.AddWithValue("@AdminKomunitas", textAdmin.Text);
                        cmd.Parameters.AddWithValue("@Deskripsi", textDeskripsi.Text);
                        cmd.Parameters.AddWithValue("@NomorTeleponKomunitas", textTelepon.Text);
                        cmd.Parameters.AddWithValue("@IdKategori", (int)cmbKategori.SelectedValue);
                        cmd.Parameters.AddWithValue("@AlamatKomunitas", textAlamat.Text);
                        cmd.Parameters.AddWithValue("@EmailKomunitas", textEmail.Text);
                        cmd.Parameters.AddWithValue("@JumlahAnggota", textJumlah.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil ditambahkan!", "Sukses");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgwKomun.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan");
                return;
            }
            if (cmbKategori.SelectedValue == DBNull.Value || cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Harap pilih kategori!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateEmail(textEmail.Text.Trim()))
            {
                return;
            }

            string currentId = textID.Text.Trim();
            string newNamaKomunitas = textNama.Text.Trim();

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Komunitas WHERE NamaKomunitas = @NamaKomunitas AND IdKomunitas <> @IdKomunitas";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@NamaKomunitas", newNamaKomunitas);
                        checkCmd.Parameters.AddWithValue("@IdKomunitas", currentId);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Nama Komunitas sudah digunakan oleh komunitas lain. Mohon gunakan nama yang berbeda.", "Peringatan Duplikasi Nama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textNama.Focus();
                            return;
                        }
                    }

                    using (var cmd = new SqlCommand("UpdateKomunitas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdKomunitas", textID.Text);
                        cmd.Parameters.AddWithValue("@NamaKomunitas", textNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@AdminKomunitas", textAdmin.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deskripsi", textDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NomorTeleponKomunitas", textTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdKategori", (int)cmbKategori.SelectedValue);
                        cmd.Parameters.AddWithValue("@AlamatKomunitas", textAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmailKomunitas", textEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@JumlahAnggota", textJumlah.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil diperbarui!", "Sukses");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgwKomun.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                var idKomunitas = dgwKomun.SelectedRows[0].Cells[0].Value.ToString();
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("DeleteKomunitas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdKomunitas", idKomunitas);
                        cmd.ExecuteNonQuery();
                    }
                }
                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil dihapus!", "Sukses");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData();
            LoadKategori();
            ClearForm();
        }

        private void textAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Hanya huruf yang diperbolehkan untuk kolom ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textAlamat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Simbol tidak diperbolehkan untuk kolom ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Simbol '" + e.KeyChar + "' tidak diperbolehkan dalam email.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            string email = textEmail.Text.Trim();

            if (!string.IsNullOrEmpty(email) && !ValidateEmail(email))
            {
                textEmail.Focus();
            }
        }

        private bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email tidak boleh kosong", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(Email, emailPattern))
            {
                MessageBox.Show("Format email tidak valid. Harap masukkan email dengan format yang benar (contoh: nama@domain.com).", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Format email tidak valid", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void textJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "Excel files|*.xlsx;*xlsm";
                if (openFile.ShowDialog() == DialogResult.OK)
                    PreviewData(openFile.FileName);
            }
        }
        /// <summary>
        ///
        /// </summary>

        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    DataTable dt = new DataTable();

                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                        dt.Columns.Add(cell.ToString());

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex++] = cell.ToString();
                        }
                        dt.Rows.Add(newRow);
                    }

                    Preview previewForm = new Preview(dt);
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Query contoh, mungkin perlu disesuaikan dengan IdKategori atau join
            var heavyQuery = "SELECT NamaKomunitas, NomorTeleponKomunitas, AdminKomunitas FROM dbo.Komunitas WHERE IdKomunitas LIKE '0%'";
            AnalyzeQuery(heavyQuery);
        }

        private void dgwKomun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgwKomun.Rows.Count > 0)
            {
                try
                {
                    var row = dgwKomun.Rows[e.RowIndex];

                    textID.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                    textNama.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    textAdmin.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                    textDeskripsi.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                    textTelepon.Text = row.Cells[4].Value?.ToString() ?? string.Empty;

                    object idKategoriValue = row.Cells["IdKategori"].Value;
                    if (idKategoriValue != null && idKategoriValue != DBNull.Value)
                    {
                        cmbKategori.SelectedValue = idKategoriValue;
                    }
                    else
                    {
                        // Jika IdKategori null, set ke pilihan default atau kosongkan
                        cmbKategori.SelectedIndex = 0;
                    }

                    textAlamat.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
                    textEmail.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
                    textJumlah.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            DataAktivitasKomunitas transactionForm = new DataAktivitasKomunitas();
            transactionForm.Show();
            this.Hide();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            RedirectBasedOnRole();
        }

        private void RedirectBasedOnRole()
        {
            switch (UserSession.RoleName)
            {
                case "Super Admin":
                    DashboardAdmin dashboardAdmin = new DashboardAdmin();
                    dashboardAdmin.Show();
                    break;
                case "Admin Komunitas":
                    DashboardAdminKomun beranda = new DashboardAdminKomun();
                    beranda.Show();
                    break;
                default:
                    MessageBox.Show("Role tidak dikenal: " + UserSession.RoleName);
                    break;
            }
            this.Hide();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKategoriKomun formKategoriKomun = new FormKategoriKomun();
            formKategoriKomun.Show();
        }
    }
}