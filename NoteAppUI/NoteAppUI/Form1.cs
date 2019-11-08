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
    public partial class Form1 : Form
    {
        private Project _project = new Project();

        public Form1()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
            var note = new Note(DateTime.Now.ToString(), DateTime.Now.ToString(), Category.Documents, DateTime.Now, DateTime.Now);
            var notesCount = _project.Notes.Count;
            _project.Notes.Add(notesCount, note);

            ListBox.Items.Add(note.Title);
        }
    }
}
