using HomeWork26_04_19.DataAccess;
using HomeWork26_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26_04_19.Services
{
    public static class SetInformation
    {
        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя:");

                    string name = Console.ReadLine().Trim();

                    for(int i = 0; i < name.Length; i++)
                    {
                        if( !(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z') )
                        {
                            throw new ArgumentException("Неверно ввели название");
                        }
                    }

                    return name;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static double SetPrice()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите цену:");

                    double price;

                    if(double.TryParse(Console.ReadLine().Trim(), out price) && price >= 0)
                    {
                        return price;
                    }

                    throw new ArgumentException("Цена была введена неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                } 
            } while (true);
        }

        public static int SetAmount()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите кол:");

                    int amount;

                    if(int.TryParse(Console.ReadLine().Trim(), out amount) && amount >= 0)
                    {
                        return amount;
                    }

                    throw new ArgumentException("Кол было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static DateTime SetProductionDate()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите дату производства (dd.mm.yyyy):");

                    DateTime productionDate = Convert.ToDateTime(Console.ReadLine().Trim());

                    if(productionDate <= DateTime.Now)
                    {
                        throw new ArgumentException("Дату производства не может быть раннее чем нынешняя дата");
                    }

                    return productionDate;
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static DateTime SetExpirationDate(DateTime productionDate)
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите срок годности (dd.mm.yyyy):");

                    DateTime expirationDate = Convert.ToDateTime(Console.ReadLine().Trim());

                    if(expirationDate < productionDate)
                    {
                        throw new ArgumentException("Срок годности не может быть раннее чем дата производства");
                    }

                    return expirationDate;
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Guid SetProducerId()
        {
            do
            {
                try
                {
                    using(var context = new StockContext())
                    {
                        var producers = context.Producers.ToList();

                        if (producers != null)
                        {
                            Console.WriteLine("Выберите производителя\n" +
                                              "======================");
                            for (int i = 0; i < producers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {producers[i].Name}");
                            }

                            int producerIndex;

                            if (int.TryParse(Console.ReadLine().Trim(), out producerIndex) && (producerIndex > 0 && producerIndex <= producers.Count))
                            {
                                return producers[producerIndex - 1].Id;
                            }

                            throw new ArgumentException("Нет такого производителя");
                        }

                        throw new ArgumentNullException("Нет ни одного производителя, добвьте хотябы одного");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
