namespace WordParser
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openDoc = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.CloseForm = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.WorkInDict = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddWorkInDict = new System.Windows.Forms.Button();
            this.NotParDict = new System.Windows.Forms.CheckBox();
            this.StatusWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openDoc
            // 
            this.openDoc.Location = new System.Drawing.Point(27, 231);
            this.openDoc.Name = "openDoc";
            this.openDoc.Size = new System.Drawing.Size(75, 23);
            this.openDoc.TabIndex = 0;
            this.openDoc.Text = "O&pen";
            this.openDoc.UseVisualStyleBackColor = true;
            this.openDoc.Click += new System.EventHandler(this.openDoc_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(27, 189);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(253, 23);
            this.progressBar2.TabIndex = 2;
            // 
            // CloseForm
            // 
            this.CloseForm.Location = new System.Drawing.Point(205, 231);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 3;
            this.CloseForm.Text = "Close";
            this.CloseForm.UseVisualStyleBackColor = true;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // WorkInDict
            // 
            this.WorkInDict.Location = new System.Drawing.Point(27, 25);
            this.WorkInDict.Name = "WorkInDict";
            this.WorkInDict.Size = new System.Drawing.Size(242, 20);
            this.WorkInDict.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add Word";
            // 
            // AddWorkInDict
            // 
            this.AddWorkInDict.Location = new System.Drawing.Point(27, 51);
            this.AddWorkInDict.Name = "AddWorkInDict";
            this.AddWorkInDict.Size = new System.Drawing.Size(75, 23);
            this.AddWorkInDict.TabIndex = 6;
            this.AddWorkInDict.Text = "Add";
            this.AddWorkInDict.UseVisualStyleBackColor = true;
            this.AddWorkInDict.Click += new System.EventHandler(this.AddWorkInDict_Click);
            // 
            // NotParDict
            // 
            this.NotParDict.AutoSize = true;
            this.NotParDict.Location = new System.Drawing.Point(27, 107);
            this.NotParDict.Name = "NotParDict";
            this.NotParDict.Size = new System.Drawing.Size(117, 17);
            this.NotParDict.TabIndex = 7;
            this.NotParDict.Text = "Not Paragraph Dict";
            this.NotParDict.UseVisualStyleBackColor = true;
            // 
            // StatusWord
            // 
            this.StatusWord.AutoSize = true;
            this.StatusWord.Location = new System.Drawing.Point(109, 60);
            this.StatusWord.Name = "StatusWord";
            this.StatusWord.Size = new System.Drawing.Size(0, 13);
            this.StatusWord.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.StatusWord);
            this.Controls.Add(this.NotParDict);
            this.Controls.Add(this.AddWorkInDict);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkInDict);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.openDoc);
            this.Name = "MainForm";
            this.Text = "WordParser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openDoc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button CloseForm;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox WorkInDict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddWorkInDict;
        private System.Windows.Forms.CheckBox NotParDict;
        private System.Windows.Forms.Label StatusWord;
    }
}

