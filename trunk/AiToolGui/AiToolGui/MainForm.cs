﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;// пространство имён для подключение к БД 

namespace AiToolGui
{
    public partial class AITool : Form
    {
        //private int childFormNumber = 0;

        Form childForm;
        Form AboutBox;
        Form ProjectManager;
        Form DocumentManager;
        NewProject np;

        public AITool()
        {
            InitializeComponent();           
        }

        private void myForm_Status(object sender, EventArgs e)
        {
            //Console.WriteLine("Event handled");
            //MessageBox.Show(sender.ToString() + "Событие!");
            //toolStripStatusLabel
            toolStripStatusLabel.Text = sender.ToString();
            //statusStrip.
        }


        public void ConnectDataBase()
        {
            string path = Application.StartupPath;
            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + "\\Base\\aitool.mdb"; 
			try{
			 OleDbConnection conn = new OleDbConnection();
             conn.ConnectionString = ConnectionString;
			}
			catch{
            	   	MessageBox.Show("Ошибка подключения к База данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            bool FormFound = false;
            FormCollection fс = Application.OpenForms;
            foreach (Form frm in fс)
            {
                if (frm.Name == "NewProject")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                np = new NewProject();
                np.Status += myForm_Status;
                np.MdiParent = this;
                np.Name = "NewProject";
                np.Text = "Create New Project";
                np.Show();
            }

            ConnectDataBase();
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox();
            AboutBox.Show();
        }

        private void documentManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentManager = new DocumentManager();
            //DocumentManager.Show();
            childForm = new Form();
            childForm = DocumentManager;
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	ProjectManager = new ProjectManager();
            childForm = new Form();
            childForm = ProjectManager;
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void AITool_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool FormFound = false;
            FormCollection fс = Application.OpenForms;
            foreach (Form frm in fс)
            {
                if (frm.Name == "Options")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                Options optwnd = new Options();
                optwnd.MdiParent = this;
                optwnd.Show();
            }
          
        }

        private void AITool_Load(object sender, EventArgs e)
        {

        }
    }
}
