using DapperStudents.DataAccess;
using DapperStudents.Models;
using System;
using System.Linq;

namespace DapperStudents.Services
{
    public static class SetInformation
    {
        public static string SetFirstName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя:");

                    string firstName = Console.ReadLine().Trim();

                    if(firstName.Any(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')))
                    {
                        return firstName; 
                    }

                    throw new ArgumentException("Имя было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetLastName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите фамилию:");

                    string lastName = Console.ReadLine().Trim();

                    if (lastName.Any(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')))
                    {
                        return lastName;
                    }

                    throw new ArgumentException("Фамилия была введена неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetMiddleName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите очество:");

                    string lastName = Console.ReadLine().Trim();

                    if (lastName.Any(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')))
                    {
                        return lastName;
                    }

                    throw new ArgumentException("Очество было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int SetGroup()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите группу:");

                    TableDataService<Group> dataService = new TableDataService<Group>();

                    dataService.GetAll().ForEach(f => Console.WriteLine($"{f.Id}) {f.Name}"));

                    int groupId;

                    if(int.TryParse(Console.ReadLine().Trim(), out groupId))
                    {
                        return groupId;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
