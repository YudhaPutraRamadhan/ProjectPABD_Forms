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
    public partial class KomunitasUser : Form
    {
        public KomunitasUser()
        {
            InitializeComponent();
        }

        private void KomunitasUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionString()))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            K.IdKomunitas AS [ID], 
                            K.NamaKomunitas, 
                            K.AdminKomunitas, 
                            K.Deskripsi, 
                            K.NomorTeleponKomunitas, 
                            TK.NamaKategori AS Kategori, -- Mengambil NamaKategori dari tabel KategoriKomunitas
                            K.AlamatKomunitas, 
                            K.EmailKomunitas, 
                            K.JumlahAnggota
                        FROM Komunitas AS K
                        INNER JOIN KategoriKomunitas AS TK ON K.IdKategori = TK.IdKategori";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvKomunUser.AutoGenerateColumns = true;
                    dgvKomunUser.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat memuat data komunitas: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardUser dashboardUser = new DashboardUser();
            dashboardUser.Show();
        }
    }
}