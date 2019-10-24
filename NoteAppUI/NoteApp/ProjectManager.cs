﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace NoteApp
{
    /// <summary>
    /// Класс сериализации, с помощью которого выполняется загрузка/выгрузка информации в формате JSON
    /// </summary>
    class ProjectManager
    {

        public static void SaveToFile(Note note, string filename)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"c:\test.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать. 
                serializer.Serialize(writer, note);
            }

        }

        public static Note LoadFromFile(string filename)
        {
            //Создаем переменную, в которую поместим результат десериализации
            Note note = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"c:\test.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                note = serializer.Deserialize<Note>(reader);
            }
            return note;

        }

    }
}
