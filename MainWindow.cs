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
            SaveCurrentSubject();

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
            foreach (ListViewItem item in subjectList.Items)
            {
                subjectList.Items.Remove(item);
            }

            int FoundCat = FindCategory(categoryName);
            if (FoundCat == -1) return;

            CurrentCategory = FoundCat;

            foreach (NoteItem note in Categories[FoundCat].notes)
            {
                subjectList.Items.Add(new ListViewItem(note.noteName));
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
         * Subjects
        */
        private void AddSubject(string subjectName)
        {
            if (CurrentCategory == -1) return;

            SaveCurrentSubject();

            subjectAddBox.Text = "";
            textEditor.Text = "";
            Categories[CurrentCategory].notes.Add(new NoteItem(subjectName, ""));
            subjectList.Items.Add(new ListViewItem(subjectName));
        }

        private void SelectSubject(string subjectName)
        {

        }

        private int FindSubject(string subjectName)
        {
            for (int i = 0; i < Categories[CurrentCategory].notes.Count; i++)
            {
                if (Categories[CurrentCategory].notes[i].noteName == subjectName)
                {
                    return i;
                }
            }
            return -1;
        }
        
        private void SaveCurrentSubject()
        {
            if (CurrentNote != -1)
            {
                NoteItem NewNoteItem = new NoteItem(Categories[CurrentCategory].notes[CurrentNote].noteName, textEditor.Text);
                Categories[CurrentCategory].notes[CurrentNote] = new NoteItem(Categories[CurrentCategory].notes[CurrentNote].noteName, textEditor.Text);
            }
        }
        
        private void SaveNotes()
        {
            string json_strings = JsonConvert.SerializeObject(Categories);
            Sql.InsertNotesData(Categories);
        }

        /*
         * Events
        */

        // Get subject list enter press
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

        private void subjectAddBox_MouseClick(object sender, MouseEventArgs e)
        {
            subjectAddBox.Text = "";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotes();
            Sql.CloseConnection();
        }

        // When categories list is clicked
        private void categoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in subjectList.Items)
            {
                subjectList.Items.Remove(item);
            }

            if (categoriesList.SelectedItems.Count == 0)
            {
                CurrentCategory = -1;
                CurrentNote = -1;
                return;
            }
            
            int CategoryIdx = FindCategory(categoriesList.SelectedItems[0].Text);
            if (CategoryIdx == -1) return;
            CurrentCategory = CategoryIdx;

            foreach (NoteItem note in Categories[CategoryIdx].notes)
            {
                subjectList.Items.Add(new ListViewItem(note.noteName));
            }
        }

        // Get subject list enter press
        private void subjectAddBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (subjectAddBox.Text != "")
                {
                    AddSubject(subjectAddBox.Text);
                }
            }
        }

        // When subject list is clicked
        private void subjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveCurrentSubject();
            textEditor.Text = "";

            if (subjectList.SelectedItems.Count == 0)
            {
                CurrentNote = -1;

                return;
            }

            int SubjectIdx = FindSubject(subjectList.SelectedItems[0].Text);
            CurrentNote = SubjectIdx;

            if (SubjectIdx == -1) return;

            textEditor.Text = Categories[CurrentCategory].notes[SubjectIdx].noteText;
        }

        // Window load
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Sql.Connect();
        }
    }
}
