﻿namespace AiToolGui
{
    partial class CreateSpecification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSpecification));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBoxtext = new System.Windows.Forms.TextBox();
            this.labelInp = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddNodeText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddNode = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Button();
            this.ExportDocXml = new System.Windows.Forms.Button();
            this.ImportDocXml = new System.Windows.Forms.Button();
            this.AddRoot = new System.Windows.Forms.Button();
            this.DelNode = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox3);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox5);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxtext);
            this.splitContainer1.Panel2.Controls.Add(this.labelInp);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxType);
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.HideSelection = false;
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // textBoxtext
            // 
            resources.ApplyResources(this.textBoxtext, "textBoxtext");
            this.textBoxtext.Name = "textBoxtext";
            // 
            // labelInp
            // 
            resources.ApplyResources(this.labelInp, "labelInp");
            this.labelInp.Name = "labelInp";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxType, "comboBoxType");
            this.comboBoxType.Items.AddRange(new object[] {
            resources.GetString("comboBoxType.Items"),
            resources.GetString("comboBoxType.Items1"),
            resources.GetString("comboBoxType.Items2"),
            resources.GetString("comboBoxType.Items3")});
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxType_DrawItem);
            this.comboBoxType.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboBoxType_MeasureItem);
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // AddNodeText
            // 
            resources.ApplyResources(this.AddNodeText, "AddNodeText");
            this.AddNodeText.Name = "AddNodeText";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // AddNode
            // 
            resources.ApplyResources(this.AddNode, "AddNode");
            this.AddNode.Name = "AddNode";
            this.AddNode.UseVisualStyleBackColor = true;
            this.AddNode.Click += new System.EventHandler(this.AddNode_Click);
            // 
            // CloseForm
            // 
            resources.ApplyResources(this.CloseForm, "CloseForm");
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // ExportDocXml
            // 
            resources.ApplyResources(this.ExportDocXml, "ExportDocXml");
            this.ExportDocXml.Name = "ExportDocXml";
            this.ExportDocXml.UseVisualStyleBackColor = true;
            this.ExportDocXml.Click += new System.EventHandler(this.ExportDocXml_Click);
            // 
            // ImportDocXml
            // 
            resources.ApplyResources(this.ImportDocXml, "ImportDocXml");
            this.ImportDocXml.Name = "ImportDocXml";
            this.ImportDocXml.UseVisualStyleBackColor = true;
            this.ImportDocXml.Click += new System.EventHandler(this.ImportDocXml_Click);
            // 
            // AddRoot
            // 
            resources.ApplyResources(this.AddRoot, "AddRoot");
            this.AddRoot.Name = "AddRoot";
            this.AddRoot.UseVisualStyleBackColor = true;
            this.AddRoot.Click += new System.EventHandler(this.AddRoot_Click);
            // 
            // DelNode
            // 
            this.DelNode.AllowDrop = true;
            resources.ApplyResources(this.DelNode, "DelNode");
            this.DelNode.Name = "DelNode";
            this.DelNode.UseVisualStyleBackColor = true;
            this.DelNode.Click += new System.EventHandler(this.DelNode_Click);
            // 
            // Save
            // 
            resources.ApplyResources(this.Save, "Save");
            this.Save.Name = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Open
            // 
            resources.ApplyResources(this.Open, "Open");
            this.Open.Name = "Open";
            this.Open.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox3);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            resources.ApplyResources(this.richTextBox3, "richTextBox3");
            this.richTextBox3.Name = "richTextBox3";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // CreateSpecification
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DelNode);
            this.Controls.Add(this.AddRoot);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ImportDocXml);
            this.Controls.Add(this.ExportDocXml);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.AddNode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddNodeText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "CreateSpecification";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelInp;
        private System.Windows.Forms.TextBox textBoxtext;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ListBox listBox1;

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddNodeText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddNode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.Button ExportDocXml;
        private System.Windows.Forms.Button ImportDocXml;
        private System.Windows.Forms.Button AddRoot;
        private System.Windows.Forms.Button DelNode;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}