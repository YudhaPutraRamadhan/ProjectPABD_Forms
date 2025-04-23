using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPABD_Forms
{
    public partial class Form1: Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public Form1()
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
                    string query = "SELECT IdKomunitas AS [ID], NamaKomunitas, AdminKomunitas, Deskripsi, NomorTeleponKomunitas," +
                        "Kategori, AlamatKomunitas, EmailKomunitas, JumlahAnggota FROM Komunitas";
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
                    string query = "INSERT INTO Komunitas (IdKomunitas, NamaKomunitas, AdminKomunitas, Deskripsi, NomorTeleponKomunitas," +
                        "Kategori, AlamatKomunitas, EmailKomunitas, JumlahAnggota) VALUES (@IdKomunitas, @NamaKomunitas, @AdminKomunitas," +
                        "@Deskripsi, @NomorTeleponKomunitas, @Kategori, @AlamatKomunitas, @EmailKomunitas, @JumlahAnggota)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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
                    string query = "UPDATE Komunitas SET NamaKomunitas = @NamaKomunitas, AdminKomunitas = @AdminKomunitas," +
                        "Deskripsi = @Deskripsi, NomorTeleponKomunitas = @NomorTeleponKomunitas, Kategori = @Kategori," +
                        "AlamatKomunitas = @AlamatKomunitas, EmailKomunitas = @EmailKomunitas, JumlahAnggota = @JumlahAnggota WHERE IdKomunitas = @IdKomunitas";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdKomunitas", textID.Text);
                        cmd.Parameters.AddWithValue("@NamaKomunitas", textNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@AdminKomunitas", textAdmin.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deskripsi", textDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NomorTeleponKomunitas", textTelepon.Text);
                        cmd.Parameters.AddWithValue("@Kategori", textKategori.Text.Trim());
                        cmd.Parameters.AddWithValue("@AlamatKomunitas", textAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmailKomunitas", textEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@JumlahAnggota", textJumlah.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
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
                            string idKomunitas = dgwKomun.SelectedRows[0].Cells[0].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM Komunitas WHERE IdKomunitas = @IdKomunitas";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
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
    }
}

