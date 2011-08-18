﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AiToolGui
{
    public partial class CreateSpecification : Form
    {
        public event EventHandler eProjectName;
        public event EventHandler eProjectNum;
        public CreateSpecification()
        {
            InitializeComponent();
        }

        protected virtual void OnProjectName(string s)
        {
            object Obj = s;
            if (eProjectName != null)
                eProjectName(Obj, EventArgs.Empty);
        }
        protected virtual void OnProjectNum(string s)
        {
            object Obj = s;
            if (eProjectNum != null)
                eProjectNum(Obj, EventArgs.Empty);
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
            dlg.FileName = "untitled";
            dlg.DefaultExt = "xml";
            dlg.Filter = "Файлы XML (*.xml)|*.xml";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // начинаем сохранять
            XmlTextWriter writer = null;
            try
            {
                // создаем класс для сохранения XML
                writer = new XmlTextWriter(dlg.FileName, System.Text.Encoding.UTF8);
                // форматирование, чтобы файл не был вытянут в одну линию
                writer.Formatting = Formatting.Indented;

                // пишем заголовок и корневой элемент
                writer.WriteStartDocument();
                writer.WriteStartElement("Specification");
                //аттрибуты элемента
                //writer.WriteAttributeString("birth", person.Birth.ToShortDateString());
                //writer.WriteAttributeString("death", person.Death.ToShortDateString());
                //вложенный элемент
                writer.WriteStartElement("description");
                writer.WriteString(textBoxNum.Text);
                writer.WriteEndElement();
                // вложенный элемент
                writer.WriteStartElement("name");
                writer.WriteString(textBoxName.Text);
                writer.WriteEndElement();
    
                // закрываем корневой элемент и завершаем работу с документом
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!");
            }
            finally
            {
                // закрываем файл
                if (writer != null) writer.Close();
            }

        }

        private void ImportDocXml_Click(object sender, EventArgs e)
        {
            //функция загрузки файла XML 
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
            TreeNode node;
            node = treeParam.SelectedNode;
            if (node == null) return;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (AddText == node.Nodes[i].Text)
                {
                    MessageBox.Show("Такой узел уже есть");
                    return;
                }
            }
    
            
            
            node.Nodes.Add(AddNodeText.Text);
            
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
             
                //treeView1.Nodes.Count
            treeParam.Nodes.Add(AddText);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
			//MessageBox.Show("Ололололо");
        }

        private void DelNode_Click(object sender, EventArgs e)
        {
            TreeNode node;
            node = treeParam.SelectedNode;
            if (node == null) return;
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

        private void Open_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            // сохранить название проекта и обозначение
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
            OnProjectName(nam); // отправляем сообщение о том что проекту присвоенно обозначение и наименование
            OnProjectNum(num);

        }

       

  
    
    }
}
