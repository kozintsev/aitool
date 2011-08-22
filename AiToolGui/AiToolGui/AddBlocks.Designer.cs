﻿namespace AiToolGui
{
    partial class AddBlocks
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BlockName = new System.Windows.Forms.TextBox();
            this.Comment = new System.Windows.Forms.TextBox();
            this.LableName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.Location = new System.Drawing.Point(205, 155);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.Ok_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(286, 155);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // BlockName
            // 
            this.BlockName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BlockName.Location = new System.Drawing.Point(79, 12);
            this.BlockName.Name = "BlockName";
            this.BlockName.Size = new System.Drawing.Size(276, 20);
            this.BlockName.TabIndex = 2;
            // 
            // Comment
            // 
            this.Comment.Location = new System.Drawing.Point(79, 38);
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(279, 104);
            this.Comment.TabIndex = 3;
            // 
            // LableName
            // 
            this.LableName.AutoSize = true;
            this.LableName.Location = new System.Drawing.Point(13, 19);
            this.LableName.Name = "LableName";
            this.LableName.Size = new System.Drawing.Size(38, 13);
            this.LableName.TabIndex = 4;
            this.LableName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comment:";
            // 
            // AddBlocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 190);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LableName);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.BlockName);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnOk);
            this.Name = "AddBlocks";
            this.Text = "AddBlocks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox BlockName;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Label LableName;
        private System.Windows.Forms.Label label1;
    }
}