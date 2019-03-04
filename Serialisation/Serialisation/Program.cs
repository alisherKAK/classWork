using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Id = 1, 
                FullName = "П.П.Керсанов",
                Age = 68
            };

            string json = JsonConvert.SerializeObject(person);

            var result = JsonConvert.DeserializeObject<Person>(json);

            //var serializer = new XmlSerializer(typeof(Person));

            //using (var stream  = File.Create("file.xml"))
            //{
            //    serializer.Serialize(stream, person);
            //}

            //using (var stream = File.OpenRead("file.xml"))
            //{
            //    var result = serializer.Deserialize(stream) as Person;

            //    Console.WriteLine($"{result.Id}, {result.FullName}, {result.Age}");
            //}

            //Console.ReadLine();
        }
    }
}
