using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeWork16_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();

            Console.WriteLine("Введите путь до файла:");

            string path = Console.ReadLine().Trim();

            Console.WriteLine();
            Console.WriteLine();

            using (StreamReader read = new StreamReader(path))
            {
                string[] sentences = read.ReadToEnd().Split('\n');

                for(int i = 0; i < sentences.Length; i++)
                {
                    string[] sentenceWords = sentences[i].Trim().Split(' ');

                    for(int j = 0; j < sentenceWords.Length; j++)
                    {
                        words.Add(sentenceWords[j]);
                    }
                }
            }


            for(int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].Trim(',');
                words[i] = words[i].Trim(' ');
                words[i] = words[i].Trim('\n');
                words[i] = words[i].Trim(':');
                words[i] = words[i].Trim(';');
                words[i] = words[i].Trim('\t');
                words[i] = words[i].Trim('.');
                words.Remove("");
                words.Remove(" ");
                words.Remove("\n");
                words.Remove("\t");
            }

            Dictionary<string, int> wordStatistic = new Dictionary<string, int>();

            for(int i = 0; i < words.Count; i++)
            {
                int count;

                if(wordStatistic.TryGetValue(words[i], out count))
                {
                    wordStatistic.Remove(words[i]);

                    wordStatistic.Add(words[i], ++count);
                }
                else
                {
                    wordStatistic.Add(words[i], 1);
                }
            }

            int a = 1;

            Console.WriteLine("№:\t\tСлово:\t\tКол:");

            foreach (KeyValuePair<string, int> keyValue in wordStatistic)
            {
                Console.WriteLine($"{a.ToString().PadLeft(MaxCount(words))}-\t\t{keyValue.Key.PadLeft(WordMaxLength(words))}\t\t{keyValue.Value}");
                ++a;
            }

            Console.WriteLine($"Всего слов: {words.Count}; Уникальных: {wordStatistic.Count}");
        }
        static int WordMaxLength(List<string> words)
        {
            int length = words[0].Length;

            for(int i = 1; i < words.Count; i++)
            {
                if(length < words[i].Length)
                {
                    length = words[i].Length;
                }
            }

            return length;
        }
        static int MaxCount(List<string> words)
        {
            int count = words.Count;
            int i = 1;

            for (; count != 0; i++)
            {
                count /= 10;
            }

            return i;
        }
    }
}
