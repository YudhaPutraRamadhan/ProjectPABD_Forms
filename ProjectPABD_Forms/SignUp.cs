using MathNet.Numerics;
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
    public partial class SignUp: Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            LoadKomunitas();
            rbLakiLaki.Checked = true;
        }

        private void LoadKomunitas()
        {
            try
            {
                String query = "SELECT IdKomunitas, NamaKomunitas FROM Komunitas ORDER BY NamaKomunitas";
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);
                if (dataTable.Rows.Count > 0)
                {
                    cmbKomunitas.DataSource = dataTable;
                    cmbKomunitas.DisplayMember = "NamaKomunitas";
                    cmbKomunitas.ValueMember = "IdKomunitas";
                    cmbKomunitas.SelectedIndex = 0;
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

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (RegisterUser())
                {
                    MessageBox.Show("Pendaftaran berhasil! Silahkan login dengan akun baru anda!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 5)
            {
                MessageBox.Show("Username harus terdiri dari minimal 5 karakter.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 5)
            {
                MessageBox.Show("Password harus terdiri dari minimal 5 karakter.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomortelp.Text))
            {
                MessageBox.Show("Nomor telepon tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomortelp.Focus();
                return false;
            }

            if (!txtNomortelp.Text.StartsWith("08") || txtNomortelp.Text.Length < 12 || txtNomortelp.Text.Length > 14 || !txtNomortelp.Text.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon harus diawali dengan '08' dan terdiri dari 12-14 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomortelp.Focus();
                return false;
            }

            if (!rbLakiLaki.Checked && !rbPerempuan.Checked)
            {
                MessageBox.Show("Silahkan pilih jenis kelamin", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbKomunitas.SelectedIndex < 0)
            {
                MessageBox.Show("Silakan pilih komunitas.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKomunitas.Focus();
                return false;
            }

            if (IsUsernameExist(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username sudah terdaftar. Silakan gunakan username lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool RegisterUser()
        {
            try
            {
                string query = @"INSERT INTO Pengguna (IdPengguna, Username, Password, NomorTelepon, JenisKelamin, IdRole, IdKomunitas) VALUES
                                (@idPengguna, @username, @password, @nomorTelepon, @jenisKelamin, @idRole, @idKomunitas)";

                string jenisKelamin = rbLakiLaki.Checked ? "L" : "P";

                int userRoleId = 3;

                string komunitasId = cmbKomunitas.SelectedValue.ToString();
                string newUserId = GenerateNewUserId();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@idPengguna", newUserId),
                    new SqlParameter("@username", txtUsername.Text.Trim()),
                    new SqlParameter("@password", txtPassword.Text.Trim()),
                    new SqlParameter("@nomorTelepon", txtNomortelp.Text.Trim()),
                    new SqlParameter("@jenisKelamin", jenisKelamin),
                    new SqlParameter("@idRole", userRoleId),
                    new SqlParameter("@idKomunitas", komunitasId)
                };
                int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    return true;
                }

                else
                {
                    MessageBox.Show("Pendaftaran gagal! Silakan coba lagi", "Pendaftaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mendaftar: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }


}
