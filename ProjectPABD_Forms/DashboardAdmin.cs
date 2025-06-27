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
    public partial class DashboardAdmin: Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm.Logout();
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
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

        private void pnlAdminKomunitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            KelolaAdminKomun kelolaAdminKomun = new KelolaAdminKomun();
            kelolaAdminKomun.Show();
        }

        private void pnlPengguna_Click(object sender, EventArgs e)
        {
            this.Hide();
            KelolaUser kelolaUser = new KelolaUser();
            kelolaUser.Show();
        }
    }
}
