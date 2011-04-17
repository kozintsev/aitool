using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace global_butom
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int vkCode = Marshal.ReadInt32(lParam);
            //if ((Keys)vkCode == Keys.T)
            {
               MessageBox.Show("Hot Key Registred");
            }
        }
    }
}

