using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AiToolGui
{
    public partial class CreateSpecification : Form
    {
        public delegate void ProjectSave(ProjectChangedEvent arg);
        public event ProjectSave eProjectSave;
        private ConnectDataBase cdb;
        private bool newscop = true , save = false;
        private int id = -1;
        private int nodeid = 0;
        //private int parentnodeid = 0;
        public CreateSpecification()
        {
            newscop = true;
            InitializeComponent();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
        }
        public CreateSpecification(int _id)
        {
            newscop = false;
            save = true;
            id = _id;
            InitializeComponent();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            command.CommandText = "SELECT ProjectName, ProjectNumber  FROM Projects WHERE ProjectID = @ProjectID";
            command.Parameters.Add("@ProjectID", OleDbType.Integer).Value = _id;
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            textBoxName.Text = reader["ProjectName"].ToString();
            textBoxNum.Text = reader["ProjectNumber"].ToString();
            reader.Close();
            command.Dispose();
        }
        protected virtual void OnProjectSave(int id, string num, string name)
        {
            ProjectChangedEvent arg = new ProjectChangedEvent();
            arg.ProjectID = id;
            arg.ProjectNum = num;
            arg.ProjectName = name;
            if (eProjectSave != null)
                eProjectSave(arg);
        }
 
        private void ExportDocXml_Click(object sender, EventArgs e)
        {
            //экспортировать в XML, в будущем реализуем возможность сохранить в DOC, DOCX, ODT
            if (textBoxNum.Text.Length < 1) 
            {
                MessageBox.Show("Слишком короткое Обозначение" );
                return;
            }
            if (textBoxName.Text.Length < 1)
            {
                MessageBox.Show("Слишком короткое Наименование");
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Файлы XML (*.xml)|*.xml";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // начинаем сохранять
            XmlTextWriter writer = null;
            try
            {
                // создаем класс для сохранения XML
                writer = new XmlTextWriter(dlg.FileName, System.Text.Encoding.UTF8);
            }
             catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!");
            }
                // форматирование, чтобы файл не был вытянут в одну линию
                writer.Formatting = Formatting.Indented;

                // пишем заголовок и корневой элемент
                writer.WriteStartDocument();
                writer.WriteComment("Export File AiTool.NET");
                writer.WriteStartElement("Specification");
                //аттрибуты элемента
                writer.WriteAttributeString("Number", textBoxNum.Text);
                writer.WriteAttributeString("ProjectName", textBoxName.Text);
                //вложенный элемент
                writer.WriteStartElement("Target");
                writer.WriteString(richTextBoxTarget.Text);
                writer.WriteEndElement();
                // вложенный элемент
                writer.WriteStartElement("Abstract");
                writer.WriteString(richTextAbs.Text);
                writer.WriteEndElement();
                writer.WriteStartElement("Parameters");
                // здесь читается дерево и пишутся параметры
                SaveXmlFile(writer, treeParam.Nodes);
                //treeParam.Nodes
                writer.WriteEndElement();
    
                // закрываем корневой элемент и завершаем работу с документом
                writer.WriteEndElement();
                writer.WriteEndDocument(); 
           if (writer != null) writer.Close();
        }
        private void SaveXmlFile(XmlTextWriter wrtr, TreeNodeCollection nodes)
        {
            NodeTechParam nodeparam = new NodeTechParam();
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes != null)
                {//Метод использует рекурсивный алглритм
                    wrtr.WriteStartElement("Node");
                    wrtr.WriteAttributeString("Text", node.Text);
                    nodeparam = node.Tag as NodeTechParam;
                    if (nodeparam != null)
                    {
                        wrtr.WriteAttributeString("VarName", nodeparam.VarName);
                        wrtr.WriteAttributeString("VarMax", nodeparam.VarMax);
                        wrtr.WriteString(nodeparam.Description);
                    }         
                    SaveXmlFile(wrtr, node.Nodes);
                    wrtr.WriteEndElement();
                }
            }          
        }
        private void ImportDocXml_Click(object sender, EventArgs e)
        {
            //функция загрузки файла XML 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xml";
            dlg.Filter = "Файлы XML (*.xml)|*.xml";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            XmlDocument doc = new XmlDocument();
            try
            {
            doc.Load(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XmlNode rootnode = doc.DocumentElement;
            if (rootnode.Name != "Specification")
                throw new ArgumentException("Incorrect file format");
            textBoxNum.Text = rootnode.Attributes["Number"].Value;
            textBoxName.Text = rootnode.Attributes["ProjectName"].Value;
            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodeList)
            { 
                switch(node.Name)
                {
                    case "Target":
                        richTextBoxTarget.Text = node.InnerText;
                        break;
                    case "Abstract":
                        richTextAbs.Text = node.InnerText;
                        break;
                    case "Parameters":
                        XmlNodeList nList = node.ChildNodes;
                        foreach (XmlNode pNode in nList)
                        {
                            if (pNode.Name == "Node")
                            {
                                TreeNode treenode = new TreeNode();
                                treenode.Text = pNode.Attributes["Text"].Value; ;
                                NodeTechParam nodparam = new NodeTechParam();
                                nodparam.Description = pNode.Attributes["Text"].InnerText;
                                nodparam.VarName = pNode.Attributes["VarName"].Value;
                                nodparam.VarMax = pNode.Attributes["VarMax"].Value;
                                treenode.Tag = nodparam;
                                treeParam.Nodes.Add(treenode);
                                OpenXmlFile(treenode, pNode.ChildNodes);
                            }
                        }
                     break;
                }
            }
        }
        /*
            TreeNode node = new TreeNode();
            node.Text = AddText;
            NodeTechParam nodparam = new NodeTechParam();
            nodparam.Description = textBoxtext.Text;
            nodparam.VarName = textVarName.Text;
            nodparam.VarMax = textVarMax.Text;
            node.Tag = nodparam;
            treeParam.Nodes.Add(node);
         * 
         * selnode.Nodes.Add(node);
        */
        private void OpenXmlFile(TreeNode treenode, XmlNodeList nodes)
        {
            NodeTechParam nodeparam = new NodeTechParam();
            foreach (XmlNode node in nodes)
            {
                if (node != null)
                {//Метод использует рекурсивный алглритм
                    if (node.Name == "Node")
                    {
                        TreeNode newnode = new TreeNode();
                        newnode.Text = node.Attributes["Text"].Value;
                        NodeTechParam nodparam = new NodeTechParam();
                        nodparam.Description = node.Attributes["Text"].InnerText;
                        nodparam.VarName = node.Attributes["VarName"].Value;
                        nodparam.VarMax = node.Attributes["VarMax"].Value;
                        newnode.Tag = nodparam;
                        treenode.Nodes.Add(newnode);
                        OpenXmlFile(newnode, node.ChildNodes);
                    }
                }
            }
        }
        
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
		/*
        private bool FindDouble(TreeNode node, string AddText)
        {
            
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (AddText == node.Nodes[i].Text)
                {
                    MessageBox.Show("Такой узел уже есть");
                    return true;
                }
            }
            return false;
        }
		*/

        private void AddNode_Click(object sender, EventArgs e)
        {
            // добавить характеристику в дерево child
            string AddText = AddNodeText.Text;
            if (AddText == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            TreeNode selnode;
            selnode = treeParam.SelectedNode;
            NodeTechParam selparam = new NodeTechParam();
            selparam = selnode.Tag as NodeTechParam;
             
            TreeNode node = new TreeNode();
            NodeTechParam nodparam = new NodeTechParam();
            nodeid++;
            nodparam.NodeID = nodeid;
            if (selparam != null)
                nodparam.ParentNodeID = selparam.NodeID;
            nodparam.Description = textBoxtext.Text;
            nodparam.VarName = textVarName.Text;
            nodparam.VarMax = textVarMax.Text;
            node.Text = AddText;
            node.Tag = nodparam;

            if (node == null || selnode == null)
                return;

            for (int i = 0; i < selnode.Nodes.Count; i++)
            {
                if (AddText == selnode.Nodes[i].Text)
                {
                    MessageBox.Show("Такой узел уже есть");
                    return;
                }
            }
            selnode.Nodes.Add(node);
            AddNodeText.Text = "";
            textBoxtext.Text = "";
            textVarName.Text = "";
            textVarMax.Text = "";
            
        }

        private void AddRoot_Click(object sender, EventArgs e)
        {
            // добавить root
            string AddText = AddNodeText.Text;
            if (AddText == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }

            //if (FindDouble(treeView1, AddNodeText.Text)) return;
            
            for (int i = 0; i < treeParam.Nodes.Count; i++)
            {
                if (AddText == treeParam.Nodes[i].Text)
                {
                    MessageBox.Show("Такой узел уже есть");
                    return;
                }
            }
            TreeNode node = new TreeNode();
            nodeid++;
            node.Text = AddText;
            NodeTechParam nodparam = new NodeTechParam();
            nodparam.NodeID = nodeid;
            nodparam.ParentNodeID = 0; // корневой элемент 
            nodparam.Description = textBoxtext.Text;
            nodparam.VarName = textVarName.Text;
            nodparam.VarMax = textVarMax.Text;
            node.Tag = nodparam;
            treeParam.Nodes.Add(node);
            
            AddNodeText.Text = "";
            textBoxtext.Text = "";
            textVarName.Text = "";
            textVarMax.Text = "";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            node = e.Node;
            NodeTechParam n = new NodeTechParam();
            n = node.Tag as NodeTechParam;
            if (node != null)
            {
                textBoxtext.Text = n.Description;
                textBoxtext.Text = n.Description;
                textVarName.Text = n.VarName;
                textVarMax.Text = n.VarMax;
            }
        }

        private void DelNode_Click(object sender, EventArgs e)
        {
            TreeNode node;
            node = treeParam.SelectedNode;
            if (node == null) return;
            if (node.Nodes.Count >= 1) return;
            node.Remove();

        }

        private void comboBoxType_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBoxType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBoxType_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int i = e.Index;
        }

        private void comboBoxType_DrawItem(object sender, DrawItemEventArgs e)
        {
            int i = e.Index;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private bool ProjectNumDup(string num)
        {
            int coun;
            OleDbCommand command = cdb.ConnLocal.CreateCommand();
            //SELECT COUNT (*) FROM
            command.CommandText = " SELECT COUNT (ProjectNumber) FROM Projects WHERE ProjectNumber = \'" + num + "\'";
            coun = (int)command.ExecuteScalar();
            if (coun > 0)
            {
                MessageBox.Show("Проект с точно таким же обозначением есть", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void SaveSpecification()
        {
            // сохранить название проекта и обозначение
            //byte[] B = {255, 255};
            int idpr = -1;
            string num = textBoxNum.Text, nam = textBoxName.Text;
            if (num.Length < 1)
            {
                MessageBox.Show("Слишком короткое Обозначение");
                return;
            }
            if (nam.Length < 1)
            {
                MessageBox.Show("Слишком короткое Наименование");
                return;
            }
            if (ProjectNumDup(num)) // проверка уникальности номера
                return;
            try
            {
                OleDbCommand command = cdb.ConnLocal.CreateCommand();
                if (newscop)
                {
                    command.CommandText = "INSERT INTO Projects (ProjectNumber, ProjectName, PTID, user_id, class) " +
                        "VALUES (@ProjectNumber, @ProjectName, 1, user_id, 1)";
                }
                else
                {
                    command.CommandText = "UPDATE Projects SET  ProjectNumber=@ProjectNumber, ProjectName=@ProjectName, user_id=@user_id " +
                     "WHERE ProjectID=@ProjectID";
                }
                command.Parameters.Add("@ProjectNumber", OleDbType.VarChar).Value = num;
                command.Parameters.Add("@ProjectName", OleDbType.VarChar).Value = nam;
                command.Parameters.Add("@user_id", OleDbType.Integer).Value = UserParam.UserId;
                if (!newscop)
                    command.Parameters.Add("@ProjectID", OleDbType.Integer).Value = id;
                command.ExecuteNonQuery();
                if (richTextBoxTarget.Text != String.Empty)
                {
                    command.CommandText = "UPDATE Projects SET ProjectTarget = \'" + richTextBoxTarget.Text +
                        "\' WHERE ProjectNumber = \'" + num + "\'";
                    command.ExecuteNonQuery();
                }
                if (richTextAbs.Text != String.Empty)
                {
                    command.CommandText = "UPDATE Projects SET  ProjectAbstract = \'" +
                        richTextAbs.Text + "\' WHERE ProjectNumber = \'" + num + "\'";
                    command.ExecuteNonQuery();
                }
                if (newscop)
                {
                    command.CommandText = "SELECT ProjectID FROM Projects WHERE ProjectNumber = @ProjectNumber";
                    command.Parameters.Add("@ProjectNumber", OleDbType.VarChar).Value = num;
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idpr = reader.GetInt32(0);
                    reader.Close();
                }
                else
                    idpr = id;
                command.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            save = true;
            MessageBox.Show("Данные сохранены", "Информация",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnProjectSave(idpr, num, nam); // отправляем сообщение о том что проекту присвоенно обозначение и наименование
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SaveSpecification();  
        }

        private void CreateSpecification_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!save)
            {
                DialogResult reply = MessageBox.Show("Сохранить?",
                               "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.Yes)
                    SaveSpecification();
            }
            cdb.CloseConnectDataBaseLocal();
        }
        //изменение текста
        private void textBoxNum_TextChanged(object sender, EventArgs e)
        {
            save = false;
        }
        // изменение текста
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            save = false;
        }
    
    }
}
