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
        private Project _project; 
        public MainForm()
        {
            InitializeComponent();
            LoadProject();
            TitleListboxAdd();
            //Передача полю CategoryCombobox формы MainForm значений из перечисления Category.
            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
        }

        /// <summary>
        /// Функция для подсчёта записей в словаре.
        /// </summary>
        public int NewNumberOfRecords()
        {
            int numberОfRecords = _project.Notes.Count;
            return numberОfRecords;
        }

        /// <summary>
        /// Обработчик, заполняющий ListBox заголовками заметок из словаря.
        /// </summary>
        public void TitleListboxAdd()
        {
            ListBox.Items.Clear();
            foreach (KeyValuePair<int, Note> kvp in _project.Notes)
            {
                int n = 0;
                if (CategoryComboBox.SelectedIndex == Convert.ToInt32(kvp.Value.Category))
                {
                    ListBox.Items.Insert(n, kvp.Value.Title);
                    n++;
                }
            }
        }

        /// <summary>
        /// Функция загрузки данных в программу.
        /// </summary>
        public void LoadProject()
        {
            try
            {
                string defaultPath = @"c:\Notes.json";
                _project = ProjectManager.LoadFromFile(defaultPath);
            }
            catch
            {
                _project = new Project();
            }
        }

        /// <summary>
        /// Функция сохранения записей в файл Json.
        /// </summary>
        public void SaveProject()
        {
            ProjectManager.SaveToFile(_project, @"c:\Notes.json");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка редактирования.
        /// </summary>
        private void ModifiedButton_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);
            // Переменная для хранения ключа редактирования записи.
            int selectedID = ListBox.SelectedIndex;
            // Показ уже имеющихся данных в окне редактирования.
            if (selectedID < 0)
            {
                MessageBox.Show("Выберите пожайлуста заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string NoteValue = ListBox.SelectedItem.ToString();
                int OperatedKey = GetKeyByValue(NoteValue);
                form.TitleBox.Text = _project.Notes[OperatedKey].Title;
                form.CategoryComboBox.SelectedIndex = Convert.ToInt32(_project.Notes[OperatedKey].Category);
                form.TextBox.Text = _project.Notes[OperatedKey].Text;
                form.dateTimePicker1.Value = _project.Notes[OperatedKey].Created;
                form.dateTimePicker2.Value = _project.Notes[OperatedKey].Modified;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DateTime KeepDate = _project.Notes[OperatedKey].Created;
                    form.note.Created = KeepDate;
                    _project.Notes[OperatedKey] = (form.note);
                    SaveProject();
                    ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
                    TitleListboxAdd();
                }
            }
        }

        /// <summary>
        /// Обработчик который выводит данные заметки на компоненты формы.
        /// </summary>
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                int selected = GetKeyByValue(ListBox.SelectedItem.ToString());
                Titlelabel.Text = ListBox.SelectedItem.ToString();
                string CategoryText = "Note not selected";
                CategoryText = _project.Notes[selected].Category.ToString();
                CategoryLabel.Text = CategoryText;
                CategoryLabel.Visible = true;
                NoteTextBox.Text = _project.Notes[selected].Text;
                dateTimePicker1.Value = _project.Notes[selected].Created;
                dateTimePicker2.Value = _project.Notes[selected].Modified;
            }
            Titlelabel.Visible = true;
        }

        /// <summary>
        /// Кнопка добавления.
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {

            AddEditForm form = new AddEditForm(_project);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Notes.Add(NewNumberOfRecords(), form.note);
                TitleListboxAdd();
                SaveProject();
            }
        }

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Выбор категории из ComboBox в MainForm.
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TitleListboxAdd();
        }
        /// <summary>
        /// Функция которая находит ключ по значению.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Возвращает индекс ключа</returns>
        public int GetKeyByValue(string value)
        {
            foreach (KeyValuePair<int, Note> kvp in _project.Notes)
            {
                if (kvp.Value.Title.Equals(value))
                    return kvp.Key;
            }

            return -1;
        }

        /// <summary>
        /// Функция, которая проверяет доступность ключа в словаре.
        /// </summary>
        /// <returns>Возвращает индекс доступного ключа.</returns>
        public int AvailableKey()
        {
            int i = 0;
            foreach (KeyValuePair<int, Note> kvp in _project.Notes)
            {
                if (kvp.Key == i)
                    i++;
                else return i;
            }
            return -1;
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка удаления.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            //Проверка выборки.
            int selectedID = ListBox.SelectedIndex;
            if (selectedID < 0)
            {
                MessageBox.Show("Выберите пожайлуста заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                int operatedKey = GetKeyByValue(ListBox.SelectedItem.ToString());
                _project.Notes.Remove(operatedKey);
                TitleListboxAdd();
                SaveProject();
            }
        }

        /// <summary>
        /// Выход в верхнем меню (File -> Exit).
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
            Application.Exit();
        }

        /// <summary>
        /// Добавление в верхнем меню.
        /// </summary>
        private void AddNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Notes.Add(AvailableKey(), form.note);
                TitleListboxAdd();
                SaveProject();
            }
        }

        /// <summary>
        /// Редактирование в верхнем меню.
        /// </summary>
        private void EditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);
            // Переменная для хранения ключа редактирования записи.
            int selectedID = ListBox.SelectedIndex;
            // Показ уже имеющихся данных в окне редактирования.
            if (selectedID < 0)
            {
                MessageBox.Show("Выберите пожайлуста заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string NoteValue = ListBox.SelectedItem.ToString();
                int OperatedKey = GetKeyByValue(NoteValue);
                form.TitleBox.Text = _project.Notes[OperatedKey].Title;
                form.CategoryComboBox.SelectedIndex = Convert.ToInt32(_project.Notes[OperatedKey].Category);
                form.TextBox.Text = _project.Notes[OperatedKey].Text;
                form.dateTimePicker1.Value = _project.Notes[OperatedKey].Created;
                form.dateTimePicker2.Value = _project.Notes[OperatedKey].Modified;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DateTime KeepDate = _project.Notes[OperatedKey].Created;
                    form.note.Created = KeepDate;
                    _project.Notes[OperatedKey] = (form.note);
                    SaveProject();
                    ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
                    TitleListboxAdd();
                }
            }
        }

        /// <summary>
        /// Удаление в верхнем меню.
        /// </summary>
        private void RemoveNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Проверка выборки.
            int selectedID = ListBox.SelectedIndex;
            if (selectedID < 0)
            {
                MessageBox.Show("Выберите пожайлуста заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                int operatedKey = GetKeyByValue(ListBox.SelectedItem.ToString());
                _project.Notes.Remove(operatedKey);
                TitleListboxAdd();
                SaveProject();
            }
        }

        /// <summary>
        /// О программе в верхнем меню.
        /// </summary>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
