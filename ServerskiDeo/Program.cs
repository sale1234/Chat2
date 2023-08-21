using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerskiDeo
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
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if(frmLogin.DialogResult == DialogResult.OK)
            {
                frmLogin.Dispose();
                Application.Run(new FrmMain());
            }
        }
    }
}
