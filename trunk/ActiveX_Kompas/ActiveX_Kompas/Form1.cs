using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kompas6Constants;
using Kompas6Constants3D;
using Kompas6API5;


namespace ActiveX_Kompas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            axKGAX1.DocumentType = KGAXLib.KDocumentType.vt_3DPart;
                        
        }

        private void Run_Click(object sender, EventArgs e)
        {
            

           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KompasObject kompas = axKGAX1.GetKompasObject();
            if (kompas == null)
            {
                MessageBox.Show("BAD KompasObject");
                return;
            }


            ksDocument3D doc = (ksDocument3D)kompas.ActiveDocument3D();
            if (doc == null)
            {
                MessageBox.Show("BAD Document3D");
                return;
            }

            ksPart part = (ksPart)doc.GetPart((short)Part_Type.pNew_Part);	//новый компонент
            if (part == null)
            {
                MessageBox.Show("BAD Part");
                return;
            }

            ksEntity entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            if (entitySketch == null)
            {
                MessageBox.Show("BAD EntitySketch");
                return;
            }

            // интерфейс свойств эскиза
            ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
            if (sketchDef == null)
            {
                MessageBox.Show("BAD SketchDefinition");
                return;
            }

            // получим интерфейс базовой плоскости XOY
            ksEntity basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            sketchDef.SetPlane(basePlane);	// установим плоскость XOY базовой для эскиза
            sketchDef.angle = 45;			// угол поворота эскиза
            entitySketch.Create();			// создадим эскиз

            // интерфейс редактора эскиза
            ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
            // введем новый эскиз - квадрат
            sketchEdit.ksLineSeg(50, 50, -50, 50, 1);
            sketchEdit.ksLineSeg(50, -50, -50, -50, 1);
            sketchEdit.ksLineSeg(50, -50, 50, 50, 1);
            sketchEdit.ksLineSeg(-50, -50, -50, 50, 1);
            sketchDef.EndEdit();	//завершение редактирования эскиза

            ksEntity entityExtr = (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtr == null)
            {
                MessageBox.Show("BAD EntityExtrusion");
                return;
            }

            // интерфейс свойств базовой операции выдавливания
            ksBaseExtrusionDefinition extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
            if (extrusionDef == null)
            {
                MessageBox.Show("BAD ExtrusionDefinition");
                return;
            }

            extrusionDef.directionType = (short)Direction_Type.dtNormal;	// направление выдавливания
            extrusionDef.SetSideParam(true, (short)End_Type.etBlind, 200, 0, false);
            extrusionDef.SetThinParam(true, (short)Direction_Type.dtBoth, 10, 10);		// тонкая стенка в два направления
            extrusionDef.SetSketch(entitySketch);					// эскиз операции выдавливания
            entityExtr.Create();									// создать операцию
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axKGAX1.StopCurrentProcess(true);
        }

        private void okToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axKGAX1.StopCurrentProcess(false);
        }
    }
}
