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
        private string _title="Безымянный";
        public string _text = "Текст";
        public DateTime _created = DateTime.Now;
        public DateTime _modified = DateTime.Now;


        /// <summary>
        /// Реализуем конструктор класса Note.
        /// </summary> 
        /// /// <param name="_title"> Поле Заголовок заметки</param>
        /// <param name="_text"> Поле Текст заметки</param>
        /// <param name="Category"> Поле Категория заметки</param>
        /// <param name="_created"> Поле Дата создания заметки</param>
        /// <param name="_modified"> Поле Дата изменения заметки</param>
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
                if (value.Length > 50)
                {
                    throw new ArgumentException("Ошибка. Можно не больше 50 символов!");
                }
                _title = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт текст. Устанавливается ограничение на количество символов.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value.Length > 1000)
                {
                    throw new ArgumentException("Ошибка. Можно не больше 1000 символов!");
                }
                _text = value;
            }
        }

        /// <summary>
        /// Метод, отвечающий за время создания заметки.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Метод, отвечающий за время изменения заметки.
        /// </summary>
        public DateTime Modified { get; set; }
    }
}
