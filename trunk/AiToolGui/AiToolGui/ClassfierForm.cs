using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;// пространство имён для подключение к БД 

namespace AiToolGui
{
    public partial class ClassfierForm : Form
    {
        private Settings sett;
        private ConnectDataBase cdb;
        DataSet dataset = new DataSet();

        void AddTreeNode(DataRow row, TreeNode node)
        {
            ClassfierTree clNode = new ClassfierTree();
            clNode.Id = row.ItemArray[0];
            clNode.ParentId = row.ItemArray[3];
            clNode.NodeName = row.ItemArray[1].ToString();
            TreeNode curnode = new TreeNode();
            curnode.Text = clNode.NodeName;
            curnode.Tag = clNode;
            //TreeNode curnode;
            string ifnull = row[3].ToString();
            if (ifnull == "0")
                treeClassfier.Nodes.Add(curnode);
            else
                node.Nodes.Add(curnode);
            foreach (DataRow currow in row.GetChildRows("Classifier"))
            {
                AddTreeNode(currow, curnode);
            }
        }

        public ClassfierForm()
        {
            InitializeComponent();
            sett = new Settings();
            /*
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase("localhost", "sdpm", "root", "9L37VKNV4X"); ;
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            command.CommandText = @"SELECT * FROM Classifier";
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataset);
            DataRelation relation = new DataRelation("Classifier", 
                dataset.Tables[0].Columns[0], dataset.Tables[0].Columns[3]);

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                if (row[3].ToString() == "0")
                    AddTreeNode(row , null);
            }
            */
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tAddTree_Click(object sender, EventArgs e)
        {
            /*
            string AddText = textNode.Text;
            if (AddText == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }

            for (int i = 0; i < treeClassfier.Nodes.Count; i++)
            {
                if (AddText == treeClassfier.Nodes[i].Text)
                {
                    MessageBox.Show("Такой узел уже есть");
                    return;
                }
            }
            ClassfierTree clNode = new ClassfierTree();
            TreeNode node = new TreeNode();
            node.Text = AddText;

            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            //command.Transaction = cdb.ConnLocal.BeginTransaction();
            command.CommandText = @"INSERT INTO Classifier (classname, ParentID) VALUES (@classname, @ParentID)";
            command.Parameters.Add("@classname", OleDbType.VarChar).Value = AddText;
            command.Parameters.Add("@ParentID", OleDbType.Integer).Value = 0;
            //OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //adapter.InsertCommand = command;

            //adapter.Update(dataset.Tables[0]);
            
            int n = command.ExecuteNonQuery();
            command.CommandText = @"SELECT @@IDENTITY as id_class"; // получить id записи
            int g = (int)command.ExecuteScalar();
            //command.Transaction.Commit();
            //command.Transaction.Rollback();
            clNode.Id = g;
            clNode.ParentId = 0;
            clNode.NodeName = AddText;
            node.Tag = clNode;
            treeClassfier.Nodes.Add(node);
            node.Expand(); // развернуть дерево
            textNode.Clear();
            */
        }

        private void tAddNode_Click(object sender, EventArgs e)
        {
            // добавить характеристику в дерево child
            /*
            string AddText = textNode.Text;
            if (AddText == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            TreeNode selnode;
            ClassfierTree clSelNode = new ClassfierTree();
            ClassfierTree clNode = new ClassfierTree();
            selnode = treeClassfier.SelectedNode;
            clSelNode = selnode.Tag as ClassfierTree;

            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            command.CommandText = @"INSERT INTO Classifier (classname, ParentID) VALUES (@classname, @ParentID)";
            command.Parameters.Add("@classname", OleDbType.VarChar).Value = AddText;
            command.Parameters.Add("@ParentID", OleDbType.Integer).Value = clSelNode.Id;
            int n = command.ExecuteNonQuery();
            command.CommandText = @"SELECT @@IDENTITY as id_class"; // получить id записи
            int g = (int)command.ExecuteScalar();
            clNode.Id = g;
            clNode.ParentId = clSelNode.Id;
            clNode.NodeName = AddText;
            TreeNode node = new TreeNode();
            node.Text = AddText;
            node.Tag = clNode;
            selnode.Nodes.Add(node);
            node.Expand();
            textNode.Clear();
            */   
        }

        private void tDelNode_Click(object sender, EventArgs e)
        {
            TreeNode node;
            node = treeClassfier.SelectedNode;
            if (node == null) return;
            if (node.Nodes.Count >= 1) return;
            node.Remove();
        }

        private void SelectNode(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            node = e.Node;
            textNode.Text = node.Text;
        }
        class ClassfierTree
        {
            public object Id { get; set; }
            public object ParentId { get; set; }
            public string NodeName { get; set; }
        }
    }
}
