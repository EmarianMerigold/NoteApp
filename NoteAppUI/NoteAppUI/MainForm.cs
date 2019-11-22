using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ModifiedButton_Click(object sender, EventArgs e)
        {

        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                NoteTextBox.Text = _project.Notes[ListBox.SelectedIndex].Text;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var note = new Note("Title", "Text", Category.Documents, DateTime.Now, DateTime.Now);
            var notesCount = _project.Notes.Count;
            _project.Notes.Add(notesCount, note);

            ListBox.Items.Add(note.Title);
            NewForm newForm = new NewForm(note);
            newForm.ShowDialog();
        }

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
