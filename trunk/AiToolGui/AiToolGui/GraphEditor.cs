using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using UMD.HCIL.Piccolo;
using UMD.HCIL.Piccolo.Nodes;
using UMD.HCIL.Piccolo.Event;
using UMD.HCIL.PiccoloX;
using UMD.HCIL.Piccolo.Util;
using UMD.HCIL.PiccoloX.Handles;

namespace UMD.HCIL.GraphEditor {
	/// <summary>
	/// A simple graph control with some random nodes and connected edges.  An event
	/// handler allows users to drag nodes around, keeping the edges connected.
	/// </summary>
    public class GraphEditor : PCanvas
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private static int DEFAULT_WIDTH = 500;
		private static int DEFAULT_HEIGHT = 500;
        private PText tooltipNode;
      
		/// <summary>
		/// Empty Constructor is necessary so that this control can be used as an applet.
		/// </summary>
		public GraphEditor() : this(DEFAULT_WIDTH, DEFAULT_HEIGHT) {}

		public GraphEditor(int width, int height) {
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
            PanEventHandler = null;
            AddInputEventListener(new PDragEventHandler());//включить движение фигур
			this.Size = new Size(width, height);            
            PCamera camera = Camera;
            tooltipNode = new PText();
            tooltipNode.Pickable = false;
            camera.AddChild(tooltipNode);
            
            PBasicInputEventHandler tipEventHandler = new PBasicInputEventHandler();
            tipEventHandler.MouseUp = new MouseUpDelegate(MouseUpHandler);
            tipEventHandler.MouseMove = new MouseMoveDelegate(MouseMoveHandler);
            tipEventHandler.MouseDrag = new MouseDragDelegate(MouseDragHandler);
            camera.AddInputEventListener(tipEventHandler);			
		}
        
        public void MouseUpHandler(object sender, PInputEventArgs e)
        {
            UpdateToolTip(e);
        }

        public void MouseMoveHandler(object sender, PInputEventArgs e)
        {
            //UpdateToolTip(e);
            
            
            PointF p = e.CanvasPosition;

            String tooltipString = "X = " + Convert.ToString(p.X) + "Y = " + Convert.ToString(p.Y);
            p = e.Path.CanvasToLocal(p, Camera);

            tooltipNode.Text = tooltipString;
            tooltipNode.SetOffset(p.X + 8, p.Y - 8);
        }

        public void MouseDragHandler(object sender, PInputEventArgs e)
        {
            //UpdateToolTip(e);
            //MessageBox.Show("Drag");
        }

        public void UpdateToolTip(PInputEventArgs e)
        {
            PNode n = e.InputManager.MouseOver.PickedNode;
            String tooltipString = (String)n.Tag;
            PointF p = e.CanvasPosition;

            p = e.Path.CanvasToLocal(p, Camera);

            tooltipNode.Text = tooltipString;
            tooltipNode.SetOffset(p.X + 8, p.Y - 8);
        }
		
        public void AddBlock()
        {
            PNode n1 = PPath.CreateEllipse(0, 0, 100, 100);
            PNode n2 = PPath.CreateRectangle(300, 200, 100, 100);

            n1.Tag = "node 1";
            n2.Tag = "node 2";
            Layer.AddChild(n1);
            Layer.AddChild(n2);

        }

        public void AddEllipse()
        {
            PNode path = PPath.CreateEllipse(10, 10, 20, 20);
            Layer.AddChild(path);
            //PBoundsHandle.AddBoundsHandlesTo(path);
          
        }


        public static void AddLine(PPath edge, PNode node1, PNode node2)
        {          
            PointF start = PUtil.CenterOfRectangle(node1.FullBounds);
            PointF end = PUtil.CenterOfRectangle(node2.FullBounds);
            edge.Reset();
            edge.AddLine(start.X, start.Y, end.X, end.Y);                   
        }



        public void AddEdge()
        {
            
            //edge = new PPath();
            //edgeLayer.AddChild(edge);
            //UpdateEdge(edge);

        }


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion

		// Draw a border for when this control is used as an applet.
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint (e);
			e.Graphics.DrawRectangle(Pens.Black, 0, 0, ClientSize.Width-1, ClientSize.Height-1);
		}
	}
}