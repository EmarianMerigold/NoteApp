using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс, содержащий в себе поля для заметок.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Задаём поля, которые будет содержать блокнот.
        /// </summary>
        public Category Category;
        public string Text { get; set; } = "Текст";
        private string _title = "Безымянный";
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;


        /// <summary>
        /// Реализуем конструктор класса Note.
        /// </summary> 
        /// /// <param name="_title"> Поле Заголовок заметки</param>
        /// <param name="Text"> Поле Текст заметки</param>
        /// <param name="Category"> Поле Категория заметки</param>
        /// <param name="Created"> Поле Дата создания заметки</param>
        /// <param name="Modified"> Поле Дата изменения заметки</param>
        public Note(string title, string text, Category category, DateTime created, DateTime modified)
        {
            Title = title;
            Text = text;
            Category = category;
            Created = created;
            Modified = modified;
        }


        /// <summary>
        /// Возвращает и задаёт заголовок.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value.Length < 50)
                {
                    _title = value;
                    Modified = DateTime.Now;
                }
                else
                    throw new ArgumentException("Ошибка. Можно не больше 50 символов!");
            }
        }
    }
}