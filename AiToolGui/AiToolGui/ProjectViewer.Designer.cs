namespace AiToolGui
{
    partial class ProjectViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripScope = new System.Windows.Forms.ToolStripButton();
            this.toolStripBlock = new System.Windows.Forms.ToolStripButton();
            this.toolStripEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripeEdge = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeProject = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripScope,
            this.toolStripBlock,
            this.toolStripEllipse,
            this.toolStripeEdge});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(451, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripScope
            // 
            this.toolStripScope.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripScope.Image = ((System.Drawing.Image)(resources.GetObject("toolStripScope.Image")));
            this.toolStripScope.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripScope.Name = "toolStripScope";
            this.toolStripScope.Size = new System.Drawing.Size(23, 22);
            this.toolStripScope.Text = "toolStripScope";
            this.toolStripScope.Click += new System.EventHandler(this.toolStripScope_Click);
            // 
            // toolStripBlock
            // 
            this.toolStripBlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBlock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBlock.Image")));
            this.toolStripBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBlock.Name = "toolStripBlock";
            this.toolStripBlock.Size = new System.Drawing.Size(23, 22);
            this.toolStripBlock.Text = "toolStripBlock";
            this.toolStripBlock.Click += new System.EventHandler(this.toolStripBlock_Click);
            // 
            // toolStripEllipse
            // 
            this.toolStripEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEllipse.Image")));
            this.toolStripEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEllipse.Name = "toolStripEllipse";
            this.toolStripEllipse.Size = new System.Drawing.Size(23, 22);
            this.toolStripEllipse.Text = "toolStripEllipse";
            this.toolStripEllipse.Click += new System.EventHandler(this.toolStripEllipse_Click);
            // 
            // toolStripeEdge
            // 
            this.toolStripeEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripeEdge.Image = ((System.Drawing.Image)(resources.GetObject("toolStripeEdge.Image")));
            this.toolStripeEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripeEdge.Name = "toolStripeEdge";
            this.toolStripeEdge.Size = new System.Drawing.Size(23, 22);
            this.toolStripeEdge.Text = "toolStripEdge";
            this.toolStripeEdge.Click += new System.EventHandler(this.toolStripeEdge_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeProject);
            this.splitContainer1.Size = new System.Drawing.Size(451, 271);
            this.splitContainer1.SplitterDistance = 139;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeProject
            // 
            this.treeProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeProject.Location = new System.Drawing.Point(3, 3);
            this.treeProject.Name = "treeProject";
            this.treeProject.Size = new System.Drawing.Size(133, 265);
            this.treeProject.TabIndex = 0;
            // 
            // ProjectViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 296);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProjectViewer";
            this.Text = "Project Viewer";
            this.Activated += new System.EventHandler(this.ProjectViewer_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeProject;
        private System.Windows.Forms.ToolStripButton toolStripScope;
        private System.Windows.Forms.ToolStripButton toolStripBlock;
        private System.Windows.Forms.ToolStripButton toolStripEllipse;
        private System.Windows.Forms.ToolStripButton toolStripeEdge;
    }
}