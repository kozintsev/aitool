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
    public partial class ProjectManager : Form
    {
  
        public ProjectManager()
        {
            InitializeComponent();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //
            MessageBox.Show(e.ToString());
        }
        
        void ListView1ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        	
        }
    }
}
