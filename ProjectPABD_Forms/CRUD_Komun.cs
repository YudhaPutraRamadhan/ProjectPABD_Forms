using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPABD_Forms
{
    public partial class CRUD_Komun: Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public CRUD_Komun()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearForm()
        {
            textID.Clear();
            textNama.Clear();
            textAdmin.Clear();
            textDeskripsi.Clear();
            textTelepon.Clear();
            textKategori.Clear();
            textAlamat.Clear();
            textEmail.Clear();
            textJumlah.Clear();

            textID.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdKomunitas AS [ID], NamaKomunitas, AdminKomunitas, Deskripsi, NomorTeleponKomunitas, Kategori, AlamatKomunitas, EmailKomunitas, JumlahAnggota FROM Komunitas";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgwKomun.AutoGenerateColumns = true;
                    dgwKomun.DataSource = dt;

                    ClearForm();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textKategori_TextChanged(object sender, EventArgs e)
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

        private void dgwKomun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgwKomun.Rows[e.RowIndex];
                textID.Text = row.Cells[0].Value.ToString();
                textNama.Text = row.Cells[1].Value.ToString();
                textAdmin.Text = row.Cells[2].Value.ToString();
                textDeskripsi.Text = row.Cells[3].Value.ToString();
                textTelepon.Text = row.Cells[4].Value.ToString();
                textKategori.Text = row.Cells[5].Value.ToString();
                textAlamat.Text = row.Cells[6].Value.ToString();
                textEmail.Text = row.Cells[7].Value.ToString();
                textJumlah.Text = row.Cells[8].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (textID.Text == "" || textNama.Text == "" || textAdmin.Text == "" || textDeskripsi.Text == "" ||
                        textTelepon.Text == "" || textKategori.Text == "" || textAlamat.Text == "" || textEmail.Text == "" ||
                        textJumlah.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddKomunitas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdKomunitas", textID.Text);
                        cmd.Parameters.AddWithValue("@NamaKomunitas", textNama.Text);
                        cmd.Parameters.AddWithValue("@AdminKomunitas", textAdmin.Text);
                        cmd.Parameters.AddWithValue("@Deskripsi", textDeskripsi.Text);
                        cmd.Parameters.AddWithValue("@NomorTeleponKomunitas", textTelepon.Text);
                        cmd.Parameters.AddWithValue("@Kategori", textKategori.Text);
                        cmd.Parameters.AddWithValue("@AlamatKomunitas", textAlamat.Text);
                        cmd.Parameters.AddWithValue("@EmailKomunitas", textEmail.Text);
                        cmd.Parameters.AddWithValue("@JumlahAnggota", textJumlah.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgwKomun.SelectedRows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateKomunitas", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@IdKomunitas", textID.Text);
                            cmd.Parameters.AddWithValue("@NamaKomunitas", textNama.Text.Trim());
                            cmd.Parameters.AddWithValue("@AdminKomunitas", textAdmin.Text.Trim());
                            cmd.Parameters.AddWithValue("@Deskripsi", textDeskripsi.Text.Trim());
                            cmd.Parameters.AddWithValue("@NomorTeleponKomunitas", textTelepon.Text.Trim());
                            cmd.Parameters.AddWithValue("@Kategori", textKategori.Text.Trim());
                            cmd.Parameters.AddWithValue("@AlamatKomunitas", textAlamat.Text.Trim());
                            cmd.Parameters.AddWithValue("@EmailKomunitas", textEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@JumlahAnggota", textJumlah.Text.Trim());
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                ClearForm();
                            }
                            else
                            {
                                MessageBox.Show("Gagal mengubah data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgwKomun.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string idKomunitas = dgwKomun.SelectedRows[0].Cells["IdKomunitas"].Value.ToString();
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("DeleteKomunitas", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@IdKomunitas", idKomunitas);
                                
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                    ClearForm();
                                }
                                else
                                {
                                    MessageBox.Show("Gagal menghapus data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Add the FROM clause to specify your table name (replace "TableKomunitas" with your actual table name)
                    string query = "SELECT IdKomunitas AS [ID], NamaKomunitas, AdminKomunitas, Deskripsi, NomorTeleponKomunitas, Kategori, AlamatKomunitas, EmailKomunitas, JumlahAnggota FROM Komunitas";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgwKomun.AutoGenerateColumns = true;
                    dgwKomun.DataSource = dt;
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void textKategori_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {

                e.Handled = true;

                MessageBox.Show("Hanya huruf yang diperbolehkan untuk kolom ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Jika email tidak kosong dan tidak mengandung '@'
            if (!string.IsNullOrEmpty(email) && !email.Contains('@'))
            {
                MessageBox.Show("Format email salah", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEmail.Focus(); // Kembalikan fokus ke field email
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewData(filePath);
            }
        }

        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open,FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    DataTable dt = new DataTable();

                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex] = cell.ToString();
                            cellIndex++;
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
    }
}

