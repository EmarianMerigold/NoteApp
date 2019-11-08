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
       public Dictionary<int, Note> Notes = new Dictionary<int, Note>();
    }
}
