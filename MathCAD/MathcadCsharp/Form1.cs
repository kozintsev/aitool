using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mathcad;

namespace MathcadCsharp
{
    public partial class Form1 : Form
    {
        Mathcad.Application MC;
        Mathcad.Worksheet WS;
        Mathcad.Worksheets WK;

        //object g = 1;
        int F;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string Path;
            double R;
            
            Path = textBox1.Text;

            MC = new Mathcad.Application();
            if (MC == null)
            {
                
                //
            }

            MC.Visible = true;
            WK = MC.Worksheets;
            WS = WK.Open(Path);

            switch (comboBox1.SelectedIndex)
            {
                case 0: F = 10; break;
                case 1: F = 15; break;
                case 2: F = 20; break;
                case 3: F = 25; break;
                case 4: F = 30; break;
            }

            //g = F;

            WS.SetValue("in0", F);
            OutputBox1.Enabled = true;

            WS.Recalculate();

            R = (WS.GetValue("out0") as NumericValue).Real;
            OutputBox1.Text = R.ToString();
           
        }

        private void Cleanup()
        {
            WS.Close(Mathcad.MCSaveOption.mcDiscardChanges);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(WK);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(WS);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(MC);
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            if (MC != null) Cleanup();
            Close();
        }
    }
}
