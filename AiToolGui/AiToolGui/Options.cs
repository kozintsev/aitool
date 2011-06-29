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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            Settings sett = new Settings();
            DBPath.Text = sett.GetDataBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файлы Microsoft Access 2003 (*.mdb)|*.mdb";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            DBPath.Text = dlg.FileName;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Сохранить настройки
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
           
         
       

        }
    }
}
