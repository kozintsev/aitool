/*
 * Created by SharpDevelop.
 * User: kov
 * Date: 12.03.2010
 * Time: 9:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace AiToolGui
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		Form About;
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void AboutToolStripMenuItem1Click(object sender, EventArgs e)
		{
			About = new AboutForm();
			if (!About.Visible) About.Show();
				else About.Activate();
		}
	}
}
