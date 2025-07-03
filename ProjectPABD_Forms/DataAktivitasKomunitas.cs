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
    public partial class DataAktivitasKomunitas : Form
    {
        DatabaseConnection dbConnection = new DatabaseConnection();

        public DataAktivitasKomunitas()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            LoadKomunitas();
            LoadJoinedData();
            ClearForm();
        }

        private void LoadKomunitas()
        {
            try
            {
                string query = "SELECT IdKomunitas, NamaKomunitas FROM Komunitas ORDER BY NamaKomunitas";
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                DataRow newRow = dataTable.NewRow();
                newRow["IdKomunitas"] = DBNull.Value;
                newRow["NamaKomunitas"] = "-- Pilih Komunitas --";
                dataTable.Rows.InsertAt(newRow, 0);

                cmbKomunitas.DataSource = dataTable;
                cmbKomunitas.DisplayMember = "NamaKomunitas";
                cmbKomunitas.ValueMember = "IdKomunitas";
                cmbKomunitas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading komunitas data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadJoinedData()
        {
            try
            {
                string query = @"
                SELECT
                    AK.IdAktivitas,
                    AK.JenisAktivitas,
                    AK.StatusAktivitas,
                    E.IdEvents,
                    E.NamaEvents,
                    E.TanggalEvent,
                    E.Lokasi,
                    K.IdKomunitas,
                    K.NamaKomunitas
                FROM
                    AktivitasKomunitas AS AK
                INNER JOIN
                    Event AS E ON AK.IdAktivitas = E.IdAktivitas
                INNER JOIN
                    Komunitas AS K ON AK.IdKomunitas = K.IdKomunitas";

                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);
                dgvAktivitas.DataSource = dataTable;

                if (dgvAktivitas.Columns["IdKomunitas"] != null)
                    dgvAktivitas.Columns["IdKomunitas"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearForm()
        {
            txtIdAktivitas.Text = "";
            comboxJenis.SelectedIndex = 0;
            comboxStatus.SelectedIndex = 0;
            if (cmbKomunitas.Items.Count > 0)
            {
                cmbKomunitas.SelectedIndex = 0;
            }
            txtIdEvent.Text = "";
            txtNamaEvent.Text = "";
            txtLokasi.Text = "";
            dateTanggalEvent.Value = DateTime.Now;
            lblMessage.Text = "";
            txtIdAktivitas.Focus();
        }


        private void dgvAktivitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAktivitas.Rows.Count > 0)
            {
                try
                {
                    var selectedRow = dgvAktivitas.Rows[e.RowIndex];

                    txtIdAktivitas.Text = selectedRow.Cells["IdAktivitas"].Value?.ToString() ?? "";
                    comboxJenis.SelectedItem = selectedRow.Cells["JenisAktivitas"].Value?.ToString() ?? "";
                    comboxStatus.SelectedItem = selectedRow.Cells["StatusAktivitas"].Value?.ToString() ?? "";

                    object idKomunitasValue = selectedRow.Cells["IdKomunitas"].Value;
                    if (idKomunitasValue != null && idKomunitasValue != DBNull.Value)
                    {
                        cmbKomunitas.SelectedValue = idKomunitasValue;
                    }
                    else
                    {
                        cmbKomunitas.SelectedIndex = 0;
                    }

                    txtIdEvent.Text = selectedRow.Cells["IdEvents"].Value?.ToString() ?? "";
                    txtNamaEvent.Text = selectedRow.Cells["NamaEvents"].Value?.ToString() ?? "";
                    txtLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString() ?? "";

                    if (selectedRow.Cells["TanggalEvent"].Value != DBNull.Value)
                    {
                        dateTanggalEvent.Value = Convert.ToDateTime(selectedRow.Cells["TanggalEvent"].Value);
                    }
                    else
                    {
                        dateTanggalEvent.Value = DateTime.Now;
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

        // Metode baru untuk memeriksa duplikasi IdAktivitas
        private bool IsAktivitasIdExist(string idAktivitas)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM AktivitasKomunitas WHERE IdAktivitas = @IdAktivitas";
                SqlParameter[] parameters = { new SqlParameter("@IdAktivitas", idAktivitas) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa ID Aktivitas: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Asumsikan ada untuk mencegah duplikasi jika terjadi error
            }
        }

        // Metode baru untuk memeriksa duplikasi IdEvents
        private bool IsEventIdExist(string idEvent)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Event WHERE IdEvents = @IdEvents";
                SqlParameter[] parameters = { new SqlParameter("@IdEvents", idEvent) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa ID Event: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Asumsikan ada untuk mencegah duplikasi jika terjadi error
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string idEvent = txtIdEvent.Text.Trim();
            string namaEvent = txtNamaEvent.Text.Trim();
            DateTime dateTanggal = dateTanggalEvent.Value;
            string lokasi = txtLokasi.Text.Trim();
            string idAktivitas = txtIdAktivitas.Text.Trim();
            string jenisAktivitas = comboxJenis.Text;
            string statusAktivitas = comboxStatus.Text;

            if (cmbKomunitas.SelectedValue == DBNull.Value || cmbKomunitas.SelectedValue == null)
            {
                lblMessage.Text = "Harap pilih komunitas!";
                return;
            }
            string idKomunitas = cmbKomunitas.SelectedValue.ToString();

            if (string.IsNullOrEmpty(idEvent) || string.IsNullOrEmpty(namaEvent) ||
                string.IsNullOrEmpty(lokasi) || string.IsNullOrEmpty(idAktivitas) ||
                string.IsNullOrEmpty(jenisAktivitas) || string.IsNullOrEmpty(statusAktivitas))
            {
                lblMessage.Text = "Isi kolom dengan data yang sesuai";
                return;
            }

            if (IsAktivitasIdExist(idAktivitas))
            {
                MessageBox.Show("ID Aktivitas sudah ada. Mohon gunakan ID yang berbeda.", "Peringatan Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdAktivitas.Focus();
                return;
            }
            if (IsEventIdExist(idEvent))
            {
                MessageBox.Show("ID Event sudah ada. Mohon gunakan ID yang berbeda.", "Peringatan Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdEvent.Focus();
                return;
            }

            using (SqlConnection conn = DatabaseConnection.GetConnection())
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
                        CommandText = "INSERT INTO AktivitasKomunitas (IdAktivitas, IdKomunitas, JenisAktivitas, StatusAktivitas, TanggalAktivitas) VALUES (@IdAktivitas, @IdKomunitas, @JenisAktivitas, @StatusAktivitas, @TanggalAktivitas)"
                    };

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@IdKomunitas", idKomunitas);
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", dateTanggal);

                    int rowsAffectedAktivitas = cmdAktivitas.ExecuteNonQuery();

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

                    int rowsAffectedEvent = cmdEvent.ExecuteNonQuery();

                    if (rowsAffectedAktivitas > 0 && rowsAffectedEvent > 0)
                    {
                        transaction.Commit();
                        lblMessage.Text = "Data berhasil disimpan";
                        LoadJoinedData();
                        ClearForm();
                    }
                    else
                    {
                        transaction.Rollback();
                        lblMessage.Text = "Gagal menyimpan data!";
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cmbKomunitas.SelectedValue == DBNull.Value || cmbKomunitas.SelectedValue == null)
            {
                lblMessage.Text = "Harap pilih komunitas!";
                return;
            }
            if (IsAktivitasIdExist(idAktivitas))
            {
                MessageBox.Show("ID Aktivitas sudah ada. Mohon gunakan ID yang berbeda.", "Peringatan Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdAktivitas.Focus();
                return;
            }
            if (IsEventIdExist(idEvent))
            {
                MessageBox.Show("ID Event sudah ada. Mohon gunakan ID yang berbeda.", "Peringatan Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdEvent.Focus();
                return;
            }
            string idKomunitas = cmbKomunitas.SelectedValue.ToString();

            if (string.IsNullOrEmpty(idAktivitas) || string.IsNullOrEmpty(jenisAktivitas) ||
                string.IsNullOrEmpty(statusAktivitas) || string.IsNullOrEmpty(idEvent) ||
                string.IsNullOrEmpty(namaEvent) || string.IsNullOrEmpty(lokasi))
            {
                lblMessage.Text = "Semua data wajib harus diisi!";
                return;
            }

            using (SqlConnection conn = DatabaseConnection.GetConnection())
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
                        TanggalAktivitas = @TanggalAktivitas,
                        IdKomunitas = @IdKomunitas
                    WHERE IdAktivitas = @IdAktivitas", conn, transaction);

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", tanggalEvent);
                    cmdAktivitas.Parameters.AddWithValue("@IdKomunitas", idKomunitas);

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
                        ClearForm();
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
            ClearForm();
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

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Hapus dari Event terlebih dahulu
                    SqlCommand cmdDeleteEvent = new SqlCommand(
                        "DELETE FROM [Event] WHERE IdEvents = @IdEvents", conn, transaction);
                    cmdDeleteEvent.Parameters.AddWithValue("@IdEvents", idEvent);

                    // Lalu hapus dari AktivitasKomunitas
                    SqlCommand cmdDeleteAktivitas = new SqlCommand(
                        "DELETE FROM AktivitasKomunitas WHERE IdAktivitas = @IdAktivitas", conn, transaction);
                    cmdDeleteAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);

                    int rowsEvent = cmdDeleteEvent.ExecuteNonQuery();
                    int rowsAktivitas = cmdDeleteAktivitas.ExecuteNonQuery();

                    if (rowsEvent > 0 && rowsAktivitas > 0)
                    {
                        transaction.Commit();
                        lblMessage.Text = "Data berhasil dihapus!";
                        LoadJoinedData();
                        ClearForm();
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
            DataKomunitas crudForm = new DataKomunitas();
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
    }
}