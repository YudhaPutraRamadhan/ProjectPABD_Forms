using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPABD_Forms
{
    public partial class DashboardAdminKomun: Form
    {
        public DashboardAdminKomun()
        {
            InitializeComponent();
        }

        private void Beranda_Load(object sender, EventArgs e)
        {

        }

        private void pnlKomunitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataKomunitas cRUD_Komun = new DataKomunitas();
            cRUD_Komun.Show();
        }

        private void pnlAktivitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataAktivitasKomunitas transaction = new DataAktivitasKomunitas();
            transaction.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm.Logout();
        }
    }
}
