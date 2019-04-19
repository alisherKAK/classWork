using HomeWork29_04_19.DataAccess;
using HomeWork29_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork29_04_19.Services
{
    public static class SelectInformation
    {
        public static City SelectDepartureCity()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите свой город:");

                    List<City> cities;
                    using (var context = new TicketContext())
                    {
                        cities = context.Cities.ToList();

                        for(int i = 0; i < cities.Count; i++)
                        {
                            Console.WriteLine($"{i+1}) {cities[i].Name}");
                        }
                    }

                    int cityNumber;

                    if(int.TryParse(Console.ReadLine().Trim(), out cityNumber))
                    {
                        if(cityNumber >= 1 && cityNumber <= cities.Count)
                        {
                            return cities[cityNumber - 1];
                        }

                        throw new ArgumentException("Выберите город из списка");
                    }

                    throw new ArgumentException("Номер был некоретно введен");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static RailwayCarriage SelectRailwayCarriage()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите вагон:");

                    List<RailwayCarriage> railwayCarriages;
                    using(var context = new TicketContext())
                    {

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            } while (true);
        }
    }
}
