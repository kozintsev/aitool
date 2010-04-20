using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace KMintegrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
        }

        private void MathParser(string MathPath)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(@MathPath);
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            XmlNode ml_id, ml_real;
            foreach (XmlNode xn in xnl)
                if (xn.Name == "regions")
                    foreach (XmlNode region in xn.ChildNodes)
                        foreach (XmlNode math in region.ChildNodes)
                            foreach(XmlNode ml_define in math.ChildNodes)
                            {
                                ml_id = ml_define.FirstChild;
                                ml_real = ml_define.LastChild;
                                this.dataGridView2.Rows.Add(ml_id.InnerText, ml_real.InnerText);
                            }
                            
    

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
            
            this.dataGridView1.Rows.Add("1", "2");
            this.NameMath.Items.Add("A");
            this.NameMath.Items.Add("B");
            this.NameMath.Items.Add("C");
            
        }

        private void AddMathCad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файлы MathCAD 14 (*.xmcd)|*.xmcd";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            MathPath.Text = dlg.FileName;

            MathParser(MathPath.Text);


        }

 
    }
}
