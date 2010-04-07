namespace ActiveX_Kompas
{
    partial class Form1
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        	this.axKGAX1 = new AxKGAXLib.AxKGAX();
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.okToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	((System.ComponentModel.ISupportInitialize)(this.axKGAX1)).BeginInit();
        	this.menuStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// axKGAX1
        	// 
        	this.axKGAX1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.axKGAX1.Enabled = true;
        	this.axKGAX1.Location = new System.Drawing.Point(0, 24);
        	this.axKGAX1.Name = "axKGAX1";
        	this.axKGAX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKGAX1.OcxState")));
        	this.axKGAX1.Size = new System.Drawing.Size(452, 500);
        	this.axKGAX1.TabIndex = 13;
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.runToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(452, 24);
        	this.menuStrip1.TabIndex = 16;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// runToolStripMenuItem
        	// 
        	this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.runToolStripMenuItem1,
        	        	        	this.stopToolStripMenuItem,
        	        	        	this.okToolStripMenuItem,
        	        	        	this.closeToolStripMenuItem});
        	this.runToolStripMenuItem.Name = "runToolStripMenuItem";
        	this.runToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
        	this.runToolStripMenuItem.Text = "Operations";
        	// 
        	// runToolStripMenuItem1
        	// 
        	this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
        	this.runToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        	this.runToolStripMenuItem1.Text = "Run";
        	this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
        	// 
        	// stopToolStripMenuItem
        	// 
        	this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
        	this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.stopToolStripMenuItem.Text = "Stop";
        	this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
        	// 
        	// okToolStripMenuItem
        	// 
        	this.okToolStripMenuItem.Name = "okToolStripMenuItem";
        	this.okToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.okToolStripMenuItem.Text = "Ok";
        	this.okToolStripMenuItem.Click += new System.EventHandler(this.okToolStripMenuItem_Click);
        	// 
        	// closeToolStripMenuItem
        	// 
        	this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        	this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.closeToolStripMenuItem.Text = "Close";
        	this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(452, 524);
        	this.Controls.Add(this.axKGAX1);
        	this.Controls.Add(this.menuStrip1);
        	this.MainMenuStrip = this.menuStrip1;
        	this.Name = "Form1";
        	this.Text = "Form1";
        	((System.ComponentModel.ISupportInitialize)(this.axKGAX1)).EndInit();
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;

        #endregion

        private AxKGAXLib.AxKGAX axKGAX1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem okToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
    }
}

