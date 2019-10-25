using System;
using NoteApp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // создали один блокнот
            Note note1 = new Note("Title", "text", Category.Finance, DateTime.Now, DateTime.Now);
            
            // создали еще один блокнот
            //Note note2 = new Note("Другой Title", "text", Category.Home, DateTime.Now, DateTime.Now);

            // создали библитеку блокнотов
            Project project1 = new Project();
            // добавили в библиотеку note1
            project1.dictionary.Add(1, note1);

            ProjectManager.SaveToFile(project1, @"c:\text.txt");
        }
    }
}
