﻿using NoteApp;
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
    public partial class AddEditForm : Form
    {
        public Note note;
        /*
        public AddEditForm(Project notes)
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
        }

        private void NewForm_Load(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

       public  Note note1;
        private void OkButton_Click(object sender, EventArgs e)
        {
            int Category = CategoryComboBox.SelectedIndex;
            note = new Note(TitleBox.Text, TextBox.Text, (Category)Category, DateTime.Now, DateTime.Now);
            DialogResult = DialogResult.OK;
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void DateModifiedPicker_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void DateCreatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    */
        public string NoteTitle_Edit
        {
            get { return TitleBox.Text; }
            set { TitleBox.Text = value; }
        }

        public string NoteText_Edit
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }

        public int NoteCategory_Edit
        {
            get { return CategoryComboBox.SelectedIndex; }
            set { CategoryComboBox.SelectedIndex = value; }
        }

        public DateTime CreatedDateTime_Edit
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public DateTime ModifiedDateTime_Edit
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker2.Value = value; }
        }

        public AddEditForm(Project notes)
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int Category = CategoryComboBox.SelectedIndex;
            note = new Note(TitleBox.Text, TextBox.Text, (Category)Category, DateTime.Now, DateTime.Now);
            DialogResult = DialogResult.OK;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
