using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    class Program
    {
        static void Main(string[] args)
        {
            double informationMemoryValue = Constants.NULL;

            SetInformationMemory(ref informationMemoryValue);
        }
        static void SetInformationMemory(ref double informationMemoryValue)
        {
            Console.WriteLine("Каков размер ваших файлов(Гб)");

            try
            {
                if (double.TryParse(Console.ReadLine().Trim(), out informationMemoryValue)) {}
                else
                {
                    throw new ArgumentException("Ввели размер файло неправильно");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                SetInformationMemory(ref informationMemoryValue);
            }
        }
    }
}
