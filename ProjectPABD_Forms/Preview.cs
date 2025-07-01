using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace ProjectPABD_Forms
{
    public partial class Preview : Form
    {
        // Connection string to the database
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public Preview(DataTable data)
        {
            InitializeComponent();
            dgvPreview.DataSource = data;
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            dgvPreview.AutoResizeColumns();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ImportDataToDatabase();
            }
        }

        private int? GetKategoriIdByName(string kategoriName)
        {
            if (string.IsNullOrWhiteSpace(kategoriName))
            {
                return null;
            }

            try
            {
                // Menggunakan DatabaseConnection.ExecuteScalar untuk mendapatkan satu nilai
                string query = "SELECT IdKategori FROM KategoriKomunitas WHERE NamaKategori = @NamaKategori";
                SqlParameter[] parameters = { new SqlParameter("@NamaKategori", kategoriName) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return null; // Kategori tidak ditemukan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat IdKategori: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool ValidateRow(DataRow row)
        {
            string idKomunitas = row["IdKomunitas"].ToString().Trim();

            if (string.IsNullOrWhiteSpace(idKomunitas) || !Regex.IsMatch(idKomunitas, @"^\d+$"))
            {
                MessageBox.Show("Id Komunitas tidak boleh kosong dan hanya boleh berisi angka", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string Admin = row["AdminKomunitas"].ToString().Trim();

            if (!Regex.IsMatch(Admin, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama Admin hanya boleh berisi huruf", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string noTelepon = row["NomorTeleponKomunitas"].ToString().Trim();

            if (!noTelepon.StartsWith("08") || noTelepon.Length < 12 || noTelepon.Length > 14 || !noTelepon.All(char.IsDigit))
            {
                MessageBox.Show("Nomor Telepon harus diawali dengan '08' dan terdiri dari 12 digit", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string kategoriName = row["Kategori"].ToString().Trim();
            int? idKategori = GetKategoriIdByName(kategoriName);

            if (!idKategori.HasValue)
            {
                MessageBox.Show($"Kategori '{kategoriName}' tidak ditemukan di database. Pastikan kategori sudah terdaftar.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string Alamat = row["AlamatKomunitas"].ToString().Trim();

            if (!Regex.IsMatch(Alamat, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Alamat hanya boleh berisi huruf, angka, dan spasi", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string Email = row["EmailKomunitas"].ToString().Trim();

            if (!ValidateEmail(Email))
            {
                return false;
            }

            string Jumlah = row["JumlahAnggota"].ToString().Trim();

            if (!Regex.IsMatch(Jumlah, @"^\d+$"))
            {
                MessageBox.Show("Jumlah anggota hanya boleh berisi angka", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email tidak boleh kosong", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPreview.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row))
                    {
                        return;
                    }

                    string kategoriName = row["Kategori"].ToString().Trim();
                    int? idKategori = GetKategoriIdByName(kategoriName);

                    if (!idKategori.HasValue)
                    {
                        MessageBox.Show($"Kategori '{kategoriName}' tidak ditemukan saat impor. Impor dibatalkan.", "Kesalahan Impor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "INSERT INTO Komunitas (IdKomunitas, NamaKomunitas, AdminKomunitas, Deskripsi, NomorTeleponKomunitas, IdKategori, AlamatKomunitas, EmailKomunitas, JumlahAnggota) " +
                                   "VALUES (@IdKomunitas, @NamaKomunitas, @AdminKomunitas, @Deskripsi, @NomorTeleponKomunitas, @IdKategori, @AlamatKomunitas, @EmailKomunitas, @JumlahAnggota)";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IdKomunitas", row["IdKomunitas"]);
                            command.Parameters.AddWithValue("NamaKomunitas", row["NamaKomunitas"]);
                            command.Parameters.AddWithValue("@AdminKomunitas", row["AdminKomunitas"]);
                            command.Parameters.AddWithValue("@Deskripsi", row["Deskripsi"]);
                            command.Parameters.AddWithValue("@NomorTeleponKomunitas", row["NomorTeleponKomunitas"]);
                            command.Parameters.AddWithValue("@IdKategori", idKategori.Value); // Gunakan IdKategori yang sudah dikonversi
                            command.Parameters.AddWithValue("@AlamatKomunitas", row["AlamatKomunitas"]);
                            command.Parameters.AddWithValue("@EmailKomunitas", row["EmailKomunitas"]);
                            command.Parameters.AddWithValue("@JumlahAnggota", row["JumlahAnggota"]);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data berhasil diimpor ke database", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

