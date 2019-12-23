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
    public partial class AddEditForm : Form
    {
        public Note Note
         {
            get
            {
                return note;
            }
    set
            {
                note = value;
                TitleBox.Text = note.Title;
                TextBox.Text = note.Text;
                CategoryComboBox.SelectedIndex = Convert.ToInt32(Note.Category);
                CreatedDateTimePicker.Value = Note.Created;
                ModifiedDateTimePicker.Value = Note.Modified;
            }
        }

        public Note note;

        public AddEditForm(Project Notes)
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            int Category = CategoryComboBox.SelectedIndex;
            note = new Note(TitleBox.Text, TextBox.Text, (Category)Category, DateTime.Now, DateTime.Now);
            DialogResult = DialogResult.OK;
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
            if (TitleBox.TextLength > 50)
            {
                DialogResult result = MessageBox.Show(
                "Длина заголовка не должна превышать 50 символов",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                TitleBox.Text = "";
            }
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
}
