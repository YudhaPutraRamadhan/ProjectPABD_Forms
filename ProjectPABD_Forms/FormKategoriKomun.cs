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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectPABD_Forms
{
    public partial class FormKategoriKomun: Form
    {
        public FormKategoriKomun()
        {
            InitializeComponent();
        }

        private void FormKategoriKomun_Load(object sender, EventArgs e)
        {
            LoadKategori();
            LoadChartData(null);
        }

        private void LoadKategori()
        {
            try
            {
                string query = "SELECT IdKategori, NamaKategori FROM KategoriKomunitas ORDER BY NamaKategori";
                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                DataRow newRow = dt.NewRow();
                newRow["IdKategori"] = DBNull.Value;
                newRow["NamaKategori"] = "-- Semua Kategori --";
                dt.Rows.InsertAt(newRow, 0);

                cmbKategori.DataSource = dt;
                cmbKategori.DisplayMember = "NamaKategori";
                cmbKategori.ValueMember = "IdKategori";
                cmbKategori.SelectedIndex = 0;

                cmbKategori.SelectedIndexChanged += cmbKategori_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat Kategori: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? idKategori = null;

            if (cmbKategori.SelectedItem != null)
            {
                if (cmbKategori.SelectedItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("IdKategori") && drv.Row["IdKategori"] != DBNull.Value)
                    {
                        idKategori = Convert.ToInt32(drv.Row["IdKategori"]);
                    }
                }
                else
                {
                    if (cmbKategori.SelectedValue != null && cmbKategori.SelectedValue != DBNull.Value)
                    {
                        idKategori = Convert.ToInt32(cmbKategori.SelectedValue);
                    }
                }
            }

            LoadChartData(idKategori);
        }

        private void LoadChartData(int? idKategori)
        {
            chartKategori.Series.Clear();
            chartKategori.Titles.Clear();
            chartKategori.ChartAreas.Clear();
            chartKategori.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartKategori.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Kategori Komunitas";
            chartArea.AxisY.Title = "Jumlah Komunitas";
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisY.Interval = 1;
            chartArea.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            Series mainSeries = new Series("Data Komunitas")
            {
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.SteelBlue
            };

            try
            {
                string query;
                SqlParameter[] parameters = null;

                if (idKategori.HasValue)
                {
                    query = @"
                SELECT
                    K.NamaKomunitas AS Nama
                FROM
                    Komunitas AS K
                INNER JOIN
                    KategoriKomunitas AS KK ON K.IdKategori = KK.IdKategori
                WHERE
                    KK.IdKategori = @IdKategoriFilter
                ORDER BY
                    K.NamaKomunitas";

                    parameters = new SqlParameter[]
                    {
                new SqlParameter("@IdKategoriFilter", idKategori.Value)
                    };

                    chartKategori.Titles.Add($"Daftar Komunitas di Kategori: {cmbKategori.Text}");
                    chartArea.AxisX.Title = "Nama Komunitas";
                    chartArea.AxisY.Title = " ";
                    mainSeries.IsValueShownAsLabel = false;
                    mainSeries.ChartType = SeriesChartType.Column;
                    mainSeries.Color = System.Drawing.Color.SteelBlue;

                    DataTable komunitasDataTable = DatabaseConnection.ExecuteQuery(query, parameters);

                    if (komunitasDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in komunitasDataTable.Rows)
                        {
                            string namaKomunitas = row["Nama"].ToString();
                            mainSeries.Points.AddXY(namaKomunitas, 1);
                        }
                        mainSeries.IsXValueIndexed = false;
                        chartArea.AxisX.LabelStyle.Enabled = true; 
                    }
                    else
                    {
                        mainSeries.Points.AddXY("Tidak ada komunitas di kategori ini", 0);
                        chartKategori.Titles.Add("Tidak ada komunitas ditemukan di kategori ini.");
                        mainSeries.IsXValueIndexed = false;
                        chartArea.AxisX.LabelStyle.Enabled = true;
                    }
                }
                else
                {
                    query = @"
                SELECT
                    KK.NamaKategori,
                    COUNT(K.IdKomunitas) AS Jumlah
                FROM
                    KategoriKomunitas AS KK
                LEFT JOIN
                    Komunitas AS K ON KK.IdKategori = K.IdKategori
                GROUP BY
                    KK.NamaKategori
                ORDER BY
                    Jumlah DESC";

                    chartKategori.Titles.Add("Distribusi Komunitas per Kategori");
                    mainSeries.IsValueShownAsLabel = true;
                    mainSeries.ChartType = SeriesChartType.Column;
                    mainSeries.Color = System.Drawing.Color.SteelBlue;

                    DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string namaKategori = row["NamaKategori"].ToString();
                        int jumlahKomunitas = row["Jumlah"] != DBNull.Value ? Convert.ToInt32(row["Jumlah"]) : 0;
                        mainSeries.Points.AddXY(namaKategori, jumlahKomunitas);
                    }

                    mainSeries.IsXValueIndexed = false;
                    chartArea.AxisX.LabelStyle.Enabled = true;

                    chartKategori.Legends.Add(new Legend("KategoriLegend"));
                    chartKategori.Legends["KategoriLegend"].Docking = Docking.Bottom;
                }

                // Tambahkan Series ke Chart
                chartKategori.Series.Add(mainSeries);
                chartKategori.Invalidate(); // Refresh chart
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data chart: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedirectBasedOnRole()
        {
            switch (UserSession.RoleName)
            {
                case "Super Admin":
                    DataKomunitas dataKomunitas = new DataKomunitas();
                    dataKomunitas.Show();
                    break;
                case "Admin Komunitas":
                    DataKomunitas komunitas = new DataKomunitas();
                    komunitas.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            RedirectBasedOnRole();
        }
    }
}
