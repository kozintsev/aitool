namespace SCDBConnect
{
    partial class FormViewTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewTable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolMy_SaveChanged = new System.Windows.Forms.ToolStripButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.toolMy = new System.Windows.Forms.ToolStrip();
            this.toolMy_StripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolMy.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolSaveChanged
            // 
            this.toolMy_SaveChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMy_SaveChanged.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveChanged.Image")));
            this.toolMy_SaveChanged.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMy_SaveChanged.Name = "toolSaveChanged";
            this.toolMy_SaveChanged.Size = new System.Drawing.Size(23, 22);
            this.toolMy_SaveChanged.Text = "save";
            this.toolMy_SaveChanged.ToolTipText = "Сохранить изменения";
            this.toolMy_SaveChanged.Click += new System.EventHandler(this.toolSaveChanged_Click);
            // 
            // dataGridViewTable
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Name = "dataGridViewTable";
            this.dataGridView.Size = new System.Drawing.Size(472, 308);
            this.dataGridView.TabIndex = 1;
            // 
            // TT
            // 
            this.TT.IsBalloon = true;
            this.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolBarMy
            // 
            this.toolMy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMy_SaveChanged,
            this.toolMy_StripSeparator1});
            this.toolMy.Location = new System.Drawing.Point(0, 0);
            this.toolMy.Name = "toolBarMy";
            this.toolMy.Size = new System.Drawing.Size(472, 25);
            this.toolMy.TabIndex = 0;
            this.toolMy.Text = "toolBarMy";
            // 
            // toolStripSeparator1
            // 
            this.toolMy_StripSeparator1.Name = "toolStripSeparator1";
            this.toolMy_StripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 333);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolMy);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Table";
            this.Text = "Table";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Table_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolMy.ResumeLayout(false);
            this.toolMy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolMy_SaveChanged;
        private System.Windows.Forms.ToolTip TT;

        public System.Data.OleDb.OleDbDataAdapter dbAdapter;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.ListViewItem listViewItem;
        private System.Windows.Forms.ToolStrip toolMy;
        private System.Windows.Forms.ToolStripSeparator toolMy_StripSeparator1;
        

    }
}