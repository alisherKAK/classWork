using ExamWork.ConstantsAndEnums;
using ExamWork.DataAccess;
using ExamWork.Models;
using System;
using System.Linq;

namespace ExamWork.Services
{
    public static class SetInformations
    {
        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя:");

                    string name = Console.ReadLine().Trim();

                    if (name.All(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') || letter == ' ' || letter == '-'))
                    {
                        return name;
                    }

                    throw new ArgumentException("Имя было введено неврено");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int SetPopulation()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите кол людей:");

                    int population;

                    if (int.TryParse(Console.ReadLine().Trim(), out population))
                    {
                        return population;
                    }

                    throw new ArgumentException("Кол людей было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }    
            } while (true);
        }

        public static Guid SetCountryId()
        {
            do
            {
                try
                {
                    using(var dataService = new TableDataService<Country>())
                    {
                        var countries = dataService.GetAll();
                        if (countries.Count != Constants.NULL)
                        {
                            Console.WriteLine("Выберите страну:");
                            for (int i = 0; i < countries.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} {countries[i].Name}");
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("Добавьте хоть одну страну");
                        }
                    }

                    int countryIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out countryIndex))
                    {
                        using(var dataService = new TableDataService<Country>())
                        {
                            return dataService.GetAll()[countryIndex - 1].Id;
                        }
                    }

                    throw new ArgumentException("Число было введено неверно");

                }
                catch(ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                    return Guid.Empty;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Guid SetCityId()
        {
            do
            {
                try
                {
                    using (var dataService = new TableDataService<City>())
                    {
                        var cities = dataService.GetAll();
                        if (cities.Count != Constants.NULL)
                        {
                            Console.WriteLine("Выберите город:");
                            for (int i = 0; i < cities.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} {cities[i].Name}");
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("Добавьте хоть один город");
                        }
                    }

                    int cityIndex;

                    if (int.TryParse(Console.ReadLine().Trim(), out cityIndex))
                    {
                        using (var dataService = new TableDataService<City>())
                        {
                            return dataService.GetAll()[cityIndex - 1].Id;
                        }
                    }

                    throw new ArgumentException("Число было введено неверно");

                }
                catch(ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                    return Guid.Empty;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Guid SetStreetId()
        {
            do
            {
                try
                {
                    using (var dataService = new TableDataService<Street>())
                    {
                        var streets = dataService.GetAll();
                        if (streets.Count != Constants.NULL)
                        {
                            Console.WriteLine("Выберите город:");
                            for (int i = 0; i < streets.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} {streets[i].Name}");
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("Добавьте хоть одну улицу");
                        }
                    }

                    int streetIndex;

                    if (int.TryParse(Console.ReadLine().Trim(), out streetIndex))
                    {
                        using (var dataService = new TableDataService<Street>())
                        {
                            return dataService.GetAll()[streetIndex - 1].Id;
                        }
                    }

                    throw new ArgumentException("Число было введено неверно");

                }
                catch(ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                    return Guid.Empty;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static CountryProperties SetCountryProperty()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите поле для изменения:\n" +
                                      "1) Имя");

                    int property;

                    if(int.TryParse(Console.ReadLine().Trim(), out property))
                    {
                        return (CountryProperties)property;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static CityProperties SetCityProperty()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите поле для изменения:\n" +
                                      "1) Имя\n" +
                                      "2) Кол людей\n" +
                                      "3) Страна");

                    int property;

                    if (int.TryParse(Console.ReadLine().Trim(), out property))
                    {
                        return (CityProperties)property;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static StreetProperties SetStreetProperty()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите поле для изменения:\n" +
                                      "1) Имя\n" +
                                      "2) Город");

                    int property;

                    if (int.TryParse(Console.ReadLine().Trim(), out property))
                    {
                        return (StreetProperties)property;
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
