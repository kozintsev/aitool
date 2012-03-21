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
            LocalBaseType.Text = sett.GetDataBaseType();
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
                sett.SetDataBaseType(LocalBaseType.Text);
            }
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }

        private void AddAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            switch (LocalBaseType.Text)
            {
                case "Access 2003":
                    dlg.Filter = "Файлы Microsoft Access 2003 (*.mdb)|*.mdb";
                    break;
                case "Access 2007":
                    dlg.Filter = "Файлы Microsoft Access 2007 (*.accdb)|*.accdb";
                    break;
                case "SQLite":
                    dlg.Filter = "Файлы SQLite (*.db, *.sqlite)|*.db;*.sqlite";
                    break;
            }
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            DBPath.Text = dlg.FileName;
        }

        private void LocalBaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Microsoft.Jet.OLEDB.4.0
            //
        }
    }
}
