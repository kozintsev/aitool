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

        public int a;
        private int itemIndex = 0;
        private int childFormNumber = 0;

        public event EventHandler Status;


        public NewProject()
        {
            InitializeComponent();
        }

        protected virtual void OnStatus(string s)
        {
            object Obj = s;
            if (Status != null)
                Status(Obj, EventArgs.Empty);
        }

        private void Dummy()
        {
            OnStatus("asS");
            MessageBox.Show("asS");
            //Console.WriteLine("Event fired");
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
            string s = listView1.Items[itemIndex].Text + itemIndex.ToString();
            //MessageBox.Show();
            childFormNumber++;
            listView1.Items[itemIndex].Selected = true;
            switch (itemIndex)
            {
                case 0:
                    {
                        Form mainForm = new CreateSpecification();
                        mainForm.MdiParent = this.ParentForm;
                        mainForm.Text = mainForm.Text + " - " + childFormNumber.ToString();
                        mainForm.Show();
                        OnStatus(s);
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
