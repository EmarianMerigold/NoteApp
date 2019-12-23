using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс, содержащий в себе стуктуру данных "Словарь".
    /// </summary>
    public class Project
    {
        /// <summary>
     /// Словарь, который содержит в себе ключ и значение из полей Note.
     /// </summary>

        public Dictionary<int, Note> Notes = new Dictionary<int, Note>();
        public Note CurrentNote;

        /// <summary>
        /// percvaya realizacya
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Note> SortedDictionary()
        {
            var newDictionary = from note in Notes
                                orderby note.Value.Modified ascending
                                select note;

            return newDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// vtoraya relizacya
        /// </summary>
        public Dictionary<int, Note> SortedDictionary(Category category)
        {
            var newDictionary = from note in Notes
                                where note.Value.Category == category
                                orderby note.Value.Modified ascending
                                select note;

            return newDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
