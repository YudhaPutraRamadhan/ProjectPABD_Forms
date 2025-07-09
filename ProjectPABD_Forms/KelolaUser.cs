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
    public partial class KelolaUser : Form
    {

        public KelolaUser()
        {
            InitializeComponent();
        }

        // Kelola User_Load untuk Roles_Load juga
        private void KelolaUser_Load(object sender, EventArgs e)
        {
            LoadKomunitas();
            LoadRoles();
            LoadData();
        }

        // ClearForm untuk reset role selection
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtNomorTelepon.Clear();

            if (cmbKomunitas.Items.Count > 0)
                cmbKomunitas.SelectedIndex = 1; // Skip "Tidak Ada Komunitas"

            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0; // Default ke role pertama

            txtUsername.Focus();
        }

        // LoadData method dengan LEFT JOIN (prevent handle NULL values)
        private void LoadData()
        {
            try
            {
                // Query dengan LEFT JOIN untuk handle NULL values di IdKomunitas
                string query = @"
                    SELECT 
                        p.IdPengguna,
                        p.Username,
                        p.Password,
                        p.NomorTelepon,
                        p.JenisKelamin,
                        r.RoleName,
                        ISNULL(k.NamaKomunitas, 'Tidak Ada Komunitas') AS NamaKomunitas,
                        p.IdKomunitas  -- Bisa NULL untuk beberapa user
                    FROM Pengguna p
                    INNER JOIN Roles r ON p.IdRole = r.IdRole
                    LEFT JOIN Komunitas k ON p.IdKomunitas = k.IdKomunitas
                    ORDER BY p.IdPengguna";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    dgvPengguna.AutoGenerateColumns = true;
                    dgvPengguna.DataSource = dt;

                    // Sembunyikan kolom 
                    if (dgvPengguna.Columns["IdPengguna"] != null)
                        dgvPengguna.Columns["IdPengguna"].Visible = false;

                    if (dgvPengguna.Columns["Password"] != null)
                        dgvPengguna.Columns["Password"].Visible = false;

                    if (dgvPengguna.Columns["IdKomunitas"] != null)
                        dgvPengguna.Columns["IdKomunitas"].Visible = false;


                    if (dgvPengguna.Columns["Username"] != null)
                    {
                        dgvPengguna.Columns["Username"].HeaderText = "Username";
                        dgvPengguna.Columns["Username"].Width = 150;
                    }

                    if (dgvPengguna.Columns["NomorTelepon"] != null)
                    {
                        dgvPengguna.Columns["NomorTelepon"].HeaderText = "Nomor Telepon";
                        dgvPengguna.Columns["NomorTelepon"].Width = 120;
                    }

                    if (dgvPengguna.Columns["JenisKelamin"] != null)
                    {
                        dgvPengguna.Columns["JenisKelamin"].HeaderText = "Jenis Kelamin";
                        dgvPengguna.Columns["JenisKelamin"].Width = 100;
                    }

                    if (dgvPengguna.Columns["RoleName"] != null)
                    {
                        dgvPengguna.Columns["RoleName"].HeaderText = "Role";
                        dgvPengguna.Columns["RoleName"].Width = 120;
                    }

                    if (dgvPengguna.Columns["NamaKomunitas"] != null)
                    {
                        dgvPengguna.Columns["NamaKomunitas"].HeaderText = "Komunitas";
                        dgvPengguna.Columns["NamaKomunitas"].Width = 200;
                    }
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKomunitas()
        {
            try
            {
                string query = "SELECT IdKomunitas, NamaKomunitas FROM Komunitas ORDER BY NamaKomunitas";
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["IdKomunitas"] = DBNull.Value;
                    newRow["NamaKomunitas"] = "-- Tidak Ada Komunitas --";
                    dataTable.Rows.InsertAt(newRow, 0);

                    cmbKomunitas.DataSource = dataTable;
                    cmbKomunitas.DisplayMember = "NamaKomunitas";
                    cmbKomunitas.ValueMember = "IdKomunitas";
                    cmbKomunitas.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Tidak ada komunitas yang tersedia", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat komunitas: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            try
            {
                string query = "SELECT IdRole, RoleName FROM Roles WHERE RoleName != 'Super Admin' ORDER BY RoleName";
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    cmbRole.DataSource = dataTable;
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "IdRole";
                    cmbRole.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Tidak ada role yang tersedia", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat roles: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (CreateUser())
                {
                    MessageBox.Show("Pembuatan akun berhasil!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 5)
            {
                MessageBox.Show("Username harus terdiri dari minimal 5 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Password harus terdiri dari minimal 5 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomorTelepon.Text))
            {
                MessageBox.Show("Nomor telepon tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomorTelepon.Focus();
                return false;
            }

            if (!txtNomorTelepon.Text.StartsWith("08") || txtNomorTelepon.Text.Length <= 12 || txtNomorTelepon.Text.Length >= 14 || !txtNomorTelepon.Text.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon harus diawali dengan '08' dan terdiri dari 12-14 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomorTelepon.Focus();
                return false;
            }

            if (!rbLakiLaki.Checked && !rbPerempuan.Checked)
            {
                MessageBox.Show("Silakan pilih jenis kelamin", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih role pengguna", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            string selectedRole = cmbRole.Text;
            if (selectedRole == "Admin Komunitas")
            {
                if (cmbKomunitas.SelectedValue == null || cmbKomunitas.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Admin Komunitas harus memiliki komunitas!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbKomunitas.Focus();
                    return false;
                }
            }

            if (IsUsernameExist(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username sudah terdaftar, silakan gunakan username lain", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            return true;
        }

        private bool IsUsernameExist(string username)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Pengguna WHERE Username = @username";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@username", username)
                };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memeriksa username: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool IsUsernameExistForOtherUser(string username, string currentUserId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Pengguna WHERE Username = @username AND IdPengguna != @currentUserId";
                SqlParameter[] parameters = {
                    new SqlParameter("@username", username),
                    new SqlParameter("@currentUserId", currentUserId)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool CreateUser()
        {
            try
            {
                string query = @"INSERT INTO Pengguna (IdPengguna, Username, Password, NomorTelepon, JenisKelamin, IdRole, IdKomunitas) VALUES
                                (@idPengguna, @username, @password, @nomorTelepon, @jenisKelamin, @idRole, @idKomunitas)";

                string jenisKelamin = rbLakiLaki.Checked ? "L" : "P";


                int selectedRoleId = Convert.ToInt32(cmbRole.SelectedValue);


                object komunitasId = cmbKomunitas.SelectedValue;
                if (komunitasId == DBNull.Value)
                    komunitasId = null;

                string newUserId = GenerateNewUserId();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@idPengguna", newUserId),
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@password", txtPassword.Text.Trim()),
                    new SqlParameter("@nomorTelepon", txtNomorTelepon.Text.Trim()),
                    new SqlParameter("@jenisKelamin", jenisKelamin),
                    new SqlParameter("@idRole", selectedRoleId),
                    new SqlParameter("@idKomunitas", komunitasId ?? (object)DBNull.Value)
                };

                int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data pengguna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data pengguna: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GenerateNewUserId()
        {
            try
            {
                string query = "SELECT MAX(IdPengguna) FROM Pengguna";
                object result = DatabaseConnection.ExecuteScalar(query);

                if (result != null && result != DBNull.Value)
                {
                    string lastId = result.ToString();
                    int numericPart = int.Parse(lastId);
                    int newNumericPart = numericPart + 1;
                    return newNumericPart.ToString("000");
                }
                else
                {
                    return "001";
                }
            }
            catch
            {
                return "999";
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Hanya huruf, angka, dan spasi yang diperbolehkan untuk kolom ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNomorTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Kolom ini hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
            MessageBox.Show("Data berhasil direfresh!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPengguna_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvPengguna.Rows[e.RowIndex];

                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? string.Empty;
                txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? string.Empty;
                txtNomorTelepon.Text = row.Cells["NomorTelepon"].Value?.ToString() ?? string.Empty;

                string jenisKelamin = row.Cells["JenisKelamin"].Value?.ToString() ?? string.Empty;
                if (jenisKelamin == "L")
                {
                    rbLakiLaki.Checked = true;
                    rbPerempuan.Checked = false;
                }
                else if (jenisKelamin == "P")
                {
                    rbPerempuan.Checked = true;
                    rbLakiLaki.Checked = false;
                }
                else
                {
                    rbLakiLaki.Checked = false;
                    rbPerempuan.Checked = false;
                }

                var idKomunitasValue = row.Cells["IdKomunitas"].Value;
                if (idKomunitasValue != null && idKomunitasValue != DBNull.Value)
                {
                    string idKomunitas = idKomunitasValue.ToString();
                    cmbKomunitas.SelectedValue = idKomunitas;
                }
                else
                {
                    cmbKomunitas.SelectedIndex = 0;
                }

                string roleName = row.Cells["RoleName"].Value?.ToString() ?? string.Empty;
                for (int i = 0; i < cmbRole.Items.Count; i++)
                {
                    DataRowView roleRow = (DataRowView)cmbRole.Items[i];
                    if (roleRow["RoleName"].ToString() == roleName)
                    {
                        cmbRole.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgvPengguna.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih pengguna yang ingin diubah", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputForUpdate())
            {
                return;
            }

            try
            {

                string selectedUserId = dgvPengguna.SelectedRows[0].Cells["IdPengguna"].Value.ToString();

                if (selectedUserId == UserSession.UserId)
                {
                    MessageBox.Show("Anda tidak dapat mengubah data diri sendiri!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = @"
                    UPDATE Pengguna 
                    SET Username = @Username,
                        Password = @Password,
                        NomorTelepon = @NomorTelepon,
                        JenisKelamin = @JenisKelamin,
                        IdRole = @IdRole,
                        IdKomunitas = @IdKomunitas
                    WHERE IdPengguna = @IdPengguna";


                object komunitasId = cmbKomunitas.SelectedValue;
                if (komunitasId == DBNull.Value)
                    komunitasId = null;


                int selectedRoleId = Convert.ToInt32(cmbRole.SelectedValue);

                SqlParameter[] parameters = {
                    new SqlParameter("@IdPengguna", selectedUserId),
                    new SqlParameter("@Username", txtUsername.Text.Trim()),
                    new SqlParameter("@Password", txtPassword.Text.Trim()),
                    new SqlParameter("@NomorTelepon", txtNomorTelepon.Text.Trim()),
                    new SqlParameter("@JenisKelamin", rbLakiLaki.Checked ? "L" : "P"),
                    new SqlParameter("@IdRole", selectedRoleId), // Update role juga
                    new SqlParameter("@IdKomunitas", komunitasId ?? (object)DBNull.Value)
                };

                int rowsAffected = DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pengguna berhasil diubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal mengubah data pengguna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInputForUpdate()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 5)
            {
                MessageBox.Show("Username harus terdiri dari minimal 5 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Password harus terdiri dari minimal 5 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomorTelepon.Text))
            {
                MessageBox.Show("Nomor telepon tidak boleh kosong", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomorTelepon.Focus();
                return false;
            }

            if (!txtNomorTelepon.Text.StartsWith("08") || txtNomorTelepon.Text.Length <= 12 || txtNomorTelepon.Text.Length >= 14 || !txtNomorTelepon.Text.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon harus diawali dengan '08' dan terdiri dari 12-14 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomorTelepon.Focus();
                return false;
            }

            if (!rbLakiLaki.Checked && !rbPerempuan.Checked)
            {
                MessageBox.Show("Silakan pilih jenis kelamin", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih role pengguna", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }


            string selectedRole = cmbRole.Text;
            if (selectedRole == "Admin Komunitas")
            {
                if (cmbKomunitas.SelectedValue == null || cmbKomunitas.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Admin Komunitas harus memiliki komunitas!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbKomunitas.Focus();
                    return false;
                }
            }


            string selectedUserId = dgvPengguna.SelectedRows[0].Cells["IdPengguna"].Value.ToString();
            if (IsUsernameExistForOtherUser(txtUsername.Text.Trim(), selectedUserId))
            {
                MessageBox.Show("Username sudah digunakan pengguna lain!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            return true;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPengguna.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih pengguna yang ingin dihapus", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUserId = dgvPengguna.SelectedRows[0].Cells["IdPengguna"].Value.ToString();
            string selectedUsername = dgvPengguna.SelectedRows[0].Cells["Username"].Value.ToString();

            if (selectedUserId == UserSession.UserId)
            {
                MessageBox.Show("Anda tidak dapat menghapus akun diri sendiri!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Yakin ingin menghapus pengguna '{selectedUsername}'?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM Pengguna WHERE IdPengguna = @IdPengguna";
                    SqlParameter[] parameters = {
                        new SqlParameter("@IdPengguna", selectedUserId)
                    };

                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(deleteQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pengguna berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh data
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus pengguna", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRole.SelectedItem != null)
                {
                    string selectedRole = cmbRole.Text;

                    if (selectedRole == "Admin Komunitas")
                    {
                        if (cmbKomunitas.SelectedIndex == 0)
                        {
                            if (cmbKomunitas.Items.Count > 1)
                                cmbKomunitas.SelectedIndex = 1;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardAdmin dashboardAdmin = new DashboardAdmin();
            dashboardAdmin.Show();
        }
    }
}