using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Threading;
//using System.Threading.Tasks;

namespace OLAP_roles
{
    public partial class frmCubeRoles : Form
    {
        public frmCubeRoles()
        {
            InitializeComponent();            
        }
        /*------------------------------------------------------------------*/
        struct CurrentOLAPData
        {
            public mycOLAPCubeWorker server;
            public mycOLAPdb db;
            public mycOLAProle role;
            public mycOLAPuser user;
        }
        private CurrentOLAPData _OLAP;
        private string _serverName;

        /*------------------------------------------------------------------*/
        private void btnLoad_Click(object sender, EventArgs e)
        {            
            LoadCubeRoles();
        }

        private void LoadCubeRoles()
        {
            if (txtServerName.Text.Trim() == "")
            {
                MessageBox.Show("Укажите имя сервера ОЛАП в окошке на панели инструментов!");
                return;
            }

            _serverName = txtServerName.Text;

            btnLoad.Enabled = false;
            btnSave.Enabled = false;

            stBarStatusLoad.Text = "Загрузка списка кубов...";


            _OLAP.server = new mycOLAPCubeWorker(_serverName);
            try
            {
                _OLAP.server.Connect();
            }
            catch (ArgumentException e)
            {
               
                btnLoad.Enabled = true;
                MessageBox.Show(e.Message);
                return;
            }

            if (_OLAP.server.StatusConnected)
            {
                _OLAP.server.LoadListDatabase();

                dxListCubes.DataSource = _OLAP.server.listDB;
                dxListCubes.DisplayMember = "Name";
                dxListCubes.ValueMember = "Name";
                dxListCubes.SortOrder = SortOrder.Ascending;

            }

            btnLoad.Enabled = true;
            btnSave.Enabled = true;

            stBarStatusLoad.Text = string.Format("Загружено {0} кубов", _OLAP.server.listDB.Count<mycOLAPdb>());
            stBarList1.Text = "";
            stBarList2.Text = "";
        }

        private void frmCubeRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_OLAP.server != null) _OLAP.server.Disconnect();
        }

        private void dxListCubes_MouseClick(object sender, MouseEventArgs e)
        {
            if (dxListCubes.SelectedIndex >= 0) ShowRoleMember();
        }

        private void ShowRoleMember()
        {
            // Для выбранного куба загрузить список ролей и пользователей 
            _OLAP.db = (mycOLAPdb)dxListCubes.SelectedItem;
            _OLAP.server.LoadListRoleUserFromDB(_OLAP.db.Name, false);

            if (tabRoleUser.SelectedTab.Name == tabRoles.Name)
            {   // Показать Роли -->> Пользователи  
                try
                {
                    _OLAP.db.listRole.Sort();
                }
                catch (Exception)
                {

                    MessageBox.Show("Ошибка сортировки списка ролей. продолжаем работать...");
                }
                
                dxListRoles.DataSource = _OLAP.db.listRole;
                dxListRoles.DisplayMember = "Name";
                dxListRoles.ValueMember = "Name";                
                stBarList1.Text = string.Format(">>> {0} ролей", _OLAP.db.listRole.Count.ToString());
            }
            else
            { // Показать Пользователи -->> Роли 
                _OLAP.db.listUsers.Sort();
                dxListUserAll.DataSource = _OLAP.db.listUsers;
                dxListUserAll.DisplayMember = "ShortName";
                dxListUserAll.ValueMember = "Name";
                stBarList1.Text = string.Format(">>> {0} пользователей", _OLAP.db.listUsers.Count.ToString());
            }
        }

        private void dxListRoles_MouseClick(object sender, MouseEventArgs e)
        {
            ShowCurrentRoleMembers();
        }

        private void ShowCurrentRoleMembers()
        {
            //Для выбранной роли показать ее пользователей
            if (dxListRoles.SelectedIndex != -1)
            {
                _OLAP.role = (mycOLAProle)dxListRoles.SelectedItem;
                _OLAP.role.listUser.Sort();
                dxListUsers.DataSource = ((mycOLAProle)dxListRoles.SelectedItem).listUser;
                dxListUsers.DisplayMember = "ShortName";
                dxListUsers.ValueMember = "Name";
                //dxListUsers.SortOrder = SortOrder.Ascending;
                stBarList2.Text = string.Format(">>> {0} пользователй", _OLAP.role.listUser.Count.ToString());
            }
        }

        private void dxListUserAll_MouseClick(object sender, MouseEventArgs e)
        {
            // для выбранного пользователя загрузить все роли
            _OLAP.user = (mycOLAPuser)dxListUserAll.SelectedItem;
            dxListUserRoles.DataSource = _OLAP.user.listRoles;
            dxListUserRoles.DisplayMember = "Name";
            dxListUserRoles.ValueMember = "Name";
            dxListUserRoles.SortOrder = SortOrder.Ascending;
            stBarList2.Text = string.Format(">>> {0} ролей", _OLAP.user.listRoles.Count.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Сохранить выбранные роли-пользователи в файл
            SaveMyRoles();
        }

        private void SaveMyRoles()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Укажите путь и имя файла для сохранения";
            saveFileDialog1.FileName = _OLAP.db.Name + "RoleMembers.txt";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {    
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName, false, Encoding.Default, 10))
                    {
                        string filerowheader = string.Format("\"{0}\",\"{1}\",\"{2}\"", "Database", "Role", "Member");
                        file.WriteLine(filerowheader);

                        string Databasename = _OLAP.db.Name;

                        foreach (mycOLAProle rol in _OLAP.db.listRole)
                        {
                            string Rolename = rol.Name;
                            foreach (mycOLAPuser usr in rol.listUser)
                            {
                                string RoleMember = usr.Name;
                                string filerow = string.Format("\"{0}\",\"{1}\",\"{2}\"", Databasename, Rolename, RoleMember);
                                file.WriteLine(filerow);
                            }
                        }
                    }
                    MessageBox.Show("Выгрузка успешно завершена", "Инфо");
                }
                catch (Exception ex)
                {

                    if (ex is Microsoft.AnalysisServices.AmoException)
                    {
                        MessageBox.Show("Ошибка чтения данных сервера SSAS");
                        return;
                    }

                    if (ex is System.IO.IOException)
                    {
                        MessageBox.Show("Ошибка открытия или записи в файл. Проверьте не открыт ли он в другой программе.");
                        return;
                    }

                    MessageBox.Show("Неизвестная и самая страшная ошибка, потому что неизвестная");

                }
            }
            saveFileDialog1.Dispose();
        }

        private void tabRoleUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowRoleMember();
        }

        private void txtServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadCubeRoles();
            }
        }

        private void frmCubeRoles_Load(object sender, EventArgs e)
        {
            this.Text = "OLAP roles viewer, v. " + Application.ProductVersion;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void popMenuAddUser_Click(object sender, EventArgs e)
        {
            frmGetDomainUser frmAD = new frmGetDomainUser();
            
            frmAD.ShowDialog();
            if (frmAD.UserAD != null)
            {               
                //добавить пользователя
                mycOLAProle role = (mycOLAProle)dxListRoles.SelectedItem;
                Microsoft.AnalysisServices.RoleMember usr = new Microsoft.AnalysisServices.RoleMember();
                usr.Name = frmAD.UserAD.UserDomainLogin;
                try
                {
                    role.AddUser(usr);
                    ReloadListMembers();
                    MessageBox.Show("Пользователь добавлен.");
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("Ошибка добавления пользователя !\n"+ex.Message);
                }

            }
            
            frmAD.Close();
        }

       

        private void popMenuDeleteUser_Click(object sender, EventArgs e)
        {
            //удалить пользователя
            mycOLAProle role = (mycOLAProle)dxListRoles.SelectedItem;
            mycOLAPuser ouser = (mycOLAPuser)dxListUsers.SelectedItem;
            Boolean bOK = false;

            DialogResult result = MessageBox.Show("Удаляем пользователя ?", "DialogBox", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes : bOK = true; break;                
            }
            if (bOK)
            {
                bOK = false;
                try
                {
                    role.DeleteUser(ouser);
                    bOK = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления пользователя !\n" + ex.Message);
                }                
            }

            if (bOK)
            {
                ReloadListMembers();
                MessageBox.Show("Пользователь удален.");
            }
        }

        private void ReloadListMembers()
        {
            //обновить списки пользователей
            int iCurrentRoleIndex;
            iCurrentRoleIndex = dxListRoles.SelectedIndex;
            _OLAP.server.LoadListRoleUserFromDB(_OLAP.db.Name, true);
            ShowRoleMember();
            dxListRoles.SelectedIndex = iCurrentRoleIndex;
            ShowCurrentRoleMembers();
        }

        private void dxListUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mycOLAPuser ouser = (mycOLAPuser)dxListUsers.SelectedItem;
            MessageBox.Show(string.Format("SID={0};\nName={1};", ouser.SID, ouser.Name));
        }

        private void dxListUserAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mycOLAPuser ouser = (mycOLAPuser)dxListUserAll.SelectedItem;
            MessageBox.Show(string.Format("SID={0};\nName={1};", ouser.SID, ouser.Name));
        }
    }
}
