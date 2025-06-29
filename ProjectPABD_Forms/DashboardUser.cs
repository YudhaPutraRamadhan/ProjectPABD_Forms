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
    public partial class DashboardUser: Form
    {
        public DashboardUser()
        {
            InitializeComponent();
        }

        private void pnlKomunitas_Click(object sender, EventArgs e)
        {
            this.Close();
            KomunitasUser komunitasUser = new KomunitasUser();
            komunitasUser.Show();
        }

        private void pnlAktivitas_Click(object sender, EventArgs e)
        {
            this.Close();
            AktivitasKomunUser aktivitasKomunUser = new AktivitasKomunUser();
            aktivitasKomunUser.Show();
        }

        private void DashboardUser_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm.Logout();
        }

        private void pnlGrafik_Click(object sender, EventArgs e)
        {
            this.Close();
            FormKategoriKomun formKategori = new FormKategoriKomun();
            formKategori.Show();
        }
    }
}
