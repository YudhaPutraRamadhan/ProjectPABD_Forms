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
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public DataAktivitasKomunitas()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            LoadKomunitas(); // Memuat data komunitas ke cmbKomunitas
            LoadJoinedData(); // Memuat data aktivitas dan event
            ClearForm(); // Memanggil ClearForm saat form dimuat
        }

        private void LoadKomunitas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Mengambil IdKomunitas dan NamaKomunitas dari tabel Komunitas
                    string query = "SELECT IdKomunitas, NamaKomunitas FROM Komunitas ORDER BY NamaKomunitas";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Menambahkan opsi default "-- Pilih Komunitas --"
                    DataRow newRow = dataTable.NewRow();
                    newRow["IdKomunitas"] = DBNull.Value; // Penting untuk nilai default
                    newRow["NamaKomunitas"] = "-- Pilih Komunitas --";
                    dataTable.Rows.InsertAt(newRow, 0);

                    cmbKomunitas.DataSource = dataTable;
                    cmbKomunitas.DisplayMember = "NamaKomunitas"; // Tampilkan nama komunitas
                    cmbKomunitas.ValueMember = "IdKomunitas";   // Gunakan IdKomunitas sebagai nilai
                    cmbKomunitas.SelectedIndex = 0; // Pilih opsi default
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading komunitas data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadJoinedData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string Query = @"
                    SELECT
                        AK.IdAktivitas,
                        AK.JenisAktivitas,
                        AK.StatusAktivitas,
                        E.IdEvents,
                        E.NamaEvents,
                        E.TanggalEvent,
                        E.Lokasi,
                        K.IdKomunitas,        -- Sertakan IdKomunitas
                        K.NamaKomunitas       -- Sertakan NamaKomunitas
                    FROM
                        AktivitasKomunitas AS AK
                    INNER JOIN
                        Event AS E ON AK.IdAktivitas = E.IdAktivitas
                    INNER JOIN
                        Komunitas AS K ON AK.IdKomunitas = K.IdKomunitas; -- Join dengan tabel Komunitas
                ";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);
                    dgvAktivitas.DataSource = dataTable;

                    dgvAktivitas.Columns["IdAktivitas"].Visible = false;
                    dgvAktivitas.Columns["IdEvents"].Visible = false;
                    dgvAktivitas.Columns["IdKomunitas"].Visible = false; // Sembunyikan kolom IdKomunitas
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading data: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtIdAktivitas.Text = "";
            comboxJenis.SelectedIndex = 0;
            comboxStatus.SelectedIndex = 0;
            if (cmbKomunitas.Items.Count > 0)
            {
                cmbKomunitas.SelectedIndex = 0; // Reset ComboBox Komunitas ke pilihan default
            }
            txtIdEvent.Text = "";
            txtNamaEvent.Text = "";
            txtLokasi.Text = "";
            dateTanggalEvent.Value = DateTime.Now; // Set ke tanggal hari ini
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

                    // Mengatur ComboBox Komunitas berdasarkan IdKomunitas dari DataGridView
                    object idKomunitasValue = selectedRow.Cells["IdKomunitas"].Value;
                    if (idKomunitasValue != null && idKomunitasValue != DBNull.Value)
                    {
                        cmbKomunitas.SelectedValue = idKomunitasValue;
                    }
                    else
                    {
                        cmbKomunitas.SelectedIndex = 0; // Pilih opsi default jika IdKomunitas null
                    }

                    txtIdEvent.Text = selectedRow.Cells["IdEvents"].Value?.ToString() ?? "";
                    txtNamaEvent.Text = selectedRow.Cells["NamaEvents"].Value?.ToString() ?? "";
                    txtLokasi.Text = selectedRow.Cells["Lokasi"].Value?.ToString() ?? "";

                    // Pastikan TanggalEvent tidak null sebelum di-parse
                    if (selectedRow.Cells["TanggalEvent"].Value != DBNull.Value)
                    {
                        dateTanggalEvent.Value = Convert.ToDateTime(selectedRow.Cells["TanggalEvent"].Value);
                    }
                    else
                    {
                        dateTanggalEvent.Value = DateTime.Now; // Set ke tanggal saat ini jika null
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
            string idEvent = txtIdEvent.Text.Trim();
            string namaEvent = txtNamaEvent.Text.Trim();
            DateTime dateTanggal = dateTanggalEvent.Value;
            string lokasi = txtLokasi.Text.Trim();
            string idAktivitas = txtIdAktivitas.Text.Trim();
            string jenisAktivitas = comboxJenis.Text;
            string statusAktivitas = comboxStatus.Text;

            // Validasi untuk cmbKomunitas
            if (cmbKomunitas.SelectedValue == DBNull.Value || cmbKomunitas.SelectedValue == null)
            {
                lblMessage.Text = "Harap pilih komunitas!";
                return;
            }
            string idKomunitas = cmbKomunitas.SelectedValue.ToString(); // Dapatkan IdKomunitas yang dipilih

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
                        // Tambahkan IdKomunitas ke INSERT statement
                        CommandText = "INSERT INTO AktivitasKomunitas (IdAktivitas, IdKomunitas, JenisAktivitas, StatusAktivitas, TanggalAktivitas) VALUES (@IdAktivitas, @IdKomunitas, @JenisAktivitas, @StatusAktivitas, @TanggalAktivitas)"
                    };

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@IdKomunitas", idKomunitas); // Tambahkan parameter IdKomunitas
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", dateTanggal);

                    int RowsAffectedAktivitas = cmdAktivitas.ExecuteNonQuery();

                    SqlCommand cmdEvent = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction,
                        // Pastikan IdAktivitas di Event cocok dengan IdAktivitas di AktivitasKomunitas
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
                        ClearForm(); // Bersihkan form setelah simpan
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

            // Validasi untuk cmbKomunitas
            if (cmbKomunitas.SelectedValue == DBNull.Value || cmbKomunitas.SelectedValue == null)
            {
                lblMessage.Text = "Harap pilih komunitas!";
                return;
            }
            string idKomunitas = cmbKomunitas.SelectedValue.ToString(); // Dapatkan IdKomunitas yang dipilih


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

                    // Update AktivitasKomunitas - tambahkan update untuk IdKomunitas
                    SqlCommand cmdAktivitas = new SqlCommand(@"
                        UPDATE AktivitasKomunitas
                        SET JenisAktivitas = @JenisAktivitas,
                            StatusAktivitas = @StatusAktivitas,
                            TanggalAktivitas = @TanggalAktivitas,
                            IdKomunitas = @IdKomunitas -- Tambahkan update IdKomunitas
                        WHERE IdAktivitas = @IdAktivitas", conn, transaction);

                    cmdAktivitas.Parameters.AddWithValue("@IdAktivitas", idAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@JenisAktivitas", jenisAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@StatusAktivitas", statusAktivitas);
                    cmdAktivitas.Parameters.AddWithValue("@TanggalAktivitas", tanggalEvent);
                    cmdAktivitas.Parameters.AddWithValue("@IdKomunitas", idKomunitas); // Tambahkan parameter IdKomunitas

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
                        ClearForm(); // Bersihkan form setelah update
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
            ClearForm(); // Panggil ClearForm untuk mereset semua input
            LoadJoinedData(); // Refresh DataGridView
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
                        ClearForm(); // Bersihkan form setelah hapus
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