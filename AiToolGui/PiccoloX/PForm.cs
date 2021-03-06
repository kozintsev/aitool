/* 
 * Copyright (c) 2003-2005, University of Maryland
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met:
 * 
 *		Redistributions of source code must retain the above copyright notice, this list of conditions
 *		and the following disclaimer.
 * 
 *		Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *		and the following disclaimer in the documentation and/or other materials provided with the
 *		distribution.
 * 
 *		Neither the name of the University of Maryland nor the names of its contributors may be used to
 *		endorse or promote products derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * Piccolo was written at the Human-Computer Interaction Laboratory www.cs.umd.edu/hcil by Jesse Grosjean
 * and ported to C# by Aaron Clamage under the supervision of Ben Bederson.  The Piccolo website is
 * www.cs.umd.edu/hcil/piccolo.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using UMD.HCIL.Piccolo;
using UMD.HCIL.Piccolo.Util;
using UMD.HCIL.Piccolo.Event;
using UMD.HCIL.Piccolo.Activities;
using UMD.HCIL.PiccoloX.Components;

namespace UMD.HCIL.PiccoloX {
	/// <summary>
	/// A delegate used to invoke the <see cref="PForm.Initialize">Initialize</see> method
	/// on the main event dispatch thread.
	/// </summary>
	public delegate void ProcessDelegate();

	/// <summary>
	/// <b>PForm</b> is meant to be subclassed by applications that just need a
	/// <see cref="PCanvas"/> in a <see cref="Form"/>.
	/// </summary>
	/// <remarks>
	/// PForm also provides full screen mode functionality.
	/// <para>
	/// <b>Notes to Inheritors:</b>  Subclasses should override the Initialize
	/// method and start adding their own code there.  Look in the
	/// UMD.HCIL.PiccoloExamples package to see some uses of PForm.
	/// </para>
	/// </remarks>
	public class PForm : System.Windows.Forms.Form {
		#region Fields
		private PCanvas canvas;
		private PScrollableControl scrollableControl;
		private ProcessDelegate processDelegate;
		private Rectangle nonFullScreenBounds;
		private bool fullScreenMode;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new PForm.
		/// </summary>
		public PForm() {
			InitializeComponent();
			InitializePiccolo(false, null);
		}

		/// <summary>
		/// Constructs a new PForm, with the given canvas, in full screen mode if
		/// specified.
		/// </summary>
		/// <param name="fullScreenMode">
		/// Determines whether this PForm starts in full screen mode.
		/// </param>
		/// <param name="aCanvas">The canvas to add to this PForm.</param>
		/// <remarks>
		/// A <c>null</c> value can be passed in for <c>aCanvas</c>, in which a case
		/// a new canvas will be created.
		/// </remarks>
		public PForm(bool fullScreenMode, PCanvas aCanvas) {
			InitializeComponent();
			InitializePiccolo(fullScreenMode, aCanvas);
		}

		/// <summary>
		/// Sets up the form, sizing and anchoring the canvas.
		/// </summary>
		/// <param name="fullScreenMode">
		/// Indicates whether or not to start up in full screen mode.
		/// </param>
		/// <param name="aCanvas">
		/// The canvas to add to this PForm; can be null.
		/// </param>
		public void InitializePiccolo(bool fullScreenMode, PCanvas aCanvas) {
			if (aCanvas == null) {
				canvas = new PCanvas();
			} else {
				canvas = aCanvas;
			}

			canvas.Focus();
			BeforeInitialize();

			scrollableControl = new PScrollableControl(canvas);
			AutoScrollCanvas = false;

			//Note: If the main application form, generated by visual studio, is set to
			//extend PForm, the InitializeComponent will set the bounds after this statement
			Bounds = DefaultFormBounds;

			this.SuspendLayout();
			canvas.Size = ClientSize;
			scrollableControl.Size = ClientSize;
			this.Controls.Add(scrollableControl);

			scrollableControl.Anchor = 
				AnchorStyles.Bottom |
				AnchorStyles.Top |
				AnchorStyles.Left |
				AnchorStyles.Right;

			this.ResumeLayout(false);

			FullScreenMode = fullScreenMode;
		}
		#endregion

		#region Basic
		/// <summary>
		/// Gets this form's canvas.
		/// </summary>
		/// <value>This form's canvas.</value>
		public virtual PCanvas Canvas {
			get { return canvas; }
		}

		/// <summary>
		/// Gets the scrollable control that contains the canvas.
		/// </summary>
		/// <value>The scrollable control that contains the canvas.</value>
		public virtual PScrollableControl ScrollControl {
			get { return scrollableControl; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether or not this form's canvas is
		/// scrollable.
		/// </summary>
		public virtual bool AutoScrollCanvas {
			get {
				return scrollableControl.Scrollable;
			}
			set {
				scrollableControl.Scrollable = value;
			}
		}

		/// <summary>
		/// Gets or sets the view position of the canvas, if it is scrollable.
		/// </summary>
		public virtual Point AutoScrollCanvasPosition {
			get {
				return scrollableControl.ViewPosition;
			}
			set {
				scrollableControl.ViewPosition = value;
			}
		}

		/// <summary>
		/// Gets the default bounds to use for this form.
		/// </summary>
		public virtual Rectangle DefaultFormBounds {
			get {
				return new Rectangle(100, 100, 400, 400);
			}
		}

		/// <summary>
		/// Gets or sets the bounds this form should revert to when full screen mode is exited
		/// </summary>
		public virtual Rectangle NonFullScreenBounds {
			get {
				return nonFullScreenBounds;
			}
			set {
				nonFullScreenBounds = value;
			}
		}

		/// <summary>
		/// Gets or sets a value that indicates whether or not this form should be viewed
		/// in full screen mode.
		/// </summary>
		/// <value>
		/// A value that indicates whether or not this form should be viewed in full screen
		/// mode.
		/// </value>
		public virtual bool FullScreenMode {
			get {
				return fullScreenMode;
			}
			set {
				if (fullScreenMode != value) {
					fullScreenMode = value;

					if (fullScreenMode) {
						AddEscapeFullScreenModeHandler();
						FormBorderStyle = FormBorderStyle.None;
						this.NonFullScreenBounds = this.Bounds;
						this.Bounds = Screen.PrimaryScreen.Bounds;
						this.BringToFront();
					}
					else {
						RemoveEscapeFullScreenModeHandler();
						FormBorderStyle = FormBorderStyle.Sizable;
						this.Bounds = this.NonFullScreenBounds;
					}
				}
			}
		}

		/// <summary>
		/// This method adds a key event handler that will take this PForm out of full
		/// screen mode when the escape key is pressed.
		/// </summary>
		/// <remarks>
		/// This is called for you automatically when the form enters full screen mode.
		/// </remarks>
		public virtual void AddEscapeFullScreenModeHandler() {
			canvas.KeyDown += new KeyEventHandler(canvas_KeyDown);
		}

		/// <summary>
		/// This method removes the escape full screen mode key event handler.
		/// </summary>
		/// <remarks>
		/// This is called for you automatically when full screen mode exits, but the
		/// method has been made public for applications that wish to use other methods
		/// for exiting full screen mode.
		/// </remarks>
		public virtual void RemoveEscapeFullScreenModeHandler() {
			canvas.KeyDown -= new KeyEventHandler(canvas_KeyDown);
		}

		/// <summary>
		/// Exits full screen mode when the escape key is pressed.
		/// </summary>
		/// <param name="sender">The source of the KeyEvent.</param>
		/// <param name="e">A KeyEventArgs that contains the event data.</param>
		protected virtual void canvas_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Escape) {
				FullScreenMode = false;
			} else if (e.KeyCode == Keys.M) {
				FullScreenMode = false;
				this.WindowState = FormWindowState.Minimized;
			}
		}
		#endregion

		#region Initialize
		/// <summary>
		/// This method will be called before the <see cref="Initialize"/> method and will
		/// be called on the thread that is constructing this object.
		/// </summary>
		public virtual void BeforeInitialize() {
		}

		/// <summary>
		/// Subclasses should override this method and add their Piccolo initialization code
		/// there.
		/// </summary>
		/// <remarks>
		/// This method will be called on the main event dispatch thread.  Note that the
		/// constructors of PForm subclasses may not be complete when this method is called.
		/// If you need to initailize some things in your class before this method is called
		/// place that code in <see cref="BeforeInitialize"/>.
		/// </remarks>
		public virtual void Initialize() {
		}

		/// <summary>
		/// Overridden.  Invokes the initialize method on the event dispatch thread.
		/// </summary>
		/// <remarks>
		/// The handle of the canvas should exist at this point, so it is safe to call invoke.
		/// </remarks>
		protected override void OnCreateControl() {
			base.OnCreateControl ();

			//Force visible
			this.Visible = true;
			this.Refresh();

			//Necessary to invalidate the bounds because the state will be incorrect since
			//the message loop did not exist when the inpts were scheduled.
			this.canvas.Root.InvalidateFullBounds();
			this.canvas.Root.InvalidatePaint();

			this.processDelegate = new ProcessDelegate(Initialize);
			canvas.Invoke(processDelegate);
		}
		#endregion

		#region Dispose
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			// 
			// PForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "PForm";
			this.Text = "PForm";
		}
		#endregion
	}
}
