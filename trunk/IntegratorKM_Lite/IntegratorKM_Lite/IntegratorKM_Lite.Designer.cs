namespace IntegratorKM_Lite
{
    partial class IntegratorKM_Lite
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
            this.AddMathCad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AddKompas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MathCadPath = new System.Windows.Forms.TextBox();
            this.KompasPath = new System.Windows.Forms.TextBox();
            this.Refresh_All = new System.Windows.Forms.Button();
            this.Apply_MathCad = new System.Windows.Forms.Button();
            this.Apply_Kompas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TableMathCad_IN = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TableKompas3D = new System.Windows.Forms.DataGridView();
            this.Exit = new System.Windows.Forms.Button();
            this.TableMathCad_OUT = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MathCadName_IN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MathCadValue_IN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MathCadName_OUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MathCadValue_OUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.KompasName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KompasValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KompasNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MathCadName_ComboBox_IN = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MathCadName_ComboBox_OUT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TableMathCad_IN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableKompas3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableMathCad_OUT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddMathCad
            // 
            this.AddMathCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddMathCad.Location = new System.Drawing.Point(373, 39);
            this.AddMathCad.Name = "AddMathCad";
            this.AddMathCad.Size = new System.Drawing.Size(75, 23);
            this.AddMathCad.TabIndex = 15;
            this.AddMathCad.Text = "Открыть";
            this.AddMathCad.UseVisualStyleBackColor = true;
            this.AddMathCad.Click += new System.EventHandler(this.AddMathCad_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Путь к файлу MathCAD:";
            // 
            // AddKompas
            // 
            this.AddKompas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddKompas.Location = new System.Drawing.Point(373, 41);
            this.AddKompas.Name = "AddKompas";
            this.AddKompas.Size = new System.Drawing.Size(75, 23);
            this.AddKompas.TabIndex = 13;
            this.AddKompas.Text = "Открыть";
            this.AddKompas.UseVisualStyleBackColor = true;
            this.AddKompas.Click += new System.EventHandler(this.AddKompas_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Путь к файлу Kompas-3D:";
            // 
            // MathCadPath
            // 
            this.MathCadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MathCadPath.Location = new System.Drawing.Point(14, 42);
            this.MathCadPath.Name = "MathCadPath";
            this.MathCadPath.Size = new System.Drawing.Size(353, 20);
            this.MathCadPath.TabIndex = 11;
            // 
            // KompasPath
            // 
            this.KompasPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.KompasPath.Location = new System.Drawing.Point(14, 43);
            this.KompasPath.Name = "KompasPath";
            this.KompasPath.Size = new System.Drawing.Size(353, 20);
            this.KompasPath.TabIndex = 10;
            // 
            // Refresh_All
            // 
            this.Refresh_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh_All.Location = new System.Drawing.Point(94, 613);
            this.Refresh_All.Name = "Refresh_All";
            this.Refresh_All.Size = new System.Drawing.Size(75, 23);
            this.Refresh_All.TabIndex = 22;
            this.Refresh_All.Text = "Обновить";
            this.Refresh_All.UseVisualStyleBackColor = true;
            this.Refresh_All.Click += new System.EventHandler(this.Refresh_All_Click);
            // 
            // Apply_MathCad
            // 
            this.Apply_MathCad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Apply_MathCad.Location = new System.Drawing.Point(373, 268);
            this.Apply_MathCad.Name = "Apply_MathCad";
            this.Apply_MathCad.Size = new System.Drawing.Size(75, 23);
            this.Apply_MathCad.TabIndex = 21;
            this.Apply_MathCad.Text = "Применить";
            this.Apply_MathCad.UseVisualStyleBackColor = true;
            this.Apply_MathCad.Click += new System.EventHandler(this.Apply_MathCad_Click);
            // 
            // Apply_Kompas
            // 
            this.Apply_Kompas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Apply_Kompas.Location = new System.Drawing.Point(371, 260);
            this.Apply_Kompas.Name = "Apply_Kompas";
            this.Apply_Kompas.Size = new System.Drawing.Size(75, 23);
            this.Apply_Kompas.TabIndex = 20;
            this.Apply_Kompas.Text = "Применить";
            this.Apply_Kompas.UseVisualStyleBackColor = true;
            this.Apply_Kompas.Click += new System.EventHandler(this.Apply_Kompas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Входные переменные MathCAD";
            // 
            // TableMathCad_IN
            // 
            this.TableMathCad_IN.AllowUserToAddRows = false;
            this.TableMathCad_IN.AllowUserToDeleteRows = false;
            this.TableMathCad_IN.AllowUserToResizeColumns = false;
            this.TableMathCad_IN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TableMathCad_IN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableMathCad_IN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MathCadName_IN,
            this.MathCadValue_IN});
            this.TableMathCad_IN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TableMathCad_IN.Location = new System.Drawing.Point(14, 94);
            this.TableMathCad_IN.MaximumSize = new System.Drawing.Size(192, 168);
            this.TableMathCad_IN.MinimumSize = new System.Drawing.Size(192, 168);
            this.TableMathCad_IN.Name = "TableMathCad_IN";
            this.TableMathCad_IN.RowHeadersVisible = false;
            this.TableMathCad_IN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TableMathCad_IN.Size = new System.Drawing.Size(192, 168);
            this.TableMathCad_IN.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Назначение переменных MathCAD переменным Kompas-3D";
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
            this.MathCadName_ComboBox_IN,
            this.MathCadName_ComboBox_OUT});
            this.TableKompas3D.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TableKompas3D.Location = new System.Drawing.Point(14, 86);
            this.TableKompas3D.MaximumSize = new System.Drawing.Size(434, 168);
            this.TableKompas3D.MinimumSize = new System.Drawing.Size(434, 168);
            this.TableKompas3D.Name = "TableKompas3D";
            this.TableKompas3D.RowHeadersVisible = false;
            this.TableKompas3D.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TableKompas3D.Size = new System.Drawing.Size(434, 168);
            this.TableKompas3D.TabIndex = 16;
            this.TableKompas3D.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EndEdit_TableKompas3D);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit.Location = new System.Drawing.Point(12, 613);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 23;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // TableMathCad_OUT
            // 
            this.TableMathCad_OUT.AllowUserToAddRows = false;
            this.TableMathCad_OUT.AllowUserToDeleteRows = false;
            this.TableMathCad_OUT.AllowUserToResizeColumns = false;
            this.TableMathCad_OUT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TableMathCad_OUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableMathCad_OUT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MathCadName_OUT,
            this.MathCadValue_OUT});
            this.TableMathCad_OUT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TableMathCad_OUT.Location = new System.Drawing.Point(256, 94);
            this.TableMathCad_OUT.MaximumSize = new System.Drawing.Size(192, 168);
            this.TableMathCad_OUT.MinimumSize = new System.Drawing.Size(192, 168);
            this.TableMathCad_OUT.Name = "TableMathCad_OUT";
            this.TableMathCad_OUT.RowHeadersVisible = false;
            this.TableMathCad_OUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TableMathCad_OUT.Size = new System.Drawing.Size(192, 168);
            this.TableMathCad_OUT.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(253, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Выходные переменные MathCAD";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Apply_MathCad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TableMathCad_OUT);
            this.groupBox1.Controls.Add(this.TableMathCad_IN);
            this.groupBox1.Controls.Add(this.AddMathCad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.MathCadPath);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.MaximumSize = new System.Drawing.Size(465, 300);
            this.groupBox1.MinimumSize = new System.Drawing.Size(465, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 300);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MathCad";
            // 
            // MathCadName_IN
            // 
            this.MathCadName_IN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadName_IN.HeaderText = "Имя IN";
            this.MathCadName_IN.Name = "MathCadName_IN";
            this.MathCadName_IN.ReadOnly = true;
            this.MathCadName_IN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MathCadName_IN.Width = 70;
            // 
            // MathCadValue_IN
            // 
            this.MathCadValue_IN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadValue_IN.HeaderText = "Значение IN";
            this.MathCadValue_IN.Name = "MathCadValue_IN";
            this.MathCadValue_IN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MathCadValue_IN.Width = 115;
            // 
            // MathCadName_OUT
            // 
            this.MathCadName_OUT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadName_OUT.HeaderText = "Имя OUT";
            this.MathCadName_OUT.Name = "MathCadName_OUT";
            this.MathCadName_OUT.ReadOnly = true;
            this.MathCadName_OUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MathCadName_OUT.Width = 70;
            // 
            // MathCadValue_OUT
            // 
            this.MathCadValue_OUT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadValue_OUT.HeaderText = "Значение OUT";
            this.MathCadValue_OUT.Name = "MathCadValue_OUT";
            this.MathCadValue_OUT.ReadOnly = true;
            this.MathCadValue_OUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MathCadValue_OUT.Width = 115;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Apply_Kompas);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TableKompas3D);
            this.groupBox2.Controls.Add(this.KompasPath);
            this.groupBox2.Controls.Add(this.AddKompas);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 318);
            this.groupBox2.MaximumSize = new System.Drawing.Size(465, 292);
            this.groupBox2.MinimumSize = new System.Drawing.Size(465, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 292);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kompas-3D";
            // 
            // KompasName
            // 
            this.KompasName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.KompasName.HeaderText = "Имя";
            this.KompasName.Name = "KompasName";
            this.KompasName.ReadOnly = true;
            this.KompasName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KompasName.Width = 60;
            // 
            // KompasValue
            // 
            this.KompasValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.KompasValue.HeaderText = "Значение";
            this.KompasValue.Name = "KompasValue";
            this.KompasValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KompasNote
            // 
            this.KompasNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.KompasNote.HeaderText = "Комментарий";
            this.KompasNote.Name = "KompasNote";
            this.KompasNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KompasNote.Width = 135;
            // 
            // MathCadName_ComboBox_IN
            // 
            this.MathCadName_ComboBox_IN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadName_ComboBox_IN.HeaderText = "ПМ IN";
            this.MathCadName_ComboBox_IN.Name = "MathCadName_ComboBox_IN";
            this.MathCadName_ComboBox_IN.Width = 65;
            // 
            // MathCadName_ComboBox_OUT
            // 
            this.MathCadName_ComboBox_OUT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MathCadName_ComboBox_OUT.HeaderText = "ПМ OUT";
            this.MathCadName_ComboBox_OUT.Name = "MathCadName_ComboBox_OUT";
            this.MathCadName_ComboBox_OUT.Width = 65;
            // 
            // IntegratorKM_Lite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 648);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Refresh_All);
            this.MaximumSize = new System.Drawing.Size(500, 675);
            this.MinimumSize = new System.Drawing.Size(500, 675);
            this.Name = "IntegratorKM_Lite";
            this.Text = "IntegratorKM_Lite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TableMathCad_IN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableKompas3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableMathCad_OUT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddMathCad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddKompas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MathCadPath;
        private System.Windows.Forms.TextBox KompasPath;
        private System.Windows.Forms.Button Refresh_All;
        private System.Windows.Forms.Button Apply_MathCad;
        private System.Windows.Forms.Button Apply_Kompas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView TableMathCad_IN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TableKompas3D;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.DataGridView TableMathCad_OUT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadName_IN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadValue_IN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadName_OUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathCadValue_OUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn KompasNote;
        private System.Windows.Forms.DataGridViewComboBoxColumn MathCadName_ComboBox_IN;
        private System.Windows.Forms.DataGridViewComboBoxColumn MathCadName_ComboBox_OUT;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

