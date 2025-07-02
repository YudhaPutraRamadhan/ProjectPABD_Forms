using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            string query = @"
                SELECT
            a.IdAktivitas,
            a.JenisAktivitas,
            a.StatusAktivitas,
            e.IdEvents,
            e.NamaEvents,
            e.TanggalEvent,
            e.Lokasi,
            k.NamaKomunitas
        FROM
            AktivitasKomunitas a
        JOIN
            Event e ON a.IdAktivitas = e.IdAktivitas
        JOIN
            Komunitas k ON a.IdKomunitas = k.IdKomunitas";

            DataTable dt = new DataTable();

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            ReportDataSource rds = new ReportDataSource("DataSet_Baru", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AktivitasReport.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.RefreshReport();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataAktivitasKomunitas transaction = new DataAktivitasKomunitas();
            transaction.Show();
        }
    }
}
