using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPABD_Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartScreen startScreen = new StartScreen();
            if (startScreen.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new LoginForm());
            }
        }
    }
}
