using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OLAP_roles
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName, false, Encoding.Default, 10))
                    {
                        string filerowheader = string.Format("\"{0}\",\"{1}\",\"{2}\"", "Database", "Role", "Member");
                        file.WriteLine(filerowheader);
                        using (Microsoft.AnalysisServices.Server Server = new Microsoft.AnalysisServices.Server())
                        {
                            Server.Connect(serverName.Text);
                            foreach (Microsoft.AnalysisServices.Database ssasdb in Server.Databases)
                            {
                                string Databasename = ssasdb.Name;
                                foreach (Microsoft.AnalysisServices.Role CubeDbRole in ssasdb.Roles)
                                {
                                    string Rolename = CubeDbRole.Name;
                                    foreach (Microsoft.AnalysisServices.RoleMember CubeRoleMember in CubeDbRole.Members)
                                    {
                                        string RoleMember = CubeRoleMember.Name;
                                        string filerow = string.Format("\"{0}\",\"{1}\",\"{2}\"", Databasename, Rolename, RoleMember);
                                        file.WriteLine(filerow);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Выгрузка успешно завершена", "Инфо");
                }
                catch (Exception ex)
                {

                    if (ex is Microsoft.AnalysisServices.AmoException)
                    {
                        throw new ApplicationException("Ошибка чтения данных сервера SSAS",  ex);
                    }

                    if (ex is System.IO.IOException)
                    {
                        throw new ApplicationException("Ошибка открытия или записи в файл. Проверьте не открыт ли он в другой программе.", ex);
                    }
                    throw new Exception("Неизвестная и самая страшная ошибка, потому что неизвестная", ex);

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dxBtnCubeRole_Click(object sender, EventArgs e)
        {
            frmCubeRoles frmCR = new frmCubeRoles();
            frmCR.serverName = serverName.Text;
            frmCR.ShowDialog();
        }
       
    }
}