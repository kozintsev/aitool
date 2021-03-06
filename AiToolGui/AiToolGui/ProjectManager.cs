﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AiToolGui
{
    public partial class ProjectManager : Form
    {
        private ConnectDataBase cdb;
        List<int> ProjectIDList;
        private int selectItem = 0;
        private Form pForm;
        
        public delegate void ProjectChanged(ProjectChangedEvent arg);
        public delegate void NewProjectChanged();

        public event ProjectChanged MyProjectChanged;
        public event NewProjectChanged NewProjectEvent;

        public ProjectManager(Form mainForm)
        {
            InitializeComponent();
            pForm = mainForm;
            ProjectIDList = new List<int>();
        }
        protected virtual void OnNewProject()
        {
            if (NewProjectEvent != null)
                NewProjectEvent();
        }
        protected virtual void OnProjectChanged(int id, string num, string name)
        {
            ProjectChangedEvent arg = new ProjectChangedEvent();
            arg.ProjectID = id;
            arg.ProjectNum = num;
            arg.ProjectName = name;
            if (MyProjectChanged != null)
                MyProjectChanged(arg);
        }

        private void LoadProjectList(bool curuser)
        {
            int i = 1;
            ProjectIDList.Clear();
            listViewProject.Items.Clear();
            /*
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            if (!curuser)
            {
                command.CommandText = @"SELECT ProjectID, ProjectNumber,  ProjectName FROM Projects";
            }
            else
            {
                command.CommandText = @"SELECT ProjectID, ProjectNumber,  ProjectName FROM Projects WHERE user_id = @userid";
                command.Parameters.Add("@userid", OleDbType.Decimal).Value = UserParam.UserId;
            }
            OleDbDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    ProjectIDList.Add(reader.GetInt32(0));
                    ListViewItem item = listViewProject.Items.Add(i.ToString());
                    item.SubItems.Add(reader["ProjectNumber"].ToString().TrimEnd());
                    item.SubItems.Add(reader["ProjectName"].ToString().TrimEnd());
                    i++;
                }
            } while (reader.NextResult());
            */
        }
        

        private void ProjectManager_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }

        
        private void listViewProjectItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectItem = Convert.ToInt32(e.Item.Text);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // создать новый проект
            OnNewProject();
            this.Close();
        }

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            LoadProjectList(checkCurUser.Checked);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (selectItem > 0)
            {
                //MessageBox.Show(selectItem.ToString());
                OpenProject(selectItem);
            }
        }

        private void ProjectManager_Shown(object sender, EventArgs e)
        {
            LoadProjectList(checkCurUser.Checked);
        }

        private void listViewProject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectItem > 0)
            {
                //MessageBox.Show(selectItem.ToString());
                OpenProject(selectItem);
            }
        }

        private void OpenProject(int id)
        {
            //ProjectViewer(string ProjectID, string ProjectNum, string ProjectName)
            int j = ProjectIDList[id - 1];
            ListViewItem item = listViewProject.Items[id-1];
            OnProjectChanged(j, item.SubItems[1].Text, item.SubItems[2].Text);
            this.Close();
        }

        private void buttonCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
