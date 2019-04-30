using System;
using System.Linq;

namespace HomeWork10_05_19.Services
{
    public static class SetInformation
    {
        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter name:");

                    string name = Console.ReadLine().Trim();

                    if(name.All(letter => (letter >= 'a' && letter <= 'z') ||
                                          (letter >= 'A' && letter <= 'Z') || letter == ' '))
                    {
                        return name;
                    }

                    throw new ArgumentException("Incorrect name");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetText()
        {
            Console.WriteLine("Enter text:");

            string text = Console.ReadLine().Trim();

            return text;
        }

        public static DateTime SetPusblishedDate()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter news published date(dd.mm.yyyy):");

                    DateTime publishedDate = Convert.ToDateTime(Console.ReadLine().Trim());

                    if(publishedDate <= DateTime.Now)
                    {
                        return publishedDate;
                    }

                    throw new ArgumentException("Published date can't be earlier than now date");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
