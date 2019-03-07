using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HomeWork03_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://habr.com/ru/rss/interesting/";

            XmlTextReader reader = new XmlTextReader(url);

            while (reader.Read())
            {
                reader.
                Console.WriteLine(reader.Value);
            }

            Console.ReadLine();
        }
    }
}
