namespace KMintegrator
{
    partial class MainForm
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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.TableKompas3D = new System.Windows.Forms.DataGridView();
        	this.KompasName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.KompasValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.KompasNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.MathCadName_ComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.label1 = new System.Windows.Forms.Label();
        	this.TableMathCad = new System.Windows.Forms.DataGridView();
        	this.MathCadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.MathCadValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.MathCadType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ID_region_xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.KompasName_ComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.label2 = new System.Windows.Forms.Label();
        	this.KompasPath = new System.Windows.Forms.TextBox();
        	this.MathCadPath = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.AddKompas = new System.Windows.Forms.Button();
        	this.label4 = new System.Windows.Forms.Label();
        	this.AddMathCad = new System.Windows.Forms.Button();
        	this.Apply_Kompas = new System.Windows.Forms.Button();
        	this.Apply_MathCad = new System.Windows.Forms.Button();
        	this.Refresh_All = new System.Windows.Forms.Button();
        	this.Exit = new System.Windows.Forms.Button();
        	this.Open_Project = new System.Windows.Forms.Button();
        	this.Save_Project = new System.Windows.Forms.Button();
        	this.label5 = new System.Windows.Forms.Label();
        	this.ProjectPath = new System.Windows.Forms.TextBox();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        	this.label6 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.TableKompas3D)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.TableMathCad)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// TableKompas3D
        	// 
        	this.TableKompas3D.AllowUserToAddRows = false;
        	this.TableKompas3D.AllowUserToDeleteRows = false;
        	this.TableKompas3D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.TableKompas3D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.TableKompas3D.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.KompasName,
        	        	        	this.KompasValue,
        	        	        	this.KompasNote,
        	        	        	this.MathCadName_ComboBox});
        	this.TableKompas3D.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.TableKompas3D.Location = new System.Drawing.Point(12, 226);
        	this.TableKompas3D.Name = "TableKompas3D";
        	this.TableKompas3D.RowHeadersVisible = false;
        	this.TableKompas3D.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.TableKompas3D.Size = new System.Drawing.Size(466, 164);
        	this.TableKompas3D.TabIndex = 0;
        	this.TableKompas3D.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EndEdit_TableKompas3D);
        	// 
        	// KompasName
        	// 
        	this.KompasName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.KompasName.HeaderText = "KompasName";
        	this.KompasName.Name = "KompasName";
        	this.KompasName.ReadOnly = true;
        	this.KompasName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// KompasValue
        	// 
        	this.KompasValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.KompasValue.HeaderText = "KompasValue";
        	this.KompasValue.Name = "KompasValue";
        	this.KompasValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.KompasValue.Width = 110;
        	// 
        	// KompasNote
        	// 
        	this.KompasNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.KompasNote.HeaderText = "KompasNote";
        	this.KompasNote.Name = "KompasNote";
        	this.KompasNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.KompasNote.Width = 150;
        	// 
        	// MathCadName_ComboBox
        	// 
        	this.MathCadName_ComboBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	dataGridViewCellStyle1.NullValue = "empty";
        	this.MathCadName_ComboBox.DefaultCellStyle = dataGridViewCellStyle1;
        	this.MathCadName_ComboBox.HeaderText = "MathCadName";
        	this.MathCadName_ComboBox.Name = "MathCadName_ComboBox";
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(18, 206);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(371, 17);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Передача переменных их MathCAD в Kompas-3D";
        	// 
        	// TableMathCad
        	// 
        	this.TableMathCad.AllowUserToAddRows = false;
        	this.TableMathCad.AllowUserToDeleteRows = false;
        	this.TableMathCad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.TableMathCad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.TableMathCad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.MathCadName,
        	        	        	this.MathCadValue,
        	        	        	this.MathCadType,
        	        	        	this.ID_region_xml,
        	        	        	this.Type,
        	        	        	this.KompasName_ComboBox});
        	this.TableMathCad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        	this.TableMathCad.Location = new System.Drawing.Point(12, 29);
        	this.TableMathCad.Name = "TableMathCad";
        	this.TableMathCad.RowHeadersVisible = false;
        	this.TableMathCad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.TableMathCad.Size = new System.Drawing.Size(466, 164);
        	this.TableMathCad.TabIndex = 2;
        	this.TableMathCad.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableMathCadCellEndEdit);
        	// 
        	// MathCadName
        	// 
        	this.MathCadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.MathCadName.HeaderText = "MathCadName";
        	this.MathCadName.Name = "MathCadName";
        	this.MathCadName.ReadOnly = true;
        	this.MathCadName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// MathCadValue
        	// 
        	this.MathCadValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.MathCadValue.HeaderText = "MathCadValue";
        	this.MathCadValue.Name = "MathCadValue";
        	this.MathCadValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.MathCadValue.Width = 120;
        	// 
        	// MathCadType
        	// 
        	this.MathCadType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.MathCadType.HeaderText = "MathCadType";
        	this.MathCadType.Name = "MathCadType";
        	this.MathCadType.ReadOnly = true;
        	this.MathCadType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	// 
        	// ID_region_xml
        	// 
        	this.ID_region_xml.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	this.ID_region_xml.FillWeight = 50F;
        	this.ID_region_xml.HeaderText = "ID_region_xml";
        	this.ID_region_xml.Name = "ID_region_xml";
        	this.ID_region_xml.ReadOnly = true;
        	this.ID_region_xml.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ID_region_xml.Visible = false;
        	this.ID_region_xml.Width = 40;
        	// 
        	// Type
        	// 
        	this.Type.HeaderText = "Type";
        	this.Type.Name = "Type";
        	this.Type.Visible = false;
        	// 
        	// KompasName_ComboBox
        	// 
        	this.KompasName_ComboBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        	dataGridViewCellStyle2.NullValue = "empty";
        	this.KompasName_ComboBox.DefaultCellStyle = dataGridViewCellStyle2;
        	this.KompasName_ComboBox.HeaderText = "KompasName";
        	this.KompasName_ComboBox.Name = "KompasName_ComboBox";
        	this.KompasName_ComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
        	this.KompasName_ComboBox.Width = 140;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(18, 9);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(372, 17);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "Передача переменных из Kompas-3D в MathCAD";
        	// 
        	// KompasPath
        	// 
        	this.KompasPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.KompasPath.Location = new System.Drawing.Point(18, 418);
        	this.KompasPath.Name = "KompasPath";
        	this.KompasPath.Size = new System.Drawing.Size(460, 20);
        	this.KompasPath.TabIndex = 4;
        	// 
        	// MathCadPath
        	// 
        	this.MathCadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.MathCadPath.Location = new System.Drawing.Point(18, 466);
        	this.MathCadPath.Name = "MathCadPath";
        	this.MathCadPath.Size = new System.Drawing.Size(460, 20);
        	this.MathCadPath.TabIndex = 5;
        	// 
        	// label3
        	// 
        	this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(15, 398);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(201, 17);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Путь к файлу Kompas-3D:";
        	// 
        	// AddKompas
        	// 
        	this.AddKompas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.AddKompas.Location = new System.Drawing.Point(500, 418);
        	this.AddKompas.Name = "AddKompas";
        	this.AddKompas.Size = new System.Drawing.Size(75, 23);
        	this.AddKompas.TabIndex = 7;
        	this.AddKompas.Text = "Добавить";
        	this.AddKompas.UseVisualStyleBackColor = true;
        	this.AddKompas.Click += new System.EventHandler(this.AddKompas_Click);
        	// 
        	// label4
        	// 
        	this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.Location = new System.Drawing.Point(15, 446);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(184, 17);
        	this.label4.TabIndex = 8;
        	this.label4.Text = "Путь к файлу MathCAD:";
        	// 
        	// AddMathCad
        	// 
        	this.AddMathCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.AddMathCad.Location = new System.Drawing.Point(500, 464);
        	this.AddMathCad.Name = "AddMathCad";
        	this.AddMathCad.Size = new System.Drawing.Size(75, 23);
        	this.AddMathCad.TabIndex = 9;
        	this.AddMathCad.Text = "Добавить";
        	this.AddMathCad.UseVisualStyleBackColor = true;
        	this.AddMathCad.Click += new System.EventHandler(this.AddMathCad_Click);
        	// 
        	// Apply_Kompas
        	// 
        	this.Apply_Kompas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.Apply_Kompas.Location = new System.Drawing.Point(503, 296);
        	this.Apply_Kompas.Name = "Apply_Kompas";
        	this.Apply_Kompas.Size = new System.Drawing.Size(75, 23);
        	this.Apply_Kompas.TabIndex = 10;
        	this.Apply_Kompas.Text = "Применить";
        	this.Apply_Kompas.UseVisualStyleBackColor = true;
        	this.Apply_Kompas.Click += new System.EventHandler(this.Apply_Kompas_Click);
        	// 
        	// Apply_MathCad
        	// 
        	this.Apply_MathCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.Apply_MathCad.Location = new System.Drawing.Point(503, 103);
        	this.Apply_MathCad.Name = "Apply_MathCad";
        	this.Apply_MathCad.Size = new System.Drawing.Size(75, 23);
        	this.Apply_MathCad.TabIndex = 12;
        	this.Apply_MathCad.Text = "Применить";
        	this.Apply_MathCad.UseVisualStyleBackColor = true;
        	this.Apply_MathCad.Click += new System.EventHandler(this.Apply_MathCadClick);
        	// 
        	// Refresh_All
        	// 
        	this.Refresh_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.Refresh_All.Location = new System.Drawing.Point(503, 200);
        	this.Refresh_All.Name = "Refresh_All";
        	this.Refresh_All.Size = new System.Drawing.Size(75, 23);
        	this.Refresh_All.TabIndex = 15;
        	this.Refresh_All.Text = "Обновить";
        	this.Refresh_All.UseVisualStyleBackColor = true;
        	this.Refresh_All.Click += new System.EventHandler(this.Refresh_All_Click);
        	// 
        	// Exit
        	// 
        	this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.Exit.Location = new System.Drawing.Point(18, 574);
        	this.Exit.Name = "Exit";
        	this.Exit.Size = new System.Drawing.Size(75, 23);
        	this.Exit.TabIndex = 16;
        	this.Exit.Text = "Выход";
        	this.Exit.UseVisualStyleBackColor = true;
        	this.Exit.Click += new System.EventHandler(this.Exit_Click);
        	// 
        	// Open_Project
        	// 
        	this.Open_Project.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.Open_Project.Location = new System.Drawing.Point(503, 542);
        	this.Open_Project.Name = "Open_Project";
        	this.Open_Project.Size = new System.Drawing.Size(75, 23);
        	this.Open_Project.TabIndex = 17;
        	this.Open_Project.Text = "Открыть";
        	this.Open_Project.UseVisualStyleBackColor = true;
        	this.Open_Project.Click += new System.EventHandler(this.Open_ProjectClick);
        	// 
        	// Save_Project
        	// 
        	this.Save_Project.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.Save_Project.Location = new System.Drawing.Point(503, 574);
        	this.Save_Project.Name = "Save_Project";
        	this.Save_Project.Size = new System.Drawing.Size(75, 23);
        	this.Save_Project.TabIndex = 18;
        	this.Save_Project.Text = "Сохранить";
        	this.Save_Project.UseVisualStyleBackColor = true;
        	this.Save_Project.Click += new System.EventHandler(this.Save_ProjectClick);
        	// 
        	// label5
        	// 
        	this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.label5.AutoSize = true;
        	this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label5.Location = new System.Drawing.Point(15, 507);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(218, 17);
        	this.label5.TabIndex = 19;
        	this.label5.Text = "Работа с файлами проекта:";
        	// 
        	// ProjectPath
        	// 
        	this.ProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.ProjectPath.Location = new System.Drawing.Point(18, 545);
        	this.ProjectPath.Name = "ProjectPath";
        	this.ProjectPath.Size = new System.Drawing.Size(460, 20);
        	this.ProjectPath.TabIndex = 20;
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Location = new System.Drawing.Point(0, 631);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(587, 22);
        	this.statusStrip1.TabIndex = 21;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// linkLabel1
        	// 
        	this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.linkLabel1.Location = new System.Drawing.Point(18, 608);
        	this.linkLabel1.Name = "linkLabel1";
        	this.linkLabel1.Size = new System.Drawing.Size(181, 23);
        	this.linkLabel1.TabIndex = 22;
        	this.linkLabel1.TabStop = true;
        	this.linkLabel1.Text = "mailto:o.kozintsev@googlemail.com";
        	this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
        	// 
        	// label6
        	// 
        	this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.label6.Location = new System.Drawing.Point(217, 608);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(284, 23);
        	this.label6.TabIndex = 23;
        	this.label6.Text = "Разработчики: Козинцев Олег и Кожевников Михаил";
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(587, 653);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.linkLabel1);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.ProjectPath);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.Save_Project);
        	this.Controls.Add(this.Open_Project);
        	this.Controls.Add(this.Exit);
        	this.Controls.Add(this.Refresh_All);
        	this.Controls.Add(this.Apply_MathCad);
        	this.Controls.Add(this.Apply_Kompas);
        	this.Controls.Add(this.AddMathCad);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.AddKompas);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.MathCadPath);
        	this.Controls.Add(this.KompasPath);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.TableMathCad);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.TableKompas3D);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MinimumSize = new System.Drawing.Size(595, 615);
        	this.Name = "MainForm";
        	this.Text = "Kompas-MathCAD Integrator";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        	((System.ComponentModel.ISupportInitialize)(this.TableKompas3D)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.TableMathCad)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView TableMathCad;
        private System.Windows.Forms.DataGridView TableKompas3D;
        private System.Windows.Forms.StatusStrip statusStrip1;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KompasPath;
        private System.Windows.Forms.TextBox MathCadPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddKompas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddMathCad;
        private System.Windows.Forms.Button Apply_Kompas;
        private System.Windows.Forms.Button Apply_MathCad;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadType;
        private System.Windows.Forms.DataGridViewComboBoxColumn KompasName_ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_region_xml;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasNote;
        private System.Windows.Forms.DataGridViewComboBoxColumn MathCadName_ComboBox;
        private System.Windows.Forms.Button Refresh_All;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Open_Project;
        private System.Windows.Forms.Button Save_Project;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ProjectPath;
        
  
    }
}

