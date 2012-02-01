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
    public partial class AddBlocks : Form
    {
        private ConnectDataBase cdb;

        public AddBlocks()
        {
            InitializeComponent();
            bool conn = false;
            cdb = new ConnectDataBase();
            conn = cdb.CreateConnectDataBase(); // подключились или нет?
            if (!conn) return;
            List<CProjectProcedures> list = cdb.GetProjectProcedureList();
            cdb.CloseConnectDataBaseLocal();
            for (int i = 0; i < list.Count; i++)
            {
                comboBoxType.Items.Add(list[i].ProcedurName);
            }
            //comboBoxType список проектных процедур
        }

        public string GetBlockName()
        {
            return BlockName.Text;
        }
        public string GetBlockDesc()
        {
            return Comment.Text;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (BlockName.Text == "")
            {
                MessageBox.Show("Введите имя блока", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else this.Hide();
        }
        
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
