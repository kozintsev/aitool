﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UMD.HCIL.GraphEditor;

namespace AiToolGui
{
    public partial class ProjectViewer : Form
    {
        GraphEditor graphEditor;
        CreateSpecification specification;
        private string projectName = String.Empty;
        private string projectNum = String.Empty;

        public ProjectViewer()
        {
            InitializeComponent();
            graphEditor = new GraphEditor(this.ClientSize.Width, this.ClientSize.Height);
            this.splitContainer1.Panel2.Controls.Add(graphEditor);
            //Controls.Add(graphEditor);
            graphEditor.Bounds = this.ClientRectangle;
            graphEditor.Anchor = graphEditor.Anchor | AnchorStyles.Right | AnchorStyles.Bottom;
        }

      

        private void toolStripScope_Click(object sender, EventArgs e)
        {
            specification = new CreateSpecification();
            specification.MdiParent = this.ParentForm;
            specification.eProjectName += new EventHandler(specification_eProjectName);
            specification.eProjectNum += new EventHandler(specification_eProjectNum);
            specification.Show();
        }

        void specification_eProjectNum(object sender, EventArgs e) // вызовится вторым
        {
            projectNum = sender.ToString();
            //throw new NotImplementedException();
        }

        void specification_eProjectName(object sender, EventArgs e)
        {
            projectName = sender.ToString();
            //throw new NotImplementedException();
        }


        private void toolStripBlock_Click(object sender, EventArgs e)
        {
            AddBlocks AddBlock = new AddBlocks();
            //AddBlocks.MdiParent = this.ParentForm;
            AddBlock.ShowDialog();
            string name = AddBlock.GetBlockName();       
            if (name == "") return;
            graphEditor.AddBlock(name);
            AddBlock.Close();
        }

        private void toolStripEllipse_Click(object sender, EventArgs e)
        {
            graphEditor.AddEllipse();
        }

        private void toolStripeEdge_Click(object sender, EventArgs e)
        {
            graphEditor.AddEdge();
        }
        // сохранение проекта
        public void SaveProject()
        {
            MessageBox.Show("Имя проекта: " + projectName);
        }
     
    }
}
