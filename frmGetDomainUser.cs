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
    public partial class frmGetDomainUser : Form
    {
        public frmGetDomainUser()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public mycActiveDirectoryUser UserAD;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUser( txtName.Text );
        }

        private void SearchUser(string p)
        {   
            if (string.IsNullOrWhiteSpace(p) )
            {
                MessageBox.Show("Введите часть фамилии в поле для поиска !", this.Text);
                return;
            }
            // выдать список пользователей, удовлетворяющих шаблону
            mycActiveDirectoryWorker adw = new mycActiveDirectoryWorker();
            adw.FindDomainUsers(p);
            lstUsers.DataSource = adw.UserList;
            lstUsers.DisplayMember = "UserDisplayName";
            if (lstUsers.Items.Count > 0)
            {
                lstUsers.Focus();
            }
        }



        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchUser(txtName.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetUserAD();
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            GetUserAD();
        }


        private void GetUserAD()
        {   // Получить пользователя из списка доступных по шаблону
            if (lstUsers.SelectedIndex >= 0)
            {
                UserAD = (mycActiveDirectoryUser)lstUsers.SelectedItem;
                this.Hide();
            }
        }

        private void lstUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetUserAD();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserAD = null;
            this.Hide();
        }
    }
}
