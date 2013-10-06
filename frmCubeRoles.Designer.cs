namespace OLAP_roles
{
    partial class frmCubeRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCubeRoles));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stBarStatusLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.stBarList1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stBarList2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dxListCubes = new DevExpress.XtraEditors.ListBoxControl();
            this.tabRoleUser = new System.Windows.Forms.TabControl();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dxListRoles = new DevExpress.XtraEditors.ListBoxControl();
            this.popMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popMenuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.popMenuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.dxListUsers = new DevExpress.XtraEditors.ListBoxControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dxListUserAll = new DevExpress.XtraEditors.ListBoxControl();
            this.dxListUserRoles = new DevExpress.XtraEditors.ListBoxControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtServerName = new System.Windows.Forms.ToolStripTextBox();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxListCubes)).BeginInit();
            this.tabRoleUser.SuspendLayout();
            this.tabRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxListRoles)).BeginInit();
            this.popMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxListUsers)).BeginInit();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxListUserAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxListUserRoles)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(529, 445);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(529, 492);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stBarStatusLoad,
            this.stBarList1,
            this.stBarList2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(529, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // stBarStatusLoad
            // 
            this.stBarStatusLoad.Name = "stBarStatusLoad";
            this.stBarStatusLoad.Size = new System.Drawing.Size(93, 17);
            this.stBarStatusLoad.Text = "Статус загрузки";
            // 
            // stBarList1
            // 
            this.stBarList1.Name = "stBarList1";
            this.stBarList1.Size = new System.Drawing.Size(116, 17);
            this.stBarList1.Text = "Состояние 1 списка";
            // 
            // stBarList2
            // 
            this.stBarList2.Name = "stBarList2";
            this.stBarList2.Size = new System.Drawing.Size(128, 17);
            this.stBarList2.Text = "Состояние 2го списка";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dxListCubes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabRoleUser);
            this.splitContainer1.Size = new System.Drawing.Size(529, 445);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 1;
            // 
            // dxListCubes
            // 
            this.dxListCubes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxListCubes.Location = new System.Drawing.Point(0, 0);
            this.dxListCubes.Name = "dxListCubes";
            this.dxListCubes.Size = new System.Drawing.Size(175, 445);
            this.dxListCubes.TabIndex = 0;
            this.dxListCubes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dxListCubes_MouseClick);
            // 
            // tabRoleUser
            // 
            this.tabRoleUser.Controls.Add(this.tabRoles);
            this.tabRoleUser.Controls.Add(this.tabUsers);
            this.tabRoleUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRoleUser.Location = new System.Drawing.Point(0, 0);
            this.tabRoleUser.Name = "tabRoleUser";
            this.tabRoleUser.SelectedIndex = 0;
            this.tabRoleUser.Size = new System.Drawing.Size(350, 445);
            this.tabRoleUser.TabIndex = 2;
            this.tabRoleUser.SelectedIndexChanged += new System.EventHandler(this.tabRoleUser_SelectedIndexChanged);
            // 
            // tabRoles
            // 
            this.tabRoles.Controls.Add(this.splitContainer2);
            this.tabRoles.Location = new System.Drawing.Point(4, 22);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoles.Size = new System.Drawing.Size(342, 419);
            this.tabRoles.TabIndex = 0;
            this.tabRoles.Text = "Роли в ОЛАПе";
            this.tabRoles.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dxListRoles);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dxListUsers);
            this.splitContainer2.Size = new System.Drawing.Size(336, 413);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 2;
            // 
            // dxListRoles
            // 
            this.dxListRoles.ContextMenuStrip = this.popMenu;
            this.dxListRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxListRoles.Location = new System.Drawing.Point(0, 0);
            this.dxListRoles.Name = "dxListRoles";
            this.dxListRoles.Size = new System.Drawing.Size(147, 413);
            this.dxListRoles.TabIndex = 1;
            this.dxListRoles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dxListRoles_MouseClick);
            // 
            // popMenu
            // 
            this.popMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popMenuAddUser,
            this.popMenuDeleteUser});
            this.popMenu.Name = "popMenu";
            this.popMenu.Size = new System.Drawing.Size(198, 48);
            // 
            // popMenuAddUser
            // 
            this.popMenuAddUser.Name = "popMenuAddUser";
            this.popMenuAddUser.Size = new System.Drawing.Size(197, 22);
            this.popMenuAddUser.Text = "Добавить пользвателя";
            this.popMenuAddUser.Click += new System.EventHandler(this.popMenuAddUser_Click);
            // 
            // popMenuDeleteUser
            // 
            this.popMenuDeleteUser.Name = "popMenuDeleteUser";
            this.popMenuDeleteUser.Size = new System.Drawing.Size(197, 22);
            this.popMenuDeleteUser.Text = "Удалить пользователя";
            this.popMenuDeleteUser.Click += new System.EventHandler(this.popMenuDeleteUser_Click);
            // 
            // dxListUsers
            // 
            this.dxListUsers.ContextMenuStrip = this.popMenu;
            this.dxListUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxListUsers.Location = new System.Drawing.Point(0, 0);
            this.dxListUsers.Name = "dxListUsers";
            this.dxListUsers.Size = new System.Drawing.Size(185, 413);
            this.dxListUsers.TabIndex = 2;
            this.dxListUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dxListUsers_MouseDoubleClick);
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.splitContainer3);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(342, 419);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Пользователи";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dxListUserAll);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dxListUserRoles);
            this.splitContainer3.Size = new System.Drawing.Size(336, 413);
            this.splitContainer3.SplitterDistance = 159;
            this.splitContainer3.TabIndex = 2;
            // 
            // dxListUserAll
            // 
            this.dxListUserAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxListUserAll.Location = new System.Drawing.Point(0, 0);
            this.dxListUserAll.Name = "dxListUserAll";
            this.dxListUserAll.Size = new System.Drawing.Size(159, 413);
            this.dxListUserAll.TabIndex = 1;
            this.dxListUserAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dxListUserAll_MouseClick);
            this.dxListUserAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dxListUserAll_MouseDoubleClick);
            // 
            // dxListUserRoles
            // 
            this.dxListUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxListUserRoles.Location = new System.Drawing.Point(0, 0);
            this.dxListUserRoles.Name = "dxListUserRoles";
            this.dxListUserRoles.Size = new System.Drawing.Size(173, 413);
            this.dxListUserRoles.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtServerName,
            this.btnLoad,
            this.btnSave,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(341, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // txtServerName
            // 
            this.txtServerName.AutoToolTip = true;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(100, 25);
            this.txtServerName.ToolTipText = "Имя сервера SSAS";
            this.txtServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServerName_KeyDown);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::OLAP_roles.Properties.Resources.LoadData;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 22);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::OLAP_roles.Properties.Resources.savebluedisk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 22);
            this.btnSave.Text = "Сохранить";
            this.btnSave.ToolTipText = "Сохранить в текстовый файл";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OLAP_roles.Properties.Resources.exitlogout;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 22);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCubeRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 492);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCubeRoles";
            this.Text = "frmCubeRoles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCubeRoles_FormClosing);
            this.Load += new System.EventHandler(this.frmCubeRoles_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxListCubes)).EndInit();
            this.tabRoleUser.ResumeLayout(false);
            this.tabRoles.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxListRoles)).EndInit();
            this.popMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxListUsers)).EndInit();
            this.tabUsers.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxListUserAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxListUserRoles)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private DevExpress.XtraEditors.ListBoxControl dxLstCubes;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.ListBoxControl dxListCubes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stBarStatusLoad;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.TabControl tabRoleUser;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.ToolStripStatusLabel stBarList1;
        private System.Windows.Forms.ToolStripStatusLabel stBarList2;
        private System.Windows.Forms.ToolStripTextBox txtServerName;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ContextMenuStrip popMenu;
        private System.Windows.Forms.ToolStripMenuItem popMenuAddUser;
        private System.Windows.Forms.ToolStripMenuItem popMenuDeleteUser;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraEditors.ListBoxControl dxListRoles;
        private DevExpress.XtraEditors.ListBoxControl dxListUsers;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevExpress.XtraEditors.ListBoxControl dxListUserAll;
        private DevExpress.XtraEditors.ListBoxControl dxListUserRoles;
    }
}