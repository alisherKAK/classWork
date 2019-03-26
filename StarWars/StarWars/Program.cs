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
            bool isFinish = false;

            using (File.Create("file.xml")) ;
            using (var stream = File.OpenWrite("file.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Character>));
                serializer.Serialize(stream, new List<Character>());
            }

            while (true)
            {
                switch (Chose())
                {
                    case Constants.FIRST_VARIANT:
                        ShowPerson();
                        break;
                    case Constants.SECOND_VARIANT:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого варианта");
                        break;
                }
                if(isFinish == true)
                {
                    break;
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

            buf.AddRange(characters);

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
        static int Chose()
        {
            try
            {
                Console.WriteLine("1. Искать перса\n" +
                    "2. Выход");

                int chose;

                if(int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    return chose;
                }

                throw new ArgumentException("Нет такого варианта");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return Chose();
            }
        }
        static void ShowPerson()
        {
            int number = ChoseNumberOfPerson(), characterNumber = 0;
            List<Character> characters = new List<Character>();

            if (!IsCharacterHave("file.xml", number, ref characterNumber, characters))
            {
                string requestString = $@"people/{number.ToString()}/";
                string result = "";

                using (var client = new WebClient())
                {
                    try
                    {
                        result = client.DownloadString("https://swapi.co/api/" + requestString);

                        Character newCharacter = JsonConvert.DeserializeObject<Character>(result);
                        newCharacter.Id = number;

                        characters.Add(newCharacter);

                        using (var stream = File.Create("file.xml"))
                        {
                            var serializer = new XmlSerializer(typeof(List<Character>));
                            serializer.Serialize(stream, characters);
                        }

                        Console.WriteLine($"Name: {newCharacter.Name}\n" +
                                          $"Height: {newCharacter.Height}\n" +
                                          $"Mass: {newCharacter.Mass}\n" +
                                          $"Hair_color: {newCharacter.Hair_color}\n" +
                                          $"Skin_color: {newCharacter.Skin_color}\n" +
                                          $"Eye_color: {newCharacter.Eye_color}\n" +
                                          $"Birth_year: {newCharacter.Birth_year}\n" +
                                          $"Gender: {newCharacter.Gender}");
                    }
                    catch
                    {
                        Console.WriteLine("Нет персонажа с таким номером");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Name: {characters[characterNumber].Name}\n" +
                                  $"Height: {characters[characterNumber].Height}\n" +
                                  $"Mass: {characters[characterNumber].Mass}\n" +
                                  $"Hair_color: {characters[characterNumber].Hair_color}\n" +
                                  $"Skin_color: {characters[characterNumber].Skin_color}\n" +
                                  $"Eye_color: {characters[characterNumber].Eye_color}\n" +
                                  $"Birth_year: {characters[characterNumber].Birth_year}\n" +
                                  $"Gender: {characters[characterNumber].Gender}");
            }
        }
    }
}
