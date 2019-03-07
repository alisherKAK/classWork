using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PracticeWork17_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Type type = typeof(string);

            var methods = type.GetMethods();

            for(int i = 0; i < methods.Length; i++)
            {
                if(methods[i].Name == "Substring" && methods[i].GetParameters().Length == 2)
                {
                    Console.WriteLine("Введите любую строку:");

                    string text = Console.ReadLine().Trim();

                    int startIndex = SetStartIndex(text);

                    int length = SetStrLength(text, startIndex);

                    object result = methods[i].Invoke(text, new object[] { startIndex, length });

                    Console.WriteLine("========================");
                    Console.WriteLine($"Result: {result}");

                    break;
                }
            }
            Console.WriteLine();

            //2
            Type typeList = typeof(List<>);

            var constuctors = typeList.GetConstructors();

            Console.WriteLine("List's counstuctors:\n" +
                              "--------------------------");
            foreach(ConstructorInfo constructor in constuctors)
            {
                var parameters = constructor.GetParameters();
                string paramsView = "";

                foreach (ParameterInfo parametr in parameters)
                {
                    paramsView += $"{parametr.ParameterType.Name} {parametr.Name}, ";
                }

                paramsView = paramsView.Trim(' ').Trim(',');

                Console.WriteLine($"List<T>({paramsView})");
            }
        }
        static int SetStartIndex(string str)
        {
            try
            {
                int startIndex;

                Console.WriteLine("Введите начальный индекс:");

                if(int.TryParse(Console.ReadLine().Trim(), out startIndex) && startIndex < str.Length && startIndex >= 0)
                {
                    return startIndex;
                }

                throw new ArgumentException("Вышли за пределы строки");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetStartIndex(str);
            }
        }
        static int SetStrLength(string str, int startIndex)
        {
            try
            {
                int length;

                Console.WriteLine("Введите длину строки:");

                if(int.TryParse(Console.ReadLine().Trim(), out length) && length > 0 && length < (str.Length - startIndex))
                {
                    return length;
                }

                throw new ArgumentException("Длина выходит за пределы строки");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetStrLength(str, startIndex);
            }
        }
    }
}
