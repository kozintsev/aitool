namespace Control_Kompas
{
    partial class UserControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.axKGAX1 = new AxKGAXLib.AxKGAX();
            ((System.ComponentModel.ISupportInitialize)(this.axKGAX1)).BeginInit();
            this.SuspendLayout();
            // 
            // axKGAX1
            // 
            this.axKGAX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axKGAX1.Enabled = true;
            this.axKGAX1.Location = new System.Drawing.Point(0, 0);
            this.axKGAX1.Name = "axKGAX1";
            this.axKGAX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKGAX1.OcxState")));
            this.axKGAX1.Size = new System.Drawing.Size(150, 150);
            this.axKGAX1.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axKGAX1);
            this.Name = "UserControl1";
            ((System.ComponentModel.ISupportInitialize)(this.axKGAX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxKGAXLib.AxKGAX axKGAX1;
    }
}
