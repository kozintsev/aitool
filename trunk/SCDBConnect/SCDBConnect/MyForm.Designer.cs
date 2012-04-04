namespace SCDBConnect
{
    partial class FormChangeDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangeDB));
            this.groupBox_DBpath = new System.Windows.Forms.GroupBox();
            this.textBox_DBpath = new System.Windows.Forms.TextBox();
            this.image32 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_DBtables = new System.Windows.Forms.GroupBox();
            this.listView_TbNameDB = new System.Windows.Forms.ListView();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.link_MyMail = new System.Windows.Forms.LinkLabel();
            this.button_OffDB = new System.Windows.Forms.Button();
            this.button_OnDB = new System.Windows.Forms.Button();
            this.button_set_path = new System.Windows.Forms.Button();
            this.groupBox_DBpath.SuspendLayout();
            this.groupBox_DBtables.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DBpath
            // 
            this.groupBox_DBpath.Controls.Add(this.textBox_DBpath);
            this.groupBox_DBpath.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_DBpath.Location = new System.Drawing.Point(12, 12);
            this.groupBox_DBpath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox_DBpath.Name = "groupBox_DBpath";
            this.groupBox_DBpath.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox_DBpath.Size = new System.Drawing.Size(316, 47);
            this.groupBox_DBpath.TabIndex = 0;
            this.groupBox_DBpath.TabStop = false;
            this.groupBox_DBpath.Text = "Path to DB for connection:";
            // 
            // textBox_DBpath
            // 
            this.textBox_DBpath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_DBpath.Location = new System.Drawing.Point(6, 19);
            this.textBox_DBpath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_DBpath.Name = "textBox_DBpath";
            this.textBox_DBpath.ReadOnly = true;
            this.textBox_DBpath.Size = new System.Drawing.Size(306, 20);
            this.textBox_DBpath.TabIndex = 0;
            this.TT.SetToolTip(this.textBox_DBpath, "Путь к БД");
            // 
            // image32
            // 
            this.image32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("image32.ImageStream")));
            this.image32.TransparentColor = System.Drawing.Color.Transparent;
            this.image32.Images.SetKeyName(0, "database-refresh.ico");
            this.image32.Images.SetKeyName(1, "database-import.ico");
            this.image32.Images.SetKeyName(2, "database-off.ico");
            this.image32.Images.SetKeyName(3, "database-on.ico");
            this.image32.Images.SetKeyName(4, "refresh.ico");
            this.image32.Images.SetKeyName(5, "database_table.png");
            this.image32.Images.SetKeyName(6, "database_table_use.png");
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDlg";
            // 
            // groupBox_DBtables
            // 
            this.groupBox_DBtables.Controls.Add(this.listView_TbNameDB);
            this.groupBox_DBtables.Enabled = false;
            this.groupBox_DBtables.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_DBtables.Location = new System.Drawing.Point(12, 111);
            this.groupBox_DBtables.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox_DBtables.Name = "groupBox_DBtables";
            this.groupBox_DBtables.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox_DBtables.Size = new System.Drawing.Size(352, 236);
            this.groupBox_DBtables.TabIndex = 5;
            this.groupBox_DBtables.TabStop = false;
            this.groupBox_DBtables.Text = "DB Tables:";
            // 
            // listView_TbNameDB
            // 
            this.listView_TbNameDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_TbNameDB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_TbNameDB.LargeImageList = this.image32;
            this.listView_TbNameDB.Location = new System.Drawing.Point(2, 21);
            this.listView_TbNameDB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView_TbNameDB.Name = "listView_TbNameDB";
            this.listView_TbNameDB.Size = new System.Drawing.Size(348, 212);
            this.listView_TbNameDB.SmallImageList = this.image32;
            this.listView_TbNameDB.TabIndex = 0;
            this.listView_TbNameDB.UseCompatibleStateImageBehavior = false;
            this.listView_TbNameDB.DoubleClick += new System.EventHandler(this.listView_TbNameDB_DoubleClick);
            // 
            // TT
            // 
            this.TT.IsBalloon = true;
            this.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(128, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "ИП \"Иванов\" Лелеко Н.А.";
            this.TT.SetToolTip(this.label1, "Разработчик");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "90-25-04";
            this.TT.SetToolTip(this.label2, "Телефон ТехПомощи");
            // 
            // link_MyMail
            // 
            this.link_MyMail.AutoSize = true;
            this.link_MyMail.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_MyMail.Location = new System.Drawing.Point(101, 90);
            this.link_MyMail.Name = "link_MyMail";
            this.link_MyMail.Size = new System.Drawing.Size(176, 22);
            this.link_MyMail.TabIndex = 8;
            this.link_MyMail.TabStop = true;
            this.link_MyMail.Text = "itotchetnost@rambler.ru";
            this.TT.SetToolTip(this.link_MyMail, "Написать письмо");
            this.link_MyMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_MyMail_LinkClicked);
            // 
            // button_OffDB
            // 
            this.button_OffDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OffDB.Enabled = false;
            this.button_OffDB.ImageIndex = 2;
            this.button_OffDB.ImageList = this.image32;
            this.button_OffDB.Location = new System.Drawing.Point(56, 65);
            this.button_OffDB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_OffDB.Name = "button_OffDB";
            this.button_OffDB.Size = new System.Drawing.Size(40, 40);
            this.button_OffDB.TabIndex = 4;
            this.TT.SetToolTip(this.button_OffDB, "Отключиться от БД");
            this.button_OffDB.UseVisualStyleBackColor = true;
            this.button_OffDB.Click += new System.EventHandler(this.button_OffDB_Click);
            // 
            // button_OnDB
            // 
            this.button_OnDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OnDB.ImageIndex = 3;
            this.button_OnDB.ImageList = this.image32;
            this.button_OnDB.Location = new System.Drawing.Point(12, 65);
            this.button_OnDB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_OnDB.Name = "button_OnDB";
            this.button_OnDB.Size = new System.Drawing.Size(40, 40);
            this.button_OnDB.TabIndex = 2;
            this.TT.SetToolTip(this.button_OnDB, "Подключиться к БД");
            this.button_OnDB.UseVisualStyleBackColor = true;
            this.button_OnDB.Click += new System.EventHandler(this.button_OnDB_Click);
            // 
            // button_set_path
            // 
            this.button_set_path.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_set_path.ImageIndex = 4;
            this.button_set_path.ImageList = this.image32;
            this.button_set_path.Location = new System.Drawing.Point(328, 19);
            this.button_set_path.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_set_path.Name = "button_set_path";
            this.button_set_path.Size = new System.Drawing.Size(40, 40);
            this.button_set_path.TabIndex = 1;
            this.button_set_path.Tag = "";
            this.TT.SetToolTip(this.button_set_path, "Выбрать путь к БД");
            this.button_set_path.UseVisualStyleBackColor = true;
            this.button_set_path.Click += new System.EventHandler(this.button_set_path_Click);
            // 
            // FormChangeDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 403);
            this.Controls.Add(this.link_MyMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_DBtables);
            this.Controls.Add(this.button_OffDB);
            this.Controls.Add(this.button_OnDB);
            this.Controls.Add(this.button_set_path);
            this.Controls.Add(this.groupBox_DBpath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormChangeDB";
            this.Text = "DB Editor V. 1.2.14";
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.groupBox_DBpath.ResumeLayout(false);
            this.groupBox_DBpath.PerformLayout();
            this.groupBox_DBtables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_DBpath;
        private System.Windows.Forms.TextBox textBox_DBpath;
        private System.Windows.Forms.Button button_set_path;
        private System.Windows.Forms.ImageList image32;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Button button_OnDB;
        private System.Windows.Forms.Button button_OffDB;
        private System.Windows.Forms.GroupBox groupBox_DBtables;
        private System.Windows.Forms.ListView listView_TbNameDB;
        private System.Windows.Forms.ToolTip TT;

        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel link_MyMail;
    }
}

