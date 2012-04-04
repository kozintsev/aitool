using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCDBConnect
{
    public partial class FormViewTable : Form
    {
        public FormViewTable()
        {
            InitializeComponent();
        }

        private void toolSaveChanged_Click(object sender, EventArgs e)
        {
            this.dataGridView.CancelEdit();
            this.dataGridView.ClearSelection();
            try
            {
                this.dbAdapter.Update(this.dataGridView.DataSource as DataTable);
                (this.dataGridView.DataSource as DataTable).AcceptChanges();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show("Ошибка обновления данных базы\n\r" + ioe.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Table_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.listViewItem.ImageIndex = 5;
        }
    }
}
