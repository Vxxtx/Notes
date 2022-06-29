using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Notes
{
    // Structure containing category name and list of notes within the category
    public struct NoteCategory
    {
        public string categoryName;
        public List<NoteItem> notes;

        public NoteCategory(string inCategoryName, List<NoteItem> inNotes)
        {
            this.categoryName = inCategoryName;
            this.notes = inNotes;
        }
    };

    // Structure that contains note name and its' content
    public struct NoteItem
    {
        public string noteName;
        public string noteText;

        public NoteItem(string inNoteName, string inNoteText)
        {
            this.noteName = inNoteName;
            this.noteText = inNoteText;
        }
    };

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Initialize variables
        List<NoteCategory> Categories = new List<NoteCategory>();
        int CurrentCategory = -1;
        int CurrentNote = -1;
        
        /*
         * Methods
        */

        /*
         * Categories
        */
        private void AddCategory(string categoryName)
        {
            SaveCurrentNote();

            categoryAddBox.Text = "";

            ListViewItem newItem = new ListViewItem(categoryName);
            categoriesList.Items.Add(newItem);

            List<NoteItem> newNote = new List<NoteItem>();
            NoteCategory noteCat = new NoteCategory(categoryName, newNote);

            Categories.Add(noteCat);
            SelectCategory(categoryName);
        }
        
        private void SelectCategory(string categoryName)
        {
            foreach (ListViewItem item in notesList.Items)
            {
                notesList.Items.Remove(item);
            }

            int FoundCat = FindCategory(categoryName);
            if (FoundCat == -1) return;

            CurrentCategory = FoundCat;

            foreach (NoteItem note in Categories[FoundCat].notes)
            {
                notesList.Items.Add(new ListViewItem(note.noteName));
            }
        }

        private int FindCategory(string categoryName)
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                if (Categories[i].categoryName == categoryName)
                {
                    return i;
                }
            }
            return -1;
        }

        /*
         * Notes
        */
        private void AddNote(string noteName)
        {
            if (CurrentCategory == -1) return;

            SaveCurrentNote();

            noteAddBox.Text = "";
            textEditor.Text = "";
            Categories[CurrentCategory].notes.Add(new NoteItem(noteName, ""));
            notesList.Items.Add(new ListViewItem(noteName));
        }

        private int FindNote(string noteName)
        {
            for (int i = 0; i < Categories[CurrentCategory].notes.Count; i++)
            {
                if (Categories[CurrentCategory].notes[i].noteName == noteName)
                {
                    return i;
                }
            }
            return -1;
        }
        
        private void SaveCurrentNote()
        {
            if (CurrentNote != -1)
            {
                NoteItem NewNoteItem = new NoteItem(Categories[CurrentCategory].notes[CurrentNote].noteName, textEditor.Text);
                Categories[CurrentCategory].notes[CurrentNote] = new NoteItem(Categories[CurrentCategory].notes[CurrentNote].noteName, textEditor.Text);
            }
        }
        
        private void SaveNotes()
        {
            SaveCurrentNote();
            Sql.InsertNotesData(Categories);
        }

        /*
         * Events
        */

        // Get category list enter press
        private void categoryAddBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (categoryAddBox.Text != "")
                {
                    AddCategory(categoryAddBox.Text);
                }
            }
        }

        private void categoryAddBox_MouseClick(object sender, MouseEventArgs e)
        {
            categoryAddBox.Text = "";
        }

        private void noteAddBox_MouseClick(object sender, MouseEventArgs e)
        {
            noteAddBox.Text = "";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotes();
            Sql.CloseConnection();
        }

        // When categories list is clicked
        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in notesList.Items)
            {
                notesList.Items.Remove(item);
            }

            if (categoriesList.SelectedItems.Count == 0)
            {
                CurrentCategory = -1;
                CurrentNote = -1;
                textEditor.ReadOnly = true;
                textEditor.BackColor = Color.Gray;
                return;
            }
            
            int CategoryIdx = FindCategory(categoriesList.SelectedItems[0].Text);
            if (CategoryIdx == -1) return;
            CurrentCategory = CategoryIdx;

            foreach (NoteItem note in Categories[CategoryIdx].notes)
            {
                notesList.Items.Add(new ListViewItem(note.noteName));
            }
        }

        // Get note list enter press
        private void noteAddBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (noteAddBox.Text != "")
                {
                    AddNote(noteAddBox.Text);
                }
            }
        }

        // When note list is clicked
        private void notesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentNote();
            textEditor.Text = "";

            if (notesList.SelectedItems.Count == 0)
            {
                CurrentNote = -1;
                textEditor.ReadOnly = true;
                textEditor.BackColor = Color.Gray;
                return;
            }

            int NoteIdx = FindNote(notesList.SelectedItems[0].Text);
            CurrentNote = NoteIdx;

            if (NoteIdx == -1) return;

            textEditor.Text = Categories[CurrentCategory].notes[NoteIdx].noteText;
            textEditor.ReadOnly = false;
            textEditor.BackColor = Color.White;
        }

        // Window load
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Categories = Sql.ConnectAndLoad();

            if (Categories.Count > 0)
            {
                for (int i = 0; i < Categories.Count; i++)
                {
                    ListViewItem newItem = new ListViewItem(Categories[i].categoryName);
                    categoriesList.Items.Add(newItem);
                }
            }
        }

        private void categoriesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                if (categoriesList.SelectedItems.Count > 0)
                {
                    DialogResult yesNoResult = MessageBox.Show("Are you sure? This action will delete the category.", "Delete", MessageBoxButtons.YesNo);
                    
                    if (yesNoResult == DialogResult.Yes)
                    {
                        CurrentCategory = -1;
                        Categories.RemoveAt(FindCategory(categoriesList.SelectedItems[0].Text));
                        categoriesList.Items.Remove(categoriesList.SelectedItems[0]);
                    }
                }
            }
        }

        private void notesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                if (categoriesList.SelectedItems.Count > 0 && notesList.SelectedItems.Count > 0)
                {
                    DialogResult yesNoResult = MessageBox.Show("Are you sure? This action will delete the note.", "Delete", MessageBoxButtons.YesNo);

                    if (yesNoResult == DialogResult.Yes)
                    {
                        CurrentNote = -1;
                        Categories[CurrentCategory].notes.RemoveAt(FindNote(notesList.SelectedItems[0].Text));
                        notesList.Items.Remove(notesList.SelectedItems[0]);
                    }
                }
            }
        }
    }
}
