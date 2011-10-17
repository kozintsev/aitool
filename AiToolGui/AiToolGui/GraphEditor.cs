using System;
using System.Collections;
using System.Collections.Generic;
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
        public event EventHandler eXY;  
        //private PNodeList nList;
      
		/// <summary>
		/// Empty Constructor is necessary so that this control can be used as an applet.
		/// </summary>
        private short typeblk = 0;
        private string nameEmptity;
        private string descEmptity;
        private float x;
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        private float y;
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        private int nodeId = 0; // идентификатор добавляемого элемента

        class Block // класс описывающий блок
        {
            public int id;
            public string name;
            public string desc; // описание блока
        }
        class Circle // класс описывающий начало и конец
        {
            int id;
            string name;
            enum View
            {
                start = 1,
                finish = 2
            }
        }
        class Arrow
        {
            int id;
            string name;
            int id_begin;
            int id_end;
        }
        private List<Block> BlockList = new List<Block>();    // список блоков
        private List<Circle> CircleList = new List<Circle>(); // список окружностей (конец, начало)
        private List<Arrow> ArrowList = new List<Arrow>();    // список стрелок (соединяющие блоки и окружности)

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
        protected virtual void OnEventXY(string cord)
        {
            object obj = cord;
            if (eXY != null)
                eXY(obj, EventArgs.Empty);
                
        }
        public void MouseUpHandler(object sender, PInputEventArgs e)
        {
            x = e.CanvasPosition.X;
            y = e.CanvasPosition.Y;
            switch (typeblk)
            {
                case 1:
                    AddEllipse(1, x, y);
                    typeblk = 0;
                    break;
                case 2:
                    AddBlock(nameEmptity, descEmptity, x, y);
                    typeblk = 0;
                    break;
            }
        }

        public void MouseMoveHandler(object sender, PInputEventArgs e)
        {
            PNode n = e.InputManager.MouseOver.PickedNode;            
            PointF p = e.CanvasPosition;
            String tooltipString = "X = " + Convert.ToString(p.X) + " Y = " + Convert.ToString(p.Y);
            OnEventXY(tooltipString);
        }

        public void MouseDragHandler(object sender, PInputEventArgs e)
        {
            //MessageBox.Show("Drag");
        }

		
        public void AddBlock(string name, string desc, float _x, float _y)
        {
            PNode n = PPath.CreateRectangle(x, y, 150, 100);
            PNode text = new PText(name);
            text.SetOffset(x + 50, y + 25);
            Block nBlk = new Block();
            nodeId++;
            nBlk.id = nodeId;
            nBlk.name = name;
            nBlk.desc = desc;
            n.Tag = (object)nBlk;
            Layer.AddChild(n);
            n.AddChild(text);
            PBoundsHandle.AddBoundsHandlesTo(n); //разрешить изменение размера          
        }

        public void AddEllipse(int t, float _x, float _y)
        {
            PNode path = PPath.CreateEllipse(_x, _y, 20, 20);
            Layer.AddChild(path);
            //PBoundsHandle.AddBoundsHandlesTo(path); //разрешить изменение размера
            nodeId++;
          
        }


        public static void AddLine(PPath edge, PNode node1, PNode node2)
        {          
            PointF start = PUtil.CenterOfRectangle(node1.FullBounds);
            PointF end = PUtil.CenterOfRectangle(node2.FullBounds);
            edge.Reset();
            edge.AddLine(start.X, start.Y, end.X, end.Y);
            //nodeId++;
        }

        public void AddEntity(short type, string name, string desc)
        {
            typeblk = type;
            nameEmptity = name;
            descEmptity = desc;
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