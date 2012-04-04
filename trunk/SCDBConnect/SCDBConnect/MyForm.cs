using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCDBConnect
{
    public partial class FormChangeDB : Form
    {
        public FormChangeDB()
        {
            InitializeComponent();
        }

        private void button_set_path_Click(object sender, EventArgs e)
        {

            DialogResult res = openFileDlg.ShowDialog();
            if (res == DialogResult.OK) textBox_DBpath.Text = openFileDlg.FileName;
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            string path = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0E3CDE49-2A21-4AE3-B5E5-F63B26D09AAF}_is1", "InstallLocation", @"");
            if (!string.IsNullOrEmpty(path)) textBox_DBpath.Text = path + @"base\db.mdb";
        }

        private void button_OnDB_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox_DBpath.Text);
                conn.Open();
                var schema = conn.GetSchema();
                var ret = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
                foreach (DataRow row in ret.Rows)
                {
                    string name = (string)row["TABLE_NAME"];
                    if(!name.StartsWith("msys", StringComparison.CurrentCultureIgnoreCase))
                        listView_TbNameDB.Items.Add(name, 5);
                }
                conn.Close();

            }
            catch (OleDbException odbe)
            {
                MessageBox.Show(odbe.Message,odbe.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            button_OnDB.Enabled = false;
            button_set_path.Enabled = false;
            groupBox_DBpath.Enabled = false;
            button_OffDB.Enabled = true;
            groupBox_DBtables.Enabled = true;
        }

        private void button_OffDB_Click(object sender, EventArgs e)
        {
            listView_TbNameDB.Clear();

            button_OnDB.Enabled = true;
            button_set_path.Enabled = true;
            groupBox_DBpath.Enabled = true;
            button_OffDB.Enabled = false;
            groupBox_DBtables.Enabled = false;
        }

        private void listView_TbNameDB_DoubleClick(object sender, EventArgs e)
        {
            FormViewTable TableView = new FormViewTable();

            TableView.listViewItem = listView_TbNameDB.SelectedItems[0];
            TableView.listViewItem.ImageIndex = 6;
            TableView.Text = "[" + TableView.listViewItem.Text.ToUpper() + " ] " + textBox_DBpath.Text;

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox_DBpath.Text);
            conn.Open();
            TableView.dbAdapter = new OleDbDataAdapter("SELECT * FROM " + TableView.listViewItem.Text, conn);
            OleDbCommandBuilder ComBilder = new OleDbCommandBuilder(TableView.dbAdapter);
            try
            {
                TableView.dbAdapter.UpdateCommand = ComBilder.GetUpdateCommand();
                TableView.dbAdapter.InsertCommand = ComBilder.GetInsertCommand();
                TableView.dbAdapter.DeleteCommand = ComBilder.GetDeleteCommand();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show("Доступ только для чтения\n\r" + ioe.Message, "Доступен только для чтения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TableView.dataGridView.ReadOnly = true;
                TableView.Text += " ReadOnly(!!!)";
            }
            conn.Close();

            DataTable DT = new DataTable();
            TableView.dbAdapter.Fill(DT);
            TableView.dataGridView.DataSource = DT;
            TableView.dataGridView.Sort(TableView.dataGridView.Columns[0], ListSortDirection.Ascending);
            bool Edit = true;
            foreach (DataGridViewColumn col in TableView.dataGridView.Columns)
            {
                col.ReadOnly = Edit;
                Edit = !Edit;
                col.Width = 50;
            }
            TableView.Show();
        }

        private void link_MyMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(String.Format("mailto:{0}", this.link_MyMail.Text));
        }
    }
}
