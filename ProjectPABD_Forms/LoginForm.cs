using NPOI.Util;
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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Koneksi ke database gagal. Pastikan database sudah berjalan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            if (ValidateLogin(txtUsername.Text, txtPassword.Text))
            {
                RedirectBasedOnRole();
            }

            else
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }


        }

        private bool ValidateLogin(string username, string password)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.IdPengguna,
                        p.Username,
                        r.RoleName,
                        p.IdKomunitas
                    FROM Pengguna p
                    INNER JOIN Roles r ON p.IdRole = r.IdRole
                    WHERE p.Username = @username AND p.Password = @password";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };

                DataTable result = DatabaseConnection.ExecuteQuery(query, parameters);
                
                if (result.Rows.Count > 0)
                {
                    DataRow user = result.Rows[0];

                    UserSession.UserId = user["IdPengguna"].ToString();
                    UserSession.Username = user["Username"].ToString();
                    UserSession.RoleName = user["RoleName"].ToString();
                    UserSession.KomunitasId = user["IdKomunitas"].ToString();
                    UserSession.IsLoggedIn = true;
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memvalidasi login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RedirectBasedOnRole()
        {
            switch(UserSession.RoleName)
            {
                case "Super Admin":
                    DashboardAdmin dashboardAdmin = new DashboardAdmin();
                    dashboardAdmin.Show();
                    break;
                case "Admin Komunitas":
                    DashboardAdminKomun beranda = new DashboardAdminKomun();
                    beranda.Show();
                    break;
                case "Pengguna":
                    DashboardUser dashboardUser = new DashboardUser();
                    dashboardUser.Show();
                    break;
                default:
                    MessageBox.Show("Role tidak dikenal: " + UserSession.RoleName);
                    break;
            }
            this.Hide();
        }

        public static void Logout()
        {
            try
            {
                DialogResult result = MessageBox.Show("Yakin logout?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UserSession.ClearSession();

                    // FIXED: Gunakan LINQ ToList() untuk copy collection
                    var formsToClose = Application.OpenForms.Cast<Form>()
                        .Where(f => f.Name != "LoginForm")
                        .ToList();

                    foreach (Form form in formsToClose)
                    {
                        form.Close();
                    }

                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }
    }
}