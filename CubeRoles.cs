using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace OLAP_roles
{
    class mycCubeRoles
    {
        public ArrayList Cubes;
        public Dictionary<string, Microsoft.AnalysisServices.Role> Roles;
        public Dictionary<string, Microsoft.AnalysisServices.RoleMember> RoleMembers;

        private String serverName;

        public mycCubeRoles(String sOLAPserverName)
        {
            serverName = sOLAPserverName;
            Cubes = new ArrayList();
            Roles = new Dictionary<string,Microsoft.AnalysisServices.Role>();
            RoleMembers = new Dictionary<string, Microsoft.AnalysisServices.RoleMember>();
        }

        //public delegate void StatusHandler(string msg);
        //public event StatusHandler StatusMessage;
        private int imaxDB = 0;
        private int iCountDB = 0;
        private int iCountRole = 0;
        private int iCountMmbr = 0;

        /// <summary>
        /// Загрузка доступных кубов сервера ОЛАП
        /// </summary>
        /// <returns> True/False </returns>
        public Boolean Load_CubeRoles(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return false;
            }
            else
            {
                try
                {
                    using (Microsoft.AnalysisServices.Server server = new Microsoft.AnalysisServices.Server())
                    {                        
                        server.Connect(serverName);

                        imaxDB = server.Databases.Count;
                        
                        if (imaxDB <= 0)
                        {
                            // report to form             
                            worker.ReportProgress(100);
                            return true;
                        }
                        // грузим кубы ( БД )
                        foreach (Microsoft.AnalysisServices.Database asDB in server.Databases)
                        {
                            // Проверка на отмену загрузки
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return false;
                            }
                            // report to form             
                            worker.ReportProgress((int)(iCountDB/imaxDB*100));
                            

                            Cubes.Add(asDB);
                            // Грузим роли для куба                            
                            foreach (Microsoft.AnalysisServices.Role dbRole in asDB.Roles)
                            {
                                // Проверка на отмену загрузки
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    return false;
                                }

                                //string sDBname = asDB.Name;
                                //string sRolname = dbRole.Name;
                                
                                Roles.Add(string.Format( asDB.Name+" _{0}", ++iCountRole ), dbRole);

                                // Грузим членов роли                                                                
                                foreach (Microsoft.AnalysisServices.RoleMember mmbr in dbRole.Members)
                                {
                                    // Проверка на отмену загрузки
                                    if (worker.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        return false;
                                    }

                                    RoleMembers.Add(string.Format(dbRole.Name+" _{0}", ++iCountMmbr), mmbr);
                                }
                                
                            }
                            //счетчик загрузки
                            iCountDB++;
                        }
                        server.Disconnect();
                    }

                    return true;

                }
                catch (Exception errr)
                {
                    
                    MessageBox.Show(string.Format("Ошибка получения данных:\n"+errr.Message), "Загрузка ролей из ОЛАП");
                    
                    return false;
                    //throw;

                }
            }
       }

        public void FillCubes( DevExpress.XtraEditors.ListBoxControl list)
        {
            list.Items.Clear();
            foreach (Microsoft.AnalysisServices.Database asDB in Cubes)
            {
                list.Items.Add(asDB);
            }
        }

        public void FillRoleMembers(string cubeName, DataGridView grid)
        {
            string rName;
            // ищем нужный куб в списке ролей
            for (int i = 0; i < Cubes.Count; i++)
            {
                if (Roles.ContainsKey(cubeName))
                { // для найденного куба раскрываем роли
                    foreach (KeyValuePair<string, Microsoft.AnalysisServices.Role> rol in Roles)
                    {                        
                        rName = rol.Value.Name; // имя роли
                        grid.RowCount = grid.RowCount++;
                        grid[1, grid.RowCount - 1].Value = rName;
                    }
                    break;
                }
            }
        }

    }
}
