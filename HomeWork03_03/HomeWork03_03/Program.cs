using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HomeWork03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до xml файла:");

            string path = Console.ReadLine().Trim();

            XmlDocument data = new XmlDocument();
            data.Load(path);

            var rootElement = data.DocumentElement;

            Student student = new Student()
            {
                Id = rootElement.GetElementsByTagName("id")[0].InnerText
            };

            Console.ReadLine();
        }
    }
}
