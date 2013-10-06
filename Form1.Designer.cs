namespace OLAP_roles
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.serverName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dxBtnCubeRole = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(25, 39);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(249, 20);
            this.serverName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить роли в файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dxBtnCubeRole
            // 
            this.dxBtnCubeRole.Location = new System.Drawing.Point(32, 80);
            this.dxBtnCubeRole.Name = "dxBtnCubeRole";
            this.dxBtnCubeRole.Size = new System.Drawing.Size(238, 24);
            this.dxBtnCubeRole.TabIndex = 3;
            this.dxBtnCubeRole.Text = "Показать роли в таблице";
            this.dxBtnCubeRole.Click += new System.EventHandler(this.dxBtnCubeRole_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 200);
            this.Controls.Add(this.dxBtnCubeRole);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serverName);
            this.Name = "frmMain";
            this.Text = "Управление ролями в ОЛАП";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.SimpleButton dxBtnCubeRole;
    }
}

