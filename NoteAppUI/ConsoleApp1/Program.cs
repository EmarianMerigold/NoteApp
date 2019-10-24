using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Note note = new Note("Title", "text", Category.Finance, DateTime.Now, DateTime.Now);
            Note note2;

            ProjectManager.SaveToFile(note, @"c:\test.txt");

            note2 = ProjectManager.LoadFromFile(@"c:\test.txt");

            Project.dict = new Project();
            dict.dictionary.Add(1, note);

            Console.Writeline(note2.Title + note2.Created);
            Console.ReadKey();
        }
    }
}
