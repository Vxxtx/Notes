namespace Notes
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoryAddBox = new System.Windows.Forms.TextBox();
            this.categoriesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subjectList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentCategoryLabel = new System.Windows.Forms.Label();
            this.currentSubjectLabel = new System.Windows.Forms.Label();
            this.textEditor = new System.Windows.Forms.RichTextBox();
            this.subjectAddBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // categoryAddBox
            // 
            this.categoryAddBox.Location = new System.Drawing.Point(12, 12);
            this.categoryAddBox.Name = "categoryAddBox";
            this.categoryAddBox.Size = new System.Drawing.Size(166, 20);
            this.categoryAddBox.TabIndex = 0;
            this.categoryAddBox.Text = "Type and enter to add category";
            this.categoryAddBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.categoryAddBox_MouseClick);
            this.categoryAddBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.categoryAddBox_KeyPress);
            // 
            // categoriesList
            // 
            this.categoriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.categoriesList.HideSelection = false;
            this.categoriesList.LabelWrap = false;
            this.categoriesList.Location = new System.Drawing.Point(12, 49);
            this.categoriesList.MultiSelect = false;
            this.categoriesList.Name = "categoriesList";
            this.categoriesList.Size = new System.Drawing.Size(166, 124);
            this.categoriesList.TabIndex = 1;
            this.categoriesList.UseCompatibleStateImageBehavior = false;
            this.categoriesList.View = System.Windows.Forms.View.Details;
            this.categoriesList.SelectedIndexChanged += new System.EventHandler(this.categoriesList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Category";
            this.columnHeader1.Width = 160;
            // 
            // subjectList
            // 
            this.subjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.subjectList.HideSelection = false;
            this.subjectList.LabelWrap = false;
            this.subjectList.Location = new System.Drawing.Point(12, 221);
            this.subjectList.MultiSelect = false;
            this.subjectList.Name = "subjectList";
            this.subjectList.Size = new System.Drawing.Size(166, 217);
            this.subjectList.TabIndex = 2;
            this.subjectList.UseCompatibleStateImageBehavior = false;
            this.subjectList.View = System.Windows.Forms.View.Details;
            this.subjectList.SelectedIndexChanged += new System.EventHandler(this.subjectList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subject";
            this.columnHeader2.Width = 160;
            // 
            // currentCategoryLabel
            // 
            this.currentCategoryLabel.AutoSize = true;
            this.currentCategoryLabel.Location = new System.Drawing.Point(12, 33);
            this.currentCategoryLabel.Name = "currentCategoryLabel";
            this.currentCategoryLabel.Size = new System.Drawing.Size(86, 13);
            this.currentCategoryLabel.TabIndex = 3;
            this.currentCategoryLabel.Text = "Current Category";
            // 
            // currentSubjectLabel
            // 
            this.currentSubjectLabel.AutoSize = true;
            this.currentSubjectLabel.Location = new System.Drawing.Point(12, 205);
            this.currentSubjectLabel.Name = "currentSubjectLabel";
            this.currentSubjectLabel.Size = new System.Drawing.Size(80, 13);
            this.currentSubjectLabel.TabIndex = 4;
            this.currentSubjectLabel.Text = "Current Subject";
            // 
            // textEditor
            // 
            this.textEditor.Location = new System.Drawing.Point(184, 12);
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(604, 426);
            this.textEditor.TabIndex = 5;
            this.textEditor.Text = "";
            // 
            // subjectAddBox
            // 
            this.subjectAddBox.Location = new System.Drawing.Point(12, 182);
            this.subjectAddBox.Name = "subjectAddBox";
            this.subjectAddBox.Size = new System.Drawing.Size(166, 20);
            this.subjectAddBox.TabIndex = 6;
            this.subjectAddBox.Text = "Type and enter to add subject";
            this.subjectAddBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.subjectAddBox_MouseClick);
            this.subjectAddBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subjectAddBox_KeyPress);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subjectAddBox);
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.currentSubjectLabel);
            this.Controls.Add(this.currentCategoryLabel);
            this.Controls.Add(this.subjectList);
            this.Controls.Add(this.categoriesList);
            this.Controls.Add(this.categoryAddBox);
            this.Name = "MainWindow";
            this.Text = "Notes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryAddBox;
        private System.Windows.Forms.ListView categoriesList;
        private System.Windows.Forms.ListView subjectList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label currentCategoryLabel;
        private System.Windows.Forms.Label currentSubjectLabel;
        private System.Windows.Forms.RichTextBox textEditor;
        private System.Windows.Forms.TextBox subjectAddBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

