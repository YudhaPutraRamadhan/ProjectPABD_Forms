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
    public partial class AktivitasKomunUser : Form
    {
        private string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";
        public AktivitasKomunUser()
        {
            InitializeComponent();
        }

        private void AktivitasKomunUser_Load(object sender, EventArgs e)
        {
            LoadJoinedData();
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
                    dgvAktivitasUser.DataSource = dataTable;

                    dgvAktivitasUser.Columns["IdAktivitas"].Visible = false;
                    dgvAktivitasUser.Columns["IdEvents"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading data: " + ex.Message);
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
