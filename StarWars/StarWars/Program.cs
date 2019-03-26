using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            using (File.Create("file.xml")) ;
            using (var stream = File.OpenWrite("file.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Character>));
                serializer.Serialize(stream, new List<Character>());
            }

            int number = ChoseNumberOfPerson(), characterNumber = 0;
            List<Character> characters = new List<Character>();

            if (!IsCharacterHave("file.xml", number, ref characterNumber, characters))
            {
                string requestString = $@"people/{number.ToString()}/";
                string result = "";

                WebRequest request = WebRequest.Create("https://swapi.co/api/" + requestString);
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                response.Close();

                Character newCharacter = JsonConvert.DeserializeObject<Character>(result);

                characters.Add(newCharacter);

                using (var stream = File.Create("file.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<Character>));
                    serializer.Serialize(stream, characters);
                }
            }
        }
        static int ChoseNumberOfPerson()
        {
            try
            {
                Console.WriteLine("Введите номер персонажа которого вы хотите выбрать");

                int number;

                if(int.TryParse(Console.ReadLine().Trim(), out number))
                {
                    return number;
                }

                throw new ArgumentException("Число было введено неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return ChoseNumberOfPerson();
            }
        }
        static bool IsCharacterHave(string path, int number, ref int characterNumber, List<Character> buf)
        {
            List<Character> characters;

            using (var stream = File.OpenRead(path))
            {
                var serializer = new XmlSerializer(typeof(List<Character>));
                characters = serializer.Deserialize(stream) as List<Character>;
            }

            buf = characters;

            if (characters.Count != Constants.NULL)
            {
                for(int i = 0; i < characters.Count; i++)
                {
                    if(characters[i].Id == number)
                    {
                        characterNumber = i;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
