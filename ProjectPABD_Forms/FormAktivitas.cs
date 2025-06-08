using Microsoft.Reporting.WinForms;
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
    public partial class FormAktivitas : Form
    {
        public FormAktivitas()
        {
            InitializeComponent();
        }

        private void FormAktivitas_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
            this.reportViewer1.RefreshReport();
        }

        private void SetupReportViewer()
        {
            string connectionString = "Data Source=PAVILIONGAME\\YUDHA_PUTRA_RAMA;Initial Catalog=Management_Komunitas;Integrated Security=True";

            string query = @"
                SELECT
                    a.IdAktivitas,
                    a.JenisAktivitas,
                    a.StatusAktivitas,
                    e.IdEvents,
                    e.NamaEvents,
                    e.TanggalEvent,
                    e.Lokasi
                FROM
                    AktivitasKomunitas a
                JOIN
                    Event e ON a.IdAktivitas = e.IdAktivitas";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            ReportDataSource rds = new ReportDataSource("DataSet_AktivitasKomunitas", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = @"C:\Pengembangan Aplikasi Basis Data\ProjectPABD_Forms\ProjectPABD_Forms\AktivitasReport.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
