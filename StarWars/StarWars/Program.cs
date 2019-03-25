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
            int number = ChoseNumberOfPerson();
            int index = 0;

            string result = "";
            string requestString = $@"people/{number.ToString()}/";
            List<Character> characters = new List<Character>();

            if (!IsCharacterHave(number, characters, ref index))
            {
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

                var serializer = new XmlSerializer(typeof(List<Character>));

                using (var stream = File.Create("file.xml"))
                {
                    serializer.Serialize(stream, characters);
                }

                Console.WriteLine($"{newCharacter.Name}\n" +
                                  $"{newCharacter.Height}\n" +
                                  $"{newCharacter.Mass}");
            }
            else
            {
                Console.WriteLine($"{characters[index].Name}\n" +
                                      $"{characters[index].Height}\n" +
                                      $"{characters[index].Mass}");
            }

        }
        static int ChoseNumberOfPerson()
        {
            try
            {
                Console.WriteLine("Введите номер перонажа которого вы хотите получить");

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
        static bool IsCharacterHave(int number, List<Character> characters, ref int index)
        {
            var serializer = new XmlSerializer(typeof(List<Character>));
            List<Character> deserializeResult;

            using (var stream = File.OpenRead("file.xml"))
            {
                deserializeResult = serializer.Deserialize(stream) as List<Character>;
            }

            characters = deserializeResult;

            for (int i = 0; i < deserializeResult.Count; i++)
            {
                if (deserializeResult[i].Id == number)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }
    }
}
