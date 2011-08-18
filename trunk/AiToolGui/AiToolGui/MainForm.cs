using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;// пространство имён для подключение к БД 
using System.Globalization; // для локализации
using System.Threading; // для локализации

namespace AiToolGui
{
    public partial class AITool : Form
    {
        //private int childFormNumber = 0;

        //private Form childForm;
        private Form AboutBox;
        private Form ProjectManager; // список проектов
        private ProjectViewer pv; // работа над проектом
        //private NewProject np;
        private Settings sett;
        private ConnectDataBase cdb;

        public AITool()
        {
            InitializeComponent();
            sett = new Settings();
            cdb = new ConnectDataBase();
            cdb.CreateConnectDataBase();
            
        }
            

        private void myForm_Status(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
            toolStripUser.Text = sender.ToString();
        }



        private void ShowNewForm(object sender, EventArgs e)
        {
            //Запрос имени проекта
            pv = new ProjectViewer();
            pv.MdiParent = this;
            pv.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox();
            AboutBox.Show();
        }

        private void documentManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool FormFound = false;
            FormCollection fс = Application.OpenForms;
            foreach (Form frm in fс)
            {
                if (frm.Name == "ProjectManager") //
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                ProjectManager = new ProjectManager();

                ProjectManager.MdiParent = this;
                ProjectManager.Name = "ProjectManager";
                ProjectManager.Show();
            }
        }

        private void AITool_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool FormFound = false;
            FormCollection fс = Application.OpenForms;
            foreach (Form frm in fс)
            {
                if (frm.Name == "Options")
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            if (FormFound == false)
            {
                Options optwnd = new Options();
                optwnd.MdiParent = this;
                optwnd.Show();
            }
          
        }

        private void AITool_Load(object sender, EventArgs e)
        {

        }
        
        void RussiaToolStripMenuItemClick(object sender, EventArgs e)
        {
        	englishToolStripMenuItem.Checked = false;
        	russiaToolStripMenuItem.Checked = true;
            defaultToolStripMenuItem.Checked = false;
         

        	
        }
        
        void EnglishToolStripMenuItemClick(object sender, EventArgs e)
        {
        	englishToolStripMenuItem.Checked = true;
        	russiaToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = false;
            
            
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = false;
            russiaToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = true;

        }

        private void AITool_Shown(object sender, EventArgs e) // событие возникает при первом отображении формы
        {
            Login FormLogin = new Login();
            FormLogin.Status += new EventHandler(myForm_Status);
            FormLogin.ShowDialog(this);
            if (FormLogin.OpenProgram == false)
                this.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            // сохранить открытый проект
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                pv = activeChildForm as ProjectViewer;  // если перобразование невозможно as вызовет null
                if (pv != null)
                    pv.SaveProject();
            }            
        }
    }
}
