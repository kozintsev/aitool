using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UMD.HCIL.GraphEditor;

namespace AiToolGui
{
    public partial class ProjectViewer : Form
    {
        public ProjectViewer()
        {
            InitializeComponent();
            GraphEditor graphEditor = new GraphEditor(this.ClientSize.Width, this.ClientSize.Height);
            this.splitContainer1.Panel2.Controls.Add(graphEditor);
            //Controls.Add(graphEditor);
            graphEditor.Bounds = this.ClientRectangle;
            graphEditor.Anchor = graphEditor.Anchor | AnchorStyles.Right | AnchorStyles.Bottom;
        }

      

        private void toolStripScope_Click(object sender, EventArgs e)
        {
            Form mainForm = new CreateSpecification();
            mainForm.MdiParent = this.ParentForm;
            mainForm.Show();
            //OnStatus(s);
        }

     
    }
}
