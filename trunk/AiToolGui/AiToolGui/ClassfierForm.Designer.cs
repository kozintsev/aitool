namespace AiToolGui
{
    partial class ClassfierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassfierForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textNode = new System.Windows.Forms.TextBox();
            this.toolTree = new System.Windows.Forms.ToolStrip();
            this.tAddTree = new System.Windows.Forms.ToolStripButton();
            this.tAddNode = new System.Windows.Forms.ToolStripButton();
            this.tDelNode = new System.Windows.Forms.ToolStripButton();
            this.treeClassfier = new System.Windows.Forms.TreeView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.toolRich = new System.Windows.Forms.ToolStrip();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.richBox = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textNode);
            this.splitContainer1.Panel1.Controls.Add(this.toolTree);
            this.splitContainer1.Panel1.Controls.Add(this.treeClassfier);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel2.Controls.Add(this.toolRich);
            this.splitContainer1.Panel2.Controls.Add(this.buttonExit);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOpen);
            this.splitContainer1.Panel2.Controls.Add(this.richBox);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Size = new System.Drawing.Size(581, 474);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // textNode
            // 
            this.textNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textNode.Location = new System.Drawing.Point(3, 28);
            this.textNode.Name = "textNode";
            this.textNode.Size = new System.Drawing.Size(196, 20);
            this.textNode.TabIndex = 2;
            // 
            // toolTree
            // 
            this.toolTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tAddTree,
            this.tAddNode,
            this.tDelNode});
            this.toolTree.Location = new System.Drawing.Point(0, 0);
            this.toolTree.Name = "toolTree";
            this.toolTree.Size = new System.Drawing.Size(203, 25);
            this.toolTree.TabIndex = 1;
            this.toolTree.Text = "toolStrip1";
            // 
            // tAddTree
            // 
            this.tAddTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tAddTree.Image = ((System.Drawing.Image)(resources.GetObject("tAddTree.Image")));
            this.tAddTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tAddTree.Name = "tAddTree";
            this.tAddTree.Size = new System.Drawing.Size(23, 22);
            this.tAddTree.Text = "Add Root";
            this.tAddTree.Click += new System.EventHandler(this.tAddTree_Click);
            // 
            // tAddNode
            // 
            this.tAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tAddNode.Image = ((System.Drawing.Image)(resources.GetObject("tAddNode.Image")));
            this.tAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tAddNode.Name = "tAddNode";
            this.tAddNode.Size = new System.Drawing.Size(23, 22);
            this.tAddNode.Text = "Add Node";
            this.tAddNode.Click += new System.EventHandler(this.tAddNode_Click);
            // 
            // tDelNode
            // 
            this.tDelNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tDelNode.Image = ((System.Drawing.Image)(resources.GetObject("tDelNode.Image")));
            this.tDelNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tDelNode.Name = "tDelNode";
            this.tDelNode.Size = new System.Drawing.Size(23, 22);
            this.tDelNode.Text = "Delete Node";
            this.tDelNode.Click += new System.EventHandler(this.tDelNode_Click);
            // 
            // treeClassfier
            // 
            this.treeClassfier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeClassfier.Location = new System.Drawing.Point(0, 54);
            this.treeClassfier.Name = "treeClassfier";
            this.treeClassfier.Size = new System.Drawing.Size(200, 420);
            this.treeClassfier.TabIndex = 0;
            this.treeClassfier.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectNode);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(113, 427);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // toolRich
            // 
            this.toolRich.Location = new System.Drawing.Point(3, 0);
            this.toolRich.Name = "toolRich";
            this.toolRich.Size = new System.Drawing.Size(373, 25);
            this.toolRich.TabIndex = 4;
            this.toolRich.Text = "toolStrip1";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(287, 427);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Close";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(200, 427);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            // 
            // richBox
            // 
            this.richBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richBox.Location = new System.Drawing.Point(3, 0);
            this.richBox.Name = "richBox";
            this.richBox.Size = new System.Drawing.Size(368, 396);
            this.richBox.TabIndex = 1;
            this.richBox.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 474);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // ClassfierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 474);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ClassfierForm";
            this.Text = "Classfier";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolTree.ResumeLayout(false);
            this.toolTree.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeClassfier;
        private System.Windows.Forms.RichTextBox richBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ToolStrip toolTree;
        private System.Windows.Forms.ToolStrip toolRich;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textNode;
        private System.Windows.Forms.ToolStripButton tAddTree;
        private System.Windows.Forms.ToolStripButton tAddNode;
        private System.Windows.Forms.ToolStripButton tDelNode;
    }
}