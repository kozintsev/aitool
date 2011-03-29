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
    public partial class NewProject : Form
    {

        int itemIndex = 0;
        public NewProject()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            itemIndex = e.ItemIndex; 
                
             //MessageBox.Show(listView1.Items[e.ItemIndex].Text);
          
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(listView1.Items[itemIndex].Text + itemIndex.ToString());
            listView1.Items[itemIndex].Selected = true;
            switch (itemIndex)
            {
                case 0:
                    {
                        CreateSpecification mainForm = new CreateSpecification();
                        mainForm.MdiParent = this.ParentForm;
                        mainForm.Show();
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                default:
                    break;
            }
        }

        private void CreateProject_Click(object sender, EventArgs e)
        {
             MessageBox.Show(listView1.Items[itemIndex].Text + itemIndex.ToString());
             listView1.Items[itemIndex].Selected = true;
        }

        private void listView1_VisibleChanged(object sender, EventArgs e)
        {
            listView1.Items[itemIndex].Selected = true;
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            //
        }

     
     
    }
}
