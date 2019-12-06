using System;
using NoteApp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // создали один блокнот
            Note note = new Note("Title", "text", Category.Finance, DateTime.Now, DateTime.Now);
            Note note1 = new Note("Title", "text", Category.Finance, DateTime.Now, DateTime.Now);
            Note note2 = new Note("Title", "text", Category.Finance, DateTime.Now, DateTime.Now);

            Project pClass = new Project();

            pClass.Notes.Add(0, note);
            pClass.Notes.Add(1, note1);
            // создали еще один блокнот
            //Note note2 = new Note("Другой Title", "text", Category.Home, DateTime.Now, DateTime.Now);

            // создали библитеку блокнотов
            //Project project1 = new Project();
            // добавили в библиотеку note1
            //project1.Notes.Add(1, note1);

            ProjectManager.SaveToFile(pClass, @"c:\text.txt");
            Project pClass2 = new Project();
        }
    }
}
