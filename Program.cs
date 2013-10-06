using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OLAP_roles
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new frmCubeRoles());
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Спокойно ! Мы уже разбираемся!\n{0}", e.Message));
            }
        }
    }
}
