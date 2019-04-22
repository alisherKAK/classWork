using System;
using System.Linq;

namespace HomeWork02_05_19.Services
{
    public static class SetInformation
    {
        public static string SetBandName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя группы:");

                    string bandName = Console.ReadLine().Trim();

                    if(bandName.All(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') || 
                    (letter >= '0' && letter <= '9') || letter == ' '))
                    {
                        return bandName;
                    }

                    throw new ArgumentException("Введите имя группы правильно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetMusicName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя музыки:");

                    string musicName = Console.ReadLine().Trim();

                    if (musicName.All(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') ||
                     (letter >= '0' && letter <= '9') || letter == ' '))
                    {
                        return musicName;
                    }

                    throw new ArgumentException("Введите имя музыки правильно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int SetMusicDuration()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите длительность песни (mm:ss)");

                    string musicDuration = Console.ReadLine().Trim();
                    int musicDurationInSeconds = int.Parse(musicDuration.Split(':').FirstOrDefault().Trim())*Constants.SECOND_IN_ONE_MINUTE + int.Parse(musicDuration.Split(':')[Constants.SECOND_ELEMENT_INDEX].Trim());

                    return musicDurationInSeconds;
                }
                catch(OverflowException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int SetMusicRating()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите место в рейтинге:");

                    int rating;

                    if(int.TryParse(Console.ReadLine().Trim(), out rating))
                    {
                        return rating;
                    }

                    throw new ArgumentException("Введите число правильно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetMusicLyrics()
        {
            Console.WriteLine("Введите текст песни, введите ключевое слово 'Save' чтобы сохранить текст:");
            string lyrics = string.Empty;
            do
            {
                string text = Console.ReadLine().Trim();

                if(text.ToLower() == "save")
                {
                    return lyrics;
                }

                lyrics += text;
            } while (true);
        }
    }
}
