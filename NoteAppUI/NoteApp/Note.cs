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
        private Category _category;
        private string _title;
        private string _text = "Текст";
        private DateTime _created = DateTime.Now;
        private DateTime _modified = DateTime.Now;

        public Note(string title, string text, Category category, DateTime created, DateTime modified)
        {
            Title = title;
            Text = text;
            category = _category;
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
        /// Возвращает и задаёт текст.
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
