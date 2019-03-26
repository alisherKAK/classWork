using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegateLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount
            {
                FullName = "Петр Жмых"
            };

            var reporter = new ConsoleReporter();
            var repoterDelegate = new ReporterDelegate(reporter.SendReport);
            //Первый способ
            bankAccount.ReportEvent += repoterDelegate;
            //Второй способ
            bankAccount.ReportEvent += BankAccountReportEvent;//Console.WriteLine;
            //Третьи способ(анонимный метод)
            bankAccount.ReportEvent += delegate (string data)
            {
                // если хотим вернуть значение то пишим return - он сам поймет
            };
            //Четвертый способ(лямбда выражение)
            bankAccount.ReportEvent += text =>
            {
                Console.WriteLine(text);
            };
            bankAccount.ReportEvent += (text) =>
            {
                Console.WriteLine(text);
                //если много действий
            };

            bankAccount.Add(40000);
            bankAccount.Withdraw(500);
            bankAccount.Withdraw(50000000);


            var cities = new List<string>
            {
                "Алматы",
                "Караганда",
                "Павлодар"
            };

            //var newCities = new List<string>();
            //foreach(string cityName in cities)
            //{
            //    if(cityName.ToLower().Contains("р"))
            //    {
            //        newCities.Add(cityName);
            //    }
            //} 8 строк
            var result = cities.Where(cityName => cityName.ToLower().Contains("р"));
        }

        private static void BankAccountReportEvent(string reportText)
        {
            //Что-то происходит
        }
    }
}
