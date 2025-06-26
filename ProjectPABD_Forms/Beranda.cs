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
    public partial class Beranda: Form
    {
        public Beranda()
        {
            InitializeComponent();
        }

        private void Beranda_Load(object sender, EventArgs e)
        {

        }

        private void pnlKomunitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            CRUD_Komun cRUD_Komun = new CRUD_Komun();
            cRUD_Komun.Show();
        }

        private void pnlAktivitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction transaction = new Transaction();
            transaction.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm.Logout();
        }
    }
}
