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
        public AddBlocks()
        {
            InitializeComponent();
        }

        public string Strrr;

        public string GetBlockName()
        {
            return BlockName.Text;
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
