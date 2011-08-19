using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

using UMD.HCIL.GraphEditor;

namespace AiToolGui
{
    public partial class ProjectViewer : Form
    {
        GraphEditor graphEditor;
        CreateSpecification specification;
        private string projectName = String.Empty;
        private string projectNum = String.Empty;
        private string projectID = String.Empty;
        public event EventHandler eStatus;

        private ConnectDataBase cdb;

        public ProjectViewer()
        {
            InitProjectViewer();
        }

        public ProjectViewer(string ProjectID, string ProjectNum, string ProjectName) 
        {
            projectID = ProjectID;
            projectNum = ProjectNum;
            projectName = ProjectName;
            InitProjectViewer();
        }

        private void InitProjectViewer()
        {
            InitializeComponent();
            graphEditor = new GraphEditor(this.ClientSize.Width, this.ClientSize.Height);
            this.splitContainer1.Panel2.Controls.Add(graphEditor);
            //Controls.Add(graphEditor);
            graphEditor.Bounds = this.ClientRectangle;
            graphEditor.Anchor = graphEditor.Anchor | AnchorStyles.Right | AnchorStyles.Bottom;
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
        }
        protected virtual void OnStatus(string s)
        {
            object Obj = s;
            if (eStatus != null)
                eStatus(Obj, EventArgs.Empty);
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
            //OnStatus(projectNum + " - " + projectName);
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
            if (projectName == "" || projectNum == "")
            {
                MessageBox.Show("Для сохранения проекта нужно создать задание", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //projectID
        }

        private void ProjectViewer_Activated(object sender, EventArgs e)
        {
            OnStatus(projectNum + " - " + projectName);
        }

        private void ProjectViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            cdb.CloseConnectDataBaseLocal();
        }
     
    }
}
