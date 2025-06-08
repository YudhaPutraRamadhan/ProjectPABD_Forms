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
    public partial class Transaction: Form
    {
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public Transaction()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {

        }

        private void LoadJoinedData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                    string Query = @"
                SELECT
                    AktivitasKomunitas.IdAktivitas,
                    AktivitasKomunitas.JenisAktivitas,
                    AktivitasKomunitas.StatusAktivitas,
                    Event.IdEvents,
                    Event.NamaEvents,
                    Event.TanggalEvent,
                    Event.Lokasi
                FROM
                    AktivitasKomunitas
                INNER JOIN
                    Event ON AktivitasKomunitas.IdAktivitas = Event.IdAktivitas";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, conn);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        dataAdapter.Fill(dataTable);
                        dgvAktivitas.DataSource = dataTable;

                        dgvAktivitas.Columns["IdAktivitas"].Visible = false;
                        dgvAktivitas.Columns["IdEvents"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Loading data: " + ex.Message);
                    }
            }
        }

        private void dgvAktivitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAktivitas.Rows.Count > 0)
            {
                try
                {
                    var IdAktivitasCellValue = dgvAktivitas.Rows[e.RowIndex].Cells["IdAktivitas"].Value;
                    if (IdAktivitasCellValue != null && IdAktivitasCellValue != DBNull.Value)
                    {
                        txtIdAktivitas.Text = dgvAktivitas.Rows[e.RowIndex].Cells["IdAktivitas"].Value.ToString() ?? "";
                        comboxJenis.SelectedItem = dgvAktivitas.Rows[e.RowIndex].Cells["JenisAktivitas"].Value.ToString() ?? "";
                        comboxStatus.SelectedItem = dgvAktivitas.Rows[e.RowIndex].Cells["StatusAktivitas"].Value.ToString() ?? "";
                        txtIdEvent.Text = dgvAktivitas.Rows[e.RowIndex].Cells["IdEvents"].Value.ToString() ?? "";
                        txtNamaEvent.Text = dgvAktivitas.Rows[e.RowIndex].Cells["NamaEvents"].Value.ToString() ?? "";
                        txtLokasi.Text = dgvAktivitas.Rows[e.RowIndex].Cells["Lokasi"].Value.ToString() ?? "";
                        dateTanggalEvent.Text = dgvAktivitas.Rows[e.RowIndex].Cells["TanggalEvent"].Value.ToString() ?? "";
                    }
                    else
                    {
                        lblMessage.Text = "ID Aktivitas tidak valid.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mengambil data: " + ex.Message);
                }
            }
        }

        private void txtIdEvent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNamaEvent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLokasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTanggalEvent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtIdAktivitas_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboxJenis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string idEvent = txtIdEvent.Text;
            string namaEvent = txtNamaEvent.Text;
            DateTime dateTanggal = dateTanggalEvent.Value;
            string lokasi = txtLokasi.Text;
            string idAktivitas = txtIdAktivitas.Text;
            string jenisAktivitas = comboxJenis.Text;
            string statusAktivitas = comboxStatus.Text;

            if (string.IsNullOrEmpty(idEvent) || string.IsNullOrEmpty(namaEvent) || dateTanggal == DateTime.MinValue ||
                string.IsNullOrEmpty(lokasi) || string.IsNullOrEmpty(idAktivitas) || string.IsNullOrEmpty(jenisAktivitas) || string.IsNullOrEmpty(statusAktivitas))
            {
                lblMessage.Text = "Isi kolom dengan data yang sesuai";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    SqlCommand cmdAktivitas = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction,
                        CommandText = "INSERT INTO AktivitasKomunitas (IdAktivitas, JenisAktivitas, StatusAktivitas, TanggalAktivitas) VALUES (@IdAktivitas, @JenisAktivitas, @StatusAktivitas, @TanggalAktivitas)"
                    };

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", dateTanggal);

                    int RowsAffectedAktivitas = cmdAktivitas.ExecuteNonQuery();

                    SqlCommand cmdEvent = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction,
                        CommandText = "INSERT INTO Event (IdEvents, NamaEvents, TanggalEvent, Lokasi, IdAktivitas) VALUES (@IdEvents, @NamaEvents, @TanggalEvent, @Lokasi, @IdAktivitas)"
                    };

                    cmdEvent.Parameters.AddWithValue("@IdEvents", idEvent);
                    cmdEvent.Parameters.AddWithValue("@NamaEvents", namaEvent);
                    cmdEvent.Parameters.AddWithValue("@TanggalEvent", dateTanggal);
                    cmdEvent.Parameters.AddWithValue("@Lokasi", lokasi);
                    cmdEvent.Parameters.AddWithValue("@IdAktivitas", idAktivitas);

                    int RowsAffectedEvent = cmdEvent.ExecuteNonQuery();

                    if (RowsAffectedAktivitas > 0 && RowsAffectedEvent > 0)
                    {
                        transaction.Commit();
                        lblMessage.Text = ("Data berhasil disimpan");
                        LoadJoinedData();
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string idAktivitas = txtIdAktivitas.Text.Trim();
            string jenisAktivitas = comboxJenis.Text.Trim();
            string statusAktivitas = comboxStatus.Text.Trim();
            DateTime tanggalEvent = dateTanggalEvent.Value;

            string idEvent = txtIdEvent.Text.Trim();
            string namaEvent = txtNamaEvent.Text.Trim();
            string lokasi = txtLokasi.Text.Trim();

            if (string.IsNullOrEmpty(idAktivitas) || string.IsNullOrEmpty(jenisAktivitas) || string.IsNullOrEmpty(statusAktivitas) ||
                string.IsNullOrEmpty(idEvent) || string.IsNullOrEmpty(namaEvent) || string.IsNullOrEmpty(lokasi))
            {
                lblMessage.Text = "Semua data wajib harus diisi!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Update AktivitasKomunitas
                    SqlCommand cmdAktivitas = new SqlCommand(@"
                UPDATE AktivitasKomunitas 
                SET JenisAktivitas = @JenisAktivitas, 
                    StatusAktivitas = @StatusAktivitas,
                    TanggalAktivitas = @TanggalAktivitas
                WHERE IdAktivitas = @IdAktivitas", conn, transaction);

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", tanggalEvent); // disamakan dengan tanggal event

                    // Update Event
                    SqlCommand cmdEvent = new SqlCommand(@"
                UPDATE Event 
                SET NamaEvents = @NamaEvents,
                    TanggalEvent = @TanggalEvent,
                    Lokasi = @Lokasi
                WHERE IdEvents = @IdEvents AND IdAktivitas = @IdAktivitas", conn, transaction);

                    cmdEvent.Parameters.AddWithValue("@IdEvents", idEvent);
                    cmdEvent.Parameters.AddWithValue("@NamaEvents", namaEvent);
                    cmdEvent.Parameters.AddWithValue("@TanggalEvent", tanggalEvent);
                    cmdEvent.Parameters.AddWithValue("@Lokasi", lokasi);
                    cmdEvent.Parameters.AddWithValue("@IdAktivitas", idAktivitas);

                    int rowsAktivitas = cmdAktivitas.ExecuteNonQuery();
                    int rowsEvent = cmdEvent.ExecuteNonQuery();

                    if (rowsAktivitas > 0 && rowsEvent > 0)
                    {
                        transaction.Commit();
                        lblMessage.Text = "Data berhasil diperbarui!";
                        LoadJoinedData();
                    }
                    else
                    {
                        transaction.Rollback();
                        lblMessage.Text = "Gagal memperbarui data!";
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtIdAktivitas.Text = "";
            txtIdEvent.Text = "";
            txtLokasi.Text = "";
            txtNamaEvent.Text = "";
            comboxJenis.Text = "";
            comboxStatus.Text = "";
            dateTanggalEvent.Text = "";

            lblMessage.Text = "";

            LoadJoinedData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string idAktivitas = txtIdAktivitas.Text.Trim();
            string idEvent = txtIdEvent.Text.Trim();

            if (string.IsNullOrEmpty(idAktivitas) || string.IsNullOrEmpty(idEvent))
            {
                lblMessage.Text = "Pilih data yang ingin dihapus!";
                return;
            }

            var result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Hapus dari tabel Event terlebih dahulu
                    SqlCommand cmdDeleteEvent = new SqlCommand(@"
                DELETE FROM [Event] WHERE IdEvents = @IdEvents", conn, transaction);
                    cmdDeleteEvent.Parameters.AddWithValue("@IdEvents", idEvent);

                    // 2. Lalu hapus dari tabel AktivitasKomunitas
                    SqlCommand cmdDeleteAktivitas = new SqlCommand(@"
                DELETE FROM AktivitasKomunitas WHERE IdAktivitas = @IdAktivitas", conn, transaction);
                    cmdDeleteAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);

                    int rowsEvent = cmdDeleteEvent.ExecuteNonQuery();
                    int rowsAktivitas = cmdDeleteAktivitas.ExecuteNonQuery();

                    if (rowsEvent > 0 && rowsAktivitas > 0)
                    {
                        transaction.Commit();
                        lblMessage.Text = "Data berhasil dihapus!";
                        LoadJoinedData(); // Refresh tampilan data
                    }
                    else
                    {
                        transaction.Rollback();
                        lblMessage.Text = "Gagal menghapus data!";
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            CRUD_Komun crudForm = new CRUD_Komun();
            crudForm.Show();
        }

        private void txtIdAktivitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtLokasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {

                e.Handled = true;

                MessageBox.Show("Hanya huruf yang diperbolehkan untuk kolom ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtIdEvent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAktivitas formAktivitas = new FormAktivitas();
            formAktivitas.Show();
        }
    }
}
