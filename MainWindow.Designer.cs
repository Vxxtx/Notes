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
            this.notesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentCategoryLabel = new System.Windows.Forms.Label();
            this.currentNoteLabel = new System.Windows.Forms.Label();
            this.textEditor = new System.Windows.Forms.RichTextBox();
            this.noteAddBox = new System.Windows.Forms.TextBox();
            this.settingsButton = new System.Windows.Forms.Button();
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
            this.categoriesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoriesList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Category";
            this.columnHeader1.Width = 160;
            // 
            // notesList
            // 
            this.notesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.notesList.HideSelection = false;
            this.notesList.LabelWrap = false;
            this.notesList.Location = new System.Drawing.Point(12, 221);
            this.notesList.MultiSelect = false;
            this.notesList.Name = "notesList";
            this.notesList.Size = new System.Drawing.Size(166, 217);
            this.notesList.TabIndex = 2;
            this.notesList.UseCompatibleStateImageBehavior = false;
            this.notesList.View = System.Windows.Forms.View.Details;
            this.notesList.SelectedIndexChanged += new System.EventHandler(this.notesList_SelectedIndexChanged);
            this.notesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.notesList_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Note";
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
            // currentNoteLabel
            // 
            this.currentNoteLabel.AutoSize = true;
            this.currentNoteLabel.Location = new System.Drawing.Point(12, 205);
            this.currentNoteLabel.Name = "currentNoteLabel";
            this.currentNoteLabel.Size = new System.Drawing.Size(67, 13);
            this.currentNoteLabel.TabIndex = 4;
            this.currentNoteLabel.Text = "Current Note";
            // 
            // textEditor
            // 
            this.textEditor.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textEditor.Location = new System.Drawing.Point(184, 12);
            this.textEditor.Name = "textEditor";
            this.textEditor.ReadOnly = true;
            this.textEditor.Size = new System.Drawing.Size(604, 456);
            this.textEditor.TabIndex = 5;
            this.textEditor.Text = "";
            // 
            // noteAddBox
            // 
            this.noteAddBox.Location = new System.Drawing.Point(12, 182);
            this.noteAddBox.Name = "noteAddBox";
            this.noteAddBox.Size = new System.Drawing.Size(166, 20);
            this.noteAddBox.TabIndex = 6;
            this.noteAddBox.Text = "Type and enter to add note";
            this.noteAddBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.noteAddBox_MouseClick);
            this.noteAddBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noteAddBox_KeyPress);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(12, 445);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(166, 23);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.noteAddBox);
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.currentNoteLabel);
            this.Controls.Add(this.currentCategoryLabel);
            this.Controls.Add(this.notesList);
            this.Controls.Add(this.categoriesList);
            this.Controls.Add(this.categoryAddBox);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryAddBox;
        private System.Windows.Forms.ListView categoriesList;
        private System.Windows.Forms.ListView notesList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label currentCategoryLabel;
        private System.Windows.Forms.Label currentNoteLabel;
        private System.Windows.Forms.RichTextBox textEditor;
        private System.Windows.Forms.TextBox noteAddBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button settingsButton;
    }
}

