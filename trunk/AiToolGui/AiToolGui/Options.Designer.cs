namespace AiToolGui
{
    partial class Options
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
            this.CloseForm = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.groupBoxDB = new System.Windows.Forms.GroupBox();
            this.txtBoxBaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSavePass = new System.Windows.Forms.CheckBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.checkWindowsUser = new System.Windows.Forms.CheckBox();
            this.txtBoxPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtBoxHost = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseForm
            // 
            this.CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseForm.Location = new System.Drawing.Point(197, 219);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 5;
            this.CloseForm.Text = "Close";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(116, 219);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBoxDB
            // 
            this.groupBoxDB.Controls.Add(this.numericPort);
            this.groupBoxDB.Controls.Add(this.txtBoxBaseName);
            this.groupBoxDB.Controls.Add(this.label1);
            this.groupBoxDB.Controls.Add(this.checkSavePass);
            this.groupBoxDB.Controls.Add(this.labelPort);
            this.groupBoxDB.Controls.Add(this.labelType);
            this.groupBoxDB.Controls.Add(this.label5);
            this.groupBoxDB.Controls.Add(this.label4);
            this.groupBoxDB.Controls.Add(this.labelHost);
            this.groupBoxDB.Controls.Add(this.checkWindowsUser);
            this.groupBoxDB.Controls.Add(this.txtBoxPwd);
            this.groupBoxDB.Controls.Add(this.txtUserName);
            this.groupBoxDB.Controls.Add(this.txtBoxHost);
            this.groupBoxDB.Controls.Add(this.comboBox2);
            this.groupBoxDB.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDB.Name = "groupBoxDB";
            this.groupBoxDB.Size = new System.Drawing.Size(262, 198);
            this.groupBoxDB.TabIndex = 16;
            this.groupBoxDB.TabStop = false;
            this.groupBoxDB.Text = "Data Base";
            // 
            // txtBoxBaseName
            // 
            this.txtBoxBaseName.Location = new System.Drawing.Point(70, 95);
            this.txtBoxBaseName.Name = "txtBoxBaseName";
            this.txtBoxBaseName.Size = new System.Drawing.Size(157, 20);
            this.txtBoxBaseName.TabIndex = 28;
            this.txtBoxBaseName.Text = "sdpm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Base Name:";
            // 
            // checkSavePass
            // 
            this.checkSavePass.AutoSize = true;
            this.checkSavePass.Checked = true;
            this.checkSavePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSavePass.Location = new System.Drawing.Point(132, 170);
            this.checkSavePass.Name = "checkSavePass";
            this.checkSavePass.Size = new System.Drawing.Size(100, 17);
            this.checkSavePass.TabIndex = 26;
            this.checkSavePass.Text = "Save Password";
            this.checkSavePass.UseVisualStyleBackColor = true;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(6, 66);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 25;
            this.labelPort.Text = "Port:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(13, 16);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 24;
            this.labelType.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "User Name:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(6, 43);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(63, 13);
            this.labelHost.TabIndex = 20;
            this.labelHost.Text = "Host Name:";
            // 
            // checkWindowsUser
            // 
            this.checkWindowsUser.AutoSize = true;
            this.checkWindowsUser.Location = new System.Drawing.Point(16, 170);
            this.checkWindowsUser.Name = "checkWindowsUser";
            this.checkWindowsUser.Size = new System.Drawing.Size(95, 17);
            this.checkWindowsUser.TabIndex = 19;
            this.checkWindowsUser.Text = "Windows User";
            this.checkWindowsUser.UseVisualStyleBackColor = true;
            // 
            // txtBoxPwd
            // 
            this.txtBoxPwd.Location = new System.Drawing.Point(70, 144);
            this.txtBoxPwd.Name = "txtBoxPwd";
            this.txtBoxPwd.PasswordChar = '*';
            this.txtBoxPwd.Size = new System.Drawing.Size(157, 20);
            this.txtBoxPwd.TabIndex = 18;
            this.txtBoxPwd.Text = "9L37VKNV4X";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(70, 121);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 20);
            this.txtUserName.TabIndex = 17;
            this.txtUserName.Text = "root";
            // 
            // txtBoxHost
            // 
            this.txtBoxHost.Location = new System.Drawing.Point(70, 40);
            this.txtBoxHost.Name = "txtBoxHost";
            this.txtBoxHost.Size = new System.Drawing.Size(157, 20);
            this.txtBoxHost.TabIndex = 16;
            this.txtBoxHost.Text = "localhost";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "MySQL"});
            this.comboBox2.Location = new System.Drawing.Point(70, 13);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Text = "My SQL";
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(70, 64);
            this.numericPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(65, 20);
            this.numericPort.TabIndex = 29;
            this.numericPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.groupBoxDB);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.CloseForm);
            this.MinimumSize = new System.Drawing.Size(300, 280);
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            this.groupBoxDB.ResumeLayout(false);
            this.groupBoxDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.GroupBox groupBoxDB;
        private System.Windows.Forms.CheckBox checkSavePass;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.CheckBox checkWindowsUser;
        private System.Windows.Forms.TextBox txtBoxPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtBoxHost;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtBoxBaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericPort;
    }
}