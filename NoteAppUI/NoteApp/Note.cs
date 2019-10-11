using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// 
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
            Category = category;
            Created = created;
            Modified = modified;
        }



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

        public string Text
        {
            get
            {
                return _text;
            }

        }

        public DateTime Created
        {
            get
            {
                return _created;
            }
        }

        public DateTime Modified
        {
            get
            { 
                return _modified;
            }
          
        }


    }
}
