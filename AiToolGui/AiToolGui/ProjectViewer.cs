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
        private int projectID;
        public event EventHandler eStatus;
        public event EventHandler eStatusEvent;
        private ConnectDataBase cdb;

        public ProjectViewer()
        {
            InitProjectViewer();
        }

        public ProjectViewer(int ProjectID, string ProjectNum, string ProjectName) 
        {
            projectID = ProjectID;
            projectNum = ProjectNum;
            projectName = ProjectName;
            InitProjectViewer();
            this.Text = String.Format("Project Viewer : [{0}] - {1}", projectNum, projectName);
        }

        private void InitProjectViewer()
        {
            InitializeComponent();
            graphEditor = new GraphEditor(this.ClientSize.Width, this.ClientSize.Height);
            this.splitContainer1.Panel2.Controls.Add(graphEditor);
            //Controls.Add(graphEditor);
            graphEditor.Bounds = this.ClientRectangle;
            graphEditor.Anchor = graphEditor.Anchor | AnchorStyles.Right | AnchorStyles.Bottom;
            // нужно добавить спец события вставка блока и.т.д
            graphEditor.eXY += new EventHandler(graphEditor_eXY);
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
        }

        void graphEditor_eXY(object sender, EventArgs e)
        {
            string s = sender as string;
            if (s != null)
                OnStatusEvent(s);
            //throw new NotImplementedException();
        }
        protected virtual void OnStatus(string s)
        {
            object Obj = s;
            if (eStatus != null)
                eStatus(Obj, EventArgs.Empty);
        }
        protected virtual void OnStatusEvent(string s) // вызываем эту функцию  если хотим изменить 
        {                                              // статус 
            object Obj = s;
            if (eStatusEvent != null)
                eStatusEvent(Obj, EventArgs.Empty);
        }

        private void toolStripScope_Click(object sender, EventArgs e)
        {
            if (projectNum != String.Empty)
                specification = new CreateSpecification(projectID);
             else
                specification = new CreateSpecification();
            specification.MdiParent = this.ParentForm;
            specification.eProjectSave += new CreateSpecification.ProjectSave(specification_eProjectSave);
            specification.Show();
        }

        void specification_eProjectSave(ProjectChangedEvent arg)
        {
            projectID = arg.ProjectID;
            projectNum = arg.ProjectNum;
            projectName = arg.ProjectName;
            this.Text = String.Format("Project Viewer : [{0}] - {1}", projectNum, projectName);
            OnStatus(projectNum + " - " + projectName);
            //treeProject.Nodes.Add("Спецификация");
            //throw new NotImplementedException();
        }

        private void toolStripBlock_Click(object sender, EventArgs e) // добавляем блок
        {
            AddBlocks AddBlock = new AddBlocks();
            AddBlock.ShowDialog();
            string name = AddBlock.GetBlockName();
            string desc = AddBlock.GetBlockDesc();
            if (name == "") return;
            graphEditor.AddEntity(2, name, desc);
            //graphEditor.AddBlock(name, desc, 0, 0, 150, 100);
            AddBlock.Close();
        }

        private void toolStripEllipse_Click(object sender, EventArgs e)
        {
            graphEditor.AddEntity(1, "start", "");
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
            if ((projectNum == "") && (projectNum == ""))
                OnStatus(" Новый проект ");
            else
                OnStatus(projectNum + " - " + projectName);
        }

        private void ProjectViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            cdb.CloseConnectDataBaseLocal();
            OnStatus(" ");
        }
     
    }
}
