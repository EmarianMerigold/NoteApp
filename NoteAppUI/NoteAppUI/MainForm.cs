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
using System.IO;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        private Project _project; 
        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadProject();
            AddTitlesToListbox();
            //Передача полю CategoryCombobox формы MainForm значений из перечисления Category.
            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                CategoryComboBox.Items.Add(item);
            }
            CategoryComboBox.Items.Add("All");
            CategoryComboBox.SelectedIndex = 8;
            CurrentNoteLoad();
        }

        /// <summary>
        /// Обработчик, заполняющий ListBox заголовками заметок из словаря.
        /// </summary>Load
        public void AddTitlesToListbox()
        {
            ListBox.Items.Clear();
            foreach (KeyValuePair<int, Note> kvp in _project.SortedDictionary((Category)CategoryComboBox.SelectedIndex))
            {
                int n = 0;
                ListBox.Items.Insert(n, kvp.Value.Title);
                n++;
            }
            if (CategoryComboBox.SelectedIndex == 8)
            {
                foreach (KeyValuePair<int, Note> kvp in _project.SortedDictionary())
                {
                    int n = 0;
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
                string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyNotes\\Notes.json");
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
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyNotes")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyNotes"));
            ProjectManager.SaveToFile(_project, (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyNotes\\Notes.json")));
        }

        /// <summary>
        /// Добавление в верхнем меню.
        /// </summary>
        private void AddNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);
            int OperatedKey = AvailableKey();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Notes.Add(AvailableKey(), form.Note);
                AddTitlesToListbox();
                SaveProject();
                CategoryComboBox.SelectedIndex = Convert.ToInt32(_project.Notes[OperatedKey].Category);
                ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
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
                form.Note = _project.Notes[OperatedKey];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DateTime KeepDate = _project.Notes[OperatedKey].Created;
                    form.note.Created = KeepDate;
                    _project.Notes[OperatedKey] = (form.note);
                    SaveProject();
                    ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
                    AddTitlesToListbox();
                }
            }
        }

        /// <summary>
        /// Обработчик событий при закрытии формы MainForm.
        /// </summary>
        private void MainForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            SaveProject();
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
                MessageBox.Show("Выберите заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                int operatedKey = GetKeyByValue(ListBox.SelectedItem.ToString());
                _project.Notes.Remove(operatedKey);
                AddTitlesToListbox();
                SaveProject();
                NoteTextBox.Text = "";
                Titlelabel.Text = "";
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
                CategoryLabel.Text = _project.Notes[selected].Category.ToString();
                NoteTextBox.Text = _project.Notes[selected].Text;
                DateCreatedPicker.Value = _project.Notes[selected].Created;
                DateModifiedPicker.Value = _project.Notes[selected].Modified;
                CurrentNoteSave(_project.Notes[selected]);
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

        /// <summary>
        /// Выход через верхнее меню (File -> Exit).
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
            Application.Exit();
        }

        /// <summary>
        /// Выбор категории из ComboBox в MainForm.
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTitlesToListbox();
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
            }
            return i;
        }

        /// <summary>
        /// Кнопка добавления.
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);
            int OperatedKey = AvailableKey();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _project.Notes.Add(AvailableKey(), form.note);
                AddTitlesToListbox();
                SaveProject();
                CategoryComboBox.SelectedIndex = Convert.ToInt32(_project.Notes[OperatedKey].Category);
                ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
            }
        }

        /// <summary>
        /// Кнопка редактирования.
        /// </summary>
        private void EditButton_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm(_project);
            // Переменная для хранения ключа редактирования записи.
            int selectedID = ListBox.SelectedIndex;
            // Показ уже имеющихся данных в окне редактирования.
            if (selectedID < 0)
            {
                MessageBox.Show("Выберите заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
               string NoteValue = ListBox.SelectedItem.ToString();
               int OperatedKey = GetKeyByValue(NoteValue);
               form.Note = _project.Notes[OperatedKey];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DateTime KeepDate = _project.Notes[OperatedKey].Created;
                    form.note.Created = KeepDate;
                    _project.Notes[OperatedKey] = (form.note);
                    SaveProject();
                    ListBox.SelectedItem = (_project.Notes[OperatedKey].Title);
                    AddTitlesToListbox();
                }
            }
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
                MessageBox.Show("Выберите заметку!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                int operatedKey = GetKeyByValue(ListBox.SelectedItem.ToString());
                _project.Notes.Remove(operatedKey);
                AddTitlesToListbox();
                NoteTextBox.Text = "";
                Titlelabel.Text = "";
                SaveProject();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ListBox.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show(
                    "Удалить заметку?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                        RemoveButton_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                SaveProject();
                Close();
            }
        }

        private void CurrentNoteLoad()
        {
            if (_project.CurrentNote != null)
            {
                Titlelabel.Text = _project.CurrentNote.Title;
                CategoryLabel.Text = _project.CurrentNote.Category.ToString();
                NoteTextBox.Text = _project.CurrentNote.Text;
                DateCreatedPicker.Value = _project.CurrentNote.Created;
                DateModifiedPicker.Value = _project.CurrentNote.Modified;
                CategoryComboBox.SelectedIndex = Convert.ToInt32(_project.CurrentNote.Category);
            }
        }

        private void CurrentNoteSave(Note note)
        {
            int LastSelected = GetKeyByValue(note.Title);
            if (LastSelected >= 0)
            {
                _project.CurrentNote = note;
            }

        }
    }
}
