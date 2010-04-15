using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMintegrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddKompas_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //txt files (*.txt)|*.txt|All files (*.*)|*.*
            dlg.Filter = "КОМПАС-Документы (*.cdw; *.m3d;*.a3d)|*.cdw;*.m3d;*.a3d";
            dlg.Filter += "|КОМПАС-Чертёж (*.cdw)|*.cdw";
            dlg.Filter += "|КОМПАС-Деталь (*.m3d)|*.m3d";
            dlg.Filter += "|КОМПАС-Сборка (*.a3d)|*.a3d";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            KompasPath.Text = dlg.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файлы MathCAD 14 (*.xmcd)|*.xmcd";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MathPath.Text = dlg.FileName;

        }
    }
}
