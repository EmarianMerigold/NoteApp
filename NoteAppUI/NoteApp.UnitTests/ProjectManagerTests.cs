using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace NoteApp.UnitTests
{
    [TestFixture] // Для того чтобы VS и adapter могли отличить простой класс от класса тестов.
    class ProjectManagerTests
    {
        private Project _testproject = new Project();
        private Project _testproject2 = new Project();

        [Test(Description = "Тест сериализации.")]
        public void SerializeTest()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string testFilePath = $@"{path}\test.json";
            string expected = File.ReadAllText(testFilePath);
            Note note0 = new Note("Проверка", "123456", Category.Work, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note1 = new Note("Халоу ворлд!", "ыыыы", Category.Home, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note2 = new Note("МАУ", "мауууу", Category.People, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note3 = new Note("qwerty", "qwerty", Category.Documents, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            string filename = $@"{path}\test1.json";
            _testproject.Notes.Add(0, note0);
            _testproject.Notes.Add(1, note1);
            _testproject.Notes.Add(2, note2);
            _testproject.Notes.Add(3, note3);
            ProjectManager.SaveToFile(_testproject, filename);
            string actual = File.ReadAllText(filename);
            Assert.AreEqual(expected, actual, "Файлы в сериализации различаются !");
        }

        [Test(Description = "Тест десериализации.")]
        public void DeserializeTest()
        {
            Note note0 = new Note("Проверка", "123456", Category.Work, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note1 = new Note("Халоу ворлд!", "ыыыы", Category.Home, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note2 = new Note("МАУ", "мауууу", Category.People, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            Note note3 = new Note("qwerty", "qwerty", Category.Documents, new DateTime(2019, 12, 12).Date, new DateTime(2019, 12, 12).Date);
            _testproject2.Notes.Add(0, note0);
            _testproject2.Notes.Add(1, note1);
            _testproject2.Notes.Add(2, note2);
            _testproject2.Notes.Add(3, note3);
            Project expected = _testproject2;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string testFilePath = $@"{path}\test.json";
            Project preactual = ProjectManager.LoadFromFile(testFilePath);
            Project actual = preactual;
            for (int i = 0; i != _testproject2.Notes.Count; i++)
            {
                Assert.AreEqual(expected.Notes[i].Title, actual.Notes[i].Title,
                "Значения в десериализации различаются !");
                Assert.AreEqual(expected.Notes[i].Text, actual.Notes[i].Text,
                    "Значения в десериализации различаются !");
                Assert.AreEqual(expected.Notes[i].Category, actual.Notes[i].Category,
                    "Значения в десериализации различаются !");
                Assert.AreEqual(expected.Notes[i].Created, actual.Notes[i].Created,
                    "Значения в десериализации различаются !");
                Assert.AreEqual(expected.Notes[i].Modified, actual.Notes[i].Modified,
                    "Значения в десериализации различаются !");
                i++;
            }
        }
    }
}