using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AiToolGui
{
    public partial class Options : Form
    {
        private Settings sett;
        public Options()
        {
            InitializeComponent();
            sett = new Settings();
            DBPath.Text = sett.GetDataBaseLocal();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Сохранить настройки
            if (File.Exists(DBPath.Text)) // если файл существует
            {
                sett.SetDataBaseLocal(DBPath.Text);
            }
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }

        private void AddAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файлы Microsoft Access 2003 (*.mdb)|*.mdb";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            DBPath.Text = dlg.FileName;
        }
    }
}
