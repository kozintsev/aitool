using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AiToolGui
{
    public partial class ClassfierForm : Form
    {
        private Settings sett;
        private ConnectDataBase cdb;
        public ClassfierForm()
        {
            InitializeComponent();
            sett = new Settings();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tAddTree_Click(object sender, EventArgs e)
        {
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
            TreeNode node = new TreeNode();
            node.Text = AddText;
            treeClassfier.Nodes.Add(node);
            textNode.Text = "";
        }

        private void tAddNode_Click(object sender, EventArgs e)
        {
            // добавить характеристику в дерево child
            string AddText = textNode.Text;
            if (AddText == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            TreeNode selnode;
            selnode = treeClassfier.SelectedNode;
            TreeNode node = new TreeNode();
            node.Text = AddText;
            selnode.Nodes.Add(node);
            textNode.Text = "";
        }

        private void tDelNode_Click(object sender, EventArgs e)
        {
            TreeNode node;
            node = treeClassfier.SelectedNode;
            if (node == null) return;
            node.Remove();
        }

        private void SelectNode(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            node = e.Node;
            textNode.Text = node.Text;
        }
    }
}
