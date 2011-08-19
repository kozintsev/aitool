using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AiToolGui
{
    public partial class ProjectManager : Form
    {
        private ConnectDataBase cdb;
        List<string> ProjectIDList;
        public ProjectManager()
        {
            InitializeComponent();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
            ProjectIDList = new List<string>();
        }

        private void LoadProjectList(bool curuser)
        {
            int i = 1;
            ProjectIDList.Clear();
            listViewProject.Items.Clear();
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            if (!curuser)
            {
                command.CommandText = "SELECT ProjectID, ProjectNumber,  ProjectName FROM Projects";
            }
            else
            {
                command.CommandText = "SELECT ProjectID, ProjectNumber,  ProjectName FROM Projects WHERE user_id = " + UserParam.UserId;
            }
            OleDbDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    ProjectIDList.Add(reader["ProjectNumber"].ToString().TrimEnd());
                    ListViewItem item = listViewProject.Items.Add(i.ToString());
                    item.SubItems.Add(reader["ProjectNumber"].ToString().TrimEnd());
                    item.SubItems.Add(reader["ProjectName"].ToString().TrimEnd());
                    i++;
                }
            } while (reader.NextResult());
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            
        }
        
        void Button4Click(object sender, EventArgs e)
        {
        	Close();
        }

        private void ProjectManager_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }

        
        private void listViewProjectItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listViewProject_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // создать новый проект
            //ProjectViewer pv = new ProjectViewer();
            //pv.MdiParent = this;
            //pv.Show();
        }

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            LoadProjectList(checkCurUser.Checked);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

        }

        private void ProjectManager_Shown(object sender, EventArgs e)
        {
            LoadProjectList(checkCurUser.Checked);
        }
    }
}
