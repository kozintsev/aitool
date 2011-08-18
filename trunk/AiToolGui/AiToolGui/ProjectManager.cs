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

        public ProjectManager()
        {
            InitializeComponent();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            int i = 1;
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            command.CommandText = "SELECT ProjectNumber,  ProjectName FROM Project";
            OleDbDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    ListViewItem item = listViewProject.Items.Add(i.ToString());
                    item.SubItems.Add(reader["ProjectNumber"].ToString().TrimEnd());
                    item.SubItems.Add(reader["ProjectName"].ToString().TrimEnd());
                    i++;
                }
            } while (reader.NextResult());
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
    }
}
