namespace CC_Cdiez
{
    partial class ExVarCompass3D
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
            this.StartCompass = new System.Windows.Forms.Button();
            this.CompassPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.Compass_EV_Read = new System.Windows.Forms.Button();
            this.Compass_EV_Write = new System.Windows.Forms.Button();
            this.TableCompassEV = new System.Windows.Forms.DataGridView();
            this.Name_EV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value_EV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RebuildCompass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableCompassEV)).BeginInit();
            this.SuspendLayout();
            // 
            // StartCompass
            // 
            this.StartCompass.Location = new System.Drawing.Point(12, 12);
            this.StartCompass.Name = "StartCompass";
            this.StartCompass.Size = new System.Drawing.Size(102, 23);
            this.StartCompass.TabIndex = 0;
            this.StartCompass.Text = "Открыть файл";
            this.StartCompass.UseVisualStyleBackColor = true;
            this.StartCompass.Click += new System.EventHandler(this.StartCompass_Click);
            // 
            // CompassPath
            // 
            this.CompassPath.Location = new System.Drawing.Point(12, 60);
            this.CompassPath.Name = "CompassPath";
            this.CompassPath.Size = new System.Drawing.Size(216, 20);
            this.CompassPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Путь к файлу Компаса:";
            // 
            // Exit
            // 
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.Location = new System.Drawing.Point(142, 372);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(87, 26);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Compass_EV_Read
            // 
            this.Compass_EV_Read.Location = new System.Drawing.Point(142, 86);
            this.Compass_EV_Read.Name = "Compass_EV_Read";
            this.Compass_EV_Read.Size = new System.Drawing.Size(87, 64);
            this.Compass_EV_Read.TabIndex = 15;
            this.Compass_EV_Read.Text = "Считать внешние переменные Компас";
            this.Compass_EV_Read.UseVisualStyleBackColor = true;
            this.Compass_EV_Read.Click += new System.EventHandler(this.Compass_EV_Read_Click);
            // 
            // Compass_EV_Write
            // 
            this.Compass_EV_Write.Location = new System.Drawing.Point(142, 156);
            this.Compass_EV_Write.Name = "Compass_EV_Write";
            this.Compass_EV_Write.Size = new System.Drawing.Size(87, 63);
            this.Compass_EV_Write.TabIndex = 16;
            this.Compass_EV_Write.Text = "Записать внешние переменные Компас";
            this.Compass_EV_Write.UseVisualStyleBackColor = true;
            this.Compass_EV_Write.Click += new System.EventHandler(this.Compass_EV_Write_Click);
            // 
            // TableCompassEV
            // 
            this.TableCompassEV.AllowUserToAddRows = false;
            this.TableCompassEV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableCompassEV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_EV,
            this.Value_EV});
            this.TableCompassEV.Location = new System.Drawing.Point(13, 86);
            this.TableCompassEV.Name = "TableCompassEV";
            this.TableCompassEV.RowHeadersVisible = false;
            this.TableCompassEV.RowHeadersWidth = 10;
            this.TableCompassEV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TableCompassEV.Size = new System.Drawing.Size(123, 312);
            this.TableCompassEV.TabIndex = 17;
            // 
            // Name_EV
            // 
            this.Name_EV.HeaderText = "Name";
            this.Name_EV.Name = "Name_EV";
            this.Name_EV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Name_EV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Name_EV.Width = 60;
            // 
            // Value_EV
            // 
            this.Value_EV.HeaderText = "Value";
            this.Value_EV.Name = "Value_EV";
            this.Value_EV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value_EV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value_EV.Width = 60;
            // 
            // RebuildCompass
            // 
            this.RebuildCompass.Location = new System.Drawing.Point(142, 225);
            this.RebuildCompass.Name = "RebuildCompass";
            this.RebuildCompass.Size = new System.Drawing.Size(87, 32);
            this.RebuildCompass.TabIndex = 18;
            this.RebuildCompass.Text = "Перестроить";
            this.RebuildCompass.UseVisualStyleBackColor = true;
            this.RebuildCompass.Click += new System.EventHandler(this.RebuildCompass_Click);
            // 
            // ExVarCompass3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit;
            this.ClientSize = new System.Drawing.Size(240, 416);
            this.Controls.Add(this.RebuildCompass);
            this.Controls.Add(this.TableCompassEV);
            this.Controls.Add(this.Compass_EV_Write);
            this.Controls.Add(this.Compass_EV_Read);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompassPath);
            this.Controls.Add(this.StartCompass);
            this.Name = "ExVarCompass3D";
            this.Text = "ExVarCompass3D";
            ((System.ComponentModel.ISupportInitialize)(this.TableCompassEV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartCompass;
        private System.Windows.Forms.TextBox CompassPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Compass_EV_Read;
        private System.Windows.Forms.Button Compass_EV_Write;
        private System.Windows.Forms.DataGridView TableCompassEV;
        private System.Windows.Forms.Button RebuildCompass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_EV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value_EV;
    }
}

