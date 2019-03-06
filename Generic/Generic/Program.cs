using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker
            {
                Id = 1, 
                PositionName = "Главный директор по подметанию тротуара",
                Salary = 8,
                NickName = "Вася одуванчик"
            };

            Director director = new Director
            {
                Id = 2,
                PositionName = "Великий и могучий главный директор",
                Salary = 10000,
                FullName = "Аркадий Леонтьевич Жмых"
            };

            Stranger starnger = new Stranger();

            DirectorsCompany<Director> company = new DirectorsCompany<Director>(new List<Director> { director});

            company.DoWorkTogether();

            Console.ReadLine();
        }
    }
}
