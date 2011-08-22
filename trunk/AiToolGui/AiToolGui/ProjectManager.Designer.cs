namespace AiToolGui
{
    partial class ProjectManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewProject = new System.Windows.Forms.ListView();
            this.colProjectN = new System.Windows.Forms.ColumnHeader();
            this.colProjectNum = new System.Windows.Forms.ColumnHeader();
            this.colProjectName = new System.Windows.Forms.ColumnHeader();
            this.checkCurUser = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewProject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.checkCurUser);
            this.splitContainer1.Panel2.Controls.Add(this.buttonClose);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAdd);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOpen);
            this.splitContainer1.Size = new System.Drawing.Size(450, 331);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 2;
            // 
            // listViewProject
            // 
            this.listViewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProjectN,
            this.colProjectNum,
            this.colProjectName});
            this.listViewProject.FullRowSelect = true;
            this.listViewProject.GridLines = true;
            this.listViewProject.HideSelection = false;
            this.listViewProject.Location = new System.Drawing.Point(3, 3);
            this.listViewProject.MultiSelect = false;
            this.listViewProject.Name = "listViewProject";
            this.listViewProject.Size = new System.Drawing.Size(332, 325);
            this.listViewProject.TabIndex = 0;
            this.listViewProject.UseCompatibleStateImageBehavior = false;
            this.listViewProject.View = System.Windows.Forms.View.Details;
            this.listViewProject.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewProject_MouseDoubleClick);
            this.listViewProject.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewProjectItemSelectionChanged);
            // 
            // colProjectN
            // 
            this.colProjectN.Text = "Numer";
            // 
            // colProjectNum
            // 
            this.colProjectNum.Text = "Project Numer";
            this.colProjectNum.Width = 100;
            // 
            // colProjectName
            // 
            this.colProjectName.Text = "Project Name";
            this.colProjectName.Width = 170;
            // 
            // checkCurUser
            // 
            this.checkCurUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCurUser.AutoSize = true;
            this.checkCurUser.Location = new System.Drawing.Point(13, 90);
            this.checkCurUser.Name = "checkCurUser";
            this.checkCurUser.Size = new System.Drawing.Size(85, 17);
            this.checkCurUser.TabIndex = 4;
            this.checkCurUser.Text = "Current User";
            this.checkCurUser.UseVisualStyleBackColor = true;
            this.checkCurUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(13, 283);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonCloseClick);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(13, 61);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(13, 32);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(13, 3);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // ProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 355);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(482, 289);
            this.Name = "ProjectManager";
            this.Text = "Project Manager";
            this.Shown += new System.EventHandler(this.ProjectManager_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectManager_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.ListView listViewProject;
        private System.Windows.Forms.CheckBox checkCurUser;
        private System.Windows.Forms.ColumnHeader colProjectN;
        private System.Windows.Forms.ColumnHeader colProjectName;
        private System.Windows.Forms.ColumnHeader colProjectNum;
    }
}